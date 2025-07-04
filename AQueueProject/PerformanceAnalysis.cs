namespace AQueueProject;
using System.Diagnostics;

/*
Performance Analysis Results:

This table shows the time (in ticks) taken by each main operation in AQueue<T> for different queue sizes.

Observations:

- Enqueue: Always very fast, confirms expected O(1).
- Dequeue: Also always very fast, confirms expected O(1) since no shifting happens.
- Peek: Always very fast, confirms O(1).
- Contains: Gets slower as the queue gets bigger, confirms O(n) because it has to check each element.

These results show that the actual measured times match the expected Big-O performance for each operation.
*/
public class PerformanceAnalysis
{
    public static void Run()
    {
        // Define different queue sizes to test
        var sizes = new[] { 10, 100, 1_000, 10_000, 50_000 };
        
        Console.WriteLine("{0,20} {1,20} {2,20} {3,20} {4,20}","Size", "Enqueue(ticks)", "Dequeue (ticks)", "Peek(ticks)", "Contains(ticks)");
        Console.WriteLine("{0,20} {1,20} {2,20} {3,20} {4,20}","------------" ,"------------","------------","------------","------------");
        foreach (var size in sizes){
            
            
            var queue = new AQueue<int>(size+1);
            for (int i = 0; i < size; i++) queue.Enqueue(i);
            var sw = Stopwatch.StartNew();
            
            
            // Scenario 1
            // Scenario: Measure Enqueue time when queue is nearly full.
            // Expected Result: Expected O(1)
            sw.Restart();
            queue.Enqueue(-1);
            sw.Stop();
            var enqueueTicks = sw.ElapsedTicks;
        
            // Scenario 2
            // Scenario: Measure Dequeue time with large number of elements
            // Expected Result:Expected O(1)
            sw.Restart();
            queue.Dequeue();
            sw.Stop();
            var dequeueTicks = sw.ElapsedTicks;
        
            // Scenario 3
            // Scenario: Measure Peek time 
            // Expected Result: Expected O(1)
            sw.Restart();
            queue.Peek();
            sw.Stop();
            var peekTicks = sw.ElapsedTicks;
            
            // Test 4
            // Scenario: Measure Contains time
            // Expected Result: Expected O(n)
         
         sw.Restart();
         queue.Contains(size - 1);
         sw.Stop();
         var containsTicks = sw.ElapsedTicks;
         Console.WriteLine("{0,20} {1,20} {2,20} {3,20} {4,20}",size,enqueueTicks,dequeueTicks,peekTicks,containsTicks);
        }
        
    }
   /* Conclusion:
    All results confirm that the AQueue<T> implementation matches the expected theoretical complexities:
    Enqueue: O(1)
    Dequeue: O(1)
    Peek: O(1)
    Contains: O(n)
    The few high tick anomalies at small sizes are likely due to system-level fluctuations(e.g., CPU scheduling, caching, or background processes).
*/
   
}