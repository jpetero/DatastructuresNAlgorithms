using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Trees
{
    class BstSearchTree
    {
        private class BstNode
        {
            public int Data { get; set; }
            public BstNode Left { get; set; }
            public BstNode Right { get; set; }

            public BstNode(int data)
            {
                Data = data;
            }
        }
        private BstNode Root; // This points to the root node in the heap
        private List<int> Numbers = new List<int>();
        public void Insert(int data)
        {
            Root = InsertAtNode(Root, data);
        }

        public bool Search(int data)
        {
            return IsInTree(Root, data);
        }
        public void PreOrderPrint()
        {
            PPreOrderPrint(Root);
        }
        private void PPreOrderPrint(BstNode node)
        {
            if (node == null)
                return;
            Console.WriteLine(node.Data);
            PPreOrderPrint(node.Left);
            PPreOrderPrint(node.Right);
        }
        // This prints sorted list
        public void InOrderPrint()
        {
            PInOrderPrint(Root);
        }
        private void PInOrderPrint(BstNode node)
        {
            if (node == null)
                return;
            PInOrderPrint(node.Left);
            Console.WriteLine(node.Data);
            PInOrderPrint(node.Right);
        }
        public bool IsBinarySearchTree()
        {
            TravserseBinarySearchTree(Root);
            if (Numbers.Count == 0)
                return true;
            for (int i = 0; i < Numbers.Count; i++)
            {
                int current = Numbers[0];
                if (Numbers[i] >= current)
                {
                    current = Numbers[i];
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        private void TravserseBinarySearchTree(BstNode node)
        {
            if (node == null)
                return;
            TravserseBinarySearchTree(node.Left);
            Numbers.Add(node.Data);
            TravserseBinarySearchTree(node.Right);
        }
        public void Delete(int data)
        {
            PDelete(Root, data);
        }
        private BstNode PDelete(BstNode node, int data)
        {
            if (node == null)
                node = null;
            else if (data < node.Data) // The data to be deleted is located in the left sub-tree
                node.Left = PDelete(node.Left, data);
            else if (data > node.Data) // The data to be deleted is located in the right sub-tree
                node.Right = PDelete(node.Right, data);
            else // Wohoo... I found, get ready to be deleted
            {
                // Case 1: No child
                if (node.Left == null && node.Right == null)
                {
                    node = null;
                }
                // Case 2: One right child 
                else if (node.Left == null)
                    node = node.Right;
                // Case 3: One left child 
                else if (node.Right == null)
                    node = node.Left;
                else
                {
                    BstNode current = PFindMin(node.Right);
                    node.Data = current.Data;
                    node.Right = PDelete(node.Right, current.Data);
                }
            }
            return node;
        }
        public void PostOrderPrint()
        {
            PPostOrderPrint(Root);
        }
        private void PPostOrderPrint(BstNode node)
        {
            if (node == null)
                return;
            PInOrderPrint(node.Left);
            PInOrderPrint(node.Right);
            Console.WriteLine(node.Data); 
        }
        public void LevelOrderPrint()
        {
            PLevelOrderPrint(Root);
        }
        private void PLevelOrderPrint(BstNode node)
        {
            if (node == null)
                return;
            Queue<BstNode> bstNodes = new Queue<BstNode>();
            bstNodes.Enqueue(node);
            // While there is atleast one discovered node
            while(bstNodes.Count > 0)
            {
                BstNode current = bstNodes.Dequeue();
                Console.WriteLine(current.Data);
                if (current.Left != null)
                    bstNodes.Enqueue(current.Left);
                if (current.Right != null)
                    bstNodes.Enqueue(current.Right);
            }
        }
        public int FindMin()
        {
            if (Root == null)
                return -1;
            return PFindMin(Root).Data;
        }
        private BstNode PFindMin(BstNode node)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.Left == null)
            {
                return node;
            }
            else
            {
                // Search in the left sub-tree
                return PFindMin(node.Left);
            }
        }   
        public int IterativeFindMin()
        {
            if (Root == null)
            {
                Console.WriteLine("The tree is empty");
                return -1;
            }
            BstNode current = Root;
            // The node with no left-child is the minimum one
            while(current.Left != null)
            {
                current = current.Left;
            }
            return current.Data;
        }
        public int IterativeFindMax()
        {
            if (Root == null)
            {
                Console.WriteLine("The tree is empty");
                return -1;
            }
            BstNode current = Root;
            // The node with no right-child is the maximum one
            while (current.Right != null)
            {
                current = current.Right;
            }
            return current.Data;
        }
        public int FindHeight()
        {
            return PFindHeight(Root);
        }
        private int PFindHeight(BstNode node)
        {
            if (node == null)
                return -1;
            int leftHeight = PFindHeight(node.Left);
            int rightHeight = PFindHeight(node.Right);
            if (leftHeight > rightHeight)
            {
                return leftHeight + 1;
            }
            else
            {
                return rightHeight + 1;
            }
        }
        public int FindMax()
        {
            if (Root == null)
                return -1;
            return PFindMax(Root).Data;
        }
        private BstNode PFindMax(BstNode node)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.Right == null)
            {
                return node;
            }
            else
            {
                // Search in the right sub-tree
                return PFindMax(node.Right);
            }
        }
        //  Insert the data at the specified node, insertion takes place when link is null
        private BstNode InsertAtNode(BstNode node, int data)
        {
            // Insertion only occurs when the pointer is pointing to null
            if (node == null)
                node = new BstNode(data);
            // Insert on the left
            else if (data <= node.Data)
            {
                node.Left = InsertAtNode(node.Left, data);
            }
            else
            {
                node.Right = InsertAtNode(node.Right, data);
            }
            return node;
        }
        private bool IsInTree(BstNode node, int data)
        {
            if (node == null)
                return false;
            else if (node.Data == data)
                return true;
            else if (data <= node.Data)
                return IsInTree(node.Left, data);
            else
                return IsInTree(node.Right, data);
        }
        public int GetSuccessor(int data)
        {
            return PGetSuccessor(Root, data).Data;
        }
        // Function to find in-order successor in a BST
        private BstNode PGetSuccessor(BstNode node, int data)
        {
            // Search the node O(h)
            BstNode current = Find(node, data);
            if (current == null)
                return null;
            if (current.Right != null) // Case 1: Node has right sub-tree
            {
                return PFindMin(current.Right);
            }
            else // No right sub-tree
            {
                BstNode successor = null;
                BstNode ancestor = node;
                while(ancestor != current)
                {
                    if (current.Data < ancestor.Data)
                    {
                        successor = ancestor; // So far this is the deepest node for which current node is in left
                        ancestor = ancestor.Left;
                    }
                    else
                    {
                        ancestor = ancestor.Right;
                    }
                }
                return successor;
            }
        }

        private BstNode Find(BstNode node, int data)
        {
            if (node == null)
                return null;
            else if (node.Data == data)
                return node;
            else if (data <= node.Data)
                return Find(node.Left, data);
            else
                return Find(node.Right, data);
        }
    }
}
