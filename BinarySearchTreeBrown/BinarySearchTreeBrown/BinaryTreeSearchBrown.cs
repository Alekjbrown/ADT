using System;
using System.Collections.Generic;
/** this program demonstrates binary search trees */

//Aleksander Brown CIS152

namespace BinarySearchTreeBrown
{
    class BinaryTreeSearchBrown
    {
        static void Main(string[] args)
        {
            Node temp;
            //construct tree
            BinarySearchTree boys = new BinarySearchTree();

            ////fill tree
            //boys.Insert(1, "Noah");
            //boys.Insert(2, "Liam");
            //boys.Insert(3, "Mason");
            //boys.Insert(4, "Jacob");
            //boys.Insert(5, "William");
            //boys.Insert(6, "Ethan");
            //boys.Insert(7, "James");
            //boys.Insert(8, "Alexander");
            //boys.Insert(9, "Michael");
            //boys.Insert(10, "Benjamin");

            boys.Insert(8, "Noah");
            boys.Insert(3, "Liam");
            boys.Insert(6, "Emma");
            boys.Insert(1, "Jacob");
            boys.Insert(7, "Sophia");
            boys.Insert(4, "Isabella");
            boys.Insert(10, "William");
            boys.Insert(14, "Mia");
            boys.Insert(13, "James");

            //hold search values to reduce driver code
            // String[] sArray = { "Noah", "Liam", "Mason", "Jacob", "William", "Ethan", "James",
            //     "Alexander", "Michael", "Benjamin", "Aleksander", "Amelia" };
            int[] sArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            //search tree for values in array and print each one as found
            Console.WriteLine("Search and Print Boys");
            for (int i = 0; i < sArray.Length; i++)
            {
                temp = boys.Search(sArray[i]);
                if (temp != null)
                {
                    Console.WriteLine(temp.IData + " " + temp.SData);
                }
                else
                {
                    Console.WriteLine(sArray[i] + " not found!");
                }
            }
            Console.WriteLine();

            ////declare and init girls binary tree
            //BinarySearchTree girls = new BinarySearchTree();
            //girls.Insert(1, "Emma");
            //girls.Insert(2, "Olivia");
            //girls.Insert(3, "Sophia");
            //girls.Insert(4, "Ava");
            //girls.Insert(5, "Isabella");
            //girls.Insert(6, "Mia");
            //girls.Insert(7, "Abigail");
            //girls.Insert(8, "Emily");
            //girls.Insert(9, "Charlotte");
            //girls.Insert(10, "Harper");

            ////hold search values to reduce driver code
            //String[] gArray = { "Emma", "Olivia", "Sophia", "Ava", "Isabella", "Mia", "Abigail",
            //    "Emily", "Charlotte", "Harper", "Aleyna", "Aleksander" };
            ////search tree for values in array and print as found
            //Console.WriteLine("Search and Print Girls");
            //for (int i = 0; i < gArray.Length; i++)
            //{
            //    temp = girls.Search(gArray[i]);
            //    if (temp != null)
            //    {
            //        Console.WriteLine(temp.SData + " " + temp.IData);
            //    }
            //    else
            //    {
            //        Console.WriteLine(gArray[i] + " not found!");
            //    }
            //}
            //Console.WriteLine();

            //Print traversal for BFS using queue
            Console.WriteLine("BFS Traversal");
            boys.BFS();
            Console.WriteLine();

            //print traversal for DFS using stack
            Console.WriteLine("DFS Traversal");
            boys.DFS();
            Console.WriteLine();

            //prints a dfs traversal recursion instead of calling a stack, order reversed from stack method
            Console.WriteLine("Print post order");
            boys.printPostorder();
            Console.WriteLine();
        }
    }

    public class Node
    {
        private String _sData;
        private int _iData;
        private Node _leftChild;
        private Node _rightChild;

        public Node(int intData, String stringData)
        {
            _sData = stringData;
            _iData = intData;
            _leftChild = null;
            _rightChild = null;
        }

        public String SData { get { return _sData; } set { _sData = value; } }
        public int IData { get { return _iData; } set { _iData = value; } }
        public Node LeftChild { get { return _leftChild; } set { _leftChild = value; } }
        public Node RightChild { get { return _rightChild; } set { _rightChild = value; } }
    }

    public class BinarySearchTree
    {
        //root of tree
        private Node _root;
        private int _length;

        public Node Root { get { return _root; } }
        public int Length { get { return _length; } }
        //constructor
        public BinarySearchTree()
        {
            _root = null;
            _length = 0;

        }

        //calls recursive insert
        public void Insert(int intData, String stringData)
        {
            _root = InsertRec(_root, intData, stringData);
            _length++;
        }
        //insert new node in tree recursively
        public Node InsertRec(Node root, int intData, String stringData)
        {
            //if empty return new node
            if (root == null)
            {
                root = new Node(intData, stringData);
                return root;
            }

            //otherwise recur down the tree
            if (intData < root.IData)
            //if (String.Compare(stringData, root.SData) < 0)
            {
                root.LeftChild = InsertRec(root.LeftChild, intData, stringData);
            }
            else if (intData > root.IData)
            //else if (String.Compare(stringData, root.SData) > 0)
            {
                root.RightChild = InsertRec(root.RightChild, intData, stringData);
            }

            //return unchanged node pointer
            return root;
        }

        //calls recursive function to traverse in order
        public void InOrder()
        {
            InOrderRec(_root);
        }

        //does in order traversal of tree & prints to console
        public void InOrderRec(Node root)
        {
            if (root != null)
            {
                InOrderRec(root.LeftChild);
                Console.WriteLine(root.IData + " " + root.SData);
                InOrderRec(root.RightChild);
            }
        }

        //Post Order traversal
        public void printPostorder()
        {
            printPostorderRec(_root);
        }
        void printPostorderRec(Node node)
        {
            if (node == null)
            {
                return;
            }

            // first recur on left subtree
            printPostorderRec(node.LeftChild);

            // then recur on right subtree
            printPostorderRec(node.RightChild);

            // now deal with the node
            Console.WriteLine(node.SData + " " + node.IData);
        }

        //call to recursive
        public void printPreorder()
        {
            printPreorderRec(_root);
        }
        void printPreorderRec(Node node)
        {
            if (node == null)
                return;

            /* first print data of node */
            Console.WriteLine(node.SData + " " + node.IData);

            /* then recur on left subtree */
            printPreorderRec(node.LeftChild);

            /* now recur on right subtree */
            printPreorderRec(node.RightChild);
        }

        //calls Recursive Search without entering root parameter
        public Node Search(String searchedValue)
        {
            return SearchRec(_root, searchedValue);
        }

        //search tree for given key, to be recursive must be called with current root pointer
        //initial would be this.Root
        //returns null if not found in tree
        public Node SearchRec(Node root, String searchedValue)
        {
            Node temp = root;
            int compare;
            //base case root null or key present at root
            if (temp != null)
            {
                compare = String.Compare(searchedValue, temp.SData);
                if (compare == 0)
                {
                    return temp;
                }


                //val is greater than root's key
                if (compare < 0)
                {
                    return SearchRec(temp.LeftChild, searchedValue);
                }
                else
                {
                    return SearchRec(temp.RightChild, searchedValue);
                }
            }
            else
            {
                return null;
            }
        }

        //search for int value
        //calls Recursive Search without entering root parameter
        public Node Search(int searchedValue)
        {
            return SearchRec(_root, searchedValue);
        }

        //search tree for given key, to be recursive must be called with current root pointer
        //initial would be this.Root
        //returns null if not found in tree
        public Node SearchRec(Node root, int searchedValue)
        {
            Node temp = root;
            //base case root null or key present at root
            if (temp != null)
            {
                if (temp.IData == searchedValue)
                {
                    return temp;
                }


                //val is greater than root's key
                if (temp.IData > searchedValue)
                {
                    return SearchRec(temp.LeftChild, searchedValue);
                }
                else
                {
                    return SearchRec(temp.RightChild, searchedValue);
                }
            }
            else
            {
                return null;
            }
        }

        //BFS no backtracking as tree is explored layer by layer
        public void BFS()
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(_root);

            while (q.Count > 0)
            {
                Node current = q.Dequeue();
                if (current == null)
                {
                    continue;
                }
                q.Enqueue(current.LeftChild);
                q.Enqueue(current.RightChild);
                Console.WriteLine(current.SData + " " + current.IData);
            }
        }

        //DFS uses backtracking because it uses Stack to explore full branches not layers
        public void DFS()
        {
            Stack<Node> s = new Stack<Node>();
            s.Push(_root);

            while (s.Count > 0)
            {
                Node current = s.Pop();
                if (current == null)
                {
                    continue;
                }
                s.Push(current.LeftChild);
                s.Push(current.RightChild);
                Console.WriteLine(current.SData + " " + current.IData);
            }
        }
    }
}
