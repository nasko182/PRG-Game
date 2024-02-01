namespace PRG_Game.Models;

using static Common.ApplicationConstants.Symbols;
public class Wall : Point
{
    public Wall(int leftX, int topY)
        : base(leftX, topY)
    {
    }

    public void InitializeWallBorders()
    {
        this.SetHorizontalLine(1);
        this.SetHorizontalLine(this.TopY+2);

        this.SetVerticalLine(0);
        this.SetVerticalLine(this.LeftX+1);

        this.FillInteriorWithSymbol();
    }

    public bool IsPointOfWall(Point playerElement)
    {
        return    playerElement.TopY == 1 
               || playerElement.LeftX == 0
               || playerElement.LeftX == this.LeftX +1 
               || playerElement.TopY == this.TopY + 2;
    }

    public void FillInteriorWithSymbol()
    {
        for (int leftX = 1; leftX <= this.LeftX ; leftX++)
        {
            for (int topY = 2; topY <= this.TopY+1; topY++)
            {
                this.Draw(leftX, topY, BoardSymbol);
            }
        }
    }

    private void SetHorizontalLine(int topY)
    {
        for (int leftX = 0; leftX <= this.LeftX+1; leftX++)
        {
            this.Draw(leftX, topY, WallSymbol);
        }
    }

    private void SetVerticalLine(int leftX)
    {
        for (int topY = 1; topY <= this.TopY + 1; topY++)
        {
            this.Draw(leftX, topY, WallSymbol);
        }
    }
}
