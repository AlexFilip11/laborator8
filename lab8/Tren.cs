using System;
using System.Collections.Generic;
using System.Text;

namespace lab8
{
    class Tren
    {
        private string nume;
        //private Vagon vagon;
        public Tren(string nume)
        {
            this.nume = nume;
        }
        public string Nume { get { return nume; } }

        public void Pleaca()
        {
            Console.WriteLine("Trenul pleaca din gara!");
        }
        public void Opreste()
        {
            Console.WriteLine("Treneul opreste in gara!");
        }
        /*public AdaugaVagon(Vagon vagon)
        {
            this.vagon = vagon;

        }*/
    }
}
