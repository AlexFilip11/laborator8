using System;
using System.Collections.Generic;
using System.Text;

namespace lab8
{
    class Vagon
    {
        private int masa;
        private int anFabricatie;
        protected TipVagon tipVagon;

        public Vagon(int masa, int anFabricatie)
        {
            this.masa = masa;
            this.anFabricatie = anFabricatie;
        }

        public int Masa { get { return masa; } }
        public int AnFabricatie { get { return anFabricatie; } }

    }
    
}
