namespace PRG_Game.Models;

using Helpers;

public class Point
{
    public Point(int leftX, int topY)
    {
        this.LeftX = leftX;
        this.TopY = topY;
    }
    public int LeftX { get; set; }

    public int TopY { get; set; }

    public void Draw(char symbol)
    {
        ConsoleHelper.ReplaceSymbolAtPosition(this.LeftX, this.TopY, symbol);

    }
    public void Draw(int leftX, int topY, char symbol)
    {
        ConsoleHelper.ReplaceSymbolAtPosition(leftX,topY,symbol);
    }
}
