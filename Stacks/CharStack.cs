using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stacks
{
    class CharStack
    {
        // Global variables can be accessed anywhere within the class
        private const int MAX_SIZE = 101;
        private char[] A = new char[MAX_SIZE];
        private int Top = -1;

        public void Push(char data)
        {
            if (Top == MAX_SIZE - 1)
                throw new StackOverflowException();
            A[++Top] = data;
        }

        public void Pop()
        {
            if (Top == -1)
            {
                Console.WriteLine("Error: No character to pop");
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
        public static string ReverseString(string s)
        {
            Stack<char> stack = new Stack<char>();
            // Loop for push
            for (int i = 0; i < s.Length; i++)
            {
                stack.Push(s[i]);
            }

            StringBuilder reversedString = new StringBuilder();
            
            // Loop for pop
            for (int i = 0; i < s.Length; i++)
            {
                reversedString.Append(stack.Pop());
            }
            return  reversedString.ToString();
        }
        public static bool AreParenthesesBalance(string expression)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(' || expression[i] == '{' || expression[i] == '[')
                {
                    stack.Push(expression[i]);
                }
                else if (expression[i] == ')' || expression[i] == '}' || expression[i] == ']')
                {
                    if (stack.Count == 0 || !ArePair(stack.Peek(), expression[i]))
                    {
                        return false;
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }
            return stack.Count == 0 ? true : false;
        }
        public static int EvaluatePostfix(string expression)
        {
            Stack<int> stack = new Stack<int>();
            string[] splittedEXpression = expression.Split(',');
            for (int i = 0; i < splittedEXpression.Length; i++)
            {
                int splitResult;
                if (int.TryParse(splittedEXpression[i], out splitResult))
                {
                    stack.Push(splitResult);
                }
                else if (splittedEXpression[i] == "+" || splittedEXpression[i] == "-" || splittedEXpression[i] == "*" || splittedEXpression[i] == "/")
                {
                    int operand2 = stack.Pop();
                    int operand1 = stack.Pop();
                    int result = CalculateResult(operand1, operand2, splittedEXpression[i]);
                    stack.Push(result);
                }
            }
            return stack.Peek();
        }
        public static int EvaluatePostfix2(string expression)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (char.IsDigit(expression[i]))
                {
                    stack.Push((int)char.GetNumericValue(expression[i]));
                }
                else if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/')
                {
                    int operand2 = stack.Pop();
                    int operand1 = stack.Pop();
                    int result = CalculateResult2(operand1, operand2, expression[i]);
                    stack.Push(result);
                }
            }
            return stack.Peek();
        }
        public static int EvaluatePrefix(string expression)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = expression.Length - 1 ; i >= 0; i--)
            {
                if (char.IsDigit(expression[i]))
                {
                    stack.Push((int)char.GetNumericValue(expression[i]));
                }
                else if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/')
                {
                    int operand1 = stack.Pop();
                    int operand2 = stack.Pop();
                    int result = CalculateResult3(operand1, operand2, expression[i]);
                    stack.Push(result);
                }
            }
            return stack.Peek();
        }
        public static string InfixToPostfix(string expression)
        {
            Stack<char> stack = new Stack<char>();
            string result = "";
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/')
                {
                    result += expression[i];
                }
                else if (!char.IsDigit(expression[i]))
                {
                    while(stack.Count > 0 && HasHigherPrecedence(stack.Peek(), expression[i]))
                    {
                        result += stack.Pop();
                    }
                    stack.Push(expression[i]);
                }
            }
            while(stack.Count > 0)
            {
                result += stack.Pop();
            }
            return result;
        }
        private static bool HasHigherPrecedence(char operator1, char operator2)
        {
            char[] operators = { '+', '-', '*', '/', '[' };
            int indexOfOperator1 = 0;
            int indexOfOperator2 = 0;
            for (int i = 0; i < operators.Length; i++)
            {
                if (operators[i] == operator1)
                    indexOfOperator1 = i;
                if (operators[i] == operator2)
                    indexOfOperator2 = i;
            }
            return (indexOfOperator1 > indexOfOperator2);
        }
        private static int CalculateResult3(int operand1, int operand2, char infix)
        {
            int result;

            if (infix == '+')
            {
                result = operand1 + operand2;
            }
            else if (infix == '-')
            {
                result = operand1 - operand2;
            }
            else if (infix == '*')
            {
                result = operand1 * operand2;
            }
            else if (infix == '/')
            {
                result = operand1 / operand2;
            }
            else
            {
                throw new InvalidOperationException();
            }
            return result;
        }
        private static bool ArePair(char opening, char closing)
        {
            if (opening == '(' && closing == ')')
                return true;
            else if (opening == '{' && closing == '}')
                return true;
            else if (opening == '[' && closing == ']')
                return true;
            return false;
        }
        private static int CalculateResult(int operand1, int operand2, string infix)
        {
            int result;

            if (infix == "+")
            {
                result = operand1 + operand2;
            }
            else if (infix == "-")
            {
                result = operand1 - operand2;
            }
            else if (infix == "*")
            {
                result = operand1 * operand2;
            }
            else if (infix == "/")
            {
                result = operand1 / operand2;
            }
            else
            {
                throw new InvalidOperationException();
            }
            return result;
        }
        private static int CalculateResult2(int operand1, int operand2, char infix)
        {
            int result;

            if (infix == '+')
            {
                result = operand1 + operand2;
            }
            else if (infix == '-')
            {
                result = operand1 - operand2;
            }
            else if (infix == '*')
            {
                result = operand1 * operand2;
            }
            else if (infix == '/')
            {
                result = operand1 / operand2;
            }
            else
            {
                throw new InvalidOperationException();
            }
            return result;
        }
    }
}
