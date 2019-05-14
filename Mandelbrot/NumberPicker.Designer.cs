namespace Mandelbrot
{
    partial class NumberPicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblText = new System.Windows.Forms.Label();
            this.mtbNumber = new System.Windows.Forms.MaskedTextBox();
            this.btnInc = new System.Windows.Forms.Button();
            this.btnDec = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(3, 6);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(0, 13);
            this.lblText.TabIndex = 3;
            // 
            // mtbNumber
            // 
            this.mtbNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mtbNumber.Location = new System.Drawing.Point(47, 3);
            this.mtbNumber.Name = "mtbNumber";
            this.mtbNumber.Size = new System.Drawing.Size(156, 20);
            this.mtbNumber.TabIndex = 2;
            // 
            // btnInc
            // 
            this.btnInc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInc.Location = new System.Drawing.Point(209, 1);
            this.btnInc.Name = "btnInc";
            this.btnInc.Size = new System.Drawing.Size(23, 23);
            this.btnInc.TabIndex = 4;
            this.btnInc.Text = "+";
            this.btnInc.UseVisualStyleBackColor = true;
            this.btnInc.Click += new System.EventHandler(this.btnInc_Click);
            // 
            // btnDec
            // 
            this.btnDec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDec.Location = new System.Drawing.Point(232, 1);
            this.btnDec.Name = "btnDec";
            this.btnDec.Size = new System.Drawing.Size(25, 23);
            this.btnDec.TabIndex = 4;
            this.btnDec.Text = "-";
            this.btnDec.UseVisualStyleBackColor = true;
            this.btnDec.Click += new System.EventHandler(this.btnDec_Click);
            // 
            // NumberPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDec);
            this.Controls.Add(this.btnInc);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.mtbNumber);
            this.Name = "NumberPicker";
            this.Size = new System.Drawing.Size(262, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.MaskedTextBox mtbNumber;
        private System.Windows.Forms.Button btnInc;
        private System.Windows.Forms.Button btnDec;
    }
}
