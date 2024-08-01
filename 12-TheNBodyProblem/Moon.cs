
public class Moon
{
    public long PosX { get; set; }
    public long PosY { get; set; }
    public long PosZ { get; set; }
    public long VelX { get; set; }
    public long VelY { get; set; }
    public long VelZ { get; set; }
    public Moon(string line)
    {
        var coords = line.Replace("<", "").Replace(">", "").Split(", ");
        PosX = long.Parse(coords[0].Split('=')[1]);
        PosY = long.Parse(coords[1].Split('=')[1]);
        PosZ = long.Parse(coords[2].Split('=')[1]);
        VelX = 0;
        VelY = 0;
        VelZ = 0;
    }


    public override string ToString()
    {
        return $"pos=[{PosX,3},{PosY,3},{PosZ,3}]   vel=[{VelX,3},{VelY,3},{VelZ,3}]";
    }
}
