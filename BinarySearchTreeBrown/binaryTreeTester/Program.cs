using System;
/** this program demonstrates binary search trees */

//Aleksander Brown CIS152

namespace BinarySearchTreeBrown
{
    class BinaryTreeSearchBrown
    {
        static void Main(string[] args)
        {
            BinarySearchTree test = new BinarySearchTree();
            test.Insert(50, "");
            test.Insert(72, "");
            test.Insert(76, "");
            test.Insert(54, "");
            test.Insert(67, "");
            test.Insert(17, "");
            test.Insert(23, "");
            test.Insert(19, "");
            test.Insert(12, "");
            test.Insert(14, "");
            test.Insert(9, "");

            test.InOrder();
            Console.WriteLine();
            test.printPostorder();
            Console.WriteLine();
            test.printPreorder();


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
            // if (String.Compare(stringData, root.SData) < 0)
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
                return;

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

        //non recursive method
        /*      public Node Search(String searchedValue)
              {
                  Node temp = _root;
                  int compare;
                  while (temp != null)
                  {
                      compare = String.Compare(searchedValue, temp.SData);
                      if (compare == 0) //found
                      {
                          return temp;
                      }

                      if (compare < 0)
                      {
                          temp = temp.LeftChild;
                      }
                      else
                      {
                          temp = temp.RightChild;
                      }
                  }
                  return null; //returns null if not found
              }*/
    }
}
