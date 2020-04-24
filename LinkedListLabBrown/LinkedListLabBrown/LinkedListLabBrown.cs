using System;

namespace LinkedListLabBrown
{
    class LinkedListLabBrown
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            Node temp;

            for (int i = 1; i <= 10; i++)
            {
                list.EnQueue(i);
            }

            for (int i = 0; i < 10; i++)
            {
                temp = list.DeQueue();
                Console.WriteLine(temp.Value);
            }

            Console.WriteLine("List is empty = {0}", list.IsEmpty());

        }

        class Node
        {
            private int _value;
            private Node _next = null;

            public int Value
            {
                get { return _value; }
                set { _value = value; }
            }
            public Node Next
            {
                get { return _next; }
                set { _next = value; }
            }

            public Node(int n)
            {
                _value = n;
            }
        }

        class LinkedList
        {
            private Node _first = null;
            private Node _last = null;

            public Node First { get; set; }
            public Node Last { get; set; }

            public LinkedList()
            {

            }

            public Node EnQueue(int n)
            {
                if (_first == null)
                {
                    _first = new Node(n);
                    _last = _first;
                }
                else
                {
                    Node previous = _last;
                    _last = new Node(n);
                    previous.Next = _last;
                }

                return _last;

            }

            public Node DeQueue()
            {
                //check for empty
                if (_first == null)
                {
                    return null;
                }

                Node result = _first;
                _first = _first.Next;

                return result;
            }

            public bool IsEmpty()
            {
                return _first == null;
            }
        }
    }
}
