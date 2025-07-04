
namespace AQueueProject;

/// <summary>
///  A generic fixed-size queue implemented using a circular buffer 
/// </summary>
/// <typeparam name="T"> The type of elements stored in the queue(can be of any type: int, string, etc.)</typeparam>
public class AQueue <T>
{
    private T[] _data;//Internal fixed-size array to hold the queue elements.
    private int _front;//Index of the front element (head) of the queue.
    private int _rear;//Index where the next element will be inserted (end of array).
    private int _capacity;//Maximum capacity of the queue.
    private int _size;//Current number of elements in the queue.

    
    /// <summary>
    /// Initializes a new instance of the AQueue class with a specified capacity.
    /// </summary>
    /// <param name="capacity">The fixed capacity of the queue.</param>
    public AQueue(int capacity)
    {
        _data = new T [capacity];
        _front = 0;
        _rear = 0;
        _capacity = capacity;
        _size = 0;
    }
    
    public int Size=> _size;//Gets the current number of elements in the queue.
    public int Capacity => _capacity;//Gets the fixed capacity of the queue.


    
    /// <summary>
    /// Adds a new item to the rear of the queue.
    /// </summary>
    /// <param name="item">The item to add to the queue.</param>
    /// <exception cref="InvalidOperationException">Thrown when the queue is full.</exception>
    public void Enqueue(T item)
    {
        if (_size == _capacity)
            throw new InvalidOperationException("Capacity exceed");
        
        _data[_rear] = item;
        _rear = (_rear + 1) % _capacity;
        _size++;
    }

    /// <summary>
    /// Removes and returns the item at the front of the queue.
    /// </summary>
    /// <returns>The front item in the queue.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
    public T Dequeue()
    {
        if (_size == 0)
        
            throw new InvalidOperationException("Queue is empty");
        T item = _data[_front];
        _data[_front] = default!;
        _front = (_front + 1) % _capacity;
        _size--;
        return item;
    }

    /// <summary>
    /// Returns the item at the front of the queue without removing it.
    /// </summary>
    /// <returns>The front item in the queue.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
    public T Peek()
    {
        if (_size == 0)
            throw new InvalidOperationException("Queue is empty");
        return _data[_front];
    }

    
    /// <summary>
    /// Determines whether the queue contains a specific item.
    /// </summary>
    /// <param name="item">The item to locate in the queue.</param>
    /// <returns>True if the item is found; otherwise, false.</returns>
    public bool Contains(T item)
    {
        for (int i = 0; i < _size; i++)
        {
            int index = (_front + i) % _capacity;
            if (Equals(_data[index], item))
                return true;
            
        }
        return false;
    }
}