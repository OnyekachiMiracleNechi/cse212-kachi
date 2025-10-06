public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        
        // TODO Start Problem 1

        //  Problem 1: Insert only unique values

        // If the value is the same as the current node, do nothing (ignore duplicates)
        if (value == Data)
        {
            return;
        }

    if (value < Data)
    {
        // Insert to the left subtree
        if (Left is null)
            Left = new Node(value);
        else
            Left.Insert(value);
    }
    
        else
        {
            // Insert to the right subtree
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }
    

public bool Contains(int value)
    {
        // TODO Start Problem 2

        //  Check if the current node holds the value
        if (value == Data)
        {
            return true;
        }

        //  If the value is smaller, look in the left subtree (recursively)
        if (value < Data && Left is not null)
        {
            return Left.Contains(value);
        }

        // If the value is larger, look in the right subtree (recursively)
        if (value > Data && Right is not null)
        {
            return Right.Contains(value);
        }

        // ❌ If we reach here, the value is not found in this branch
        return false;
    }
    
    public int GetHeight()
    {
        // TODO Start Problem 4

        //  Recursively get the height of the left subtree
        int leftHeight = (Left is not null) ? Left.GetHeight() : 0;

        //  Recursively get the height of the right subtree
        int rightHeight = (Right is not null) ? Right.GetHeight() : 0;

        //  Height is 1 (for the current node) + max of left and right subtree heights
        return 1 + Math.Max(leftHeight, rightHeight);
    }

}