using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Lists
{
    class DoublyLinkedList
    {
        private class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }

            public Node(int data)
            {
                Data = data;
            }
        }
        private Node Head;
        public void InsertAtHead(int data)
        {
            Node node = new Node(data);
            if(IsEmpty())
            {
                Head = node;
                return;
            }
            Head.Prev = node;
            node.Next = Head;
            Head = node;
        }

        public void InsertAtTail(int data)
        {
            Node node = new Node(data);
            if (IsEmpty())
            {
                Head = node;
                return;
            }
            Node current = Head;
            // Traverse to the end of the list
            while(current.Next != null)
            {
                current = current.Next;
            }
            current.Next = node;
            node.Prev = current;
        }


        public void Print()
        {
            Node current = Head;
            Console.WriteLine("Forward");
            while(current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
        public void ReversePrint()
        {
            Node current = Head;
            // Empty list exit
            if (current == null)
                return;
            // Going to the last node
            while(current.Next != null)
            {
                current = current.Next;
            }
            // Traversing backward using prev pointer
            Console.WriteLine("Backward");
            while(current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Prev;
            }
        }
        private bool IsEmpty()
        {
            return Head == null;
        }
    }
}
