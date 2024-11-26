using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JustCode2
{
    public enum CowState
    {
        Awake,
        Sleepping,
        Eats
    }
    class MyClass : EventArgs
    {
        public CowState CurrentCowState { get; set; }

        public MyClass(CowState cst) 
        { 
            this.CurrentCowState = cst; 
        }
    }
    
    class Cow
    {
        public string Name { get; set; }

        public event EventHandler<MyClass> Moo;

        public void Method()
        {
            Random random = new Random();
            int a = random.Next(1, 4);

            switch (a)
            {
                case 1:
                    Moo?.Invoke(this, new MyClass(CowState.Awake));
                    break;
                case 2:
                    Moo?.Invoke(this, new MyClass(CowState.Sleepping));
                    break;
                case 3:
                    Moo?.Invoke(this, new MyClass(CowState.Eats));
                    break;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Cow cow1 = new Cow() { Name = "Betsy" };
            cow1.Moo += Cow1_Moo;

            Cow cow2 = new Cow() { Name = "William" };
            cow2.Moo += (sender, e) =>
            {
                Cow c = sender as Cow;

                switch (e.CurrentCowState)
                {
                    case CowState.Awake:
                        Console.WriteLine($"{c.Name} {e.CurrentCowState} ");
                        break;
                    case CowState.Sleepping:
                        Console.WriteLine($"{c.Name} {e.CurrentCowState} ");
                        break;
                    case CowState.Eats:
                        Console.WriteLine($"{c.Name} {e.CurrentCowState} ");
                        break;

                }
            };

            Cow cow3 = new Random().Next() % 2 == 0 ? cow1 : cow2;
            cow3.Method();
        }

        private static void Cow1_Moo(object sender, MyClass e)
        {
            Cow c = sender as Cow;

            switch (e.CurrentCowState)
            {
                case CowState.Awake:
                    Console.WriteLine($"{c.Name} {e.CurrentCowState} ");
                    break;
                case CowState.Sleepping:
                    Console.WriteLine($"{c.Name} {e.CurrentCowState} ");
                    break;
                case CowState.Eats:
                    Console.WriteLine($"{c.Name} {e.CurrentCowState} ");
                    break;
                   
            }
        }
    }
}
