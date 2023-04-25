global using NUnit.Framework;
using System.Xml.Xsl;
using FluentAssertions;
using Kata_5_MR;

namespace Tests;

public class Tests
{
    
    [Test]
    public void CreateDomainObjects()
    {
        var rover = new Rover(0 ,0, Direction.North);
    }

    [TestCase(Direction.North, 0, 1)]
    [TestCase(Direction.East, 1, 0)]
    [TestCase(Direction.South, 0, -1)]
    [TestCase(Direction.West, -1, 0)]
    public void CanMoveRoverForwards(Direction initialFacing, int expectedX, int expectedY)
    {
        var rover = new Rover(0, 0, initialFacing);
        rover.MoveForwards();
        rover.X.Should().Be(expectedX);
        rover.Y.Should().Be(expectedY);
    }
    
    [TestCase(Direction.North, 0, -1)]
    [TestCase(Direction.East, -1, 0)]
    [TestCase(Direction.South, 0, 1)]
    [TestCase(Direction.West, 1, 0)]
    public void CanMoveRoverBackwards(Direction initialFacing, int expectedX, int expectedY)
    {
        var rover = new Rover(0, 0, initialFacing);
        rover.MoveBackwards();
        rover.X.Should().Be(expectedX);
        rover.Y.Should().Be(expectedY);
    }
    
    [TestCase(Direction.North, Direction.West)]
    [TestCase(Direction.East, Direction.North)]
    [TestCase(Direction.South, Direction.East)]
    [TestCase(Direction.West, Direction.South)]
    public void CanTurnRoverLeft(Direction initialFacing, Direction expectedFacing)
    {
        var rover = new Rover(0, 0, initialFacing);
        rover.TurnLeft();
        rover.Facing.Should().Be(expectedFacing);
    }
    
    [TestCase(Direction.North, Direction.East)]
    [TestCase(Direction.East, Direction.South)]
    [TestCase(Direction.South, Direction.West)]
    [TestCase(Direction.West, Direction.North)]
    public void CanTurnRoverRight(Direction initialFacing, Direction expectedFacing)
    {
        var rover = new Rover(0, 0, initialFacing);
        rover.TurnRight();
        rover.Facing.Should().Be(expectedFacing);
    }

    // [Test]
    // public void X()
    // {
    //     var rover = new Rover(0, 0, Direction.North);
    //     rover.Move(new []{(Forward,1), (Backward,1), (Left,1), (Right,1)});
    // }
}