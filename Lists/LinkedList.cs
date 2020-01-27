using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Lists
{
     
    class LinkedList
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
        private Node First;
        private Node Last;
        public void AddLast(int data)
        {
            Node node = new Node(data);
            if (IsEmpty())
            {
                First = Last = node;
            }
            else
            {
                Last.Next = node;
                Last = node;
            }
        }
        public void AddFirst(int data)
        {
            Node node = new Node(data);
            if (IsEmpty())
            {
                First = Last = node;
            }
            else
            {
                // This points to the node whose reference address was First
                // The actually value is located in the memory 
                node.Next = First;
                First = node;
            }
        }
        public void DeleteFirst()
        {
            if (IsEmpty())
                throw new MissingMemberException();

            if (First == Last)
            {
                First = Last = null;
                return;
            }
            // Store the second link for backup
            Node second = First.Next;
            // Remove the link
            First.Next = null;
            First = second;
        }
        public void Delete(int data)
        {
            if (IsEmpty())
                throw new MissingMemberException();

            if (First == Last)
            {
                First = Last = null;
                return;
            }

            Node current = First;
            int index = 0;
            while(current != null)
            {
                if (current.Data == data)
                {
                    DeleteAt(index);
                    return;
                }
                current = current.Next;
                index++;
            }

            throw new MissingMemberException();
        }
        public void DeleteAt(int index)
        {
            if (IsEmpty())
                throw new MissingMemberException();

            if (First == Last)
            {
                First = Last = null;
                return;
            }

            // This is tha same add first
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == 0)
            {
                DeleteFirst();
                // Return to stop execution of further algorithm
                return;
            }
            else if (index > IndexOf(Last.Data))
            {
                //throw new IndexOutOfRangeException();
                DeleteLast();
                return;
            }

            // Set the (n-1)th node as the previous
            Node previous = First;
            for(int i = 0; i < index - 1; i++)
            {
                previous = previous.Next;
            }

            // Node at the nth index
            Node current = previous.Next;

            // Link the (n-1)th node to (n+1)th node
            previous.Next = current.Next;

            // Free the nth node from the memory
            current = null;
        }
        public void DeleteLast()
        {
            if (IsEmpty())
            throw new MissingMemberException();

            if (First == Last)
            {
                First = Last = null;
                return;
            }
            Node previous = GetPreviousNode(Last);
            Last = previous;
            Last.Next = null;
        }
        public bool Contains(int data)
        {
            return IndexOf(data) != -1;
        }
        public int IndexOf(int data)
        {
            int index = 0;
            Node current = First;

            // We have not reach the end of this loop
            while(current != null)
            {
                if (current.Data == data)
                {
                    return index;
                }
                else
                {
                    current = current.Next;
                    index++;
                }
            }
            return -1;
        }
        public void InsertAt(int data, int index)
        {
            // This is tha same add first
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == 0)
            {
                AddFirst(data);
                // Return to stop execution of further algorithm
                return;
            }
            else if (index > IndexOf(Last.Data))
            {
                //throw new IndexOutOfRangeException();
                AddLast(data);
                return;
            }

            Node previous  = First;
            // Determine the node located before the intended index
            for(int i = 0; i < index - 1; i++)
            {
                previous = previous.Next;
            }

            Node node = new Node(data);

            // The Link of the newly created node is the next of the previous node
            node.Next = previous.Next;

            // The next of the pre
            previous.Next = node;
        }
        public void IterativeReverse()
        {
            // In the beginning the current node = First and the previous node is null
            Node previous = null;
            Node current = First;
            Node next;

            while (current != null)
            {
                if (current == First)
                {
                    Last = new Node(current.Data);
                }

                // Store the address of the next variable in order not to loose it
                next = current.Next;
                // Link the current node to the previous node instead of the next node
                current.Next = previous;
                // Move the previous to the current
                previous = current;
                // Move current to the next
                current = next;
            }
            // Set the First to the previous variable because the current is now null
            First = previous;
        }
        public void RecursiveReverse()
        {
            Last = new Node(First.Data);
            PRecursiveReverse(First);
        }
        public void StackReverse()
        {
            if (First == null)
                return;
            Node current = First;
            Stack<Node> stack = new Stack<Node>();
            // This pushes all the nodes into the stack
            while(current != null)
            {
                stack.Push(current);
                current = current.Next;
            }
            // The last node is placed on top of the stack
            current = stack.Pop();
            // Set the first node to be the one top of the stack
            First = current;
            while(stack.Count > 0)
            {
                current.Next = stack.Pop();
                current = current.Next;
            }
            current.Next = null;
        }
        public void Print()
        {
            PPrint(First);
        }
        public void ReversePrint()
        {
            IterativeReverse();
            PPrint(First);
        }
        private void PRecursiveReverse(Node node)
        {
            #region This region is executed during the forward move of recursion
            // This occurs when the last node has been traversed i.e. next = null
            if (node.Next == null)
            {
                // Set the head node to be the last node
                First = node;
                // Returns means when you encountered a node without its next, do not
                // Execute the backward move of recursion
                return;
            }
            PRecursiveReverse(node.Next);
            #endregion

            #region This region is executed in the backward move of recursion
            // Previous because we are now traversing the node backward, it is at index 1 from the reverse order
            Node previous = node.Next;
            previous.Next = node;
            node.Next = null;
            //node.Next.Next = node;
            #endregion

        }
        private void PPrint(Node node)
        {
            // For the last node, the recursion will return
            if (node == null)
                return;
            PPrint(node.Next);

            // At first this is not executed but in reverse order
            Console.WriteLine(node.Data);
        }
        private bool IsEmpty()
        {
            return First == null;
        }
        // Return the node that is before the one that is passed in
        private Node GetPreviousNode(Node node)
        {
            Node current = First;
            while(current != null)
            {
                if (current.Next == node)
                    return current;
                current = current.Next;
            }

            // Return null when you can find the specified node
            return null;
        }
    }
}
