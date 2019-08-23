using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Five_in_A_Row
{
    class Move
    {
        public Move()
        {
        }
        public Move(Point tP,Variation v)
        {
            this.p = tP;
            origin = v;
            hasvia = false;
            turnCount = v.movelist.Count+v.startstep.turnCount ;
        }
        public void createNewVia(Point tP)
        {
            Variation v = new Variation();
            v.record =  origin .record ;
            addVariation(v) ;
            v.addToVariation(tP);
        }
        public void addVariation(Variation v)
        {
            if (!hasvia)
            {
                hasvia = true;
                varList = new List<Variation>();
            }
            v.startstep = this;
            varList.Add(v);
        }
        public string movetostring()
        {
            string s;
            s=Convert.ToString((char)('A' + p.X ))+Convert.ToString(p.Y + 1);
            if (this.turnCount % 2 == 0) s = Convert.ToString(turnCount / 2 + 1) + "." + s;
            return s;
        }
        public Point getP() { return p; }
        //string annotation="";
        Point p;
        public int turnCount;
        public Variation origin;
        public bool hasvia;
        public List<Variation> varList;
        //int level;
        //Label lbl;
    }
}
