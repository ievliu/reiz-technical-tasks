using HierarchicalStructure;

var tree = new BinaryTree();
tree.Insert(5);
tree.Insert(3);
tree.Insert(7);
tree.Insert(1);
tree.Insert(4);
tree.Insert(6);
tree.Insert(8);

var depth = BinaryTree.CalculateDepth(tree.Root);
Console.WriteLine($"Depth of tree is: {depth}");