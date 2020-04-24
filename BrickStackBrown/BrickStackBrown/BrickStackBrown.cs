using System;

namespace BrickStackBrown
{
    class BrickStackBrown
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
            Brick temp = new Brick(null);

            bs.Push(redBrick);
            bs.Push(greenBrick);
            bs.Push(yelllowBrick);
            bs.Push(purpleBrick);
            bs.Push(pinkBrick);
            bs.Print();
            Console.WriteLine("Stack size is {0}", bs.Size());
            bs.Push(blueBrick);
            Console.WriteLine("Stack size is {0}", bs.Size());
            temp = bs.Pop();
            temp = bs.Pop();
            Console.WriteLine("Stack size is {0}", bs.Size());
            temp = bs.Pop();
            bs.Print();
            temp = bs.Peek();
            Console.WriteLine("Next brick is {0}", temp.Color);
            temp = bs.Pop();
            temp = bs.Pop();
            bs.Print();
            Console.WriteLine("Stack size is {0}", bs.Size());
            Console.WriteLine("Stack is empty: {0}", bs.IsEmpty().ToString());
            bs.Print();
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


    //class for brickstack
    class BrickStack
    {
        private int _top;
        private const int MAX_SIZE = 10;

        public Brick[] stack = new Brick[MAX_SIZE];  //Maximum size of Stack
        public BrickStack()
        {
            _top = -1;
        }

        // function to insert data into stack
        public void Push(Brick brick)
        {
            if (IsFull())
            {
                Console.WriteLine("Stack fell over!");
            }
            else
            {
                _top++;
                stack[_top] = brick;
                Console.WriteLine("{0} brick added", brick.Color);
            }
        }

        // function to remove data from the top of the stack
        public Brick Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("No bricks in stack");
                return null;
            }
            else
            {
                Brick brick = stack[_top];
                Console.WriteLine("Removed {0} Brick", brick.Color);
                _top--;
                return brick;
            }
        }

        //function to check top data item without removing
        public Brick Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("No bricks in stack");
                return null;
            }
            else
            {
                return stack[_top];
            }

        }

        //size() returns the int size of the stacks, stack s is not modified
        public int Size()
        {
            return _top + 1;
        }

        //print() prints the stacks from front to rear, use the toString() method to print each brick, stack s is not modified.
        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("No bricks in stack");
            }
            else
            {
                for (int i = _top; i > -1; i--)
                {
                    Console.WriteLine(stack[i].Color);
                }
            }
        }

        //function to check if stack is full
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

        // function to check if stack is empty
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
