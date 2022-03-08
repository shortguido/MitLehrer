using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen.Models
{
    public class Schnellspirtz {
        public static int Schwanzlänge;


        public static void Zufall() {
            var rand = new Random();
            for (Schwanzlänge = 0; Schwanzlänge < 1; Schwanzlänge++)
            {
                Console.WriteLine("Deine random Schwanzlänge: " + "{0,8:N0}", rand.Next(0, 30) + "cm");
            }


        }

    }

 }