namespace HierarchicalStructure;

public class BinaryTree
{
    public Node? Root { get; private set; }

    public void Insert(int value)
    {
        Node? previous = null;
        var next = Root;

        while (next is not null)
        {
            previous = next;

            if (value < next.Value)
            {
                next = next.Left;
            }
            else if (value > next.Value)
            {
                next = next.Right;
            }
            else
            {
                return;
            }
        }

        var newNode = new Node
        {
            Value = value
        };

        if (Root is null)
        {
            Root = newNode;
        }
        else
        {
            if (value < previous?.Value)
            {
                previous.Left = newNode;
            }
            else if (previous is not null)
            {
                previous.Right = newNode;
            }
        }
    }

    public static int CalculateDepth(Node? node) => node is null
        ? 0
        : Math.Max(CalculateDepth(node.Left), CalculateDepth(node.Right)) + 1;
}