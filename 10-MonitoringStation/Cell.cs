
public class Cell
{
    public bool IsAnAsteroid;
    public bool HasBeenChecked;

    public Cell(int row, int col, bool value)
    {
        IsAnAsteroid = value;
        HasBeenChecked = false;
    }

    public override string ToString()
    {
        return IsAnAsteroid? HasBeenChecked ? "O" : "#" : ".";
    }
}
