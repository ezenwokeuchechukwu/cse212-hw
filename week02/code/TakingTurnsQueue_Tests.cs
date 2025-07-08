using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private readonly Queue<Person> _queue = new();

    public int Length => _queue.Count;

    public void AddPerson(string name, int turns)
    {
        _queue.Enqueue(new Person(name, turns));
    }

    public Person GetNextPerson()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        var person = _queue.Dequeue();

        // If person has infinite turns, don't modify their turn count
        if (person.Turns <= 0)
        {
            _queue.Enqueue(person);
        }
        else
        {
            person.Turns--;
            if (person.Turns > 0)
            {
                _queue.Enqueue(person);
            }
        }

        return person;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}
