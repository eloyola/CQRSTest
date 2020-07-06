using System;
using System.Collections.Generic;
using static System.Console;
using System.Threading.Tasks;
using CQRSTest.Commands;
using CQRSTest.Queries;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CQRSTest
{
    //CQRS = command query responsability segregation
    //CQS = command query separation
    //COMMAND = do/change

    public class Event
    {
        //backtrack
    }
    public class AgeChangedEvent : Event
    {
        public Person Target;
        public int OldValue, NewValue;

        public AgeChangedEvent(Person target, int oldValue, int newValue)
        {
            Target = target;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public override string ToString()
        {
            return $"Age changed from {OldValue} to {NewValue}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var eb = new EventBroker();

            var p = new Person(eb);
            eb.Command(new ChangeAgeCommand(p, 12));

            foreach (var e in eb.AllEvents)
            {
                WriteLine(e);
            }

            int age;
            age = eb.Query<int>(new AgeQuery { Target = p });

            WriteLine($"Hello World! \n{age}");

            eb.UndoLast();

            foreach (var e in eb.AllEvents)
            {
                WriteLine(e);
            }

            ReadKey();
        }
    }
}
