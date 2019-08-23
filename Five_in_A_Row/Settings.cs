using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Five_in_A_Row
{
    public partial class DlgSettings : Form
    {
        public DlgSettings()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (checkBoxSel.Checked)
            {
                if (radioBtnSelN.Checked && !(checkBoxSwap.Checked && radioBtnSwap3.Checked))
                {
                    BoardOfFIR.ShowInfo("五手N打：\n必须选中三手交换规则");
                    return;
                }
                if (radioBtnSelx.Checked)
                {
                    short x;
                    try
                    {
                        x = Convert.ToInt16(TBoxSelC.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("请输入一个整数", "五子棋");
                        TBoxSelC.Focus();
                        TBoxSelC.SelectAll();
                        return;
                    }
                    if (x > 10 || x < 2)
                    {
                        MessageBox.Show("请输入一个2-10的数", "五子棋");
                        TBoxSelC.Focus();
                        TBoxSelC.SelectAll();
                        return;
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DlgSettings_Load(object sender, EventArgs e)
        {
            checkBoxBanned.Checked = BoardOfFIR.bannedMove;
            checkBoxSel.Checked = BoardOfFIR.selectMove;
            checkBoxSwap.Checked = BoardOfFIR.swap1 || BoardOfFIR.swap3 || BoardOfFIR.swap3SelN;
            if (checkBoxSwap.Checked)
            {
                if (!(radioBtnSwap1.Checked = BoardOfFIR.swap1))
                    radioBtnSwap3.Checked = true;
            }
            else
            {
                radioBtnSwap1.Enabled = false;
                radioBtnSwap3.Enabled = false;
                radioBtnSwap3.Checked = true;
            }
            if (checkBoxSel.Checked)
            {
                if (BoardOfFIR.swap3SelN)
                    radioBtnSelN.Checked = true;
                else
                    if (BoardOfFIR.selectQuantity == 2)
                    {
                        radioBtnSel2.Checked = true;
                    }
                    else
                    {
                        radioBtnSelx.Checked = true;
                        TBoxSelC.Enabled = true;
                        TBoxSelC.Text = Convert.ToString(BoardOfFIR.selectQuantity);
                    }
            }
            else
            {
                radioBtnSelx.Enabled = false;
                radioBtnSelN.Enabled = false;
                radioBtnSel2.Enabled = false;
                radioBtnSel2.Checked = true;
            }
        }

        private void checkBoxSwap_CheckedChanged(object sender, EventArgs e)
        {
            radioBtnSwap1.Enabled = checkBoxSwap.Checked;
            radioBtnSwap3.Enabled = checkBoxSwap.Checked;
        }

        private void checkBoxSel_CheckedChanged(object sender, EventArgs e)
        {
            radioBtnSelx.Enabled = checkBoxSel.Checked;
            radioBtnSelN.Enabled = checkBoxSel.Checked;
            radioBtnSel2.Enabled = checkBoxSel.Checked;
        }

        private void radioBtnSelx_CheckedChanged(object sender, EventArgs e)
        {
            TBoxSelC.Enabled = radioBtnSelx.Checked;
        }

        private void radioBtnSelN_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnSelN.Checked)
            {
                checkBoxSwap.Checked = true;
                radioBtnSwap3.Checked = true;
            }
        }
    }
}
