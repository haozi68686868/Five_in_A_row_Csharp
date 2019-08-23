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
    class BoardOfFIR
    {
        protected PieceType[,] board = new PieceType[15, 15];//0为黑，1为白，2为黑禁，3为黑打点,4为空
        public int[,] stepRecord = new int[15, 15];
        protected PieceType turn;
        protected int turnCount;
        //
        public static bool swap1 = false;
        public static bool swap3 = false;
        public static bool swap3SelN = false;
        public static bool selectMove = false;
        public static int selectQuantity = 2;
        public static bool bannedMove = true;
        public Form1 form1;
        //RulesSetting
        //protected Point[] recd = new Point[225];
        protected Point lastPt;
        protected Point[] selectedPoint = new Point[10];
        protected int selectedPointCount;
        protected Status status;//1为游戏进行 2为游戏结束 3为选择打点 4为去除打点
        protected bool[] symmetryLine = new bool[4];
        //函数部分
        public BoardOfFIR()
        {
            init();
        }
        protected void init()
        {
            clearBoard();
            selectedPointCount = 0;
            turnCount = 0;
            turn = PieceType.Black;
            status = Status.Play;
        }
        public void boardCopy(BoardOfFIR formerBoard)
        {
            int i, j;
            for (i = 0; i < 15; i++)
                for (j = 0; j < 15; j++)
                    this.board[i, j] = formerBoard.board[i, j];
            turnCount = formerBoard.turnCount;
            turn = formerBoard.turn;
        }
        bool checkWin()
        {
            return (checkWin(turn));
        }
        bool checkWin(PieceType color,Point p)
        {
            int i;
            for (i = 0; i < 4; i++)
            {
                if (countLine(p, (direction)i, color) >= 4) return true;
            }
            return false;
        }
        bool checkWin(PieceType color)
        {
            return checkWin(color, lastPt);
        }
        int countLine(Point p, direction dir, PieceType color, bool positive)
        {
            int j;
            int count;
            j = 0;
            while (true)
            {
                if (!fixPosition(ref p, dir, positive, 1)) break;
                if (board[p.X, p.Y] != color) break;
                j++;
            }
            count = j;
            return count;
        }
        int countLine(Point p, direction dir, PieceType color, out int leftCount, out int rightCount)
        {
            leftCount = countLine(p, dir, color, false);
            rightCount = countLine(p, dir, color, true);
            return leftCount + rightCount;
        }
        int countLine(Point p, direction dir, PieceType color)
        {
            int left, right;
            countLine(p, dir, color, out left, out right);
            return left + right;
        }
        protected Result checkResult()//-1为无 0为黑胜 1为白胜 2为白抓禁手胜 3为平
        {
            if (board[lastPt.X, lastPt.Y] == PieceType.Banned && turn == PieceType.Black) return Result.WhiteW_Ban;
            if (checkWin())
                if (turn == PieceType.Black) return Result.BlackW;
                else
                    return Result.WhiteW;
            if (turnCount == 224) return Result.Draw;
            return Result.None;
        }
        bool isOverline(Point p)
        {
            foreach (direction dir in Enum.GetValues(typeof(direction)))
            {
                if (isOverline(p, dir)) return true;
            }
            return false;
        }
        bool isOverline(Point p, direction dir)//0为右 1为上 2为右上 3为右下
        {
            if (countLine(p, dir, PieceType.Black) >= 5) return true;
            return false;
        }
        static void dirTo_mn(direction dir, out int m, out int n, bool positive)
        {
            switch (dir)
            {
                case direction.Horizontal: m = 1; n = 0; break;
                case direction.Vertical: m = 0; n = 1; break;
                case direction.DiagonalUp: m = 1; n = 1; break;
                case direction.DiagonalDown: m = 1; n = -1; break;
                default: m = 0; n = 0; break;
            }
            if (!positive)
            {
                m = -m;
                n = -n;
            }
        }
        public static bool checkP(Point p)//检查是否在棋盘内
        {
            if (p.X < 0 || p.X > 14 || p.Y < 0 || p.Y > 14) return false;
            return true;
        }
        static bool fixPosition(ref Point p, direction dir, bool positive, int step)//请将Point务必设置为临时变量
        {
            int m, n;
            dirTo_mn(dir, out m, out n, positive);
            p.X += m * step;
            p.Y += n * step;
            return checkP(p);
        }
        bool isDoubleFour(Point p)//默认有禁手才会调用该函数
        {
            int count4 = 0;
            int left, right, mid;
            Point tP;
            foreach (direction dir in Enum.GetValues(typeof(direction)))
            {
                if (isOpenFour(p, dir, PieceType.Black))
                {
                    count4++;
                    continue;
                }
                mid = countLine(p, dir, PieceType.Black, out left, out right) + 1;
                tP = p;
                if ((fixPosition(ref tP, dir, false, left + 1) && (int)board[tP.X, tP.Y] >= 2))
                {
                    left = countLine(tP, dir, PieceType.Black, false);
                    if ((left + mid) == 4) count4++;
                }
                tP = p;
                if ((fixPosition(ref tP, dir, true, right + 1) && (int)board[tP.X, tP.Y] >= 2))
                {
                    right = countLine(tP, dir, PieceType.Black, true);
                    if ((right + mid) == 4) count4++;
                }
            }
            if (count4 >= 2) return true;
            return false;
        }
        bool isDoubleThree(Point p)
        {
            int count3 = 0;
            foreach (direction dir in Enum.GetValues(typeof(direction)))
            {
                if (isOpenThree(p, dir, PieceType.Black)) count3++;
            }
            if (count3 >= 2) return true;
            return false;
        }
        bool isFour(Point p,PieceType color)
        {
            int left, right, mid;
            Point tP;
            foreach (direction dir in Enum.GetValues(typeof(direction)))
            {
                mid = countLine(p, dir, PieceType.Black, out left, out right) + 1;
                tP = p;
                if ((fixPosition(ref tP, dir, false, left + 1) && (int)board[tP.X, tP.Y] >= 2))
                {
                    left = countLine(tP, dir, color, false);
                    if ((left + mid) >= 4) return true;
                }
                tP = p;
                if ((fixPosition(ref tP, dir, true, right + 1) && (int)board[tP.X, tP.Y] >= 2))
                {
                    right = countLine(tP, dir, color, true);
                    if ((right + mid) >= 4) return true;
                }
            }
            return false;
        }
        bool isOpenFour(Point p, direction dir, PieceType color)
        {
            int left, right;
            Point tP;
            if (countLine(p, dir, color, out left, out right) == 3)
            {
                tP = p;
                if (!(fixPosition(ref tP, dir, false, left + 1) && (int)board[tP.X, tP.Y] >= 2)) return false;
                if (bannedMove && color == PieceType.Black && fixPosition(ref tP, dir, false, 1) && board[tP.X, tP.Y] == PieceType.Black) return false;
                tP = p;
                if (!(fixPosition(ref tP, dir, true, right + 1) && (int)board[tP.X, tP.Y] >= 2)) return false;
                if (bannedMove && color == PieceType.Black && fixPosition(ref tP, dir, true, 1) && board[tP.X, tP.Y] == PieceType.Black) return false;//判断长连禁手
                return true;
            }
            return false;
        }
        bool isOpenFour(Point p,  PieceType color)
        {
            foreach (direction dir in Enum.GetValues(typeof(direction)))
            {
                if (isOpenFour(p, dir, color)) return true;
            }
            return false;
        }
        bool isOpenThree(Point p, direction dir, PieceType color)
        {
            int left, right, mid;
            int leftC, rightC;
            BoardOfFIR newBd = new BoardOfFIR();
            Point tP;
            mid = countLine(p, dir, color, out left, out right) + 1;
            tP = p;
            if ((fixPosition(ref tP, dir, false, left + 1) && (int)board[tP.X, tP.Y] >= 2))
            {
                leftC = countLine(tP, dir, color, false);
                if ((mid + leftC) == 3)
                {
                    newBd.boardCopy(this);
                    newBd.board[p.X, p.Y] = color;
                    if (newBd.isOpenFour(tP, dir, color) && (!newBd.isBanned(tP) || color != PieceType.Black)) return true;
                }
            }
            tP = p;
            if ((fixPosition(ref tP, dir, true, right + 1) && (int)board[tP.X, tP.Y] >= 2))
            {
                rightC = countLine(tP, dir, color, true);
                if ((mid + rightC) == 3)
                {
                    newBd.boardCopy(this);
                    newBd.board[p.X, p.Y] = color;
                    if (newBd.isOpenFour(tP, dir, color) && (!newBd.isBanned(tP) || color != PieceType.Black)) return true;
                }
            }

            return false;
        }
        bool isBanned(Point p)
        {
            foreach (direction dir in Enum.GetValues(typeof(direction)))
            {
                if (countLine(p, dir, PieceType.Black) == 4) return false;
            }
            if (isOverline(p) || isDoubleFour(p) || isDoubleThree(p)) return true;
            return false;
        }
        protected void findBannedMoves()
        {
            Point tP = new Point();
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                    if ((int)board[i, j] >= 2)
                    {
                        tP.X = i; tP.Y = j;
                        if (isBanned(tP)) board[i, j] = PieceType.Banned;
                        else
                            board[i, j] = PieceType.Empty;
                    }
        }
        //↑为判定禁手以及判断输赢
        protected void turnNext()
        {
            if (turn == PieceType.White)
                turn = PieceType.Black;
            else
                turn = PieceType.White;
            turnCount++;
        }
        protected void dealWithEvent()
        {
            if (swap1 && turnCount == 1)
            {
                if (MessageBox.Show("一手交换规则\n您是否交换颜色", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) swapColor();
            }
            if (swap3 && turnCount == 3)
            {
                if (MessageBox.Show("三手交换规则\n您是否交换颜色", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) swapColor();
            }
            if (swap3SelN && turnCount == 3)
            {
                InputBox input = new InputBox();
                input.text.Text = "三手交换 五手N打规则：请黑方输入第五手打点数量";
                while (true)
                {
                    if ((input.ShowDialog() == DialogResult.OK))
                    {
                        short x;
                        try
                        {
                            x = Convert.ToInt16(input.Input.Text);
                        }
                        catch
                        {
                            MessageBox.Show("请输入一个整数", "五子棋");
                            continue;
                        }
                        if (x > 10 || x < 2)
                        {
                            MessageBox.Show("请输入一个2-10的数", "五子棋");
                            continue;
                        }
                        else
                        {
                            selectQuantity = x;
                            break;
                        }
                    }
                }
                if (MessageBox.Show("三手交换,五手N打规则\n黑方指定打点数量为： " + Convert.ToString(selectQuantity) + "\n您是否交换颜色", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) swapColor();
            }
        }
        protected bool isLegal(Point p)
        {
            if (swap3 || swap3SelN)
            {
                if (turnCount == 0 && (p.X != 7 || p.Y != 7))
                {
                    MessageBox.Show("三手交换规则\n第一手必须下在天元");
                    return false;
                }
                if (turnCount == 1 && (Math.Abs(p.X - 7) > 1 || Math.Abs(p.Y - 7) > 1))
                {
                    MessageBox.Show("三手交换规则\n第二手必须下在中心3x3的区域内");
                    return false;
                }
                if (turnCount == 2 && (Math.Abs(p.X - 7) > 2 || Math.Abs(p.Y - 7) > 2))
                {
                    MessageBox.Show("三手交换规则\n第三手必须下在中心5x5的区域内");
                    return false;
                }
            }
            if ((int)board[p.X, p.Y] < 2) return false;
            return true;
        }
        public static void ShowInfo(object msg)
        {
            System.Windows.Forms.MessageBox.Show(msg.ToString(), "五子棋", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        protected bool isSelectedLegal(Point p)
        {
            int i;
            if (board[p.X, p.Y] != PieceType.Empty) return false;
            if (selectedPointCount == 0) return true;
            if (symmetryLine[0])
                for (i = 0; i < selectedPointCount; i++)
                    if (selectedPoint[i].Y == p.Y && selectedPoint[i].X + p.X == 14) return false;
            if (symmetryLine[1])
                for (i = 0; i < selectedPointCount; i++)
                    if (selectedPoint[i].X == p.X && selectedPoint[i].Y + p.Y == 14) return false;
            if (symmetryLine[2])
                for (i = 0; i < selectedPointCount; i++)
                    if (selectedPoint[i].Y == p.X && selectedPoint[i].X == p.Y) return false;
            if (symmetryLine[3])
                for (i = 0; i < selectedPointCount; i++)
                    if (selectedPoint[i].X + p.Y == 14 && selectedPoint[i].Y + p.X == 14) return false;
            return true;
        }
        //↑为处理特殊事件五手两打等等
        //以下为AI部分
        judgeCount[] judge = new judgeCount[2];//0为黑，1为白
        public static int AIdepth=2;
        public void statistics()//1重置禁手点，2判定局面，3找禁手，4禁手加权评分
        {
            judge[0].init(); judge[1].init();
            int i, j;
            for (i = 0; i < 15; i++)
                for (j = 0; j < 15; j++)
                    if (board[i, j] == PieceType.Banned)
                        board[i, j] = PieceType.Empty;//将禁手点重置为
            for (i = 0; i < 15; i++)
            {
                lineStatistics(new Point(0, i), direction.Horizontal);
                lineStatistics(new Point(i, 0), direction.Vertical);
                lineStatistics(new Point(i, 0), direction.DiagonalUp);
                if (i != 0)
                    lineStatistics(new Point(0, i), direction.DiagonalUp);
                lineStatistics(new Point(0, i), direction.DiagonalDown);
                if (i != 0)
                    lineStatistics(new Point(i, 14), direction.DiagonalDown);
            }
            if(bannedMove)
            findBannedMoves();
        }
        Evalute getEvalute()
        {
            Evalute e = new Evalute();
            statistics();
            e.judge[0] = this.judge[0];
            e.judge[1] = this.judge[1];
            return e;
        }
        Evalute PointEvalute(Point p)
        {
            Evalute e = new Evalute();
            judge[0].init();
            judge[1].init();
            lineStatistics(new Point (0,p.Y ), direction.Horizontal);
            lineStatistics(new Point(p.X,0), direction.Vertical);
            int min = Math.Min(p.X, p.Y);
            lineStatistics(new Point(p.X -min, p.Y -min), direction.DiagonalUp);
            if (p.X + p.Y > 14)
                lineStatistics(new Point(p.X + p.Y - 14, 14), direction.DiagonalDown);
            else
                lineStatistics(new Point(0, p.X +p.Y ), direction.DiagonalDown);
            e.judge[0] = this.judge[0];
            e.judge[1] = this.judge[1];
            return e;
        }
        Evalute PointEvaluteChange(Point p, PieceType color)
        {
            PieceType origin = board[p.X, p.Y];
            Evalute e1 =PointEvalute (p);
            board[p.X, p.Y] = color;
            Evalute e2 = PointEvalute(p);
            board[p.X, p.Y] =origin ;
            return e2 - e1;
        }
        bool isAround(Point p)
        {
            //PieceType oppColor = oppoPiece (color );
            int i, j;
            for (i = -2; i <= 2; i++)
                for (j = -2; j <= 2; j++)
                    if (checkP(new Point (i + p.X,j + p.Y))&&(int)board [i+ p.X,j + p.Y]<=2/*(board[i + p.X, j + p.Y] == color || (board[i + p.X, j + p.Y] == oppColor && Math.Abs(i) != 3 && Math.Abs(j) != 3))*/) 
                        return true;
            return false;
        }
        static PieceType oppoPiece(PieceType p)
        {
            return(PieceType)(((int)p + 1) % 2);
        }
        void lineStatistics(Point p, direction dir)//p为起始点
        {
            int i;
            int sum;
            List<chessShape> list = new List<chessShape>();
            chessShape temp;
            PieceType nowType;
            bool isEnd;
            list.Add(new chessShape(PieceType.Banned, 0));//此处banned代表墙
            nowType = PieceType.Empty;
            while (true)
            {
                temp = GetNextShape(ref p, dir, out isEnd);
                if (temp.type != PieceType.Empty && list.Count % 2 == 1)//插入长为0的empty，不会影响总长,模2为1意味着应当插入空白
                {
                    list.Add(new chessShape(PieceType.Empty, 0));//0意味着左侧有子堵上
                }
                list.Add(temp);
                if (nowType != PieceType.Empty && temp.type != nowType && temp.type != PieceType.Empty)//对立棋子出现
                {
                    judgeShape(list);//判定棋型
                    list.RemoveRange(0, list.Count - 3);
                }
                else//空棋子或者本方棋子出现
                {
                    sum = 0;
                    for (i = 2; i < list.Count; i++)
                    {
                        sum += list[i].count;
                    }
                    if (sum >= 5)//大于5即能成型
                    {
                        //判定棋型
                        judgeShape(list);
                        list.RemoveRange(0, 2);//移除开头两个元素
                    }
                    else if (temp.type == PieceType.Empty && isEnd)
                    {
                        list.Add(new chessShape(PieceType.Banned, 0));
                        judgeShape(list);
                    }
                }
                if (isEnd) break;
                if (temp.type != PieceType.Empty) nowType = temp.type;
            }
        }
        void judgeShape(List<chessShape> list)
        {
            PieceType color = list[2].type;//第3个元素始终标示判定的颜色
            int checkCount = 0;
            int emptyCount = 0;
            int i;
            int live = 2;//0表示完全封死 1表示被封一半 2表示open
            int leftE = list[1].count;
            bool overline = false;//将来可能用到，目前没有使用
            if (list[list.Count - 1].type == PieceType.Empty)//以空格结尾且达到5个子
            {
                if (leftE == 0) live = 1;
                for (i = 2; i < list.Count - 1; i++)
                {
                    if (i % 2 == 0) checkCount += list[i].count;
                    else
                        emptyCount += list[i].count;
                }
            }
            else if (list[list.Count - 1].type == color)//以同色子结尾，且达到5个
            {
                live = 1;
                for (i = 2; i < list.Count; i++)
                {
                    if (i % 2 == 0) checkCount += list[i].count;
                    else
                        emptyCount += list[i].count;
                    if (checkCount + emptyCount > 5) overline = true;
                }
                checkCount = 5 - emptyCount;
            }
            else//以不同色子结尾，不一定有5个
            {
                for (i = 2; i < list.Count - 2; i++)
                {
                    if (i % 2 == 0) checkCount += list[i].count;
                    else
                        emptyCount += list[i].count;
                }
                if (leftE + emptyCount + checkCount + list[list.Count - 2].count < 5) return;
                if (leftE + emptyCount + checkCount + list[list.Count - 2].count == 5) live = 1;
                else if (leftE == 0 || list[list.Count - 2].count == 0) live = 1;
                else
                    live = 2;
            }
            switch (checkCount)
            {
                case 1:
                    if (live == 2) judge[(int)color].L1++;
                    break;
                case 2:
                    if (live == 2) judge[(int)color].L2++;
                    if (live == 1) judge[(int)color].H2++;
                    break;
                case 3:
                    if (live == 2) judge[(int)color].L3++;
                    if (live == 1) judge[(int)color].H3++;
                    break;
                case 4:
                    if (live == 2) judge[(int)color].L4++;
                    if (live == 1) judge[(int)color].H4++;
                    break;
            }
        }
        chessShape GetNextShape(ref Point p, direction dir, out bool isEnd)//保证p都是存在的,若到尾了则isEnd返回true，p会不断移动
        {
            PieceType tType = board[p.X, p.Y];
            int temp = countLine(p, dir, tType, true);
            isEnd = !fixPosition(ref p, dir, true, temp + 1);
            return new chessShape(tType, temp + 1);
        }
        public int searchtimes;
        protected Point FindMove()
        {
            Point move;
            searchtimes = 0;
            if (turnCount == 0)
            {
                return new Point(7, 7);
            }
            else if (turnCount == 1)
            {
                Random rand=new Random ();
                for (int i = 0; i < 15; i++)
                    for (int j = 0; j < 15; j++)
                        if (board[i, j] != PieceType.Empty)
                            return new Point(i + 1, j + 1);
                return new Point(7, 7);         
            }
            else
            {
                BoardOfFIR newBd = new BoardOfFIR();
                newBd.boardCopy(this);
                Evalute e = getEvalute();
                newBd.FindBestMove(-10000, 10000, AIdepth, turn, out move, e);
                //ShowInfo(newBd.searchtimes);
            }
            return move;
        }
        int FindBestMove(int alpha,int beta,int depth,PieceType color,out Point bestP,Evalute e)//该函数用alphabeta搜索，以在今后搜索更深的深度
        {
            bestP = new Point(0, 0);
            int i, j;
            Point tP=new Point();
            PieceType oppoColor = oppoPiece(color);
            int temp;
            Point tempPoint;
            Evalute tempE;
            int best=-10000;
            List<Point> movelist = new List<Point>();//get possible move
            for (i = 0; i < 15; i++)
                for (j = 0; j < 15; j++)
                {
                    tP.X = i; tP.Y = j;
                    if ((int)board[i, j] >= 2 && isAround(tP)&&(board [i,j]!=PieceType .Banned ||color ==PieceType .White) ) movelist.Add(tP);
                }
            if (AIdepth == depth)
                for (i = 0; i < 15; i++)for (j = 0; j < 15; j++)if (board[i, j] == PieceType.Banned)board[i, j] = PieceType.Empty;
            if (e.judge[(int)color].H4 + e.judge[(int)color].L4 > 0)
            {
                for (i = 0; i < 15; i++)
                    for (j = 0; j < 15; j++)
                    {
                        tP.X =i;tP.Y =j;
                        if ((int)board[i, j] >= 2 && checkWin(color, tP) && (board[i, j] != PieceType.Banned || color == PieceType.White))
                        {
                            bestP = tP;
                            return 5000;
                        }
                    }
            }
            if (e.judge[(int)oppoColor].L4 > 0)
            {
                for (i = 0; i < 15; i++)
                    for (j = 0; j < 15; j++)
                    {
                        tP.X = i; tP.Y = j;
                        if ((int)board[i, j] >= 2 && checkWin(oppoColor, tP) && (board[i, j] != PieceType.Banned || oppoColor  == PieceType.White))
                        {
                            bestP = tP;
                            return -5000+e.getscore(color);
                        }
                    }
            }
            if (e.judge[(int)oppoColor].H4 > 0)
            {
                for (i = 0; i < 15; i++)
                    for (j = 0; j < 15; j++)
                    {
                        tP.X = i; tP.Y = j;
                        if ((int)board[i, j] >= 2 && checkWin(oppoColor, tP) && (board[i, j] != PieceType.Banned || oppoColor == PieceType.White))
                        {
                            bestP = tP;
                            tempE = PointEvaluteChange(tP, color) + e;
                            if (depth == AIdepth) return e.getscore (color );
                            setPieceType(tP, color);
                            temp= -FindBestMove(-beta, -alpha, depth-1, oppoColor, out tempPoint, tempE);
                            setPieceType(tP, PieceType.Empty);
                            return temp;
                        }
                    }
            }
            if (e.judge[(int)color].L3 > 0)
            {
                 for (i = 0; i < 15; i++)
                     for (j = 0; j < 15; j++)
                     {
                         tP.X = i; tP.Y = j;
                         if ((int)board[i, j] >= 2 && isOpenFour (tP,color) && (board[i, j] != PieceType.Banned || oppoColor == PieceType.White))
                         {
                             bestP = tP;
                             return 5000;
                         }
                     }
            }
            if (e.judge[(int)color].H3 > 0 && AIdepth <= depth+1)
            {
                if (VCF(out tempPoint, color,e))
                {
                    bestP = tempPoint;
                    return 4000;
                }
            }
            if (depth <= 0)
            {
                searchtimes++;
                return e.getscore (color);
            }
            foreach (Point p in movelist)
            {
                tempE = PointEvaluteChange(p, color)+e;
                setPieceType(p, color);
                temp= -FindBestMove(-beta, -alpha, depth - 1,oppoColor ,out tempPoint,tempE );//tempPoint为下一步最好的走法
                setPieceType(p, PieceType.Empty);
                if (temp > best)                        // 找到最佳值
                {
                    best = temp;                                 
                    if (temp >= beta)// 找到一个Beta走法
                    {
                        bestP = p;
                        break;//提高效率所在
                    }
                    if (temp > alpha)
                    {
                        bestP = p;
                        alpha = temp;                               // '缩小Alpha-Beta边界
                    }
                }
            }
            if (best < -3000&&depth ==AIdepth )//输局已定，选择位置得分最高的点
            {
                int better=-10000;
                foreach (Point p in movelist)
                {
                    temp = PointEvaluteChange(p, oppoColor ).getscore(oppoColor) ;
                    if (temp > better)
                    {
                        better = temp;
                        bestP = p;
                    }
                }
            }
            return best;
        }
        bool VCF(out Point move,PieceType color,Evalute e)
        {
            
            move = new Point(7, 7);
            Point tP = new Point();
            int i, j;
            bool temp;
            Point tempP;
            Evalute tempE1,tempE2;
            PieceType oppoColor = oppoPiece(color);
            List<Point> movelist = new List<Point>();
            for (i = 0; i < 15; i++)
                for (j = 0; j < 15; j++)
                {
                    tP.X = i; tP.Y = j;
                    if (board[i,j]==PieceType.Empty&&isFour(tP,color ))movelist.Add (tP);
                }
            foreach (Point p in movelist)
            {
                tempE1 = PointEvaluteChange(p, color) + e;
                setPieceType(p, color);
                for(i=0;i<15;i++)
                    for (j = 0; j < 15; j++)
                    {
                        tP.X = i; tP.Y = j;
                        if ((int)board[i, j] >= 2 && checkWin(color, tP))
                        {
                            tempE2 = PointEvaluteChange(tP, oppoColor)+tempE1;
                            if (tempE2.judge[(int)color].H4 > 0)//由于不可能出现活4，只需判断冲4
                            {
                                setPieceType(p, PieceType.Empty);
                                move = p;
                                return true;
                            }
                            else if (tempE2.judge[(int)oppoColor].L4 + tempE2.judge[(int)oppoColor].H4 > 0)
                            {
                                setPieceType(p, PieceType.Empty);
                                continue;
                            }
                            else if (tempE2.judge[(int)color].L3 > 0)
                            {
                                move = p;
                                setPieceType(p, PieceType.Empty);
                                return true;
                            }
                            else if (tempE2.judge[(int)color].H3 > 0)
                            {
                                setPieceType(tP, oppoColor);
                                temp = VCF(out tempP, color, tempE2);
                                setPieceType(tP, PieceType.Empty);
                                if (temp)
                                {
                                    move = p;
                                    setPieceType(p, PieceType.Empty);
                                    return true;
                                }
                            }
                        }
                    }
                setPieceType(p,PieceType.Empty );
            }
            return false;
        }
        //以下为对外接口
        public PieceType getPieceType(Point p)
        {
            return board[p.X, p.Y];
        }
        public PieceType getPieceType(int x, int y)
        {
            return board[x, y];
        }
        public void setPieceType(Point p, PieceType t)
        {
            board[p.X, p.Y] = t;
        }
        public void clearBoard()
        {
            int i, j;
            for (i = 0; i < 15; i++)
                for (j = 0; j < 15; j++)
                {
                    this.board[i, j] = PieceType.Empty;
                    stepRecord[i, j] = 0;
                }
        }
        public Status getStatus()
        {
            return this.status;
        }
        public void setTurn(int turnC)
        {
            turnCount = turnC;
            turn = (PieceType)(turnCount % 2);
        }
        public void swapColor()
        {
            ShowInfo("Swap Color");
        }
        
    }

}
