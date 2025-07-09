
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]

public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue all
    // Expected Result: Highest priority items dequeued first; FIFO order among same priorities
    // Defect(s) Found: 
    public void TestPriorityQueue_BasicPriorityOrdering()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 5);
        pq.Enqueue("Medium", 3);
        pq.Enqueue("High2", 5);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("High2", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority and ensure FIFO ordering is preserved
    // Expected Result: Items dequeued in the same order they were enqueued
    // Defect(s) Found: 
    public void TestPriorityQueue_FIFOWhenPriorityEqual()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 3);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 3);

        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: InvalidOperationException is thrown
    // Defect(s) Found: 
    public void TestPriorityQueue_EmptyQueueThrows()
    {
        var pq = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
}
