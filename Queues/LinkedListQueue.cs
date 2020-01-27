namespace DataStructures.Queues
{
    class LinkedListQueue
    {
        private class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }

            public Node(int data)
            {
                Data = data;
            }
        }
        private Node Front;
        private Node Rear;

        public void Enqueue(int data)
        {
            Node node = new Node(data);
            if (Front == null && Rear == null)
            {
                Front = Rear = node;
                return;
            }
            // Rear is linked to null
            Rear.Next = node;
            Rear = node;
        }
        public void Dequeue()
        {
            Node current = Front;
            if (Front == null)
                return;
            if (Front == Rear)
                Front = Rear = null;
            else
            {
                Front = Front.Next;
            }
            current = null;
        }
    }   
}
