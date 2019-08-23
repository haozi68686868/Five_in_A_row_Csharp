using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Five_in_A_Row
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
                           ControlStyles.AllPaintingInWmPaint,
                           true);
            this.UpdateStyles();
            BdColor = defaultBdColor;
        }
        const int intervalOfBd = 35;
        const int widOfBorder = 20;
        const int Pxy = 60;//第一个点的坐标
        const int stSize = 15;
        const int rCrsSize = 7;
        const int dotsSize = 4;
        const int FontSize = 10;
        string path="";
        static Color defaultBdColor = Color.FromArgb(249, 214, 91);
        Color BdColor = new Color();
        RoomOfFIR room = new RoomOfFIR();
        static Point BdToCoordt(int indexX, int indexY)//棋盘坐标到图层
        {
            Point p = new Point();
            p.X = Pxy + indexX * intervalOfBd;
            p.Y = Pxy + indexY * intervalOfBd;
            return p;
        }
        static Point BdToCoordt(Point p)//棋盘坐标到图层
        {
            p.X = Pxy + p.X * intervalOfBd;
            p.Y = Pxy + p.Y * intervalOfBd;
            return p;
        }
        static Point coordinateToBd(Point p)//图层坐标变换到棋盘坐标
        {
            return p;
        }
        static Point coordinateToBd(int indexX, int indexY)//图层坐标变换到棋盘坐标
        {
            Point p = new Point();
            p.X = (indexX - Pxy) / intervalOfBd;
            if ((indexX - Pxy) % intervalOfBd > (intervalOfBd / 2)) p.X++;
            p.Y = (indexY - Pxy) / intervalOfBd;
            if ((indexY - Pxy) % intervalOfBd > (intervalOfBd / 2)) p.Y++;
            return p;
        }
        
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point tP = new Point();
                tP = coordinateToBd(e.X, e.Y);
                if (room.running) return;
                if (BoardOfFIR.checkP(tP))
                {
                    room.select(tP);
                    Invalidate();
                    textBox1.Text = room.record.mainvariation.varToString();
                    if (MenuItemAutoMove.Checked)
                    {
                        room.AI();
                    }
                    ToolStripAutoRedo.Checked = false;
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                if (MenuItemRightBtnUndo.Checked)
                {
                    room.Undo();
                    Invalidate();
                }
                else
                {
                    contextMenuStrip1.Show(e.Location);
                }
            }
        }
        void drawString(Graphics g, string s, Brush b, Point p)
        {
            StringFormat format = new StringFormat
   (StringFormatFlags.NoClip);
            format.Alignment =
               StringAlignment.Center;
            format.LineAlignment =
               StringAlignment.Center;
            g.DrawString(s, new Font("verdana", FontSize), b, new RectangleF(p.X - intervalOfBd / 2, p.Y - intervalOfBd / 2, intervalOfBd, intervalOfBd), format);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int i, j;
            Point tP;
            Brush YellowBrush = new SolidBrush(BdColor);
            Pen bPen = new Pen(Color.Black);
            Pen bWPen = new Pen(Color.Black, 3);
            Pen rPen = new Pen(Color.Red, 2);
            e.Graphics.FillRectangle(YellowBrush, Pxy - widOfBorder, Pxy - widOfBorder, intervalOfBd * 14 + 2 * widOfBorder, intervalOfBd * 14 + 2 * widOfBorder);
            e.Graphics.DrawRectangle(bWPen, Pxy, Pxy, 14 * intervalOfBd, 14 * intervalOfBd);
            for (i = 1; i < 14; i++)
            {
                e.Graphics.DrawLine(bPen, Pxy + i * intervalOfBd, Pxy, Pxy + i * intervalOfBd, intervalOfBd * 14 + Pxy);
                e.Graphics.DrawLine(bPen, Pxy, Pxy + i * intervalOfBd, intervalOfBd * 14 + Pxy, Pxy + i * intervalOfBd);
            }
            SolidBrush BBrush = new SolidBrush(Color.Black);
            SolidBrush WBrush = new SolidBrush(Color.White);
            SolidBrush GBrush = new SolidBrush(Color.FromArgb(128, 128, 128));
            e.Graphics.FillEllipse(BBrush, 3 * intervalOfBd + Pxy - dotsSize, 3 * intervalOfBd + Pxy - dotsSize, dotsSize * 2, dotsSize * 2);
            e.Graphics.FillEllipse(BBrush, 7 * intervalOfBd + Pxy - dotsSize, 7 * intervalOfBd + Pxy - dotsSize, dotsSize * 2, dotsSize * 2);
            e.Graphics.FillEllipse(BBrush, 3 * intervalOfBd + Pxy - dotsSize, 11 * intervalOfBd + Pxy - dotsSize, dotsSize * 2, dotsSize * 2);
            e.Graphics.FillEllipse(BBrush, 11 * intervalOfBd + Pxy - dotsSize, 3 * intervalOfBd + Pxy - dotsSize, dotsSize * 2, dotsSize * 2);
            e.Graphics.FillEllipse(BBrush, 11 * intervalOfBd + Pxy - dotsSize, 11 * intervalOfBd + Pxy - dotsSize, dotsSize * 2, dotsSize * 2);
            for (i = 0; i < 15; i++)
                for (j = 0; j < 15; j++)
                {
                    tP = BdToCoordt(i, j);
                    switch (room.getPieceType(i, j))
                    {
                        case PieceType.Black:
                            e.Graphics.FillEllipse(
                            BBrush, tP.X - stSize, tP.Y - stSize, stSize * 2, stSize * 2);
                            if (MenuItemNumVis.Checked)
                                drawString(e.Graphics, Convert.ToString(room.stepRecord[i, j]), WBrush, tP);
                            break;
                        case PieceType.White:
                            e.Graphics.FillEllipse(
                            WBrush, tP.X - stSize, tP.Y - stSize, stSize * 2, stSize * 2);
                            e.Graphics.DrawEllipse(bPen, tP.X - stSize, tP.Y - stSize, stSize * 2, stSize * 2);
                            if (MenuItemNumVis.Checked)
                                drawString(e.Graphics, Convert.ToString(room.stepRecord[i, j]), BBrush, tP);
                            break;
                        case PieceType.Selected:
                            e.Graphics.FillEllipse(
                            GBrush, tP.X - stSize, tP.Y - stSize, stSize * 2, stSize * 2);
                            if (MenuItemNumVis.Checked)
                                drawString(e.Graphics, "5", WBrush, tP);
                            break;
                        case PieceType.Banned:
                            if (MenuItemBanVis.Checked)
                            {
                                e.Graphics.DrawLine(rPen, tP.X - rCrsSize, tP.Y - rCrsSize, tP.X + rCrsSize, tP.Y + rCrsSize);
                                e.Graphics.DrawLine(rPen, tP.X - rCrsSize, tP.Y + rCrsSize, tP.X + rCrsSize, tP.Y - rCrsSize);
                            }
                            break;
                        case PieceType.Empty:
                            break;
                    }
                }
            if (MenuItemcoordinateVis.Checked)
                for (i = 0; i < 15; i++)
                {
                    tP = BdToCoordt(-1, i);
                    drawString(e.Graphics, Convert.ToString(i + 1), BBrush, tP);
                    tP = BdToCoordt(i, 15);
                    drawString(e.Graphics, Convert.ToString((char)('A' + i)), BBrush, tP);
                }
            textBox1.Text = room.record.ToText();
            if (room.running) toolStripStatusLabel1.Text = "电脑计算中.....";
            else
            {
                switch (room.getStatus())
                {
                    case Status .Play :
                        toolStripStatusLabel1.Text = "棋局进行中";
                        break;
                    case Status .Finished :
                        toolStripStatusLabel1.Text = "棋局结束";
                        break;
                    case Status .Selecting :
                        toolStripStatusLabel1.Text = "第5手黑棋摆放打点";
                        break;
                    case Status .DeleteSel :
                        toolStripStatusLabel1.Text = "第5手白棋选择打点";
                        break;
                }
            }
            if (room.record.presentMove == null)
            {
                i = 0;
            }
            else
            {
                i = room.record.presentMove.turnCount+1;
            }
            if (i % 2 == 0)
            {
                labelNext.Text = string.Format("Next: {0}.   Black", i + 1);
                labelNext.BackColor = Color.Black;
                labelNext.ForeColor = Color.White;
            }
            else
            {
                labelNext.Text = string.Format("Next: {0}.  White", i + 1);
                labelNext.BackColor = Color.White;
                labelNext.ForeColor = Color.Black;
            }
            if (room.pause) timer1.Enabled = false;
            else
                timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            room.form1 = this;
        }
        private void MenuItemNGm_Click(object sender, EventArgs e)
        {
            room.Init();
            Invalidate();
        }

        private void MenuItemUndo_Click(object sender, EventArgs e)
        {
            room.Undo();
            Invalidate();
        }

        private void MenuItemNext_Click(object sender, EventArgs e)
        {
            room.Forward();
            Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuItemBackGroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDia = new ColorDialog();
            colorDia.CustomColors = new int[] { 6018809 };
            if (colorDia.ShowDialog() == DialogResult.OK)
            {
                BdColor = colorDia.Color;
                Invalidate();
            }
        }

        private void MenuItemNumVis_Click(object sender, EventArgs e)
        {
            MenuItemNumVis.Checked = !MenuItemNumVis.Checked;
            Invalidate();
        }

        private void MenuItemcoordinateVis_Click(object sender, EventArgs e)
        {
            MenuItemcoordinateVis.Checked = !MenuItemcoordinateVis.Checked;
            Invalidate();
        }

        private void MenuItemSetting_Click(object sender, EventArgs e)
        {
            DlgSettings dlgsetting = new DlgSettings();
            if (dlgsetting.ShowDialog()==DialogResult .OK )
            {
                BoardOfFIR.bannedMove = dlgsetting.checkBoxBanned.Checked;
                BoardOfFIR.selectMove = dlgsetting.checkBoxSel.Checked ;
                if (BoardOfFIR.selectMove)
                {
                    if (dlgsetting.radioBtnSel2.Checked) BoardOfFIR.selectQuantity = 2;
                    if (dlgsetting.radioBtnSelx.Checked) BoardOfFIR.selectQuantity = Convert.ToInt16(dlgsetting.TBoxSelC.Text);
                    if (dlgsetting.radioBtnSelN.Checked) BoardOfFIR.swap3SelN = true;
                }
                if (dlgsetting.checkBoxSwap.Checked)
                {
                    BoardOfFIR.swap1 = dlgsetting.radioBtnSwap1.Checked;
                    BoardOfFIR.swap3 = (dlgsetting.radioBtnSwap3.Checked && !BoardOfFIR.swap3SelN);
                }
                else
                {
                    BoardOfFIR.swap1 = false;
                    BoardOfFIR.swap3 = false;
                    BoardOfFIR.swap3SelN = false;
                }
                room.SetRule();
                if (System.Windows.Forms.MessageBox.Show("新的规则已经生效，是否要重新开始游戏？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    room.Init();
                    Invalidate();
                }
            }
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Point tP = new Point();
            tP = coordinateToBd(e.X, e.Y);
            if (room.getStatus() == Status.DeleteSel && BoardOfFIR.checkP(tP))
            {
                this.Cursor = Cursors.No ;
            }
            else
                this.Cursor = Cursors.Default;
        }

        private void MenuItemBanVis_Click(object sender, EventArgs e)
        {
            MenuItemBanVis.Checked = !MenuItemBanVis.Checked;
            Invalidate();
        }

        private void MenuItemSave_Click(object sender, EventArgs e)
        {
            if (path == "")
            {
                SaveFileDialog sDlg = new SaveFileDialog();
                sDlg.Filter = "觉皇五子棋记录文件(*.fir)|*.fir";
                if (sDlg.ShowDialog() == DialogResult.OK)
                {
                    room.SaveRecord(sDlg.FileName);
                }
            }
            else
            {
                room.SaveRecord(path);
            }
        }

        private void MenuItemloadGame_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "觉皇五子棋记录文件(*.fir)|*.fir";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                room.LoadRecord(openDlg.FileName);
                textBox1.Text = room.record.mainvariation.varToString();
                path = openDlg.FileName;
            }
        }

        private void MenuItemSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sDlg = new SaveFileDialog();
            sDlg.Filter = "觉皇五子棋记录文件(*.fir)|*.fir";
            if (sDlg.ShowDialog() == DialogResult.OK)
            {
                room.SaveRecord(sDlg.FileName);
            }
        }

        private void MenuItemAI_Click(object sender, EventArgs e)
        {
            if (room.running) return;
            room.AI();
        }

        private void MenuItemMultiLine_Click(object sender, EventArgs e)
        {
            MenuItemMultiLine.Checked = !MenuItemMultiLine.Checked;
            room.multiLine = MenuItemMultiLine.Checked;
        }

        private void MenuItemRightBtnUndo_Click(object sender, EventArgs e)
        {
            MenuItemRightBtnUndo.Checked = !MenuItemRightBtnUndo.Checked;
            if (MenuItemRightBtnUndo.Checked)
            {
                ContextMenuStrip = contextMenuStrip1;
            }
            else
            {
                ContextMenuStrip = null;
            }
        }

        private void MenuItemAutoMove_Click(object sender, EventArgs e)
        {
            MenuItemAutoMove.Checked = !MenuItemAutoMove.Checked;
        }

        private void MenuItemMatchInfo_Click(object sender, EventArgs e)
        {
            RecordInfo dlg = new RecordInfo();
            dlg.textBox1.Text = room.record.BName;
            dlg.textBox2.Text = room.record.WName;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                room.record.BName= dlg.textBox1.Text;
                room.record.WName = dlg.textBox2.Text;
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (room.record.presentMove == null || room.record.presentMove.turnCount % 2 == 1)
            {
                room.BTime++;
            }
            else
                room.WTime++;
            string s1, s2; int i, j;
            i = room.BTime % 60; s1 = Convert.ToString(i); if (i < 10) s1 = "0" + s1;
            j = ((room.BTime - i) / 60) % 60; s2 = Convert.ToString(j); if (j < 10) s2 = "0" + s2;
            TxBTimeB.Text = Convert.ToString(room.BTime / 3600) + ": " + s2 + " :" + s1;
            i = room.WTime % 60; s1 = Convert.ToString(i); if (i < 10) s1 = "0" + s1;
            j = ((room.WTime - i) / 60) % 60; s2 = Convert.ToString(j); if (j < 10) s2 = "0" + s2;
            TxbTimeW.Text = Convert.ToString(room.WTime / 3600) + ": " + s2 + " :" + s1;
        }

        private void MenuItemAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("作者： 刘鑫浩 2110406130  于2014.5.6 西安","五子棋");
        }

        private void MenuItemSetAI_Click(object sender, EventArgs e)
        {
            InputBox dlg = new InputBox();
            dlg.text.Text = "设置AI水平 （1-10），建议为2-3";
            while(dlg.ShowDialog() == DialogResult.OK)
            {
                short x;
                try
                {
                    x = Convert.ToInt16(dlg.Input.Text);
                }
                catch
                {
                    MessageBox.Show("请输入一个整数", "五子棋");
                    continue;
                }
                if (x > 10 || x < 1)
                {
                    MessageBox.Show("请输入一个1-10的数", "五子棋");
                    continue;
                }
                else
                {
                    BoardOfFIR .AIdepth = x;
                    break;
                }
            }
        }

        private void ToolStripAutoRedo_Click(object sender, EventArgs e)
        {
            ToolStripAutoRedo.Checked = !ToolStripAutoRedo.Checked;
            timer2.Enabled = ToolStripAutoRedo.Checked;
        }
    }
}
