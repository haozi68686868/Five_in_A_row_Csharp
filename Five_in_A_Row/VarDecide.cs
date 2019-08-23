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
    public partial class VarDecide : Form
    {
        public VarDecide()
        {
            InitializeComponent();
            nDecision = VarDecision.None;
        }
        public VarDecision nDecision;
        private void VarDecide_Load(object sender, EventArgs e)
        {

        }

        private void btnNewV_Click(object sender, EventArgs e)
        {
            nDecision = VarDecision.New_Variatiaon;
            this.Close();
        }

        private void btnNewM_Click(object sender, EventArgs e)
        {
            nDecision = VarDecision.New_Main_Line ;
            this.Close();
        }

        private void btnOvR_Click(object sender, EventArgs e)
        {
            nDecision = VarDecision.OverWrite;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            nDecision = VarDecision.None;
            this.Close();
        }
    }
}
