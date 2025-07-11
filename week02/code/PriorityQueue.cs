﻿public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Adds a new value to the queue with an associated priority.
    /// The item is always added to the back of the queue regardless of priority.
    /// </summary>
    /// <param name="value">The value to enqueue</param>
    /// <param name="priority">The priority of the value</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    /// <summary>
    /// Removes and returns the item with the highest priority from the queue.
    /// If multiple items share the highest priority, the one closest to the front
    /// of the queue (FIFO order) is removed first.
    /// Throws InvalidOperationException if the queue is empty.
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority
        // If there's a tie, the first (lowest index) is chosen
        int highPriorityIndex = 0;
        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = i;
            }
            // If equal priority, do nothing to keep FIFO order
        }

        // Get the value to return
        var value = _queue[highPriorityIndex].Value;

        // Remove the item from the queue
        _queue.RemoveAt(highPriorityIndex);

        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
