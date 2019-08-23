namespace Five_in_A_Row
{
    partial class VarDecide
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
            this.btnNewV = new System.Windows.Forms.Button();
            this.btnNewM = new System.Windows.Forms.Button();
            this.btnOvR = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNewV
            // 
            this.btnNewV.Location = new System.Drawing.Point(167, 41);
            this.btnNewV.Name = "btnNewV";
            this.btnNewV.Size = new System.Drawing.Size(140, 25);
            this.btnNewV.TabIndex = 0;
            this.btnNewV.Text = "New Variation";
            this.btnNewV.UseVisualStyleBackColor = true;
            this.btnNewV.Click += new System.EventHandler(this.btnNewV_Click);
            // 
            // btnNewM
            // 
            this.btnNewM.Location = new System.Drawing.Point(167, 82);
            this.btnNewM.Name = "btnNewM";
            this.btnNewM.Size = new System.Drawing.Size(140, 25);
            this.btnNewM.TabIndex = 0;
            this.btnNewM.Text = "New Main Line";
            this.btnNewM.UseVisualStyleBackColor = true;
            this.btnNewM.Click += new System.EventHandler(this.btnNewM_Click);
            // 
            // btnOvR
            // 
            this.btnOvR.Location = new System.Drawing.Point(167, 123);
            this.btnOvR.Name = "btnOvR";
            this.btnOvR.Size = new System.Drawing.Size(140, 25);
            this.btnOvR.TabIndex = 0;
            this.btnOvR.Text = "OverWrite";
            this.btnOvR.UseVisualStyleBackColor = true;
            this.btnOvR.Click += new System.EventHandler(this.btnOvR_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(167, 164);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(140, 25);
            this.BtnCancel.TabIndex = 0;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(132, 148);
            this.listBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Old Moves";
            // 
            // VarDecide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 205);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnOvR);
            this.Controls.Add(this.btnNewM);
            this.Controls.Add(this.btnNewV);
            this.Name = "VarDecide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input New Move";
            this.Load += new System.EventHandler(this.VarDecide_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewV;
        private System.Windows.Forms.Button btnNewM;
        private System.Windows.Forms.Button btnOvR;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListBox listBox1;
    }
}