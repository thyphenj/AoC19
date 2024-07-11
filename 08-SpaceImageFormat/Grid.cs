
public class Grid
{
    public string Answer;
    public int MinBlack = 150;
    public int WhiteTimesTrans = 0;

    public Grid()
    {
        Answer = new string('2', 150);
    }

    public void Add(Layer layer)
    {
        string nextAnswer = "";
        for (int i = 0; i < layer.Grid.Length; i++)
        {
            if (Answer[i] == '2' && layer.Grid[i] != '2')
                nextAnswer += layer.Grid[i].ToString();
            else
                nextAnswer += Answer[i].ToString(); ;
        }
        Answer = nextAnswer;
        
        if (layer.Black < MinBlack)
        {
            MinBlack = layer.Black;
            WhiteTimesTrans = layer.White * layer.Trans;
        }
    }
    public override string ToString()
    {
        string retval = "";
        for (int j = 0; j < 6; j++)
        {
            for (int i = 0; i < 25; i++)
            {
                retval += Answer[j * 25 + i] switch { '0' => ' ', '1' => '#', _ => '0' };
            }
            retval += "\n";
        }
        return retval;
    }
}
