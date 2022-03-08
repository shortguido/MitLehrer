    //Using entspricht "import" in Java
using Grundlagen.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Grundlagen {
    class Program : AbstractClass{
        static void Main(string[] args) {
            /* Person p = new Person();

             Console.WriteLine("Hello World!");

             //Datentypen und variablen
             int val;
             double val2;    //float(braucht weniger speicher ist aber ungenauer)
             decimal salary; //für geldbeträge
             char choice;
             string Name;
             bool isMale;
             DateTime birthdate;

             //Konstanten
             const double PI = 3.1415;
             const string PWD = "123";
             /*
             //Ausgabe
             Console.ForegroundColor = ConsoleColor.Yellow;
             Console.BackgroundColor = ConsoleColor.DarkCyan;
             Console.Clear();
             Console.WriteLine("PI = " + PI);
             Console.WriteLine("PI(Math) = {0,20:f4}, {1}", Math.PI, "Georg");

             //Eingabe 
             Console.Write("Ihr Name: ");
             //alles was in der Console eingegeben wird ist von typ string
             Name = Console.ReadLine();

             Console.Write("Sind Sie männlich [true, false]: ");
             isMale = Convert.ToBoolean( Console.ReadLine());

             Console.Write("Ihr Gehalt: ");
             salary = Convert.ToDecimal(Console.ReadLine());

             Console.WriteLine("Name: " + Name);
             Console.WriteLine("männlich: {0}; Gehalt: {1:f2}", isMale, salary);

             /* Auswahlanweisung
              * íf
              * switch
              * ?:
              */
            /* 
             Console.Write("Bitte Ganzzahl eingeben: ");
             val = Convert.ToInt32(Console.ReadLine());
             if (val < 0)
             {
                 Console.WriteLine("negativ");
             }
             else if (val > 0)
             {
                 Console.WriteLine("positiv");
             } else {
                 Console.WriteLine("0");
             }

             */
            
            Department dep = Department.notSpecified;
            Console.WriteLine("Abteilung eingeben [0..WI, 1..MA, usw.]: ");
            dep = (Department)Convert.ToInt32 (Console.ReadLine());

            switch (dep)
            {
                case Department.WI:
                    Console.WriteLine("Wirtschaft");
                    break;
                case Department.MA:
                    Console.WriteLine("Maschinenbau");
                    break;
                case Department.EL:
                    Console.WriteLine("Elektronik");
                    break;
                case Department.ET:
                    Console.WriteLine("Elektrotechnik");
                    break;
                case Department.BM:
                    Console.WriteLine("Biomedizin");
                    break;
                default:
                    Console.WriteLine("falsche eingabe");
                    break;

            }
            
            /*
            string result;
            int input;
            Console.WriteLine("Ganzzahl: ");
            input = Convert.ToInt32(Console.ReadLine());

            result = input >= 0 ? "positiv bzw. 0" : "negativ";

            Console.WriteLine("Ressult = " + result);
            */



            //Schleifen
            //for, while, do while, foreach
            /*
            for(int i=1; i<100; i += 10)
            {
                Console.WriteLine(i);
            }
            */
            /*
            int i=100;
            while (i >= 0)
            {
                Console.WriteLine(i);
                i -= 10;
                
            }
            */
            /*
            int age;
            do
            {
                Console.Write("Alter: ");
                age = Convert.ToInt32(Console.ReadLine());
            } while (!((age >= 10) && (age <= 100)));
              */


            /*
            PrintPersonData();
            //Instanzen Objekte von Person erzeugen
            Person p1 = new Person();
            Person p2 = new Person(100, "Matteo", "Höllrigl", 2090.90m, Department.WI, new DateTime(2004, 2, 25));

            //Zuweisung (=) hier wird die set Methode des Properties Salary aufgerufen
            p1.Salary = 2001.90m;
            p1.Firstname = "Johnathan";
            p1.Lastname = "Egger";
            p1.Department = Department.WI;
            p1.Birthdate = new DateTime(2004, 8, 4);

            //Ausgabe
            PrintPersonData(p1);
            PrintPersonData(p2);
            */


            /*
            Schnellspirtz.Zufall();

            int[] zahlen = new int[20];
            int[] zahlen2 = { 1, 3, 4, 5, 2 };
            List<String> namen = new List<string> { "Mehli", "Leo", "me", "Luca" };

            foreach (int z in zahlen2)
            {
                Console.WriteLine("Zahlen " + z);

            }
            foreach (string n in namen)
            {
                Console.WriteLine("Namen " + n);

            }
            Dictionary<string, List<string>> klasse = new Dictionary<string, List<string>>();
            klasse.Add("hw4b", new List<string> { "Kristof" });
            klasse.Add("hw3b", new List<string> { "Klemens", "Luca" });

            klasse["hw4b"].Add("Johnathan");
            klasse["hw4b"].Add("me");
            klasse["hw4b"].Add("Mehli");

            */
            /*
            //Dateimanagement und Exceptions 
            string file = "C://temp//file.txt";
            string content = ReadFile(file);
            Console.WriteLine(content);
            */
            //statische Klasse verwenden
            //statische Members werdenüber denKlassennamen aufgerufen
            //es darf keine Instanz/Objekt erzeugt werden
            /*
            Console.WriteLine("Unser Pi = " + StaticClass.PI);
            Console.WriteLine("String = " + StaticClass.Do());


            //normale Klasse mit statischen Members 
            //Zugriff auf statische Members
            NormalClasswithstaticMembers.val = "300";
            Console.WriteLine("Value = " + NormalClasswithstaticMembers.val);
            Console.WriteLine("30+20 = "+ NormalClasswithstaticMembers.Add(30,25));

            //Zugriff auf normale Members
            NormalClasswithstaticMembers cl = new NormalClasswithstaticMembers();
            cl.Text = "bla";
            Console.WriteLine( "Text = "+ cl.Text);
            Console.WriteLine("Claculate() " + cl.Calculate() );
        }


        //eine Methode sollte nur eine einzige Aufgabe erfüllen
        
        static public void PrintPersonData()
        {
            Console.WriteLine("Jonathan");
            Console.WriteLine("4.8.2004");
            Console.WriteLine("Moarhofen");
        }
        public static void PrintPersonData(Person p)
        {
            Console.WriteLine("Name: " + p.Name);
            Console.WriteLine("ID: " + p.PersonId);
            Console.WriteLine("Gebsat: " + p.Birthdate);
        }

        public static string ReadFile(string pathAndFilename) {

            try
            {
                return File.ReadAllText(pathAndFilename);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Sie haben keinen Zugriff auf diese Datei!");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Fehler amk.");
            }
            catch (IOException)
            {
                Console.WriteLine("Fehler IO");
            }
            catch (Exception)
            {
                Console.WriteLine("Du hasch dein programm gfickt ey");
            }
            return null;
        }
    }
            */

            
        }

        public override string Do2() {
            string i = "moin";
            return i;
        }
    }
}
