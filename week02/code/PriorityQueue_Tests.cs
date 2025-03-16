using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Adding a priority queue with the following value(priority)): "Register1(2)", "Register2(2)", "Register3(2)" and "Register4(2)"
    // Test if the enqueue adds the items in the correct order
    // Case if the priorities are the same, it should be dequeued in the order they were added
    // Expected Result: Register1, Register2, Register3, Register4
    // Defect(s) Found: Not in order, Dequeue is not working as expected, No removal of the item from the queue
    public void TestPriorityQueue_AddItems()
    {
        var Register1 = new PriorityItem("Register1", 2);
        var Register2 = new PriorityItem("Register2", 2);
        var Register3 = new PriorityItem("Register3", 2);
        var Register4 = new PriorityItem("Register4", 2);

        PriorityItem[] expectedResult = [Register1, Register2, Register3, Register4];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(Register1.Value, Register1.Priority);
        priorityQueue.Enqueue(Register2.Value, Register2.Priority);
        priorityQueue.Enqueue(Register3.Value, Register3.Priority);
        priorityQueue.Enqueue(Register4.Value, Register4.Priority);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, person);
        }
    }

    [TestMethod]
    // Scenario: Enqueue and Dequeue the following values with varied priority: "Register1(2)", "Register2(3)", "Register3(1)" and "Register4(4)"
    // Expected Result: Register4, Register2, Register1, Register3
    // Defect(s) Found: No issue found
    public void TestPriorityQueue_Priority()
    {
        var Register1 = new PriorityItem("Register1", 2);
        var Register2 = new PriorityItem("Register2", 3);
        var Register3 = new PriorityItem("Register3", 1);
        var Register4 = new PriorityItem("Register4", 4);

        PriorityItem[] expectedResult = [Register4, Register2, Register1, Register3];
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue(Register1.Value, Register1.Priority);
        priorityQueue.Enqueue(Register2.Value, Register2.Priority);
        priorityQueue.Enqueue(Register3.Value, Register3.Priority);
        priorityQueue.Enqueue(Register4.Value, Register4.Priority);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, person);
        }
    }

    [TestMethod]
    // Scenario: Enqueue and Dequeue the following values with the same priority: "Register1(2)", "Register2(3)", "Register3(3)" and "Register4(4)"
    // Expected Result: Register4, Register2, Register3, Register1
    // Defect(s) Found: It removes the highest priority first, but it should remove the first item added first, not the last
    public void TestPriorityQueue_SamePriority2()
    {
        var Register1 = new PriorityItem("Register1", 2);
        var Register2 = new PriorityItem("Register2", 3);
        var Register3 = new PriorityItem("Register3", 3);
        var Register4 = new PriorityItem("Register4", 4);

        PriorityItem[] expectedResult = [Register4, Register2, Register3, Register1];
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue(Register1.Value, Register1.Priority);
        priorityQueue.Enqueue(Register2.Value, Register2.Priority);
        priorityQueue.Enqueue(Register3.Value, Register3.Priority);
        priorityQueue.Enqueue(Register4.Value, Register4.Priority);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, person);
        }
    }

    [TestMethod]
    // Scenario: try to get the next Item in an empty queue
    // Expected Result: InvalidOperationException
    // Defect(s) Found: No Issue
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        
        try 
        {
            priorityQueue.Dequeue();
            Assert.Fail("An exception should have been thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}