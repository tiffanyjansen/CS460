namespace BitTranslate
{
    /// <summary>
    /// A FIFO queue interface. This ADT is suitable for a singly 
    /// linked queue.
    /// </summary>
    interface IQueue<T>
    {
        /// <summary>
        /// Add an element to the rear of the queue
        /// </summary>
        /// <param name="Element"></param>
        /// <returns>The element that was enqueued</returns>
        T push(T Element);

        /// <summary>
        /// Remove and return the front element.
        /// </summary>
        /// <returns>The element that was dequeued</returns>
        /// <exception cref="QueueUnderflowException">Thrown if the queue is empty</exception>
        T pop();

        /// <summary>
        /// Test if the queue is empty
        /// </summary>
        /// <returns>true if the queue is empty; otherwise false</returns>
        bool isEmpty();
    }
}
