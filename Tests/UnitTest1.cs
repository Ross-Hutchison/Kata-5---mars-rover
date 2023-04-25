global using NUnit.Framework;
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
}