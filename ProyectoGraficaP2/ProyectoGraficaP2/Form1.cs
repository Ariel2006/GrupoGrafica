using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoGraficaP2
{
    public partial class Form1 : Form
    {
        private List<Point3D> vertices;
        private List<(int, int)> edges;

        private float angleX = 0, angleY = 0, angleZ = 0;
        private float scale = 1;
        private float translateX = 0, translateY = 0, translateZ = 0;

        private Timer animationTimer;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            BackColor = Color.Black;

            comboBoxFigures.Items.AddRange(new object[] { "Cubo", "Piramide", "Esfera", "Cono", "Cilindro" });
            comboBoxFigures.SelectedIndex = 0;

            comboBoxFigures.SelectedIndexChanged += (s, e) =>
            {
                SetFigure(comboBoxFigures.SelectedItem.ToString());
                Invalidate();
            };

            sliderTranslateX.Scroll += SliderTranslate_Scroll;
            sliderTranslateY.Scroll += SliderTranslate_Scroll;
            sliderTranslateZ.Scroll += SliderTranslate_Scroll;

            sliderRotateX.Scroll += SliderRotate_Scroll;
            sliderRotateY.Scroll += SliderRotate_Scroll;
            sliderRotateZ.Scroll += SliderRotate_Scroll;

            sliderScale.Scroll += SliderScale_Scroll;

            UpdateTranslateLabels();
            UpdateRotateLabels();
            UpdateScaleLabel();

            animationTimer = new Timer();
            animationTimer.Interval = 30; // 30ms para animación suave (~33 FPS)
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();

            SetFigure("Cubo");
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            angleY += 0.5f;
            if (angleY > 360) angleY -= 360;

            // No actualizar sliderRotateY.Value ni labelRotateYValue aquí para que no se mueva el slider
            labelAnimationAngleY.Text = $"Rot Y: {(int)angleY}°";

            Invalidate();
        }

        private void SliderRotate_Scroll(object sender, EventArgs e)
        {
            angleX = sliderRotateX.Value;
            angleY = sliderRotateY.Value;
            angleZ = sliderRotateZ.Value;

            UpdateRotateLabels();
            Invalidate();
        }

        private void SliderTranslate_Scroll(object sender, EventArgs e)
        {
            translateX = sliderTranslateX.Value;
            translateY = sliderTranslateY.Value;
            translateZ = sliderTranslateZ.Value;

            UpdateTranslateLabels();
            Invalidate();
        }

        private void SliderScale_Scroll(object sender, EventArgs e)
        {
            scale = sliderScale.Value / 100f;
            UpdateScaleLabel();
            Invalidate();
        }

        private void UpdateTranslateLabels()
        {
            labelTranslateXValue.Text = translateX.ToString();
            labelTranslateYValue.Text = translateY.ToString();
            labelTranslateZValue.Text = translateZ.ToString();
        }

        private void UpdateRotateLabels()
        {
            labelRotateXValue.Text = angleX.ToString();
            labelRotateYValue.Text = sliderRotateY.Value.ToString(); // Mostrar solo el valor del slider, no la animación
            labelRotateZValue.Text = angleZ.ToString();
        }

        private void UpdateScaleLabel()
        {
            labelScaleValue.Text = scale.ToString("F2");
        }

        private void SetFigure(string figure)
        {
            vertices = new List<Point3D>();
            edges = new List<(int, int)>();

            switch (figure)
            {
                case "Cubo":
                    vertices.AddRange(new[] {
                        new Point3D(-1,-1,-1), new Point3D(1,-1,-1), new Point3D(1,1,-1), new Point3D(-1,1,-1),
                        new Point3D(-1,-1,1),  new Point3D(1,-1,1),  new Point3D(1,1,1),  new Point3D(-1,1,1)
                    });
                    edges.AddRange(new[] {
                        (0,1),(1,2),(2,3),(3,0),(4,5),(5,6),(6,7),(7,4),(0,4),(1,5),(2,6),(3,7)
                    });
                    break;

                case "Piramide":
                    vertices.AddRange(new[] {
                        new Point3D(-1, -1, -1), new Point3D(1, -1, -1), new Point3D(1, -1, 1), new Point3D(-1, -1, 1),
                        new Point3D(0, 1.5f, 0)
                    });
                    edges.AddRange(new[] {
                        (0,1),(1,2),(2,3),(3,0),(0,4),(1,4),(2,4),(3,4)
                    });
                    break;

                case "Esfera":
                    int latitudes = 10, longitudes = 10;
                    for (int lat = 0; lat <= latitudes; lat++)
                    {
                        double theta = lat * Math.PI / latitudes;
                        for (int lon = 0; lon <= longitudes; lon++)
                        {
                            double phi = lon * 2 * Math.PI / longitudes;
                            float x = (float)(Math.Sin(theta) * Math.Cos(phi));
                            float y = (float)Math.Cos(theta);
                            float z = (float)(Math.Sin(theta) * Math.Sin(phi));
                            vertices.Add(new Point3D(x, y, z));
                        }
                    }
                    for (int lat = 0; lat < latitudes; lat++)
                    {
                        for (int lon = 0; lon < longitudes; lon++)
                        {
                            int current = lat * (longitudes + 1) + lon;
                            int next = current + longitudes + 1;
                            edges.Add((current, current + 1));
                            edges.Add((current, next));
                        }
                    }
                    break;

                case "Cono":
                    int coneSegments = 20;
                    for (int i = 0; i < coneSegments; i++)
                    {
                        double angle = 2 * Math.PI * i / coneSegments;
                        vertices.Add(new Point3D((float)Math.Cos(angle), -1, (float)Math.Sin(angle)));
                    }
                    vertices.Add(new Point3D(0, 1.5f, 0));
                    for (int i = 0; i < coneSegments; i++)
                    {
                        edges.Add((i, (i + 1) % coneSegments));
                        edges.Add((i, coneSegments));
                    }
                    break;

                case "Cilindro":
                    int cylSegments = 20;
                    for (int i = 0; i < cylSegments; i++)
                    {
                        double angle = 2 * Math.PI * i / cylSegments;
                        vertices.Add(new Point3D((float)Math.Cos(angle), -1, (float)Math.Sin(angle)));
                        vertices.Add(new Point3D((float)Math.Cos(angle), 1, (float)Math.Sin(angle)));
                    }
                    for (int i = 0; i < cylSegments; i++)
                    {
                        int lower = i * 2;
                        int upper = i * 2 + 1;
                        int lowerNext = (lower + 2) % (cylSegments * 2);
                        int upperNext = (upper + 2) % (cylSegments * 2);

                        edges.Add((lower, lowerNext));
                        edges.Add((upper, upperNext));
                        edges.Add((lower, upper));
                    }
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (vertices == null || edges == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.Black);

            int centerX = this.ClientSize.Width / 2 - panelControls.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            var transformedPoints = new List<PointF>();

            Matrix3D rotationX = Matrix3D.RotationX(angleX * (float)(Math.PI / 180));
            Matrix3D rotationY = Matrix3D.RotationY(angleY * (float)(Math.PI / 180));
            Matrix3D rotationZ = Matrix3D.RotationZ(angleZ * (float)(Math.PI / 180));

            Matrix3D rotation = rotationX * rotationY * rotationZ;

            foreach (var v in vertices)
            {
                var p = rotation * v;

                p.X = p.X * scale + translateX / 50f;
                p.Y = p.Y * scale + translateY / 50f;
                p.Z = p.Z * scale + translateZ / 50f;

                // Proyección simple perspectiva
                float distance = 3;
                float z = 1 / (distance - p.Z);
                float x2d = p.X * z * 200 + centerX;
                float y2d = -p.Y * z * 200 + centerY;

                transformedPoints.Add(new PointF(x2d, y2d));
            }

            using (Pen pen = new Pen(Color.Cyan, 2))
            {
                foreach (var edge in edges)
                {
                    PointF p1 = transformedPoints[edge.Item1];
                    PointF p2 = transformedPoints[edge.Item2];
                    g.DrawLine(pen, p1, p2);
                }
            }
        }
    }

    public struct Point3D
    {
        public float X, Y, Z;

        public Point3D(float x, float y, float z)
        {
            X = x; Y = y; Z = z;
        }

        public static Point3D operator *(Matrix3D m, Point3D p)
        {
            float x = m.M11 * p.X + m.M12 * p.Y + m.M13 * p.Z + m.M14;
            float y = m.M21 * p.X + m.M22 * p.Y + m.M23 * p.Z + m.M24;
            float z = m.M31 * p.X + m.M32 * p.Y + m.M33 * p.Z + m.M34;
            return new Point3D(x, y, z);
        }
    }

    public struct Matrix3D
    {
        public float M11, M12, M13, M14;
        public float M21, M22, M23, M24;
        public float M31, M32, M33, M34;
        public float M41, M42, M43, M44;

        public static Matrix3D RotationX(float angle)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);
            return new Matrix3D
            {
                M11 = 1,
                M12 = 0,
                M13 = 0,
                M14 = 0,
                M21 = 0,
                M22 = cos,
                M23 = -sin,
                M24 = 0,
                M31 = 0,
                M32 = sin,
                M33 = cos,
                M34 = 0,
                M41 = 0,
                M42 = 0,
                M43 = 0,
                M44 = 1,
            };
        }

        public static Matrix3D RotationY(float angle)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);
            return new Matrix3D
            {
                M11 = cos,
                M12 = 0,
                M13 = sin,
                M14 = 0,
                M21 = 0,
                M22 = 1,
                M23 = 0,
                M24 = 0,
                M31 = -sin,
                M32 = 0,
                M33 = cos,
                M34 = 0,
                M41 = 0,
                M42 = 0,
                M43 = 0,
                M44 = 1,
            };
        }

        public static Matrix3D RotationZ(float angle)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);
            return new Matrix3D
            {
                M11 = cos,
                M12 = -sin,
                M13 = 0,
                M14 = 0,
                M21 = sin,
                M22 = cos,
                M23 = 0,
                M24 = 0,
                M31 = 0,
                M32 = 0,
                M33 = 1,
                M34 = 0,
                M41 = 0,
                M42 = 0,
                M43 = 0,
                M44 = 1,
            };
        }

        public static Matrix3D operator *(Matrix3D a, Matrix3D b)
        {
            Matrix3D r = new Matrix3D();
            r.M11 = a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41;
            r.M12 = a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42;
            r.M13 = a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43;
            r.M14 = a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44;

            r.M21 = a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41;
            r.M22 = a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42;
            r.M23 = a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43;
            r.M24 = a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44;

            r.M31 = a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41;
            r.M32 = a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42;
            r.M33 = a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43;
            r.M34 = a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44;

            r.M41 = a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41;
            r.M42 = a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42;
            r.M43 = a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43;
            r.M44 = a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44;

            return r;
        }
    }
}
