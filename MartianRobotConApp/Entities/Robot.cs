public struct Robot
{
    public int x;
    public int y;
    public char orientation;
    private static readonly char[] compass = { 'N', 'E', 'S', 'W' };

    public Robot(int x, int y, char orientation)
    {
        this.x = x;
        this.y = y;
        this.orientation = orientation;
    }
    
    public Robot()
    {
        this.x = 0;
        this.y = 0;
        this.orientation = 'N';
    }

    public void Move(char direction)
    {
        switch (direction)
        {
            case 'F':
                if (orientation == 'N') y++;
                else if (orientation == 'E') x++;
                else if (orientation == 'S') y--;
                else if (orientation == 'W') x--;
                break;
            case 'L':
                TurnLeft();
                break;
            case 'R':
                TurnRight();
                break;
        }
    }

    private void TurnLeft()
    {
        int currentIndex = Array.IndexOf(compass, orientation);
        int newIndex = (currentIndex - 1 + compass.Length) % compass.Length;
        orientation = compass[newIndex];
    }
    private void TurnRight()
    {
        int currentIndex = Array.IndexOf(compass, orientation);
        int newIndex = (currentIndex + 1) % compass.Length;
        orientation = compass[newIndex];
    }
}