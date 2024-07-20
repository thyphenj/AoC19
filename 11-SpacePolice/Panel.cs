using System.Drawing;

public class Panel
{
    public long Colour;
    
    public Panel(int colour)
    {
        Colour = colour;
    }
 
    public override string ToString() => Colour == 0 ? " " : "#";
}
