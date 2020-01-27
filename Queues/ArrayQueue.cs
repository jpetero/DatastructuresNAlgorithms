using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Queues
{
    class ArrayQueue
    {
        private int Front = -1;
        private int Rear = -1;
        private const int MAX_SIZE = 10;
        private int[] A = new int[MAX_SIZE];

        public bool IsEmpty()
        {
            return (Front == -1 && Rear == -1);
        }
        public bool IsFull()
        {
            return (Rear == A.Length - 1);
        }

        public void Enqueue(int data)
        {
            // The next position of rear brings us back to the front
            if ((Rear + 1) % MAX_SIZE == Front)
                return;
            else if (IsFull())
                return;
            else if (IsEmpty())
                Front = Rear = 0;
            else
                Rear = (Rear + 1) % MAX_SIZE;
            A[Rear] = data;
        }
        public int Dequeue()
        {
            int current = Front;
            if (IsEmpty())
                return -1;
            else if (Front == Rear)
                Front = Rear = -1;
            else
            {
                Front = (Front + 1) % MAX_SIZE;
                current = Front;
            }
              
            return A[current];
        }

        public int Peek()
        {
            return A[Front];
        }
    }
}
