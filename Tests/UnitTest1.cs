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
        rover.Move(new []{Move.Forward(1)});
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
        rover.Move(new []{Move.Backward(1)});
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
        rover.Move(new []{Move.Left(1)});
        rover.Facing.Should().Be(expectedFacing);
    }
    
    [TestCase(Direction.North, Direction.East)]
    [TestCase(Direction.East, Direction.South)]
    [TestCase(Direction.South, Direction.West)]
    [TestCase(Direction.West, Direction.North)]
    public void CanTurnRoverRight(Direction initialFacing, Direction expectedFacing)
    {
        var rover = new Rover(0, 0, initialFacing);
        rover.Move(new []{Move.Right(1)});
        rover.Facing.Should().Be(expectedFacing);
    }

    [Test]
    public void CanMoveMultipleTimes()
    {
        var rover = new Rover(0, 0, Direction.North);
        rover.Move(new []{Move.Forward(1), Move.Backward(1), Move.Left(1), Move.Right(2)});
        rover.Facing.Should().Be(Direction.East);
        rover.X.Should().Be(0);
        rover.Y.Should().Be(0);
    }
}