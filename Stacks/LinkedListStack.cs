using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stacks
{
    class LinkedListStack
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
        private Node Top;

        public void Push(int data)
        {
            Node node = new Node(data);
            node.Next = Top;
            Top = node;
        }

        public void Pop()
        {
            if (Top == null)
                return;
            // Store address of the second node
            Node second = Top.Next;
            // Free the link
            Top.Next = null;
            // Set the second node as the top one
            Top = second;
        }
        public int GetTop()
        {
            if (Top == null)
            {
                Console.WriteLine("Error: No element on top");
                return -1;
            }
            return Top.Data;
        }
        public bool IsEmpty()
        {
            return Top == null;
        }
        public void Print()
        {
            Console.WriteLine("Stack:");
            Node current = Top;
            while(current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
}
