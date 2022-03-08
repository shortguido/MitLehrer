using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen.Models
{
    class Person
    {


        //fields
        private int personId;
        private decimal salary;
     


        //Properties - automatische (falls kein Überprüfung notwendig ist)
        //           - normale (falls eine Überprüfung notwendig ist)
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Schwanzlänge { get; set; }
        public int PersonId

        {
            get { return personId; }
            set
            {
                if (value >= 0)
                {
                    this.personId = value;
                }
            }


            //ctors
            //other methods



        }
        public decimal Salary
        {
            get
            {
                return salary;
            }
            set
            {
                if (value >= 0)
                {
                    this.salary = value;
                }
            }
        }
        public DateTime Birthdate { get; set; }
        public Department Department { get; set; }
        public DateTime dateTime { get; set; }
        public string Name
        {
            get { return this.Lastname  + " " + this.Firstname; }
        }

        //ctors
        public Person() : this(0, "", "", 0.0m, Department.WI, DateTime.MinValue, 0) {

        }
        public Person(int id, string firstname, string lastname, decimal salary, Department dep, DateTime birthdate, int schwanzlänge)
        {
            this.PersonId = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Salary = salary;
            this.Department = dep;
            this.Birthdate = birthdate;
            this.Schwanzlänge = schwanzlänge;
        }

        //andere Mehtoden
        public override string ToString()
        {
            return "ID = " + this.PersonId + " " + this.Firstname + " " + this.Lastname + "\n" + this.Birthdate.ToLongDateString() + " " + this.Department
                + " " + this.salary + " Euro" + " " + this.Schwanzlänge;
        }
    }
}
