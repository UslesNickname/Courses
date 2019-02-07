using System;
using System.Collections.Generic;

namespace try_task
{
    class Task
    {
        public string taskD;
        public string tDate;
        public bool status = false;
        public DateTime dateT = new DateTime();

        public void setStatus()
        {
            if (status == false)
                status = true;
            else
                status = false;
        }

        public void showTask()
        {
            Console.WriteLine(" {0,-20}  created:{1,-11}  lastDate:{2,-11}   status:{3,-5}\n", taskD, dateT.ToString("dd/MM/yyyy"), tDate, status);
        }

    }


    class Program
    {
        public static void showInd(List<Task> dolist)
        {
            int ind = 0;
            foreach (Task t in dolist)
            {
                Console.Write(ind + ") ");
                t.showTask();
                ind++;
            }
            ind = 0;
        }

        public static void helpMenu()
        {
            Console.WriteLine("Commands:\n" +
                            "add - add new task ot the tasklist\n" +
                            "show - shows the tasklist\n" +
                            "statusset - allows to change task stsus in the tasklist/n" +
                            "delete - deleting task\n" +
                            "exit - stops the program\n");
            Console.ReadLine();
        }
        /*
        public static void sorting(List<Task> dolist)
        {
            dolist.Sort((x, y) => { return DateTime.Compare(x.dateT, y.dateT); });
        }
        */
        static void Main(string[] args)
        {
            List<Task> dolist = new List<Task>();
            string command;
             
            while (true)
            {
                Console.Clear();
                int ind = 0;
                Console.WriteLine("enter  help  to see the list of available commands\n");
                Console.WriteLine("Enter the command: ");
                command = Console.ReadLine();

                switch (command)
                {

                    case "help":
                        helpMenu();
                        break;

                    case "add":
                        Task task = new Task();
                        Console.WriteLine("Enter task: ");
                        task.taskD = Console.ReadLine();

                        Console.WriteLine("Enter last date: ");
                        task.tDate = Console.ReadLine();

                        task.dateT = DateTime.Now;

                        dolist.Add(task);
                        Console.WriteLine("Task added, press enter");
                        Console.ReadLine();
                    break;

                    case "show":
                        showInd(dolist);
                        Console.ReadLine();
                        break;

                    case "statusset":
                        showInd(dolist);
                        Console.WriteLine("Enter the task index\nfor what to change status: ");
                        ind = Convert.ToInt32( Console.ReadLine());
                        dolist[ind].setStatus();
                        Console.WriteLine("Status changed, press enter");
                        Console.ReadLine();
                        break;

                    case "delete":
                        showInd(dolist);
                        Console.WriteLine("Enter the task index\nof task to be deleted: ");
                        ind = Convert.ToInt32(Console.ReadLine());
                        dolist.RemoveAt(ind);
                        Console.WriteLine("Task been deleted");
                        Console.ReadLine();
                        break;

                    //case "sort":
                        //sorting(dolist);
                        //return;

                    case "exit":
                        return;
 
                    default:
                        Console.WriteLine("Command does not exist\nType help to see the list of commands");
                        Console.ReadLine();
                        break;

                }
            }

        }
    }
}
