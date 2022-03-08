using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen.Models {
    //Vererbung: Student erbt alles von Person
    //ctors werden nicht vererbt -> müssen neu programmiert werden 
    // public: die Members (Fleder/Mehtoden) sind von überall aus verwendbar
    // protected: ist nur in der Klasse und allen Unterklassen verwendbar
    // private: nur innerhalb der klasse können die members verwendet werden
    class Student : Person{
        public string SClass { get; set; }
        public Student() : this(0, "", "", 0.0m, Department.notSpecified, DateTime.MinValue, "-"){ }
        public Student(int id, string firstname, string lastname, decimal salary, Department dep, DateTime birthdate, string SClass) 
            //ctors der Basisklasse aufrufen
           : base(id, firstname, lastname, salary, dep, birthdate)
        {
            //zusätzlicher Felder setzen
            this.SClass = SClass;
        }

        public override string ToString() {
            //mit base kann auf die Members der Basisklasse zugegriffen werden aber 
            //nur auf public und protected members
            return base.ToString();
        }

    }
}
