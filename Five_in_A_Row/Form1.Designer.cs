namespace Five_in_A_Row
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuItemLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemNGm = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemloadGame = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.棋局GToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemNext = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAI = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripAutoRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.设置SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemMatchInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemMultiLine = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemRightBtnUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAutoMove = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSetAI = new System.Windows.Forms.ToolStripMenuItem();
            this.查看VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemNumVis = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemcoordinateVis = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemBanVis = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemBackGroundColor = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TxBTimeB = new System.Windows.Forms.TextBox();
            this.TxbTimeW = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.labelNext = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemLoad,
            this.棋局GToolStripMenuItem,
            this.设置SToolStripMenuItem,
            this.查看VToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(934, 25);
            this.menuStrip.Stretch = false;
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // MenuItemLoad
            // 
            this.MenuItemLoad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemNGm,
            this.MenuItemloadGame,
            this.MenuItemSave,
            this.MenuItemSaveAs,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.MenuItemLoad.Name = "MenuItemLoad";
            this.MenuItemLoad.Size = new System.Drawing.Size(58, 21);
            this.MenuItemLoad.Text = "文件(&F)";
            // 
            // MenuItemNGm
            // 
            this.MenuItemNGm.Name = "MenuItemNGm";
            this.MenuItemNGm.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.MenuItemNGm.Size = new System.Drawing.Size(190, 22);
            this.MenuItemNGm.Text = "&New Game";
            this.MenuItemNGm.Click += new System.EventHandler(this.MenuItemNGm_Click);
            // 
            // MenuItemloadGame
            // 
            this.MenuItemloadGame.Name = "MenuItemloadGame";
            this.MenuItemloadGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuItemloadGame.Size = new System.Drawing.Size(190, 22);
            this.MenuItemloadGame.Text = "&Load Game";
            this.MenuItemloadGame.Click += new System.EventHandler(this.MenuItemloadGame_Click);
            // 
            // MenuItemSave
            // 
            this.MenuItemSave.Name = "MenuItemSave";
            this.MenuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuItemSave.Size = new System.Drawing.Size(190, 22);
            this.MenuItemSave.Text = "&Save Game";
            this.MenuItemSave.Click += new System.EventHandler(this.MenuItemSave_Click);
            // 
            // MenuItemSaveAs
            // 
            this.MenuItemSaveAs.Name = "MenuItemSaveAs";
            this.MenuItemSaveAs.Size = new System.Drawing.Size(190, 22);
            this.MenuItemSaveAs.Text = "Save As..";
            this.MenuItemSaveAs.Click += new System.EventHandler(this.MenuItemSaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(187, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // 棋局GToolStripMenuItem
            // 
            this.棋局GToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemUndo,
            this.MenuItemNext,
            this.MenuItemAI,
            this.ToolStripAutoRedo});
            this.棋局GToolStripMenuItem.Name = "棋局GToolStripMenuItem";
            this.棋局GToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.棋局GToolStripMenuItem.Text = "棋局(&G)";
            // 
            // MenuItemUndo
            // 
            this.MenuItemUndo.Name = "MenuItemUndo";
            this.MenuItemUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.MenuItemUndo.Size = new System.Drawing.Size(214, 22);
            this.MenuItemUndo.Text = "&Undo 上一步";
            this.MenuItemUndo.Click += new System.EventHandler(this.MenuItemUndo_Click);
            // 
            // MenuItemNext
            // 
            this.MenuItemNext.Name = "MenuItemNext";
            this.MenuItemNext.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.MenuItemNext.Size = new System.Drawing.Size(214, 22);
            this.MenuItemNext.Text = "&Next  下一步";
            this.MenuItemNext.Click += new System.EventHandler(this.MenuItemNext_Click);
            // 
            // MenuItemAI
            // 
            this.MenuItemAI.Name = "MenuItemAI";
            this.MenuItemAI.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.MenuItemAI.Size = new System.Drawing.Size(214, 22);
            this.MenuItemAI.Text = "&AI 电脑走棋";
            this.MenuItemAI.Click += new System.EventHandler(this.MenuItemAI_Click);
            // 
            // ToolStripAutoRedo
            // 
            this.ToolStripAutoRedo.Name = "ToolStripAutoRedo";
            this.ToolStripAutoRedo.Size = new System.Drawing.Size(214, 22);
            this.ToolStripAutoRedo.Text = "自动复盘";
            this.ToolStripAutoRedo.Click += new System.EventHandler(this.ToolStripAutoRedo_Click);
            // 
            // 设置SToolStripMenuItem
            // 
            this.设置SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemSetting,
            this.MenuItemMatchInfo,
            this.MenuItemMultiLine,
            this.MenuItemRightBtnUndo,
            this.MenuItemAutoMove,
            this.MenuItemSetAI});
            this.设置SToolStripMenuItem.Name = "设置SToolStripMenuItem";
            this.设置SToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.设置SToolStripMenuItem.Text = "设置(&S)";
            // 
            // MenuItemSetting
            // 
            this.MenuItemSetting.Name = "MenuItemSetting";
            this.MenuItemSetting.Size = new System.Drawing.Size(150, 22);
            this.MenuItemSetting.Text = "&Settings 设置";
            this.MenuItemSetting.Click += new System.EventHandler(this.MenuItemSetting_Click);
            // 
            // MenuItemMatchInfo
            // 
            this.MenuItemMatchInfo.Name = "MenuItemMatchInfo";
            this.MenuItemMatchInfo.Size = new System.Drawing.Size(150, 22);
            this.MenuItemMatchInfo.Text = "设置比赛信息";
            this.MenuItemMatchInfo.Click += new System.EventHandler(this.MenuItemMatchInfo_Click);
            // 
            // MenuItemMultiLine
            // 
            this.MenuItemMultiLine.Checked = true;
            this.MenuItemMultiLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItemMultiLine.Name = "MenuItemMultiLine";
            this.MenuItemMultiLine.Size = new System.Drawing.Size(150, 22);
            this.MenuItemMultiLine.Text = "多线程计算";
            this.MenuItemMultiLine.Click += new System.EventHandler(this.MenuItemMultiLine_Click);
            // 
            // MenuItemRightBtnUndo
            // 
            this.MenuItemRightBtnUndo.Checked = true;
            this.MenuItemRightBtnUndo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItemRightBtnUndo.Name = "MenuItemRightBtnUndo";
            this.MenuItemRightBtnUndo.Size = new System.Drawing.Size(150, 22);
            this.MenuItemRightBtnUndo.Text = "右键悔棋功能";
            this.MenuItemRightBtnUndo.Click += new System.EventHandler(this.MenuItemRightBtnUndo_Click);
            // 
            // MenuItemAutoMove
            // 
            this.MenuItemAutoMove.Name = "MenuItemAutoMove";
            this.MenuItemAutoMove.Size = new System.Drawing.Size(150, 22);
            this.MenuItemAutoMove.Text = "电脑自动走子";
            this.MenuItemAutoMove.Click += new System.EventHandler(this.MenuItemAutoMove_Click);
            // 
            // MenuItemSetAI
            // 
            this.MenuItemSetAI.Name = "MenuItemSetAI";
            this.MenuItemSetAI.Size = new System.Drawing.Size(150, 22);
            this.MenuItemSetAI.Text = "设置AI水平";
            this.MenuItemSetAI.Click += new System.EventHandler(this.MenuItemSetAI_Click);
            // 
            // 查看VToolStripMenuItem
            // 
            this.查看VToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemNumVis,
            this.MenuItemcoordinateVis,
            this.MenuItemBanVis,
            this.MenuItemBackGroundColor});
            this.查看VToolStripMenuItem.Name = "查看VToolStripMenuItem";
            this.查看VToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.查看VToolStripMenuItem.Text = "查看(&V)";
            // 
            // MenuItemNumVis
            // 
            this.MenuItemNumVis.Checked = true;
            this.MenuItemNumVis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItemNumVis.Name = "MenuItemNumVis";
            this.MenuItemNumVis.Size = new System.Drawing.Size(148, 22);
            this.MenuItemNumVis.Text = "显示数字";
            this.MenuItemNumVis.Click += new System.EventHandler(this.MenuItemNumVis_Click);
            // 
            // MenuItemcoordinateVis
            // 
            this.MenuItemcoordinateVis.Checked = true;
            this.MenuItemcoordinateVis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItemcoordinateVis.Name = "MenuItemcoordinateVis";
            this.MenuItemcoordinateVis.Size = new System.Drawing.Size(148, 22);
            this.MenuItemcoordinateVis.Text = "显示坐标";
            this.MenuItemcoordinateVis.Click += new System.EventHandler(this.MenuItemcoordinateVis_Click);
            // 
            // MenuItemBanVis
            // 
            this.MenuItemBanVis.Checked = true;
            this.MenuItemBanVis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItemBanVis.Name = "MenuItemBanVis";
            this.MenuItemBanVis.Size = new System.Drawing.Size(148, 22);
            this.MenuItemBanVis.Text = "显示禁手符号";
            this.MenuItemBanVis.Click += new System.EventHandler(this.MenuItemBanVis_Click);
            // 
            // MenuItemBackGroundColor
            // 
            this.MenuItemBackGroundColor.Name = "MenuItemBackGroundColor";
            this.MenuItemBackGroundColor.Size = new System.Drawing.Size(148, 22);
            this.MenuItemBackGroundColor.Text = "设置棋盘底色";
            this.MenuItemBackGroundColor.Click += new System.EventHandler(this.MenuItemBackGroundColor_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemHelp,
            this.toolStripMenuItem2,
            this.MenuItemAbout});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // MenuItemHelp
            // 
            this.MenuItemHelp.Name = "MenuItemHelp";
            this.MenuItemHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.MenuItemHelp.Size = new System.Drawing.Size(124, 22);
            this.MenuItemHelp.Text = "&Help";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(121, 6);
            // 
            // MenuItemAbout
            // 
            this.MenuItemAbout.Name = "MenuItemAbout";
            this.MenuItemAbout.Size = new System.Drawing.Size(124, 22);
            this.MenuItemAbout.Text = "&About";
            this.MenuItemAbout.Click += new System.EventHandler(this.MenuItemAbout_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(602, 253);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(320, 309);
            this.textBox1.TabIndex = 4;
            this.textBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem4,
            this.toolStripMenuItem7});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(215, 98);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.toolStripMenuItem3.Size = new System.Drawing.Size(214, 22);
            this.toolStripMenuItem3.Text = "&New Game";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.MenuItemNGm_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.toolStripMenuItem5.Size = new System.Drawing.Size(214, 22);
            this.toolStripMenuItem5.Text = "&Undo 上一步";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.MenuItemUndo_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.toolStripMenuItem6.Size = new System.Drawing.Size(214, 22);
            this.toolStripMenuItem6.Text = "&Next  下一步";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.MenuItemNext_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(211, 6);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.toolStripMenuItem7.Size = new System.Drawing.Size(214, 22);
            this.toolStripMenuItem7.Text = "&Exit";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 611);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(934, 26);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(40, 21);
            this.toolStripStatusLabel1.Text = "       ";
            // 
            // TxBTimeB
            // 
            this.TxBTimeB.BackColor = System.Drawing.SystemColors.MenuText;
            this.TxBTimeB.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxBTimeB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.TxBTimeB.Location = new System.Drawing.Point(679, 108);
            this.TxBTimeB.Name = "TxBTimeB";
            this.TxBTimeB.ReadOnly = true;
            this.TxBTimeB.Size = new System.Drawing.Size(226, 54);
            this.TxBTimeB.TabIndex = 6;
            this.TxBTimeB.TabStop = false;
            this.TxBTimeB.Text = "0: 00 :00";
            this.TxBTimeB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxbTimeW
            // 
            this.TxbTimeW.BackColor = System.Drawing.Color.Black;
            this.TxbTimeW.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxbTimeW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.TxbTimeW.Location = new System.Drawing.Point(679, 183);
            this.TxbTimeW.Name = "TxbTimeW";
            this.TxbTimeW.ReadOnly = true;
            this.TxbTimeW.Size = new System.Drawing.Size(226, 54);
            this.TxbTimeW.TabIndex = 6;
            this.TxbTimeW.TabStop = false;
            this.TxbTimeW.Text = "0: 00 :00";
            this.TxbTimeW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Black;
            this.textBox4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox4.Location = new System.Drawing.Point(630, 123);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(28, 26);
            this.textBox4.TabIndex = 7;
            this.textBox4.TabStop = false;
            // 
            // textBox5
            // 
            this.textBox5.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox5.Location = new System.Drawing.Point(630, 197);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(28, 26);
            this.textBox5.TabIndex = 7;
            this.textBox5.TabStop = false;
            // 
            // labelNext
            // 
            this.labelNext.AutoSize = true;
            this.labelNext.BackColor = System.Drawing.Color.Black;
            this.labelNext.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNext.ForeColor = System.Drawing.Color.White;
            this.labelNext.Location = new System.Drawing.Point(636, 45);
            this.labelNext.Name = "labelNext";
            this.labelNext.Size = new System.Drawing.Size(269, 38);
            this.labelNext.TabIndex = 8;
            this.labelNext.Text = "Next:   1. Black";
            this.labelNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 2000;
            this.timer2.Tick += new System.EventHandler(this.MenuItemNext_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 637);
            this.Controls.Add(this.labelNext);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.TxbTimeW);
            this.Controls.Add(this.TxBTimeB);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "五子棋";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem MenuItemLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveAs;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem MenuItemloadGame;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem 查看VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNumVis;
        private System.Windows.Forms.ToolStripMenuItem MenuItemcoordinateVis;
        private System.Windows.Forms.ToolStripMenuItem 棋局GToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUndo;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNext;
        private System.Windows.Forms.ToolStripMenuItem 设置SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSetting;
        private System.Windows.Forms.ToolStripMenuItem MenuItemBanVis;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNGm;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAI;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemMultiLine;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRightBtnUndo;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAutoMove;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemMatchInfo;
        private System.Windows.Forms.TextBox TxBTimeB;
        private System.Windows.Forms.TextBox TxbTimeW;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label labelNext;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSetAI;
        private System.Windows.Forms.ToolStripMenuItem MenuItemBackGroundColor;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripAutoRedo;
    }
}

