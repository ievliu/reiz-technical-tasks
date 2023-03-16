using FluentAssertions;
using HierarchicalStructure;

namespace BinaryTreeTests;

public class BinaryTreeTests
{
    private readonly BinaryTree _binaryTree;

    public BinaryTreeTests()
    {
        _binaryTree = new BinaryTree();
    }

    [Fact]
    public void BinaryTree_Insert_RootNodeIsNull()
    {
        // Act
        _binaryTree.Insert(5);

        // Assert
        _binaryTree.Root.Should().NotBeNull();
        _binaryTree.Root?.Value.Should().Be(5);
    }

    [Fact]
    public void BinaryTree_Insert_AddsNodeToTheLeft()
    {
        // Arrange
        _binaryTree.Insert(5);

        // Act
        _binaryTree.Insert(3);

        // Assert
        _binaryTree.Root?.Left.Should().NotBeNull();
        _binaryTree.Root?.Left?.Value.Should().Be(3);
    }

    [Fact]
    public void BinaryTree_Insert_AddsNodeToTheRight()
    {
        // Arrange
        _binaryTree.Insert(5);

        // Act
        _binaryTree.Insert(7);

        // Assert
        _binaryTree.Root?.Right.Should().NotBeNull();
        _binaryTree.Root?.Right?.Value.Should().Be(7);
    }

    [Fact]
    public void BinaryTree_Insert_DuplicateValue_NotAdded()
    {
        // Arrange
        _binaryTree.Insert(5);
        _binaryTree.Insert(3);

        // Act
        _binaryTree.Insert(3);

        // Assert
        _binaryTree.Root?.Left?.Left.Should().BeNull();
        _binaryTree.Root?.Left?.Right.Should().BeNull();
    }

    [Theory]
    [InlineData(5, 1)]
    [InlineData(5, 3, 1)]
    [InlineData(5, 6, 7, 8)]
    public void BinaryTree_CalculateDepth_ReturnsCorrectDepth(params int[] values)
    {
        // Arrange
        foreach (var value in values)
        {
            _binaryTree.Insert(value);
        }

        // Act
        var depth = BinaryTree.CalculateDepth(_binaryTree.Root);

        // Assert
        depth.Should().Be(values.Length);
    }
}