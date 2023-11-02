namespace OrderedLinkedList;

public class Node
{
    public string? Item { get; private set; }
    public Node? Next { get; set; }

    public Node()
    {
        Next = null;
        Item = null;
    }
    
    public Node(string newItem)
    {
        Item = newItem;
        Next = null;
    }
    
    public Node(string newItem, Node nextNode)
    {
        Item = newItem;
        Next = nextNode;
    }
}