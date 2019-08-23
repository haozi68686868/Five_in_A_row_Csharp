namespace Five_in_A_Row
{
    partial class DlgSettings
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
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.checkBoxBanned = new System.Windows.Forms.CheckBox();
            this.checkBoxSwap = new System.Windows.Forms.CheckBox();
            this.radioBtnSwap1 = new System.Windows.Forms.RadioButton();
            this.radioBtnSwap3 = new System.Windows.Forms.RadioButton();
            this.checkBoxSel = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBtnSel2 = new System.Windows.Forms.RadioButton();
            this.radioBtnSelx = new System.Windows.Forms.RadioButton();
            this.radioBtnSelN = new System.Windows.Forms.RadioButton();
            this.TBoxSelC = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(12, 230);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(61, 23);
            this.BtnOK.TabIndex = 0;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(92, 230);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(61, 23);
            this.BtnCancel.TabIndex = 0;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // checkBoxBanned
            // 
            this.checkBoxBanned.AutoSize = true;
            this.checkBoxBanned.Location = new System.Drawing.Point(35, 22);
            this.checkBoxBanned.Name = "checkBoxBanned";
            this.checkBoxBanned.Size = new System.Drawing.Size(84, 16);
            this.checkBoxBanned.TabIndex = 1;
            this.checkBoxBanned.Text = "有禁手规则";
            this.checkBoxBanned.UseVisualStyleBackColor = true;
            // 
            // checkBoxSwap
            // 
            this.checkBoxSwap.AutoSize = true;
            this.checkBoxSwap.Location = new System.Drawing.Point(35, 55);
            this.checkBoxSwap.Name = "checkBoxSwap";
            this.checkBoxSwap.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSwap.TabIndex = 2;
            this.checkBoxSwap.UseVisualStyleBackColor = true;
            this.checkBoxSwap.CheckedChanged += new System.EventHandler(this.checkBoxSwap_CheckedChanged);
            // 
            // radioBtnSwap1
            // 
            this.radioBtnSwap1.AutoSize = true;
            this.radioBtnSwap1.Location = new System.Drawing.Point(6, 20);
            this.radioBtnSwap1.Name = "radioBtnSwap1";
            this.radioBtnSwap1.Size = new System.Drawing.Size(71, 16);
            this.radioBtnSwap1.TabIndex = 3;
            this.radioBtnSwap1.TabStop = true;
            this.radioBtnSwap1.Text = "一手交换";
            this.radioBtnSwap1.UseVisualStyleBackColor = true;
            // 
            // radioBtnSwap3
            // 
            this.radioBtnSwap3.AutoSize = true;
            this.radioBtnSwap3.Location = new System.Drawing.Point(6, 42);
            this.radioBtnSwap3.Name = "radioBtnSwap3";
            this.radioBtnSwap3.Size = new System.Drawing.Size(71, 16);
            this.radioBtnSwap3.TabIndex = 4;
            this.radioBtnSwap3.TabStop = true;
            this.radioBtnSwap3.Text = "三手交换";
            this.radioBtnSwap3.UseVisualStyleBackColor = true;
            // 
            // checkBoxSel
            // 
            this.checkBoxSel.AutoSize = true;
            this.checkBoxSel.Location = new System.Drawing.Point(35, 126);
            this.checkBoxSel.Name = "checkBoxSel";
            this.checkBoxSel.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSel.TabIndex = 5;
            this.checkBoxSel.UseVisualStyleBackColor = true;
            this.checkBoxSel.CheckedChanged += new System.EventHandler(this.checkBoxSel_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnSwap1);
            this.groupBox1.Controls.Add(this.radioBtnSwap3);
            this.groupBox1.Location = new System.Drawing.Point(58, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(85, 65);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "交换规则";
            // 
            // radioBtnSel2
            // 
            this.radioBtnSel2.AutoSize = true;
            this.radioBtnSel2.Location = new System.Drawing.Point(64, 149);
            this.radioBtnSel2.Name = "radioBtnSel2";
            this.radioBtnSel2.Size = new System.Drawing.Size(71, 16);
            this.radioBtnSel2.TabIndex = 7;
            this.radioBtnSel2.TabStop = true;
            this.radioBtnSel2.Text = "五手两打";
            this.radioBtnSel2.UseVisualStyleBackColor = true;
            // 
            // radioBtnSelx
            // 
            this.radioBtnSelx.AutoSize = true;
            this.radioBtnSelx.Location = new System.Drawing.Point(64, 172);
            this.radioBtnSelx.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.radioBtnSelx.Name = "radioBtnSelx";
            this.radioBtnSelx.Size = new System.Drawing.Size(77, 16);
            this.radioBtnSelx.TabIndex = 8;
            this.radioBtnSelx.TabStop = true;
            this.radioBtnSelx.Text = "五手   打";
            this.radioBtnSelx.UseVisualStyleBackColor = true;
            this.radioBtnSelx.CheckedChanged += new System.EventHandler(this.radioBtnSelx_CheckedChanged);
            // 
            // radioBtnSelN
            // 
            this.radioBtnSelN.AutoSize = true;
            this.radioBtnSelN.Location = new System.Drawing.Point(64, 195);
            this.radioBtnSelN.Name = "radioBtnSelN";
            this.radioBtnSelN.Size = new System.Drawing.Size(65, 16);
            this.radioBtnSelN.TabIndex = 9;
            this.radioBtnSelN.TabStop = true;
            this.radioBtnSelN.Text = "五手N打";
            this.radioBtnSelN.UseVisualStyleBackColor = true;
            this.radioBtnSelN.CheckedChanged += new System.EventHandler(this.radioBtnSelN_CheckedChanged);
            // 
            // TBoxSelC
            // 
            this.TBoxSelC.Enabled = false;
            this.TBoxSelC.Location = new System.Drawing.Point(107, 169);
            this.TBoxSelC.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.TBoxSelC.Name = "TBoxSelC";
            this.TBoxSelC.Size = new System.Drawing.Size(15, 21);
            this.TBoxSelC.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(57, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(86, 97);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "五手多打";
            // 
            // DlgSettings
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(165, 259);
            this.Controls.Add(this.TBoxSelC);
            this.Controls.Add(this.radioBtnSelN);
            this.Controls.Add(this.radioBtnSelx);
            this.Controls.Add(this.radioBtnSel2);
            this.Controls.Add(this.checkBoxSel);
            this.Controls.Add(this.checkBoxSwap);
            this.Controls.Add(this.checkBoxBanned);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "DlgSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.DlgSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        public System.Windows.Forms.CheckBox checkBoxBanned;
        public System.Windows.Forms.CheckBox checkBoxSwap;
        public System.Windows.Forms.CheckBox checkBoxSel;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton radioBtnSel2;
        public System.Windows.Forms.RadioButton radioBtnSelx;
        public System.Windows.Forms.RadioButton radioBtnSelN;
        public System.Windows.Forms.TextBox TBoxSelC;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.RadioButton radioBtnSwap1;
        public System.Windows.Forms.RadioButton radioBtnSwap3;
    }
}