using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stacks
{
    class ArrayStack
    {
        // Global variables can be accessed anywhere within the class
        private const int MAX_SIZE = 101;
        private int[] A = new int[MAX_SIZE];
        private int Top = -1;

        public void Push(int data)
        {
            if (Top == MAX_SIZE - 1)
                throw new StackOverflowException();
            A[++Top] = data;
        }
        public int[] ReverseArray(int[] numbers)
        {

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                stack.Push(numbers[i]);
            }
            for (int i = 0; i < numbers.Length; i++)
            {       
                numbers[i] = stack.Pop();
            }
            return numbers;
        }
        public void Pop()
        {
            if (Top == -1)
            {
                Console.WriteLine("Error: No element to pop");
                return;
            }
            Top--;
        }
        public int GetTop()
        {
            if (Top == -1)
            {
                Console.WriteLine("Error: No element on top");
                return -1;
            }
            return A[Top];
        }
        public bool IsEmpty()
        {
            return Top == -1;
        }
        public void Print()
        {
            Console.WriteLine("Stack:");
            for (int i = 0; i <= Top; i++)
            {
                Console.WriteLine(A[i]);
            }
        }
    }
}
