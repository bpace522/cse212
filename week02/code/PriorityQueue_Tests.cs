using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Adding 4 different items with distinct priorities for each. Adding lowest priority to the front and highest to the back
    // Expected Result: highest priority taken out first, Root Beer, Ginger Ale, Mini, Shield Pot
    // Defect(s) Found: Dequeue method was never removing the item from the queue which was changed adding _queue.RemoveAt()
    public void TestPriorityQueue_1()
    {
        var data1 = new PriorityItem("Shield Pot", 1);
        var data2 = new PriorityItem("Mini", 2);
        var data3 = new PriorityItem("Ginger Ale", 3);
        var data4 = new PriorityItem("Root Beer", 4);

        PriorityItem[] expectedResult = [data4, data3, data2, data1];

        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue(data1.Value, data1.Priority);
        priorityQueue.Enqueue(data2.Value, data2.Priority);
        priorityQueue.Enqueue(data3.Value, data3.Priority);
        priorityQueue.Enqueue(data4.Value, data4.Priority);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }
            Console.WriteLine(priorityQueue);
            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, person);
        }
    }

    [TestMethod]
    // Scenario: Adding more than one item with highest priority
    // Expected Result: The highest priority closest to the front will be removed first. 
    // Defect(s) Found: The Dequeue method was returning the last item with highest priority instead of first because it was 
    // >= instead of >
    public void TestPriorityQueue_2()
    {
        var data1 = new PriorityItem("curse", 1);
        var data2 = new PriorityItem("forge", 2);
        var data3 = new PriorityItem("ghast", 2);

        PriorityItem[] expectedOutput = [data2, data3, data1];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(data1.Value, data1.Priority);
        priorityQueue.Enqueue(data2.Value, data2.Priority);
        priorityQueue.Enqueue(data3.Value, data3.Priority);

        for (int i = 0; i < expectedOutput.Length; i++)
        {
            Console.WriteLine(priorityQueue);
            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedOutput[i].Value, person);
        }
    }


    [TestMethod]
    //Scenario: Testing an empty queue, confirming the thrown error and message
    // Expected Result: Correct error thrown, and correct message displayed
    // Defect(s) found: 
    public void TestPriorityQueue_3()
    {
        var priorityQueueempty = new PriorityQueue();
        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueueempty.Dequeue());

        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    // Add more test cases as needed below.
}