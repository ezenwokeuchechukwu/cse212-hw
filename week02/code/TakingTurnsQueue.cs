public Person GetNextPerson()
{
    if (_people.IsEmpty())
    {
        throw new InvalidOperationException("No one in the queue.");
    }

    Person person = _people.Dequeue();

    if (person.Turns <= 0)
    {
        // Infinite turns, re-enqueue without decrement
        _people.Enqueue(person);
    }
    else if (person.Turns > 1)
    {
        person.Turns -= 1;
        _people.Enqueue(person);
    }
    // If person.Turns == 1, we return them and do NOT enqueue again

    return person;
}
