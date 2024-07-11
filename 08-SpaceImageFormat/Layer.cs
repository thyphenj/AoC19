
public class Layer
{
    public string Grid;
    public int Black = 0;
    public int White = 0;
    public int Trans = 0;

    public Layer(string text)
    {
        Grid = text;

        for (int i = 0; i < text.Length; i++)
        {
            switch (text[i])
            {
                case '0': Black++; break;
                case '1': White++; break;
                case '2': Trans++; break;
            }
        }
    }
}

