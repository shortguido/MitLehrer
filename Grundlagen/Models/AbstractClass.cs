using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen.Models {

    //abstrakte Klasse: es kann methoden geben, die abstrakt sind (sie haben keinen Programmcode) und es kann
    //Mehtoden geben die nicht abstrakt sind(sie haben Programmcóde)
    abstract class AbstractClass {
        //normale nicht abstrakte Methode
        public int Do() {
            return 10;
        }

        //abstrakte Methode
        abstract public string Do2();


    }
}
