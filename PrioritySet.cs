namespace AoC2023;

public class PrioritySet<T, K>
{
    public PriorityQueue<T, K> Queue { get; set; } = new PriorityQueue<T, K>();
    public HashSet<T> Set { get; set; } = new HashSet<T>();

    public int Count => Queue.Count;
    public T Dequeue() => Queue.Dequeue();
    public bool Enqueue(T item, K prio)
    {
        if (!Set.Contains(item))
        {
            Queue.Enqueue(item, prio);
            Set.Add(item);
            return true;
        }
        return false;
    }
}