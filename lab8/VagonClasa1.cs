using System;
using System.Collections.Generic;
using System.Text;

namespace lab8
{
    class VagonClasa1 : Vagon
    {
        public VagonClasa1(int masa, int anFabricatie) : base(masa, anFabricatie)
        {
            this.tipVagon = TipVagon.ClasaI;
        }
        public void Porneste()
        {
            Console.WriteLine("AC este pornit");
        }
        public void Opreste()
        {
            Console.WriteLine("AC este oprit");
        }
    }
}
