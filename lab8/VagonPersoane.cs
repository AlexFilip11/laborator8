using System;
using System.Collections.Generic;
using System.Text;

namespace lab8
{
    class VagonPersoane : Vagon
    {
        private int nrLocuri;

        public VagonPersoane(int masa, int anFabricatie, int nrLocuri) : base(masa, anFabricatie)
        {
            this.nrLocuri = nrLocuri;
            this.tipVagon = TipVagon.Persoane;
        }
        public void Deschide()
        {
            Console.WriteLine("Usile se deschid");
        }
        public void Inchide()
        {
            Console.WriteLine("Usile se inchid");
        }
        public int NrLocuri { get { return nrLocuri; } }
    }
}
