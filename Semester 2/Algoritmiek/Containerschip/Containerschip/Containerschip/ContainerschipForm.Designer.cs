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
            this.normalCount = new System.Windows.Forms.NumericUpDown();
            this.valuableCount = new System.Windows.Forms.NumericUpDown();
            this.coolableCount = new System.Windows.Forms.NumericUpDown();
            this.coolableValuableCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.shipWidthInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipLengthInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.normalCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valuableCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coolableCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coolableValuableCount)).BeginInit();
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
            // normalCount
            // 
            this.normalCount.Location = new System.Drawing.Point(89, 25);
            this.normalCount.Name = "normalCount";
            this.normalCount.Size = new System.Drawing.Size(55, 22);
            this.normalCount.TabIndex = 7;
            // 
            // valuableCount
            // 
            this.valuableCount.Location = new System.Drawing.Point(181, 25);
            this.valuableCount.Name = "valuableCount";
            this.valuableCount.Size = new System.Drawing.Size(55, 22);
            this.valuableCount.TabIndex = 8;
            // 
            // coolableCount
            // 
            this.coolableCount.Location = new System.Drawing.Point(276, 25);
            this.coolableCount.Name = "coolableCount";
            this.coolableCount.Size = new System.Drawing.Size(55, 22);
            this.coolableCount.TabIndex = 9;
            // 
            // coolableValuableCount
            // 
            this.coolableValuableCount.Location = new System.Drawing.Point(371, 25);
            this.coolableValuableCount.Name = "coolableValuableCount";
            this.coolableValuableCount.Size = new System.Drawing.Size(55, 22);
            this.coolableValuableCount.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Normal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Valuable";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Coolable";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(368, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Coolable & Valuable";
            // 
            // form_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 359);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.coolableValuableCount);
            this.Controls.Add(this.coolableCount);
            this.Controls.Add(this.valuableCount);
            this.Controls.Add(this.normalCount);
            this.Controls.Add(this.shipLengthInput);
            this.Controls.Add(this.shipWidthInput);
            this.Controls.Add(this.LengthLabel);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.runBtn);
            this.Name = "form_1";
            this.Text = "Containerschip";
            ((System.ComponentModel.ISupportInitialize)(this.shipWidthInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipLengthInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.normalCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valuableCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coolableCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coolableValuableCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label LengthLabel;
        private System.Windows.Forms.NumericUpDown shipWidthInput;
        private System.Windows.Forms.NumericUpDown shipLengthInput;
        private System.Windows.Forms.NumericUpDown normalCount;
        private System.Windows.Forms.NumericUpDown valuableCount;
        private System.Windows.Forms.NumericUpDown coolableCount;
        private System.Windows.Forms.NumericUpDown coolableValuableCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

