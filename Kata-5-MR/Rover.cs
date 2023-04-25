namespace Kata_5_MR;

public class Rover
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Direction Facing { get; private set; }

    public Rover(int x, int y, Direction facing)
    {
        X = x;
        Y = y;
        Facing = facing;
    }


    public void MoveForwards()
    {
        switch (Facing)
        {
            case Direction.North:
                Y++;
                break;
            case Direction.South:
                Y--;
                break;
            case Direction.East:
                X++;
                break;
            case Direction.West:
                X--;
                break;
            default:
                return;
        }
    }
    
}