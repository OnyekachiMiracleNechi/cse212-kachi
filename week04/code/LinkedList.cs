using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);

        // If the list is empty, point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, insert at the beginning
        else
        {
            newNode.Next = _head; // New node points to current head
            _head.Prev = newNode; // Current head points back to new node
            _head = newNode;      // Update head to new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        //  Problem 1: Insert a new node at the end
        Node newNode = new(value);

        // If the list is empty, new node is both head and tail
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;   // Current tail points to new node
            newNode.Prev = _tail;   // New node points back to current tail
            _tail = newNode;        // Update tail to new node
        }
    }

    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item or is empty, set head and tail to null.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If there are multiple items, remove the first one
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect second node from first
            _head = _head.Next;      // Update head to point to second node
        }
    }

    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        //  Problem 2: Remove the last node
        // If the list is empty or has one node
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If there are multiple nodes
        else if (_tail is not null)
        {
            _tail = _tail.Prev;  // Move tail back one node
            _tail!.Next = null;  // Disconnect the old tail
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' starting at the head
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If 'value' is at the end, just insert at the tail
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // Otherwise, create a new node and link it in between
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr;           // New node points back to current
                    newNode.Next = curr.Next;      // New node points forward to next
                    curr.Next!.Prev = newNode;     // Next node points back to new node
                    curr.Next = newNode;           // Current points forward to new node
                }
                return; // Stop after inserting
            }
            curr = curr.Next; // Continue searching
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        //  Problem 3: Remove first occurrence of a node with given value
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If it's the head node
                if (curr == _head)
                {
                    RemoveHead();
                }
                // If it's the tail node
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                // If it's a middle node
                else
                {
                    curr.Prev!.Next = curr.Next; // Skip current node forward
                    curr.Next!.Prev = curr.Prev; // Skip current node backward
                }
                return; // Stop after removing the first match
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace them with 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // Problem 4: Replace all occurrences
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue; // Change the node's value
            }
            curr = curr.Next; // Move to the next node
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // Call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning
        while (curr is not null)
        {
            yield return curr.Data; // Give current node's data
            curr = curr.Next;       // Move forward
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // Problem 5: Iterate backwards starting from the tail
        Node? curr = _tail; // Start at the end
        while (curr is not null)
        {
            yield return curr.Data; // Give current node's data
            curr = curr.Prev;       // Move backwards
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
