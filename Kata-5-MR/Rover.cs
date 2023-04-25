namespace Kata_5_MR;

public record Move(MoveDirection Direction, int Magnitude)
{
    public static Move Forward(int magnitude) => new(MoveDirection.Forward, magnitude);
    public static Move Backward(int magnitude) => new(MoveDirection.Backward, magnitude);
    public static Move Left(int magnitude) => new(MoveDirection.Left, magnitude);
    public static Move Right(int magnitude) => new(MoveDirection.Right, magnitude);
};

public enum MoveDirection
{
    Forward,
    Backward,
    Left,
    Right
}

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

    public void Move(IReadOnlyCollection<Move> moves)
    {
        foreach (var move in moves)
        {
            switch (move.Direction)
            {
                case MoveDirection.Forward:
                    MoveForwards(move.Magnitude);
                    break;
                case MoveDirection.Backward:
                    MoveBackwards(move.Magnitude);
                    break;
                case MoveDirection.Left:
                    TurnLeft(move.Magnitude);
                    break;
                case MoveDirection.Right:
                    TurnRight(move.Magnitude);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }


    public void MoveForwards(int magnitude)
    {
        switch (Facing)
        {
            case Direction.North:
                Y += magnitude;
                break;
            case Direction.South:
                Y -= magnitude;
                break;
            case Direction.East:
                X += magnitude;
                break;
            case Direction.West:
                X -= magnitude;
                break;
            default:
                return;
        }
    }

    public void MoveBackwards(int magnitude)
    {
        switch (Facing)
        {
            case Direction.North:
                Y -= magnitude;
                break;
            case Direction.South:
                Y += magnitude;
                break;
            case Direction.East:
                X -= magnitude;
                break;
            case Direction.West:
                X += magnitude;
                break;
            default:
                return;
        }
    }

    private void TurnLeft(int magnitude)
    {
        for (var i = 0; i < magnitude; i++)
        {
            TurnLeft();
        }
    }

    private void TurnLeft()
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

    private void TurnRight(int magnitude)
    {
        for (var i = 0; i < magnitude; i++)
        {
            TurnRight();
        }
    }

    private void TurnRight()
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