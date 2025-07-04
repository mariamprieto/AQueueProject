namespace AQueueTest;
using AQueueProject;
using NUnit.Framework;

public class EdgeTests
{
    [Test]
    public void EdgeTestAQueue1()
    {
        // Test 1
        // Scenario: Dequeue from an empty Queue
        // Expected Result: An exception should be raised
        var queue = new AQueue<int>(5);
        try {
            queue.Dequeue();
            Assert.Fail("Oops ... Exception expected.");
        }
        catch (InvalidOperationException) {
            Console.WriteLine("I got the exception as expected.");
        }
        // Defect(s) Found
    }
    [Test]
    public void EdgeTestAQueue2()
    {
        // Test 2
        // Scenario: Peek from an empty queue
        // Expected Result: An exception should be raised
        var queue = new AQueue<int>(3);
        try {
            queue.Peek();
            Assert.Fail("Oops ... Exception expected.");
        }
        catch (InvalidOperationException) {
            Console.WriteLine("I got the exception as expected.");
        }
        // Defect(s) Found
    }

    [Test]
    public void EdgeTestAQueue3()
    {
        // Test 3
        // Scenario: Enqueue into a full queue
        // Expected Result: Should throw exception
        var queue = new AQueue<int>(2);
        queue.Enqueue(1);
        queue.Enqueue(2);

        try
        {
            queue.Enqueue(3);
            Assert.Fail("Oops ... Exception expected.");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("I got the exception as expected.");
        }
        // Defect(s) Found 
    }

    [Test]
    public void EdgeTestAQueue4()
    {
        // Test 4
        // Scenario: Test circular behavior when rear and front wrap around
        // Expected Result: Queue should still work and return correct order
        var queue = new AQueue<int>(3);
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Dequeue();
        queue.Enqueue(3);
        queue.Enqueue(4);
        
        Assert.That(queue.Dequeue(), Is.EqualTo(2));
        Assert.That(queue.Dequeue(), Is.EqualTo(3));
        Assert.That(queue.Dequeue(), Is.EqualTo(4));
        // Defect(s) Found:
    }
}
