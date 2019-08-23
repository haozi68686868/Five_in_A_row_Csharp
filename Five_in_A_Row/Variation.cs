using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Five_in_A_Row
{
    class Variation
    {
        public List<Move> movelist = new List<Move>();
        public Record record;
        public Move startstep;//变招处的步数
        public void overwrite(Point p)
        {
            int index = record.presentMove.turnCount - startstep.turnCount+1;
            movelist.RemoveRange(index, movelist.Count  -index );
            addToVariation(p);
        }
        public void mainVariation(Point p)
        {
            Variation v = new Variation();
            v.record = this.record;
            int index=movelist.IndexOf(record.presentMove)+1;
            for (int i = index; i < movelist.Count; i++)
            {
                v.movelist.Add(movelist[i]);
                movelist[i].origin = v;
            }
            v.movelist[0].hasvia = false;
            movelist.RemoveRange(index, movelist .Count-index );
            addToVariation(p);
            record.presentMove.addVariation(v);
            if (v.movelist[0].hasvia)
            {
                foreach (Variation v0 in v.movelist[0].varList)
                {
                    record.presentMove.addVariation(v0);
                }
                v.movelist[0].hasvia=false;
                v.movelist[0].varList.Clear();
            }
        }
        public void newVariation(Point p)
        {
            int index = movelist.IndexOf(record.presentMove);
            movelist[index + 1].createNewVia (p);
        }
        public void addToVariation(Point p)
        {
            Move m = new Move(p,this);
            movelist.Add(m);
            this.record.presentMove = m;
        }
        public string varToString()
        {
            string s="";
            if (startstep.turnCount % 2 == 1)
                s = Convert.ToString((startstep.turnCount + 1) / 2) + "...";
            foreach (Move m in movelist)
            {
                s += (m.movetostring()+" ");
                if (m.hasvia)
                {
                    if(this==record .mainvariation )
                    s += "\r\n[ ";
                    else
                        s += "\r\n( ";
                    foreach (var v in m.varList)
                    {
                        s += v.varToString();
                        s += ";";
                    }
                    if (this == record.mainvariation)
                        s += "]\r\n";
                    else
                        s += ")\r\n";
                }
            }
            return s;
        }
    }
}
