using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them. Items should come out in priority order.
    // Enqueue: "Low" (1), "Medium" (3), "High" (5), "VeryHigh" (10)
    // Expected Result: Dequeue returns VeryHigh, High, Medium, Low
    // Defect(s) Found: Loop in Dequeue only checks up to Count-1, missing the last item. Item not removed after dequeue. 
    public void TestPriorityQueue_DifferentPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("VeryHigh", 10);

        Assert.AreEqual("VeryHigh", priorityQueue.Dequeue());
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with same priority. When dequeuing, the first one added (FIFO) should come out first.
    // Enqueue: "First" (5), "Second" (5), "Third" (5)
    // Expected Result: Dequeue returns First, Second, Third (FIFO order)
    // Defect(s) Found: Uses >= for priority comparison instead of >, causing later items to replace earlier ones with same priority (violates FIFO). 
    public void TestPriorityQueue_SamePriority_FIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mix of priorities where highest priority items should come out first, but among same priority, FIFO applies.
    // Enqueue: "A" (3), "B" (5), "C" (3), "D" (5), "E" (1)
    // Expected Result: B, D (both priority 5, FIFO), then A, C (both priority 3, FIFO), then E
    // Defect(s) Found: Uses >= instead of > for priority comparison, violating FIFO. Loop stops at Count-1 instead of Count. 
    public void TestPriorityQueue_MixedPriorities_FIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 5);
        priorityQueue.Enqueue("E", 1);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("E", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None - exception is thrown correctly with correct message. 
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Enqueue single item and dequeue it
    // Expected Result: Item is returned correctly
    // Defect(s) Found: Loop stops at Count-1, so with only one item (index 0), the loop doesn't run and index stays 0. Item not removed. 
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("OnlyItem", 5);

        Assert.AreEqual("OnlyItem", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Verify items are always added to the back (order preserved until dequeue)
    // Enqueue: "Item1" (1), "Item2" (2), "Item3" (3)
    // Expected Result: Highest priority (3) comes out first, even though it was added last
    // Defect(s) Found: Loop stops at Count-1, missing the last item with highest priority. Item not removed from queue. 
    public void TestPriorityQueue_AddToBack()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        priorityQueue.Enqueue("Item2", 2);
        priorityQueue.Enqueue("Item3", 3);

        Assert.AreEqual("Item3", priorityQueue.Dequeue());
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
    }
}