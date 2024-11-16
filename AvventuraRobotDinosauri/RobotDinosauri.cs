using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AvventuraRobotDinosauri
{
    internal class RobotDinosauri
    {
        private List<Task> DinosauriList = new List<Task>();
        private List<Task> RobotList = new List<Task>();

        private int CntComponents = 0;

        private Stack<Componenti> ComponentsStack = new Stack<Componenti>();
        private Queue<Componenti> ComponentsQueue = new Queue<Componenti>();

        int DinoNumber = 0;
        int RoboNumber = 0;

        public RobotDinosauri() { 
            DinoNumber = 5;
            RoboNumber = 5;
            this.Populate();
        }

        public RobotDinosauri(int dinoNumber, int roboNumber)
        {
            DinoNumber = dinoNumber;
            RoboNumber = roboNumber;
            this.Populate();
        }

        public void Populate()
        {
            for (int i = 0; i < DinoNumber; i++)
            {
                Task toAdd = new Task(() => { Dinosauro(); });
                DinosauriList.Add(toAdd);
            }

            for (int i = 0; i < RoboNumber; i++)
            {
                Task toAdd = new Task(() => { Robot(); });
                RobotList.Add(toAdd);
            }
        }

        public void Run()
        {
            for (int i = 0; i < DinoNumber; i++)
            {
                DinosauriList[i].Start();
            }

            for (int i = 0; i < RoboNumber; i++)
            {
                RobotList[i].Start();
            }
        }

        private readonly object Lock = new object();

        private void Robot()
        {
            while(true)
            {
                lock (Lock)
                {
                    Componenti NewComponente = new Componenti();
                    ComponentsQueue.Enqueue(NewComponente);

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Enqueued: " + NewComponente.ToString());
                    Console.ForegroundColor = ConsoleColor.White;

                    Monitor.Pulse(Lock);
                    Thread.Sleep(500);
                }
            }
            
        }

        private void Dinosauro()
        {
            while (true)
            {
                lock (Lock)
                {
                    try
                    {
                        if (ComponentsQueue.Count == 0)
                        {
                            Monitor.Wait(Lock);
                        }

                        Componenti TookComponente = ComponentsQueue.Dequeue();
                        ComponentsStack.Push(TookComponente);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Stacked: " + TookComponente.ToString());
                        Console.ForegroundColor = ConsoleColor.White;

                        Monitor.Pulse(Lock);
                        Thread.Sleep(500);
                    }
                    catch
                    {
                        Monitor.Wait(Lock);
                    }
                }
            }

        }
    }
}
