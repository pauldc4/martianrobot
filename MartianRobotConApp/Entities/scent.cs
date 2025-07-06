public struct Scent
{
    public int x;
    public int y;
    public char orientation;

    public Scent(int x, int y, char orientation)
    {
        this.x = x;
        this.y = y;
        this.orientation = orientation;
    }

    public override string ToString()
    {
        return $"Scent at ({x}, {y}) facing {orientation}";
    }
}