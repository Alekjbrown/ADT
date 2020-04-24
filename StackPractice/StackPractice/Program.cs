using System;

namespace StackPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack s1 = new Stack();
            s1.Push(10);
            s1.Push(100);

            Console.WriteLine("Stack is Empty: " + s1.IsEmpty());
            Console.WriteLine("Stack is Full: " + s1.IsFull());
            int x = s1.Pop();
            Console.WriteLine(x);
            x = s1.Peek();
            Console.WriteLine(x);
            x = s1.Pop();
            Console.WriteLine(x);
            Console.WriteLine("Stack is Empty: " + s1.IsEmpty());
            Console.WriteLine("Stack is Full: " + s1.IsFull());
        }
    }


    class Stack
    {
        private int _top;
        private const int MAX_SIZE = 10;

        public int[] a = new int[MAX_SIZE];  //Maximum size of Stack
        public Stack()
        {
            _top = -1;
        }

        // function to insert data into stack
        public void Push(int x)
        {
            if (IsFull())
            {
                Console.WriteLine("Stack Overflow");
            }
            else
            {
                _top++;
                a[_top] = x;
                Console.WriteLine("Element Inserted");
            }
        }

        // function to remove data from the top of the stack
        public int Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack Underflow");
                return 0;
            }
            else
            {
                int d = a[_top];
                _top--;
                return d;
            }
        }

        //function to check top data item without removing, stack is not modified
        public int Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is Empty");
                return 0;
            }
            else
            {
                return a[_top];
            }

        }

        //fucnction to return current size of stack, stack is not modified
        public int Size()
        {
            return (_top + 1);
        }

        //function to check if stack is full, stack is not modified
        public bool IsFull()
        {
            if (_top >= MAX_SIZE)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // function to check if stack is empty, stack is not modified
        public bool IsEmpty()
        {
            if (_top < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

