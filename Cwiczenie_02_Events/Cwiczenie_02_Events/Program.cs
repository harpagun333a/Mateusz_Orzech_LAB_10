using System;

namespace Cwiczenie_02_Events
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Cwiczenie 2\n");

            ConsoleKeyInfo key;
            Ewenty ev = new Ewenty();
            ev.OnDigit += to_cyfra;
            ev.OnCharacter += to_litera;


            while(true)
            {
                key = Console.ReadKey();
                Console.WriteLine("\b" + key.KeyChar);
                if(!ev.CheckSign(key.KeyChar))
                {
                    break;
                }
                
            }

        }

        public static void to_cyfra()
        {
            Console.WriteLine("Naciśnięto cyfrę!");
        }

        public static void to_litera()
        {
            Console.WriteLine("Naciśnięto literę!");
        }
    }

    class Ewenty
    {
        public delegate void cyfra();
        public delegate void znak();

        public event cyfra OnDigit;
        public event znak OnCharacter;

        public bool CheckSign(char c)
        {
            if(Char.IsDigit(c))
            {
                if(OnDigit != null)
                {
                    OnDigit();
                    return true;
                }
            }
            else if(Char.IsLetter(c))
            {
                if(OnCharacter != null)
                {
                    OnCharacter();
                    return true;
                }
            }
            return false;
        }
    }
}
