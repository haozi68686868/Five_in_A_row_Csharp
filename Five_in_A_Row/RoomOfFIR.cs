using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Five_in_A_Row
{
    class RoomOfFIR:BoardOfFIR 
    {
        public RoomOfFIR()
        {
            Init();
        }
        public void AI()
        {
            if(status ==Status .Finished )return;
            if (multiLine)
            {
                thd = new Thread(new ThreadStart(usingthd));
                thd.IsBackground = true;
                running = true;
                thd.Start();
                running = false;
            }
            else
                usingthd();
        }
        public void usingthd()
        {
            running = true;
            form1.Invalidate();
            Point p = FindMove();
            select(p);
            running = false;
            form1.Invalidate();
        }
        public void Init()
        {
            base.init();
            record.init();
            BTime = 0;
            WTime = 0;
            pause = true;
        }
        public Record record = new Record();
        public bool running;//标志AI是否运作
        public bool multiLine=true;//是否多线程
        public int BTime;
        public int WTime;
        public bool pause;
        public Thread thd ;
        public void select(Point p)
        {
            Point tP = new Point();
            int i;
            switch (status)
            {
                case Status.Finished:
                    break;
                case Status.Play:
                    if (isLegal(p))
                    {
                        pause = false;
                        if(record .addMove (p))
                        move(p);
                        dealWithEvent();
                        
                    }
                    break;
                case Status.Selecting:
                    if (isSelectedLegal(p))
                    {
                        selectedPoint[selectedPointCount] = p;
                        board[p.X, p.Y] = PieceType.Selected;
                        selectedPointCount++;
                        if (selectedPointCount == selectQuantity) status = Status.DeleteSel;
                    }
                    else if (getPieceType(p) == PieceType.Empty) MessageBox.Show("不允许选择对称的打点");
                    break;
                case Status.DeleteSel:
                    {
                        if (board[p.X, p.Y] == PieceType.Selected)
                        {
                            board[p.X, p.Y] = PieceType.Empty;
                            selectedPointCount--;
                            if (selectedPointCount == 1)
                            {
                                for (i = 0; i < selectQuantity; i++)
                                {
                                    if (board[selectedPoint[i].X, selectedPoint[i].Y] == PieceType.Selected)
                                        tP = selectedPoint[i];
                                }
                                selectedPointCount = 0;
                                status = Status.Play;
                                select(tP);
                            }
                        }
                    }
                    break;
            }

        }
        public void Forward()
        {
            if (!record.Next()) return;
            Point tP;
            tP = record.presentMove.getP();
            move(tP);
            pause = true;
        }
        public void Undo()
        {
            if (turnCount == 0) return;
            Point tP;
            if (turn == PieceType.Black)
            {
                turn = PieceType.White;
            }
            else
                turn = PieceType.Black;
            turnCount--;
            tP = record.presentMove.getP();
            record.Undo();
            board[tP.X, tP.Y] = PieceType.Empty;
            status = Status.Play;
            moveFinished();
            pause = true;
        }
        void checkSymmetry()//仅在第5回合
        {
            int x1, x2, y1, y2;
            Variation v = record.TopresentVar();
            x1 = v.movelist[0].getP().X; x2 = v.movelist[2].getP().X; y1 = v.movelist[0].getP().Y; y2 = v.movelist[2].getP().Y;
            symmetryLine[0] = (y1 == y2 && x1 + x2 == 14) || (x1 == 7 && x2 == 7);
            symmetryLine[1] = (x1 == x2 && y1 + y2 == 14) || (y1 == 7 && y2 == 7);
            symmetryLine[2] = (x1 == y2 && y1 == x2) || (x1 == y1 && x2 == y2);
            symmetryLine[3] = (x2 + y2 == 14 && x1 + y1 == 14) || (x1 + y2 == 14 && x2 + y1 == 14);
            x1 = v.movelist[1].getP().X; x2 = v.movelist[3].getP().X; y1 = v.movelist[1].getP().Y; y2 = v.movelist[3].getP().Y;
            symmetryLine[0] = symmetryLine[0] && ((y1 == y2 && x1 + x2 == 14) || (x1 == 7 && x2 == 7));
            symmetryLine[1] = symmetryLine[1] && ((x1 == x2 && y1 + y2 == 14) || (y1 == 7 && y2 == 7));
            symmetryLine[2] = symmetryLine[2] && ((x1 == y2 && y1 == x2) || (x1 == y1 && x2 == y2));
            symmetryLine[3] = symmetryLine[3] && ((x2 + y2 == 14 && x1 + y1 == 14) || (x1 + y2 == 14 && x2 + y1 == 14));

        }
        protected void moveFinished()
        {
            if (selectMove && turnCount == 4 && turn == PieceType.Black)
            {
                status = Status.Selecting;
                checkSymmetry();
            }
            else
                status = Status.Play;
            if (status == Status.Play && bannedMove)
                findBannedMoves();
        }
        protected void move(Point p)
        {
            lastPt = p;
            Result re = checkResult();
            board[p.X, p.Y] = turn;
            stepRecord[p.X, p.Y] = turnCount + 1;
            form1.Invalidate();
            turnNext();
            switch (re)
            {
                case Result.BlackW:
                    ShowInfo("Game Over！\nBlack Win!");
                    break;
                case Result.WhiteW:
                    ShowInfo("Game Over！\nWhite Win!");
                    break;
                case Result.WhiteW_Ban:
                    ShowInfo("Game Over！\nWhite Win!\nThis is a foul!");
                    break;
                case Result.Draw:
                    ShowInfo("Game Over！\nThis Game is Drawed");
                    break;
                case Result.None:
                    moveFinished();
                    return;
            }
            record.result = re;
            pause = true;
            status = Status.Finished;
        }
        public void LoadRecord(string fileName)
        {
            if (record.load(fileName))
            {
                record.ToBoard(this, record.presentMove);
                form1.Invalidate();
                GetRule();
            }
        }
        public void SaveRecord(string fileName)
        {
            SetRule();
            record.save(fileName);
        }
        public void SetRule()
        {
            record.swap1 = swap1;
            record.swap3 = swap3;
            record.swap3SelN = swap3SelN;
            record.bannedMove  = bannedMove ;
            record.selectMove  = selectMove ;
            record.selectQuantity = selectQuantity;
            record.swap1 = swap1;
        }
        void GetRule()
        {
            swap1 = record.swap1;
            swap3 = record.swap3;
            swap3SelN = record.swap3SelN;
            bannedMove = record.bannedMove;
            selectMove = record.selectMove;
            selectQuantity = record.selectQuantity;
            swap1 = record.swap1;
        }
        //public BoardOfFIR board=new BoardOfFIR ();
    }
}
