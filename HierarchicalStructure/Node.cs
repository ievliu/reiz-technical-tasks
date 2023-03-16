namespace HierarchicalStructure;

public class Node
{
    public required int Value { get; init; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }
}