public class AngleList
{
    List<Angle> Angles = new List<Angle>();

    public AngleList(int height, int width)
    {
        var eighth = new List<Angle>();
        // eighth.Add(new Angle(0, 1));

        for (int row = 0; row < height; row++)
        {
            for (int col = row; col < width; col++)
            {
                if (row == 0 && col == 0) continue;

                int r = row;
                int c = col;
                {
                    foreach (var p in new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 }.Where(z => z < width))
                    {
                        while (r > 0 && r % p == 0 && c > 0 && c % p == 0)
                        {
                            r /= p;
                            c /= p;
                        }
                    }
                    var ang = new Angle(r, c);
                    if (eighth.Where(z => z.Vector == ang.Vector).Count() == 0)
                        eighth.Add(ang);
                }
            }
        }

        foreach (var ang in eighth)
        {
            var newAng = new Angle(-ang.RowOffset,ang.ColOffset);
            if (Angles.Where(z => z.Vector == newAng.Vector).Count() == 0)
                Angles.Add(newAng);

            newAng = new Angle(-ang.ColOffset,ang.RowOffset);
            if (Angles.Where(z => z.Vector == newAng.Vector).Count() == 0)
                Angles.Add(newAng);

            newAng = new Angle(ang.RowOffset,ang.ColOffset);
            if (Angles.Where(z => z.Vector == newAng.Vector).Count() == 0)
                Angles.Add(newAng);

            newAng = new Angle(ang.ColOffset,ang.RowOffset);
            if (Angles.Where(z => z.Vector == newAng.Vector).Count() == 0)
                Angles.Add(newAng);
            
            newAng = new Angle(ang.RowOffset,-ang.ColOffset);
            if (Angles.Where(z => z.Vector == newAng.Vector).Count() == 0)
                Angles.Add(newAng);

            newAng = new Angle(ang.ColOffset,-ang.RowOffset);
            if (Angles.Where(z => z.Vector == newAng.Vector).Count() == 0)
                Angles.Add(newAng);

            newAng = new Angle(-ang.RowOffset,-ang.ColOffset);
            if (Angles.Where(z => z.Vector == newAng.Vector).Count() == 0)
                Angles.Add(newAng);

            newAng = new Angle(-ang.ColOffset,-ang.RowOffset);
            if (Angles.Where(z => z.Vector == newAng.Vector).Count() == 0)
                Angles.Add(newAng);

        }

        Angles.Sort();
    }

    public IEnumerator<Angle> GetEnumerator()
    {
        foreach (var ang in Angles)
            yield return ang;
    }
    public void Sort()
    {
        Angles.Sort();
    }
}
