namespace Mandelbrot
{
    partial class MandelbrotForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.glRenderPanel = new OpenTK.GLControl();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpControls = new System.Windows.Forms.TableLayoutPanel();
            this.btnRedraw = new System.Windows.Forms.Button();
            this.panelCoordinates = new System.Windows.Forms.Panel();
            this.lblSize = new System.Windows.Forms.Label();
            this.npHeight = new Mandelbrot.NumberPicker();
            this.sectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblOrigin = new System.Windows.Forms.Label();
            this.npWidth = new Mandelbrot.NumberPicker();
            this.npIm = new Mandelbrot.NumberPicker();
            this.npRe = new Mandelbrot.NumberPicker();
            this.panelOtherControls = new System.Windows.Forms.Panel();
            this.txtIterations = new System.Windows.Forms.TextBox();
            this.lblIterations = new System.Windows.Forms.Label();
            this.tbNumOfIters = new System.Windows.Forms.TrackBar();
            this.cbAutoRedraw = new System.Windows.Forms.CheckBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.tlpControls.SuspendLayout();
            this.panelCoordinates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sectionBindingSource)).BeginInit();
            this.panelOtherControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbNumOfIters)).BeginInit();
            this.SuspendLayout();
            // 
            // glRenderPanel
            // 
            this.glRenderPanel.BackColor = System.Drawing.Color.Black;
            this.glRenderPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.glRenderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glRenderPanel.Location = new System.Drawing.Point(0, 0);
            this.glRenderPanel.Margin = new System.Windows.Forms.Padding(0);
            this.glRenderPanel.Name = "glRenderPanel";
            this.glRenderPanel.Size = new System.Drawing.Size(600, 600);
            this.glRenderPanel.TabIndex = 0;
            this.glRenderPanel.VSync = false;
            this.glRenderPanel.Load += new System.EventHandler(this.glRenderPanel_Load);
            this.glRenderPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.glRenderPanel_Paint);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.glRenderPanel, 0, 0);
            this.tlpMain.Controls.Add(this.tlpControls, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(868, 600);
            this.tlpMain.TabIndex = 1;
            // 
            // tlpControls
            // 
            this.tlpControls.ColumnCount = 1;
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControls.Controls.Add(this.btnRedraw, 0, 2);
            this.tlpControls.Controls.Add(this.panelCoordinates, 0, 0);
            this.tlpControls.Controls.Add(this.panelOtherControls, 0, 1);
            this.tlpControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpControls.Location = new System.Drawing.Point(603, 3);
            this.tlpControls.Name = "tlpControls";
            this.tlpControls.RowCount = 3;
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 177F));
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlpControls.Size = new System.Drawing.Size(262, 594);
            this.tlpControls.TabIndex = 1;
            // 
            // btnRedraw
            // 
            this.btnRedraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRedraw.Location = new System.Drawing.Point(20, 539);
            this.btnRedraw.Margin = new System.Windows.Forms.Padding(20);
            this.btnRedraw.Name = "btnRedraw";
            this.btnRedraw.Size = new System.Drawing.Size(222, 35);
            this.btnRedraw.TabIndex = 0;
            this.btnRedraw.Text = "Draw";
            this.btnRedraw.UseVisualStyleBackColor = true;
            this.btnRedraw.Click += new System.EventHandler(this.btnRedraw_Click);
            // 
            // panelCoordinates
            // 
            this.panelCoordinates.Controls.Add(this.lblSize);
            this.panelCoordinates.Controls.Add(this.npHeight);
            this.panelCoordinates.Controls.Add(this.lblOrigin);
            this.panelCoordinates.Controls.Add(this.npWidth);
            this.panelCoordinates.Controls.Add(this.npIm);
            this.panelCoordinates.Controls.Add(this.npRe);
            this.panelCoordinates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCoordinates.Location = new System.Drawing.Point(3, 3);
            this.panelCoordinates.Name = "panelCoordinates";
            this.panelCoordinates.Size = new System.Drawing.Size(256, 171);
            this.panelCoordinates.TabIndex = 1;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(3, 80);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(27, 13);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "Size";
            // 
            // npHeight
            // 
            this.npHeight.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sectionBindingSource, "Height", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N6"));
            this.npHeight.LabelText = "Height:";
            this.npHeight.Location = new System.Drawing.Point(0, 128);
            this.npHeight.Name = "npHeight";
            this.npHeight.Size = new System.Drawing.Size(249, 26);
            this.npHeight.TabIndex = 0;
            this.npHeight.Value = double.NaN;
            // 
            // sectionBindingSource
            // 
            this.sectionBindingSource.DataSource = typeof(Mandelbrot.Section);
            // 
            // lblOrigin
            // 
            this.lblOrigin.AutoSize = true;
            this.lblOrigin.Location = new System.Drawing.Point(3, 3);
            this.lblOrigin.Name = "lblOrigin";
            this.lblOrigin.Size = new System.Drawing.Size(34, 13);
            this.lblOrigin.TabIndex = 1;
            this.lblOrigin.Text = "Origin";
            // 
            // npWidth
            // 
            this.npWidth.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sectionBindingSource, "Width", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N6"));
            this.npWidth.LabelText = "Width:";
            this.npWidth.Location = new System.Drawing.Point(0, 96);
            this.npWidth.Name = "npWidth";
            this.npWidth.Size = new System.Drawing.Size(249, 26);
            this.npWidth.TabIndex = 0;
            this.npWidth.Value = double.NaN;
            // 
            // npIm
            // 
            this.npIm.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sectionBindingSource, "Im", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "N6"));
            this.npIm.LabelText = "Im:";
            this.npIm.Location = new System.Drawing.Point(0, 51);
            this.npIm.Name = "npIm";
            this.npIm.Size = new System.Drawing.Size(249, 26);
            this.npIm.TabIndex = 0;
            this.npIm.Value = double.NaN;
            // 
            // npRe
            // 
            this.npRe.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sectionBindingSource, "Re", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N6"));
            this.npRe.LabelText = "Re:";
            this.npRe.Location = new System.Drawing.Point(0, 19);
            this.npRe.Name = "npRe";
            this.npRe.Size = new System.Drawing.Size(249, 26);
            this.npRe.TabIndex = 0;
            this.npRe.Value = double.NaN;
            // 
            // panelOtherControls
            // 
            this.panelOtherControls.Controls.Add(this.btnRight);
            this.panelOtherControls.Controls.Add(this.btnLeft);
            this.panelOtherControls.Controls.Add(this.btnZoomOut);
            this.panelOtherControls.Controls.Add(this.btnZoomIn);
            this.panelOtherControls.Controls.Add(this.btnDown);
            this.panelOtherControls.Controls.Add(this.btnUp);
            this.panelOtherControls.Controls.Add(this.txtIterations);
            this.panelOtherControls.Controls.Add(this.lblIterations);
            this.panelOtherControls.Controls.Add(this.tbNumOfIters);
            this.panelOtherControls.Controls.Add(this.cbAutoRedraw);
            this.panelOtherControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOtherControls.Location = new System.Drawing.Point(3, 180);
            this.panelOtherControls.Name = "panelOtherControls";
            this.panelOtherControls.Size = new System.Drawing.Size(256, 336);
            this.panelOtherControls.TabIndex = 2;
            // 
            // txtIterations
            // 
            this.txtIterations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIterations.Location = new System.Drawing.Point(139, 54);
            this.txtIterations.MaxLength = 8;
            this.txtIterations.Name = "txtIterations";
            this.txtIterations.ReadOnly = true;
            this.txtIterations.Size = new System.Drawing.Size(100, 20);
            this.txtIterations.TabIndex = 3;
            // 
            // lblIterations
            // 
            this.lblIterations.AutoSize = true;
            this.lblIterations.Location = new System.Drawing.Point(14, 57);
            this.lblIterations.Name = "lblIterations";
            this.lblIterations.Size = new System.Drawing.Size(104, 13);
            this.lblIterations.TabIndex = 2;
            this.lblIterations.Text = "Number of iterations:";
            // 
            // tbNumOfIters
            // 
            this.tbNumOfIters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNumOfIters.LargeChange = 50;
            this.tbNumOfIters.Location = new System.Drawing.Point(0, 3);
            this.tbNumOfIters.Maximum = 4000;
            this.tbNumOfIters.Minimum = 10;
            this.tbNumOfIters.Name = "tbNumOfIters";
            this.tbNumOfIters.Size = new System.Drawing.Size(256, 45);
            this.tbNumOfIters.SmallChange = 15;
            this.tbNumOfIters.TabIndex = 1;
            this.tbNumOfIters.Value = 1;
            this.tbNumOfIters.Scroll += new System.EventHandler(this.tbNumOfIters_Scroll);
            // 
            // cbAutoRedraw
            // 
            this.cbAutoRedraw.AutoSize = true;
            this.cbAutoRedraw.Location = new System.Drawing.Point(6, 316);
            this.cbAutoRedraw.Name = "cbAutoRedraw";
            this.cbAutoRedraw.Size = new System.Drawing.Size(80, 17);
            this.cbAutoRedraw.TabIndex = 0;
            this.cbAutoRedraw.Text = "Autoredraw";
            this.cbAutoRedraw.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(107, 108);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(45, 45);
            this.btnUp.TabIndex = 4;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(56, 168);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(45, 45);
            this.btnLeft.TabIndex = 4;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(158, 168);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(45, 45);
            this.btnRight.TabIndex = 4;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(107, 219);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(45, 45);
            this.btnDown.TabIndex = 4;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(107, 159);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(45, 24);
            this.btnZoomIn.TabIndex = 4;
            this.btnZoomIn.Text = "+";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(107, 189);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(45, 24);
            this.btnZoomOut.TabIndex = 4;
            this.btnZoomOut.Text = "-";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // MandelbrotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 600);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MandelbrotForm";
            this.Text = "MandelbrotForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MandelbrotForm_FormClosing);
            this.tlpMain.ResumeLayout(false);
            this.tlpControls.ResumeLayout(false);
            this.panelCoordinates.ResumeLayout(false);
            this.panelCoordinates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sectionBindingSource)).EndInit();
            this.panelOtherControls.ResumeLayout(false);
            this.panelOtherControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbNumOfIters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl glRenderPanel;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpControls;
        private System.Windows.Forms.Button btnRedraw;
        private System.Windows.Forms.Panel panelCoordinates;
        private Mandelbrot.NumberPicker npIm;
        private Mandelbrot.NumberPicker npRe;
        private System.Windows.Forms.Label lblOrigin;
        private System.Windows.Forms.Label lblSize;
        private Mandelbrot.NumberPicker npHeight;
        private Mandelbrot.NumberPicker npWidth;
        private System.Windows.Forms.BindingSource sectionBindingSource;
        private System.Windows.Forms.Panel panelOtherControls;
        private System.Windows.Forms.TextBox txtIterations;
        private System.Windows.Forms.Label lblIterations;
        private System.Windows.Forms.TrackBar tbNumOfIters;
        private System.Windows.Forms.CheckBox cbAutoRedraw;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
    }
}

