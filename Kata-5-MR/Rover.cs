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
    
    public void MoveBackwards()
    {
        switch (Facing)
        {
            case Direction.North:
                Y--;
                break;
            case Direction.South:
                Y++;
                break;
            case Direction.East:
                X--;
                break;
            case Direction.West:
                X++;
                break;
            default:
                return;
        }
    }

    public void TurnLeft()
    {
        switch (Facing)
        {
            case Direction.North:
                Facing = Direction.West;
                break;
            case Direction.South:
                Facing = Direction.East;
                break;
            case Direction.East:
                Facing = Direction.North;
                break;
            case Direction.West:
                Facing = Direction.South;
                break;
            default:
                return;
        }
    }

    public void TurnRight()
    {
        switch (Facing)
        {
            case Direction.North:
                Facing = Direction.East;
                break;
            case Direction.South:
                Facing = Direction.West;
                break;
            case Direction.East:
                Facing = Direction.South;
                break;
            case Direction.West:
                Facing = Direction.North;
                break;
            default:
                return;
        }
    }
}