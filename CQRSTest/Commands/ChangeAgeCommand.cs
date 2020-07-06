using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSTest.Commands
{
    public class ChangeAgeCommand : Command
    {
        public Person Target;
        public int Age;

        public ChangeAgeCommand(Person target, int age)
        {
            Target = target;
            Age = age;
        }
    }
}
