using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three people with different priorities and remove one.
    // Expected Result: The person with the highest priority should be removed first.
    // Defect(s) Found: Dequeue logic did not correctly identify the highest priority item 
    // because the loop was stopping too early (off-by-one error).
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Alice", 1);
        priorityQueue.Enqueue("Bob", 3);
        priorityQueue.Enqueue("Charlie", 2);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Bob", result);
    }


    [TestMethod]
    // Scenario: Two items have the same highest priority. The one that was enqueued first
    // should be removed first, following FIFO rules.
    // Expected Result: "Alice" is dequeued before "Bob" since both have priority 5, but Alice was added first.
    // Defect(s) Found: Original code incorrectly updated highPriorityIndex on ties, 
    // causing later items with the same priority (e.g., Bob) to be chosen instead of Alice.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Alice", 5);  // first high priority
        priorityQueue.Enqueue("Bob", 5);    // second high priority
        priorityQueue.Enqueue("Charlie", 3);

        var firstOut = priorityQueue.Dequeue();
        Assert.AreEqual("Alice", firstOut, "FIFO rule broken when priorities are equal.");
    }



    [TestMethod]
    // Scenario: Add items with different priorities.
    // Expected Result: The item with the highest priority should be removed first, regardless of order added.
    // Defect(s) Found: Loop skipped last element and did not always pick highest priority.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    

}