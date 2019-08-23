using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Five_in_A_Row
{
    class Evalute
    {
        public judgeCount[] judge=new judgeCount [2];
        public Evalute()
        {
            init();
        }
        public void init()
        {
            judge[0].init();
            judge[1].init();
        }
        static public Evalute operator -(Evalute e1,Evalute e2)
        {
            e1.judge[0] -= e2.judge[0];
            e1.judge[1] -= e2.judge[1];
            return e1;
        }
        static public Evalute operator +(Evalute e1, Evalute e2)
        {
            e1.judge[0] += e2.judge[0];
            e1.judge[1] += e2.judge[1];
            return e1;
        }
        public int getscore()
        {
            return getscore(PieceType.Black);
        }
        public int getscore(PieceType color)//>0为黑优 <0白优
        {
            int score = 0;
            Random rand = new Random();
            //score -= bannedCount * 10;
            score += judge[0].L1 * 15;
            score += judge[0].L2 * 110;
            score += judge[0].L3 * 500;
            score += judge[0].L4 * 5000;
            score += judge[0].H2 * 30;
            score += judge[0].H3 * 100;
            score += judge[0].H4 * 510;
            score -= judge[1].L1 * 15;
            score -= judge[1].L2 * 110;
            score -= judge[1].L3 * 500;
            score -= judge[1].L4 * 5000;
            score -= judge[1].H2 * 30;
            score -= judge[1].H3 * 100;
            score -= judge[1].H4 * 480;
            score = rand.Next(10) + score;
            if (color == PieceType.White)
                score = -score;
            return score;
        }
    }
    struct judgeCount//L-live,H-halfLive
    {
        public int L1;
        public int L2;
        public int H2;
        public int L3;
        public int H3;
        public int L4;
        public int H4;
        public int W5;
        public void init()
        {
            L1 = 0;
            L2 = 0;
            H2 = 0;
            L3 = 0;
            H3 = 0;
            L4 = 0;
            H4 = 0;
            W5 = 0;
        }
        static public judgeCount operator -(judgeCount j1, judgeCount j2)
        {
            j1.L1 -= j2.L1;
            j1.L2 -= j2.L2;
            j1.H2 -= j2.H2;
            j1.L3 -= j2.L3;
            j1.L4 -= j2.L4;
            j1.H3 -= j2.H3;
            j1.H4 -= j2.H4;
            j1.W5 -= j2.W5;
            return j1;
        }
        static public judgeCount operator +(judgeCount j1, judgeCount j2)
        {
            j1.L1 += j2.L1;
            j1.L2 += j2.L2;
            j1.H2 += j2.H2;
            j1.L3 += j2.L3;
            j1.L4 += j2.L4;
            j1.H3 += j2.H3;
            j1.H4 += j2.H4;
            j1.W5 += j2.W5;
            return j1;
        }
    }
    struct chessShape//保持0,2,4位为有子，1,3,5均为empty数量
    {
        public PieceType type;
        public int count;
        public chessShape(PieceType t, int Count)
        {
            count = Count;
            type = t;
        }
    }
}
