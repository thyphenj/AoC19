public class Angle : IEquatable<Angle>, IComparable<Angle>
{
    public int RowOffset;
    public int ColOffset;
    public double Vector
    {
        get
        {
            if (RowOffset < 0 && ColOffset >= 0)                // -- 0 to 90
                if (-RowOffset > ColOffset)
                    return 0 - (double)ColOffset / RowOffset;       
                else
                    return 2 + (double)RowOffset / ColOffset;   

            else if (RowOffset >= 0 && ColOffset >= 0)          // -- 90 to 180
                if (RowOffset <= ColOffset)
                    return 2 + (double)RowOffset / ColOffset;   
                else
                    return 4 - (double)ColOffset / RowOffset;   

            else if (RowOffset >= 0 && ColOffset < 0)           // -- 180 to 270
                if (-ColOffset <= RowOffset)
                    return 4 - (double)ColOffset / RowOffset;   
                else
                    return 6 + (double)RowOffset / ColOffset;   

            else //if (RowOffset < 0 && ColOffset < 0)         // -- 270 to 360
                if (-RowOffset <= -ColOffset)
                    return 6 + (double)RowOffset / ColOffset;   
                else
                    return 8 - (double)ColOffset / RowOffset;   
        }
    }

    public Angle(int rowOff, int colOff)
    {
        RowOffset = rowOff;
        ColOffset = colOff;
    }
    public override string ToString()
    {
        return $"{RowOffset,3} {ColOffset,3}    {Vector}";
    }
    bool IEquatable<Angle>.Equals(Angle? other)
    {
        if (other == null)
            return false;
        else
            return this.Vector == ((Angle)other).Vector;
    }

    public override int GetHashCode()
    {
        int rr = RowOffset < 0 ? 1000000 * RowOffset : 100 * RowOffset;
        int cc = ColOffset < 0 ? 10000 * ColOffset : ColOffset;
        return rr + cc;
    }
    public int SortByVector(int a, int b)
    {
        return a < b ? -1 : a > b ? 1 : 0;
    }
    public int CompareTo(Angle? other)
    {
        if (other == null)
            return 1;
        else
            return this.Vector < other.Vector ? -1 : this.Vector > other.Vector ? 1 : 0;
    }
}
