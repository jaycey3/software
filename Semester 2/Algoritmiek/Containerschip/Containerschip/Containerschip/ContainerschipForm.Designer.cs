namespace Containerschip
{
    partial class form_1
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
            this.runBtn = new System.Windows.Forms.Button();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.LengthLabel = new System.Windows.Forms.Label();
            this.shipWidthInput = new System.Windows.Forms.NumericUpDown();
            this.shipLengthInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.shipWidthInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipLengthInput)).BeginInit();
            this.SuspendLayout();
            // 
            // runBtn
            // 
            this.runBtn.Font = new System.Drawing.Font("Trebuchet MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runBtn.Location = new System.Drawing.Point(89, 146);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(489, 141);
            this.runBtn.TabIndex = 0;
            this.runBtn.Tag = "run";
            this.runBtn.Text = "RUN";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(86, 66);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(71, 16);
            this.WidthLabel.TabIndex = 3;
            this.WidthLabel.Text = "Ship Width";
            // 
            // LengthLabel
            // 
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Location = new System.Drawing.Point(219, 66);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(77, 16);
            this.LengthLabel.TabIndex = 4;
            this.LengthLabel.Text = "Ship Length";
            // 
            // shipWidthInput
            // 
            this.shipWidthInput.Location = new System.Drawing.Point(89, 85);
            this.shipWidthInput.Name = "shipWidthInput";
            this.shipWidthInput.Size = new System.Drawing.Size(76, 22);
            this.shipWidthInput.TabIndex = 5;
            // 
            // shipLengthInput
            // 
            this.shipLengthInput.Location = new System.Drawing.Point(222, 85);
            this.shipLengthInput.Name = "shipLengthInput";
            this.shipLengthInput.Size = new System.Drawing.Size(76, 22);
            this.shipLengthInput.TabIndex = 6;
            // 
            // form_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 359);
            this.Controls.Add(this.shipLengthInput);
            this.Controls.Add(this.shipWidthInput);
            this.Controls.Add(this.LengthLabel);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.runBtn);
            this.Name = "form_1";
            this.Text = "Containerschip";
            ((System.ComponentModel.ISupportInitialize)(this.shipWidthInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipLengthInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label LengthLabel;
        private System.Windows.Forms.NumericUpDown shipWidthInput;
        private System.Windows.Forms.NumericUpDown shipLengthInput;
    }
}

