using System;
using System.Collections.Generic;

//Aleksander Brown CIS 152

namespace TicketQueueBrown
{
    class TicketQueueBrown
    {
        static void Main(string[] args)
        {
            //vars for simulation
            const int START_LINE_QTY = 10;
            int tickets = 0;
            //vars to print simulation after 10 runs
            const int SIM_COUNT = 10;
            int runningCount = 0;
            int average = 0;
            //init and declare Queue and random
            Queue<Person> ticketLine = new Queue<Person>();
            Random r = new Random();

            //loop sim 10 times
            for (int x = 0; x < 10; x++)
            {
                //fill queue with 10 people
                for (int i = 0; i < START_LINE_QTY; i++)
                {
                    ticketLine.Enqueue(new Person());
                }

                //random number test to fill or empty tickets
                while (ticketLine.Count != 0)
                {
                    int rInt = r.Next(1, 10);

                    if (rInt < 7)
                    {
                        ticketLine.Dequeue();
                        tickets++;
                    }
                    else
                    {
                        ticketLine.Enqueue(new Person());
                    }
                }

                //print tickets sold for current sim
                Console.WriteLine("Test {0}: {1} Tickets Sold", x + 1, tickets);
                //track for average
                runningCount += tickets;
                //clear vars for next sim
                ticketLine.Clear();
                tickets = 0;
            }

            //print average after 10 runs
            average = runningCount / SIM_COUNT;
            Console.WriteLine("{0} tickets sold on average", average);
        }
    }

    //person class
    class Person
    {
        public Person()
        {
        }
    }
}
