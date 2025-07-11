using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue several items with different priorities and dequeue them one by one.
    // Expected Result: Items are dequeued in order from highest to lowest priority.
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("low", 1);
        pq.Enqueue("medium", 5);
        pq.Enqueue("high", 10);

        Assert.AreEqual("high", pq.Dequeue());
        Assert.AreEqual("medium", pq.Dequeue());
        Assert.AreEqual("low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority and dequeue them.
    // Expected Result: Items with the same priority are dequeued in FIFO order.
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("first", 3);
        pq.Enqueue("second", 3);
        pq.Enqueue("third", 3);

        Assert.AreEqual("first", pq.Dequeue());
        Assert.AreEqual("second", pq.Dequeue());
        Assert.AreEqual("third", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: Throws InvalidOperationException with appropriate message.
    // Defect(s) Found: 
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Enqueue items and verify ToString() output.
    // Expected Result: ToString returns all items in the queue in enqueue order.
    // Defect(s) Found: 
    public void TestPriorityQueue_ToString()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("a", 2);
        pq.Enqueue("b", 4);

        var str = pq.ToString();
        Assert.IsTrue(str.Contains("a (Pri:2)"));
        Assert.IsTrue(str.Contains("b (Pri:4)"));
    }
}
