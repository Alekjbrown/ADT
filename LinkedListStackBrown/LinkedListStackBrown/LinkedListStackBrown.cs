using System;

namespace LinkedListStackBrown
{
    class LinkedListStackBrown
    {
        static void Main(string[] args)
        {
            BrickStack bs = new BrickStack();
            Brick redBrick = new Brick("Red");
            Brick blueBrick = new Brick("Blue");
            Brick yelllowBrick = new Brick("Yellow");
            Brick purpleBrick = new Brick("Purple");
            Brick greenBrick = new Brick("Green");
            Brick pinkBrick = new Brick("Pink");
            Brick t = new Brick(null);

            bs.Push(redBrick);
            bs.Push(greenBrick);
            bs.Push(yelllowBrick);
            bs.Push(purpleBrick);
            bs.Push(pinkBrick);
            bs.Print();
            Console.WriteLine("Stack size is {0}", bs.Size());
            bs.Push(blueBrick);
            Console.WriteLine("Stack size is {0}", bs.Size());
            t = bs.Pop().Value;
            t = bs.Pop().Value;
            Console.WriteLine("Stack size is {0}", bs.Size());
            t = bs.Pop().Value;
            bs.Print();
            t = bs.Peek().Value;
            Console.WriteLine("Next brick is {0}", t.Color);
            t = bs.Pop().Value;
            t = bs.Pop().Value;
            bs.Print();
            Console.WriteLine("Stack size is {0}", bs.Size());
            Console.WriteLine("Stack is empty: {0}", bs.IsEmpty().ToString());
            bs.Print();
        }
    }
    class Node
    {
        private Brick _value;
        private Node _next = null;
        private Node _prev = null;
        private bool _visited = false;

        public bool Visited
        {
            get { return _visited; }
            set { _visited = value; }
        }

        public Brick Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public Node Next
        {
            get { return _next; }
            set { _next = value; }
        }
        public Node Prev
        {
            get { return _prev; }
            set { _prev = value; }
        }

        public Node(Brick n)
        {
            _value = n;
        }
    }


    class BrickStack
    {
        private Node _first = null;
        private Node _last = null;

        public Node First
        {
            get { return _first; }
            set { _first = value; }
        }
        public Node Last
        {
            get { return _last; }
            set { _last = value; }
        }

        public BrickStack()
        {

        }

        public void Push(Brick n)
        {
            //create new node
            Node temp = new Node(n);
            temp.Prev = null;
            temp.Next = _first;

            //if empty
            if (_first == null)
            {
                _first = temp;
                _last = _first;
            }
            else
            {
                _first.Prev = temp;
                _first = temp;
            }
        }

        public Node Pop()
        {
            //check for empty
            if (_first == null)
            {
                Console.WriteLine("No bricks in stack");
                return null;
            }

            Node temp = First;
            Console.WriteLine("{0} brick removed", temp.Value.Color);
            _first = _first.Next;
            _first.Prev = null;

            return temp;
        }

        public Node Peek()
        {
            return _first;
        }

        //loop detector returns true if there is a loop
        public bool DetectLoop()
        {
            bool detected = false;
            Node temp = _first;
            while (temp != null)
            {
                if (temp.Visited == true)
                {
                    detected = true;
                    break;
                }
                else
                {
                    temp.Visited = true;
                    temp = temp.Next;
                }
            }
            return detected;

        }

        public void Print()
        {
            Node temp = _first;
            int count = 1;
            if (temp == null)
            {
                Console.WriteLine("No bricks in stack");
            }
            else
            {
                while (temp != null)
                {
                    Console.WriteLine("{0} brick", temp.Value.Color, count++);

                    temp = temp.Next;
                }
            }
        }

        public int Size()
        {
            Node temp = _first;
            int count = 0;
            while (temp != null)
            {
                count++;
                temp = temp.Next;
            }
            return count;
        }

        public bool IsEmpty()
        {
            return _first == null;
        }
    }

    //class for bricks
    class Brick
    {
        //Field
        private String _color;

        //property
        public String Color
        {
            get { return _color; }
            set { _color = value; }
        }

        //constructor
        public Brick(String color)
        {
            _color = color;
        }

        //return string for color
        public String GetColor()
        {
            return this.Color;
        }
    }
}



