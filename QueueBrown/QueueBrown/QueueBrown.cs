using System;
//Aleksander Brown CIS 152

namespace QueueBrown
{
    public static class QueueBrown
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
            cwl.InitQueue();
            cwl.EnQueue(car1);
            cwl.EnQueue(car2);
            cwl.EnQueue(car3);
            cwl.EnQueue(car4);
            cwl.EnQueue(car5);
            Console.WriteLine(cwl.Size());
            Console.WriteLine(cwl.Peek().Make + " " + cwl.Peek().Model + " is next in line");
            cwl.DeQueue();
            cwl.Print();
            cwl.EnQueue(car6);
            cwl.EnQueue(car7);
            cwl.EnQueue(car8);
            cwl.EnQueue(car9);
            cwl.EnQueue(car10);
            cwl.EnQueue(car11);
            Console.WriteLine(cwl.Size());
            Console.WriteLine("Line is full: " + cwl.IsFull());
            cwl.Print();
            while (!cwl.IsEmpty())
            {
                cwl.DeQueue();
            }
            Console.WriteLine(cwl.Size());
            cwl.EnQueue(car12);
            cwl.Print();
        }
    }

    //class for car wash line
    public class CarWashLine
    {
        private int _tail;
        private int _head;
        private const int MAX_SIZE = 10;
        private Car[] _queue;

        public CarWashLine()
        {
        }
        //function to initialize queue
        public void InitQueue()
        {
            if (_queue == null)
            {
                _queue = new Car[MAX_SIZE];
                _tail = -1;
                _head = -1;
            }
        }

        // function to insert data into queue
        public void EnQueue(Car car)
        {
            if (IsFull())
            {
                Console.WriteLine("Too many cars in queue!");
            }
            else
            {
                if (_head == -1)
                {
                    _head++;
                }
                //test if _tail is at end of array. will move back to reuse start of array
                if (_tail == MAX_SIZE - 1)
                {
                    _tail = 0;
                }
                else
                {
                    _tail++;
                }
                // add car to queue
                _queue[_tail] = car;
                Console.WriteLine("New car in queue.");
            }
        }

        // function to remove data from the top of the queue
        public Car DeQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("No cars in queue.");
                return null;
            }
            else
            {
                Car car = _queue[_head];
                Console.WriteLine("Washing {0}.", car.Print());
                if (_head == _tail)
                {
                    _head = -1;
                    _tail = -1;
                }
                else if (_head == MAX_SIZE - 1)
                {
                    _head = 0;
                }
                else
                {
                    _head++;
                }
                return car;
            }
        }

        //function to check top data item without removing
        public Car Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("No cars in line.");
                return null;
            }
            else
            {
                return _queue[_head];
            }
        }

        //size() returns the int size of the queues, queue s is not modified
        public int Size()
        {
            if (_tail > _head)
            {
                return _tail - _head + 1;
            }
            else if (_tail < _head)
            {
                return (MAX_SIZE - _head) + _tail + 1;
            }
            else if (_head == _tail && _head != -1 && _tail != -1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //print() prints the queue from head to tail, queue is not modified.
        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("No cars in line.");
            }
            else if (Size() == 1)
            {
                Console.WriteLine("A {0} {1} is in line at spot 1.", _queue[_head].Make, _queue[_head].Model);
            }
            else if (_tail > _head)
            {
                int spot = 0;
                for (int i = _head; i <= _tail; i++)
                {
                    Console.WriteLine("A {0} {1} is in line at spot {2}.", _queue[i].Make, _queue[i].Model, spot++);
                }
            }
            else
            {
                int spot = 0;
                for (int i = _head; i < MAX_SIZE; i++)
                {
                    Console.WriteLine("A {0} {1} is in line at spot {2}.", _queue[i].Make, _queue[i].Model, spot++);
                }
                for (int i = 0; i <= _tail; i++)
                {
                    Console.WriteLine("A {0} {1} is in line at spot {2}.", _queue[i].Make, _queue[i].Model, spot++);
                }
            }
        }

        //function to check if queue is full
        public bool IsFull()
        {
            return Size() == MAX_SIZE;
        }

        // function to check if queue is empty
        public bool IsEmpty()
        {
            return Size() == 0;
        }
    }

    //class for car

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
