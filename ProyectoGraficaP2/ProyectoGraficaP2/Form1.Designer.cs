using System.Drawing;

namespace ProyectoGraficaP2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelControls;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelControls;

        private System.Windows.Forms.Label labelTranslateX;
        private System.Windows.Forms.Label labelTranslateY;
        private System.Windows.Forms.Label labelTranslateZ;
        private System.Windows.Forms.Label labelRotateX;
        private System.Windows.Forms.Label labelRotateY;
        private System.Windows.Forms.Label labelRotateZ;
        private System.Windows.Forms.Label labelScale;

        private System.Windows.Forms.TrackBar sliderTranslateX;
        private System.Windows.Forms.TrackBar sliderTranslateY;
        private System.Windows.Forms.TrackBar sliderTranslateZ;
        private System.Windows.Forms.TrackBar sliderRotateX;
        private System.Windows.Forms.TrackBar sliderRotateY;
        private System.Windows.Forms.TrackBar sliderRotateZ;
        private System.Windows.Forms.TrackBar sliderScale;

        private System.Windows.Forms.Label labelTranslateXValue;
        private System.Windows.Forms.Label labelTranslateYValue;
        private System.Windows.Forms.Label labelTranslateZValue;
        private System.Windows.Forms.Label labelRotateXValue;
        private System.Windows.Forms.Label labelRotateYValue;
        private System.Windows.Forms.Label labelRotateZValue;
        private System.Windows.Forms.Label labelScaleValue;

        private System.Windows.Forms.ComboBox comboBoxFigures;

        // NUEVO label para mostrar la rotación animada en esquina inferior derecha
        private System.Windows.Forms.Label labelAnimationAngleY;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelControls = new System.Windows.Forms.Panel();
            this.tableLayoutPanelControls = new System.Windows.Forms.TableLayoutPanel();

            this.labelTranslateX = new System.Windows.Forms.Label();
            this.labelTranslateY = new System.Windows.Forms.Label();
            this.labelTranslateZ = new System.Windows.Forms.Label();
            this.labelRotateX = new System.Windows.Forms.Label();
            this.labelRotateY = new System.Windows.Forms.Label();
            this.labelRotateZ = new System.Windows.Forms.Label();
            this.labelScale = new System.Windows.Forms.Label();

            this.sliderTranslateX = new System.Windows.Forms.TrackBar();
            this.sliderTranslateY = new System.Windows.Forms.TrackBar();
            this.sliderTranslateZ = new System.Windows.Forms.TrackBar();
            this.sliderRotateX = new System.Windows.Forms.TrackBar();
            this.sliderRotateY = new System.Windows.Forms.TrackBar();
            this.sliderRotateZ = new System.Windows.Forms.TrackBar();
            this.sliderScale = new System.Windows.Forms.TrackBar();

            this.labelTranslateXValue = new System.Windows.Forms.Label();
            this.labelTranslateYValue = new System.Windows.Forms.Label();
            this.labelTranslateZValue = new System.Windows.Forms.Label();
            this.labelRotateXValue = new System.Windows.Forms.Label();
            this.labelRotateYValue = new System.Windows.Forms.Label();
            this.labelRotateZValue = new System.Windows.Forms.Label();
            this.labelScaleValue = new System.Windows.Forms.Label();

            this.comboBoxFigures = new System.Windows.Forms.ComboBox();
            this.labelAnimationAngleY = new System.Windows.Forms.Label();

            // Panel de controles
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControls.Width = 320;
            this.panelControls.BackColor = Color.FromArgb(20, 30, 40);
            this.panelControls.Padding = new System.Windows.Forms.Padding(10);
            this.Controls.Add(this.panelControls);

            // TableLayoutPanel configuración
            this.tableLayoutPanelControls.ColumnCount = 3;
            this.tableLayoutPanelControls.RowCount = 8;
            this.tableLayoutPanelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            for (int i = 0; i < 8; i++)
            {
                this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            }

            // Agregar controles a cada fila
            this.tableLayoutPanelControls.Controls.Add(this.labelTranslateX, 0, 0);
            this.tableLayoutPanelControls.Controls.Add(this.sliderTranslateX, 1, 0);
            this.tableLayoutPanelControls.Controls.Add(this.labelTranslateXValue, 2, 0);

            this.tableLayoutPanelControls.Controls.Add(this.labelTranslateY, 0, 1);
            this.tableLayoutPanelControls.Controls.Add(this.sliderTranslateY, 1, 1);
            this.tableLayoutPanelControls.Controls.Add(this.labelTranslateYValue, 2, 1);

            this.tableLayoutPanelControls.Controls.Add(this.labelTranslateZ, 0, 2);
            this.tableLayoutPanelControls.Controls.Add(this.sliderTranslateZ, 1, 2);
            this.tableLayoutPanelControls.Controls.Add(this.labelTranslateZValue, 2, 2);

            this.tableLayoutPanelControls.Controls.Add(this.labelRotateX, 0, 3);
            this.tableLayoutPanelControls.Controls.Add(this.sliderRotateX, 1, 3);
            this.tableLayoutPanelControls.Controls.Add(this.labelRotateXValue, 2, 3);

            this.tableLayoutPanelControls.Controls.Add(this.labelRotateY, 0, 4);
            this.tableLayoutPanelControls.Controls.Add(this.sliderRotateY, 1, 4);
            this.tableLayoutPanelControls.Controls.Add(this.labelRotateYValue, 2, 4);

            this.tableLayoutPanelControls.Controls.Add(this.labelRotateZ, 0, 5);
            this.tableLayoutPanelControls.Controls.Add(this.sliderRotateZ, 1, 5);
            this.tableLayoutPanelControls.Controls.Add(this.labelRotateZValue, 2, 5);

            this.tableLayoutPanelControls.Controls.Add(this.labelScale, 0, 6);
            this.tableLayoutPanelControls.Controls.Add(this.sliderScale, 1, 6);
            this.tableLayoutPanelControls.Controls.Add(this.labelScaleValue, 2, 6);

            // Estilo de labels
            var labels = new[]{
        (labelTranslateX, "Translate X"),
        (labelTranslateY, "Translate Y"),
        (labelTranslateZ, "Translate Z"),
        (labelRotateX, "Rotate X"),
        (labelRotateY, "Rotate Y"),
        (labelRotateZ, "Rotate Z"),
        (labelScale, "Scale"),
    };

            foreach (var (label, text) in labels)
            {
                label.Text = text;
                label.Dock = System.Windows.Forms.DockStyle.Fill;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                label.ForeColor = Color.White;
                label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            }

            // Estilo de labels de valores
            var valueLabels = new[]{
        labelTranslateXValue,
        labelTranslateYValue,
        labelTranslateZValue,
        labelRotateXValue,
        labelRotateYValue,
        labelRotateZValue,
        labelScaleValue,
    };

            foreach (var valLabel in valueLabels)
            {
                valLabel.Dock = System.Windows.Forms.DockStyle.Fill;
                valLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                valLabel.ForeColor = Color.LightCyan;
                valLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            }

            // Estilo de sliders
            var sliders = new[]{
        sliderTranslateX,
        sliderTranslateY,
        sliderTranslateZ,
        sliderRotateX,
        sliderRotateY,
        sliderRotateZ,
        sliderScale,
    };

            foreach (var slider in sliders)
            {
                slider.Dock = System.Windows.Forms.DockStyle.Fill;
                slider.TickStyle = System.Windows.Forms.TickStyle.None;
            }

            // Rango sliders Translate
            sliderTranslateX.Minimum = -100; sliderTranslateX.Maximum = 100; sliderTranslateX.Value = 0;
            sliderTranslateY.Minimum = -100; sliderTranslateY.Maximum = 100; sliderTranslateY.Value = 0;
            sliderTranslateZ.Minimum = -100; sliderTranslateZ.Maximum = 100; sliderTranslateZ.Value = 0;

            // Rango sliders Rotate
            sliderRotateX.Minimum = 0; sliderRotateX.Maximum = 360; sliderRotateX.Value = 0;
            sliderRotateY.Minimum = 0; sliderRotateY.Maximum = 360; sliderRotateY.Value = 0;
            sliderRotateZ.Minimum = 0; sliderRotateZ.Maximum = 360; sliderRotateZ.Value = 0;

            // Rango de escala (0.1 a 3.0)
            sliderScale.Minimum = 10; sliderScale.Maximum = 300; sliderScale.Value = 100;

            // Configuración ComboBox
            this.comboBoxFigures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxFigures.Height = 30;
            this.comboBoxFigures.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxFigures.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.comboBoxFigures.ForeColor = Color.Black;
            this.comboBoxFigures.BackColor = Color.LightGray;

            // Layout principal
            var mainControlLayout = new System.Windows.Forms.TableLayoutPanel();
            mainControlLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            mainControlLayout.ColumnCount = 1;
            mainControlLayout.RowCount = 2;
            mainControlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            mainControlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            mainControlLayout.Controls.Add(this.comboBoxFigures, 0, 0);
            mainControlLayout.Controls.Add(this.tableLayoutPanelControls, 0, 1);

            this.panelControls.Controls.Add(mainControlLayout);

            // Label animación Y
            this.labelAnimationAngleY.AutoSize = false;
            this.labelAnimationAngleY.Width = 120;
            this.labelAnimationAngleY.Height = 30;
            this.labelAnimationAngleY.BackColor = Color.FromArgb(30, 40, 50);
            this.labelAnimationAngleY.ForeColor = Color.Cyan;
            this.labelAnimationAngleY.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelAnimationAngleY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelAnimationAngleY.Text = "Rot Y: 0°";
            this.labelAnimationAngleY.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.labelAnimationAngleY.Location = new System.Drawing.Point(this.ClientSize.Width - this.labelAnimationAngleY.Width - 20, this.ClientSize.Height - this.labelAnimationAngleY.Height - 20);
            this.Controls.Add(this.labelAnimationAngleY);

            // Evento Resize para mover el label animado
            this.Resize += (s, e) =>
            {
                this.labelAnimationAngleY.Location = new System.Drawing.Point(this.ClientSize.Width - this.labelAnimationAngleY.Width - 20, this.ClientSize.Height - this.labelAnimationAngleY.Height - 20);
            };

            // Propiedades del formulario
            this.Text = "Proyecto Gráfica 3D";
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.MinimumSize = new System.Drawing.Size(900, 600);
        }
    }
}
