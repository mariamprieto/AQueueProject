namespace AQueueTest;
using NUnit.Framework;
using AQueueProject;

public class BasicTests
{
    
    [Test]
    public void TestAQueue1()
    {
        // Test 1
        // Scenario: Enqueue two values and check the size
        // Expected Result: It should display size = 2
        var queue = new AQueue<int>(5);
        queue.Enqueue(100);
        queue.Enqueue(200);
        Assert.That(queue.Size, Is.EqualTo(2));
        // Defect(s) Found:
    }
    
    [Test]
    public void TestAQueue2()
    {
        // Test 2
        // Scenario: Check capacity is set correctly
        // Expected Result: Capacity should be exactly the value given (5)
        var queue = new AQueue<string>(5);
        Assert.That(queue.Capacity, Is.EqualTo(5));
        // Defect(s) Found:
    }
    
    [Test]
    public void TestAQueue3()
    {
        // Test 3
        // Scenario: Enqueue one value and then Dequeue it.
        // Expected Result: It should display "A"
        var queue = new AQueue<string>(3);
        queue.Enqueue("A");
        var result = queue.Dequeue();
        Assert.That(result, Is.EqualTo("A"));
        // Defect(s) Found:
    }

    [Test]
    public void TestAQueue4()
    {
        // Test 4
        // Scenario: Enqueue multiple values and then Dequeue all of them
        // Expected Result: It should display 200, then 300, then 400 in that order
        var queue = new AQueue<int>(5);
        queue.Enqueue(200);
        queue.Enqueue(300);
        queue.Enqueue(400);
        Assert.That(queue.Dequeue(), Is.EqualTo(200));
        Assert.That(queue.Dequeue(), Is.EqualTo(300));
        Assert.That(queue.Dequeue(), Is.EqualTo(400));
        // Defect(s) Found: 
    }

    
    
    [Test]
    public void TestAQueue5()
    {
        // Test 5
        // Scenario: Enqueue values and call Peek
        // Expected Result: It should return the first value without removing it
        var queue = new AQueue<int>(5);
        queue.Enqueue(200);
        queue.Enqueue(300);
        
        var peekedValue = queue.Peek();
        Assert.That(peekedValue, Is.EqualTo(200));
        Assert.That(queue.Size, Is.EqualTo(2));
        // Defect(s) Found: 
    }
   
    [Test]
    public void TestLQueue6()
    {
        // Test 6
        // Scenario: Enqueue values and check if Contains finds them
        // Expected Result: Should return true for inserted values and false for others
        var queue = new AQueue<string>(5);
        queue.Enqueue("apple");
        queue.Enqueue("orange");
        
        
        Assert.That(queue.Contains("apple"), Is.True);
        Assert.That(queue.Contains("orange"), Is.True);
        Assert.That(queue.Contains("cherry"), Is.False);
        // Defect(s) Found: 
    }
}