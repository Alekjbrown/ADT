using System;
/** this program implements a linked list for objects (cars)*/
//Aleksander Brown CIS152

namespace LinkedListQueueBrown
{
    class LinkedListQueueBrown
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Ford", "Mustang");
            Car car2 = new Car("Ford", "GT40");
            Car car3 = new Car("Alfa Romeo", "Giulia");
            Car car4 = new Car("Fiat", "500");
            Car car5 = new Car("Volkswagen", "Beetle");
            Car car6 = new Car("Audi", "V8 Quattro");
            Car car7 = new Car("Holden", "Monaro");
            Car car8 = new Car("Holden", "Commodore");
            Car car9 = new Car("BMW", "320iS");
            Car car10 = new Car("Range Rover", "Vitesse");
            Car car11 = new Car("BMW", "635i");
            Car car12 = new Car("Mosler", "MT900S");
            CarWashLine cwl = new CarWashLine();
            cwl.EnQueue(car1);
            cwl.EnQueue(car2);
            cwl.EnQueue(car3);
            cwl.EnQueue(car4);
            cwl.EnQueue(car5);
            Console.WriteLine("{0} cars in line.", cwl.Size());
            Console.WriteLine(cwl.Peek().Value.Make + " " + cwl.Peek().Value.Model + " is next in line");
            cwl.DeQueue();
            cwl.Print();
            cwl.EnQueue(car6);
            cwl.EnQueue(car7);
            cwl.EnQueue(car8);
            cwl.EnQueue(car9);
            cwl.EnQueue(car10);
            cwl.EnQueue(car11);
            Console.WriteLine("{0} cars in line.", cwl.Size());
            cwl.Print();
            while (!cwl.IsEmpty())
            {
                cwl.DeQueue();
            }
            Console.WriteLine("{0} cars in line.", cwl.Size());
            cwl.EnQueue(car12);
            cwl.Print();
        }
    }

    class Node
    {
        private Car _value;
        private Node _next = null;
        private bool _visited = false;

        public bool Visited
        {
            get { return _visited; }
            set { _visited = value; }
        }

        public Car Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public Node Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public Node(Car n)
        {
            _value = n;
        }
    }

    class CarWashLine
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

        public CarWashLine()
        {

        }

        public Node EnQueue(Car n)
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
            Console.WriteLine("{0} {1} is being washed.", result.Value.Make, result.Value.Model);
            _first = _first.Next;

            return result;
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
                Console.WriteLine("No cars in line.");
            }
            else
            {
                while (temp != null)
                {
                    Console.WriteLine("A {0} {1} is in line at spot {2}.", temp.Value.Make, temp.Value.Model, count++);

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

    public class Car
    {
        private String _make;
        private String _model;

#pragma warning disable RCS1085 // Use auto-implemented property.
        public String Make
#pragma warning restore RCS1085 // Use auto-implemented property.
        {
            get { return _make; }
            set { _make = value; }
        }

#pragma warning disable RCS1085 // Use auto-implemented property.
        public String Model
#pragma warning restore RCS1085 // Use auto-implemented property.
        {
            get { return _model; }
            set { _model = value; }
        }

        //constructor
        public Car(String make, String model)
        {
            _make = make;
            _model = model;
        }

        public String Print()
        {
            return _make + " " + _model;
        }
    }
}

