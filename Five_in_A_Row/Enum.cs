public enum PieceType 
{ 
    Black, 
    White, 
    Banned, 
    Selected,
    Empty 
};
enum direction
{
    Horizontal,
    Vertical,
    DiagonalUp,
    DiagonalDown
};
enum Result
{
    None,
    BlackW,
    WhiteW,
    WhiteW_Ban,
    Draw
};
public enum Status
{
    Finished,
    Play,
    Selecting,
    DeleteSel
};
public enum VarDecision
{
    New_Variatiaon,
    New_Main_Line,
    OverWrite,
    None,
};