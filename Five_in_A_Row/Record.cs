using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Five_in_A_Row
{
    class Record //一局棋为单位
    {
        public Record()
        {
            mainvariation.record = this;
            mainvariation.startstep = new Move();
            mainvariation.startstep.turnCount = 0;
            swap = false;
            BName = "诸葛暗";
            WName = "诸葛亮";
            result = Result.None;
            swap1 = false;
            swap3 = false;
            swap3SelN = false;
            selectMove = false;
            selectQuantity = 2;
            bannedMove = true;
        }
        public void init()
        {
            presentMove = null;
            mainvariation.movelist.Clear();
            result = Result.None;
        }
        public string BName, WName;
        public Result result;
        bool swap;
        public bool swap1;
        public bool swap3;
        public bool swap3SelN ;
        public bool selectMove;
        public int selectQuantity;
        public bool bannedMove ;
        public Variation mainvariation = new Variation();
        public Move presentMove;//标志着棋局进行的情况
        public void overwrite(Point p)//覆盖
        {
            presentMove.origin.overwrite(p);
        }
        public void mainVariation(Point p)//新的主变
        {
            presentMove.origin.mainVariation(p);
        }
        public void newVariation(Point p)//新的变化
        {
            presentMove.origin.newVariation(p);
        }
        public void addToVariation(Point p)//增加一步棋
        {
            if (presentMove != null)
            {
                presentMove.origin.addToVariation(p);
            }
            else
                mainvariation.addToVariation(p);
        }
        public bool Undo()
        {
            if (presentMove == null)
                return false;
            if (presentMove.turnCount == 0)
            {
                presentMove = null;
                return true;
            }
            if (presentMove.turnCount == presentMove.origin.startstep.turnCount)
            {
                Variation v = presentMove.origin.startstep.origin;
                int x = v.movelist.IndexOf(presentMove.origin.startstep);
                presentMove = v.movelist[x - 1];
            }
            else
            {
                presentMove = presentMove.origin.movelist[presentMove.origin.movelist.IndexOf(presentMove) - 1];
            }
            return true;
        }//返回是否执行成功
        public bool Next()//返回是否成功
        {
            int index;
            Move m;
            if (mainvariation.movelist.Count == 0) return false;
            if (presentMove == null && mainvariation.movelist.Count != 0)
            {
                m = mainvariation.movelist[0];
            }
            else
            {
                index = presentMove.origin.movelist.IndexOf(presentMove);
                if (presentMove.origin.movelist.IndexOf(presentMove) == presentMove.origin.movelist.Count - 1) return false;
                m = presentMove.origin.movelist[index + 1];
            }
            if (m.hasvia)
            {
                chooseVarDlg dlg = new chooseVarDlg();
                string s = m.movetostring();
                if (m.turnCount % 2 == 1) s = Convert.ToString((m.turnCount + 1) / 2) + "..." + s;
                dlg.listBox1.Items.Add(s);
                foreach (Variation v in m.varList)
                {
                    dlg.listBox1.Items.Add(v.varToString());
                }
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.listBox1.SelectedIndex == 0)
                    {
                        presentMove = m;
                    }
                    else
                    {
                        Variation v0 = m.varList[dlg.listBox1.SelectedIndex - 1];
                        presentMove = v0.movelist[0];
                    }
                }
                else
                    return false;

            }
            else
                presentMove = m;
            return true;
        }
        public bool addMove(Point p)
        {
            //先寻找本来有没有这步棋
            if (presentMove == null)
            {
                mainvariation.movelist.Clear();
                addToVariation(p);
                return true;
            }
            int index = presentMove.origin.movelist.IndexOf(presentMove);
            if (index == presentMove.origin.movelist.Count - 1)
                addToVariation(p);
            else
            {
                Move next = presentMove.origin.movelist[index + 1];
                if (next.getP() == p)
                {
                    presentMove = presentMove.origin.movelist[index + 1];
                    return true;
                }
                else if (next.hasvia)
                {
                    foreach (Variation v in next.varList)
                    {
                        if (v.movelist[0].getP() == p)
                        {
                            presentMove = v.movelist[0];
                            return true;
                        }
                    }
                }
                VarDecision decision = VarDecision.None;
                VarDecide dlg = new VarDecide();
                string s = next.movetostring();
                if (next.turnCount % 2 == 1) s = Convert.ToString((next.turnCount + 1) / 2) + "..." + s;
                dlg.listBox1.Items.Add(s);
                if (next.hasvia)
                {
                    foreach (Variation v in next.varList)
                    {
                        dlg.listBox1.Items.Add(v.varToString());
                    }
                }
                dlg.ShowDialog();
                decision = dlg.nDecision;
                switch (decision)
                {
                    case VarDecision.OverWrite:
                        overwrite(p);
                        break;
                    case VarDecision.New_Variatiaon:
                        newVariation(p);
                        break;
                    case VarDecision.New_Main_Line:
                        mainVariation(p);
                        break;
                    case VarDecision.None:
                        return false;
                }
            }
            return true;
        }//返回是否成功
        public void ToBoard(BoardOfFIR board, Move move)
        {
            board.clearBoard();
            Variation v = this.TopresentVar(move);
            foreach (Move m in v.movelist)
            {
                board.setPieceType(m.getP(), (PieceType)(m.turnCount % 2));
                board.stepRecord[m.getP().X, m.getP().Y] = m.turnCount + 1;
            }
            board.setTurn(move.turnCount + 1);
        }
        public Variation TopresentVar(Move m)
        {
            Variation v = new Variation();
            while (true)
            {
                v.movelist.Insert(0, m);
                if (m.turnCount == 0) break;
                if (m.turnCount == m.origin.startstep.turnCount)
                {
                    m = m.origin.startstep;
                }
                m = m.origin.movelist[m.origin.movelist.IndexOf(m) - 1];
            }
            return v;
        }
        public Variation TopresentVar()
        {
            return TopresentVar(presentMove);
        }
        public bool load(string fileName)
        {
            init();
            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    int temp, temp1, temp2;
                    Move tempM;
                    BName = reader.ReadString();
                    WName = reader.ReadString();
                    swap = reader.ReadBoolean();
                    result = (Result)reader.ReadInt32();
                    swap1 = reader.ReadBoolean() ;
                    swap3 = reader.ReadBoolean();
                    swap3SelN = reader.ReadBoolean();
                    selectMove = reader.ReadBoolean();
                    selectQuantity = reader.ReadInt32();
                    bannedMove = reader.ReadBoolean();
                    Stack<Move> moveStack = new Stack<Move>();
                    while (true)
                    {
                        temp = reader.ReadInt32();//读到-1为结束，读到-2表示此处有节点
                        if (temp < 0)
                        {
                            if (temp == -1)
                            {
                                if (moveStack.Count == 0) break;
                                presentMove = moveStack.Pop();
                            }
                            if (temp == -2)
                            {
                                temp1 = reader.ReadInt32();
                                temp2 = reader.ReadInt32();
                                tempM = presentMove;
                                presentMove.createNewVia(new Point(temp1, temp2));
                                moveStack.Push(presentMove);
                                presentMove = tempM;
                            }
                        }
                        else
                        {
                            temp1 = reader.ReadInt32();
                            addToVariation(new Point(temp, temp1));
                        }
                    }
                    reader.Close();
                    presentMove = mainvariation.movelist[mainvariation.movelist.Count - 1];
                }
                return true;
            }
            return false;
        }
        public void save(string fileName)
        {
            int index;
            bool temp;
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                writer.Write(BName);
                writer.Write(WName);
                writer.Write(swap);
                writer.Write((int)result);
                writer.Write(swap1);
                writer.Write(swap3);
                writer.Write(swap3SelN);
                writer.Write(selectMove);
                writer.Write(selectQuantity);
                writer.Write(bannedMove);
                Stack<Move> moveStack = new Stack<Move>();
                Move m;
                if (mainvariation.movelist.Count == 0)
                {
                    writer.Write(-1);
                }
                else
                {
                    m = mainvariation.movelist[0];
                    temp = true;
                    while (true)
                    {
                        if (temp)
                        {
                            writer.Write(m.getP().X);
                            writer.Write(m.getP().Y);
                        }
                        if (m.hasvia)
                        {
                            foreach (Variation v in m.varList)
                            {
                                moveStack.Push(v.movelist[0]);
                                writer.Write(-2);
                                writer.Write(v.movelist[0].getP().X);
                                writer.Write(v.movelist[0].getP().Y);
                            }
                        }
                        index = m.origin.movelist.IndexOf(m);
                        if ((index + 1) == m.origin.movelist.Count)
                        {
                            writer.Write(-1);
                            if (moveStack.Count == 0) break;
                            m = moveStack.Pop();
                            temp = false;
                        }
                        else
                        {
                            m = m.origin.movelist[index + 1]; temp = true;
                        }
                    }
                }
                writer.Close();
            }

        }
        public string ToText()
        {
            string s;
            s = "规则： ";
            if (bannedMove)
                s += "有禁手 ";
            else 
                s += "无禁手 ";
            if(swap3SelN )s+=" 三手交换 五手N打";
            else
            {
                if (selectMove) s += string.Format("五手{0}打 ", selectQuantity);
                if (swap1) s += "一手交换";
                if (swap3) s += "三手交换";
            }
            s += "\r\n\r\n";
            s += string.Format("       {0} vs {1} ", BName, WName);
            if (result != Result.None)
            {
                if (result == Result.BlackW) s += " Black Win";
                else if (result == Result.Draw) s += " Draw";
                else
                    s += " White Win";
            }
            s += "\r\n";
            s += "____________________________\r\n";
            s += mainvariation.varToString();
            return s;

        }
    }
}