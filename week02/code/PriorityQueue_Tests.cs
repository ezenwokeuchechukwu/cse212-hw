using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue one item and dequeue it
    // Expected Result: Should return the same person
    // Defect(s) Found: None
    public void TestPriorityQueue_EnqueueDequeue_Single()
    {
        var queue = new PriorityQueue();
        var person = new Person("Alice", 1);

        queue.Enqueue(person, priority: 10);
        var dequeued = queue.Dequeue();

        Assert.AreEqual(person, dequeued);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities
    // Expected Result: Highest priority person should be dequeued first
    // Defect(s) Found: None
    public void TestPriorityQueue_EnqueueDequeue_Multiple()
    {
        var queue = new PriorityQueue();
        var low = new Person("Low", 1);
        var medium = new Person("Medium", 1);
        var high = new Person("High", 1);

        queue.Enqueue(low, priority: 1);
        queue.Enqueue(medium, priority: 5);
        queue.Enqueue(high, priority: 10);

        Assert.AreEqual(high, queue.Dequeue());
        Assert.AreEqual(medium, queue.Dequeue());
        Assert.AreEqual(low, queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: Should throw InvalidOperationException
    // Defect(s) Found: None
    public void TestPriorityQueue_Dequeue_Empty()
    {
        var queue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Count reflects correct number of elements
    // Expected Result: Count should be accurate before and after dequeue
    public void TestPriorityQueue_Count()
    {
        var queue = new PriorityQueue();
        queue.Enqueue(new Person("A", 1), 2);
        queue.Enqueue(new Person("B", 1), 3);

        Assert.AreEqual(2, queue.Count);

        queue.Dequeue();
        Assert.AreEqual(1, queue.Count);

        queue.Dequeue();
        Assert.AreEqual(0, queue.Count);
    }
}
