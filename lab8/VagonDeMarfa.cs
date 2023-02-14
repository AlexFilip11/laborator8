using System;
using System.Collections.Generic;
using System.Text;

namespace lab8
{
    class VagonDeMarfa : Vagon
    {
        //private enum TipMarfa { cereale, carbune, otel};
        private string tipMarfa;
        private int capacitate;

        public VagonDeMarfa(int masa, int anFabricatie, string marfa, int capacitate) : base(masa, anFabricatie)
        {
            this.tipMarfa = marfa;
            this.capacitate = capacitate;
            this.tipVagon = TipVagon.Marfa;
        }
        public  string TipMarfa { get { return tipMarfa; } }
        public int Capacitate { get { return capacitate; } }
    }
}
