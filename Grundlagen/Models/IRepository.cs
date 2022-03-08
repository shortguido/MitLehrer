using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen.Models {

    //Interface; schnittstelle
    //gibt nur die Methodenköpfe vor-es ist kein Programmcode vorhanden
    //ein Interface ist ein Vertrag für eine Klase - diese muss alle Methoden ausprogrammieren
    interface IRepository {
        void Open();
        void Close();
        bool insert(Person p);
        //usw.
    }
}
