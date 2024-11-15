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

        private readonly object Lock = new object();

        private void Robot()
        {
            while(true)
            {
                lock (Lock)
                {
                    Componenti NewComponente = new Componenti();
                    ComponentsQueue.Enqueue(NewComponente);
                    Monitor.Pulse(Lock);
                    Task.Delay(1000);
                }
            }
            
        }

        private void Dinosauro()
        {
            while (true)
            {
                lock (Lock)
                {
                    if (ComponentsQueue.Count == 0)
                    {
                        Monitor.Wait(Lock);
                    }

                    Componenti TookComponente = ComponentsQueue.Dequeue();
                    ComponentsStack.Push(TookComponente);
                    Monitor.Pulse(Lock);
                    Task.Delay(1000);
                }
            }

        }
    }
}
