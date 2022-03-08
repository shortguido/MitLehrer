using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen.Models {
    class NormalClasswithstaticMembers {

        //2 normale Member
        public string Text { get; set; }
        public double Calculate() {
            return 200;
        }

        //2 statische Member
        public static string val { get; set; }
        public static decimal Add(decimal z1, decimal z2) {
            return z1 + z2;

        }

    }
}
