using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Models {
    public class Mitarbeiter {
        private int mitarbeiterId;
        public int MitarbeiterId {
            get { return this.mitarbeiterId; }
            set { if (value >= 0)
                {
                    this.mitarbeiterId = value;
                } }
        }
        public string Name { get; set; }
        public string Rang { get; set; }
        public DateTime Geburtsdatum { get; set; }
    }
}