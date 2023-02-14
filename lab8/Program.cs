using System;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti numele trenului: ");
            Tren tren = new Tren(Console.ReadLine());
            Locomotiva locomotiva = new Locomotiva();
            Console.WriteLine("Introduceti numarul de vagoane: ");
            int n = int.Parse(Console.ReadLine());
            Vagon[] vagon = new Vagon[n];
            VagonClasa1[] vagonClasaI = new VagonClasa1[n];
            VagonDeMarfa[] vagonMarfa = new VagonDeMarfa[n];
            VagonPersoane[] vagonPersoane = new VagonPersoane[n];
            int[] tipVagon = new int[n];
            CitireVagoane(vagon, n, tipVagon, vagonClasaI, vagonMarfa, vagonPersoane);
            AfisareToateVagoane(tren, vagon, n, tipVagon);
            AccesareFunctii(tren, locomotiva, vagon, n, tipVagon, vagonClasaI, vagonMarfa, vagonPersoane);
        }
        static Vagon[] CitireVagoane(Vagon[] vagon, int n, int[]tipVagon, VagonClasa1[] vagonClasaI, VagonDeMarfa[] vagonMarfa, VagonPersoane[] vagonPersoane)
        {
            //citim toate cele N vagoane si pentru fiecare citim tipul lor si accesam o functie care sa creeze tipul respectiv
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Introduceti masa si anul de fabricatie pentru vagonul {i}");
                int masa = int.Parse(Console.ReadLine());
                int anFabricatie = int.Parse(Console.ReadLine());
                Console.WriteLine($"Introduceti tipul vagonului: Marfa(0), Persoane(1), Clasa I(2)");
                int tipul = int.Parse(Console.ReadLine());
                vagon[i] = new Vagon(masa, anFabricatie);
                if(tipul == 0)
                {
                    tipVagon[i] = tipul;
                    vagonMarfa[i] = CitireVagonMarfa(masa, anFabricatie);
                }
                else if(tipul==1)
                {
                    tipVagon[i] = tipul;
                    vagonPersoane[i] = CitireVagonPersoane(masa, anFabricatie);
                }
                else if(tipul ==2)
                {
                    tipVagon[i] = tipul;
                    vagonClasaI[i]= CitireVagonClasaI(masa, anFabricatie);
                }
                else
                {
                    Console.WriteLine("Tipul de vagon atribuit nu exista");
                    tipVagon[i] = -1;
                }
            }
            return vagon;
        }
        static VagonClasa1 CitireVagonClasaI( int masa, int anFabricatie)
        {
            VagonClasa1 vagonClasaI = new VagonClasa1(masa, anFabricatie);
            return vagonClasaI;
        }
        static VagonDeMarfa CitireVagonMarfa(int masa, int anFabricatie)
        {
            Console.WriteLine("Introduceti capacitatea vagonului de marfa: ");
            int capacitate = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti tipul de marfa transportat: ");
            string marfa = Console.ReadLine();
            VagonDeMarfa vagonMarfa = new VagonDeMarfa(masa, anFabricatie, marfa, capacitate);
            return vagonMarfa;
        }
        static VagonPersoane CitireVagonPersoane(int masa, int anFabricatie)
        {
            Console.WriteLine("Introduceti numarul de locuri din vagonul de persoane: ");
            int nrLocuri = int.Parse(Console.ReadLine());
            VagonPersoane vagonPersoane = new VagonPersoane(masa, anFabricatie,nrLocuri);
            return vagonPersoane;
        }
        static void AfisareToateVagoane(Tren tren, Vagon[] vagon, int n, int[] tipVagon)
        {
            //afisam vagoanele de la 0 la n si ce tip de vagon sunt
            Console.WriteLine($"Trenul {tren.Nume} are urmatoarele {n} tipuri de vagoane: ");
            for (int i = 0; i < n; i++)
            {
                if (tipVagon[i] == 0)
                {
                    Console.WriteLine($"Vagonul {i} are masa de {vagon[i].Masa} kg si a fost fabricat in anul {vagon[i].AnFabricatie} si tipul vagonului este de marfa");
                }
                else if(tipVagon[i] == 1)
                {
                    Console.WriteLine($"Vagonul {i} are masa de {vagon[i].Masa} kg si a fost fabricat in anul {vagon[i].AnFabricatie} si tipul vagonului este de persoane");
                }
                else if(tipVagon[i]==2)
                {
                    Console.WriteLine($"Vagonul {i} are masa de {vagon[i].Masa} kg si a fost fabricat in anul {vagon[i].AnFabricatie} si tipul vagonului este clasa I");
                }
                else
                {
                    Console.WriteLine($"Vagonul {i} are masa de {vagon[i].Masa} kg si a fost fabricat in anul {vagon[i].AnFabricatie} iar tipul vagonului nu este atribuit");
                }
            }
            
        }
        
        static void AccesareFunctii(Tren tren, Locomotiva locomotiva, Vagon[] vagon, int n, int[] tipVagon, VagonClasa1[] vagonClasaI, VagonDeMarfa[] vagonMarfa, VagonPersoane[] vagonPersoane)
        {
            //am complicat-o aici pt ca nu stiam sa fac mai simplu, accesam orice functie/informatie de la tren/vagoane
            bool executa = true;
            while (executa == true)
            {
                Console.WriteLine("Doriti sa accesati functiile trenului(0), locomotivei(1) sau ale unui vagon specific(2)");
                int optiunile = int.Parse(Console.ReadLine());
                if (optiunile == 0)
                {
                    Console.WriteLine("Doriti sa opriti(0) sau sa porniti(1) trenul?");
                    optiunile = int.Parse(Console.ReadLine());
                    if (optiunile == 0) { tren.Opreste(); }
                    else if (optiunile == 1) { tren.Pleaca(); }
                    else { Console.WriteLine("Optiune inexistenta!"); }
                }
                else if (optiunile == 1)
                {
                    Console.WriteLine("Doriti sa opriti(0) sau sa porniti(1) locomotiva?");
                    optiunile = int.Parse(Console.ReadLine());
                    if (optiunile == 0) { locomotiva.Opreste(); }
                    else if (optiunile == 1) { locomotiva.Pornese(); }
                    else { Console.WriteLine("Optiune inexistenta!"); }
                }
                else if (optiunile == 2)
                {
                    Console.WriteLine($"Ce vagon doriti sa accesati? Vagoanele sunt numerotate de la 0 la {n - 1}!");
                    optiunile = int.Parse(Console.ReadLine());
                    if (optiunile > (n) || optiunile < 0)
                    {
                        Console.WriteLine("Vagon inexistent!");
                    }
                    else
                    {
                        if (tipVagon[optiunile] == 0)
                        {
                            Console.WriteLine($"Vagonul {optiunile} are masa de {vagonMarfa[optiunile].Masa} kg si a fost fabricat in anul {vagonMarfa[optiunile].AnFabricatie} si tipul vagonului este de marfa");
                            Console.WriteLine($"Vagonul de marfa are capacitatea de {vagonMarfa[n].Capacitate} si transporta {vagonMarfa[optiunile].TipMarfa}");
                        }
                        else if (tipVagon[optiunile] == 1)
                        {
                            Console.WriteLine($"Vagonul {optiunile} are masa de {vagonPersoane[optiunile].Masa} kg, a fost fabricat in anul {vagonPersoane[optiunile].AnFabricatie} si este un vagonului de persoane cu {vagonPersoane[optiunile].NrLocuri} locuri");
                            Console.WriteLine("Doriti sa deschideti(0) sau sa inchdeti(1) usile?");
                            int usi = int.Parse(Console.ReadLine());
                            if (usi == 0) { vagonPersoane[optiunile].Deschide(); }
                            else if (usi == 1) { vagonPersoane[optiunile].Inchide(); }
                            else { Console.WriteLine("Optiune inexistenta!"); }
                        }
                        else if (tipVagon[optiunile] == 2)
                        {
                            Console.WriteLine($"Vagonul {optiunile} are masa de {vagonClasaI[optiunile].Masa} kg si a fost fabricat in anul {vagonClasaI[optiunile].AnFabricatie} si tipul vagonului este clasa I");
                            Console.WriteLine("Doriti sa porniti(0) sau sa opriti(1) aerul conditionat?");
                            int ac = int.Parse(Console.ReadLine());
                            if (ac == 0) { vagonClasaI[optiunile].Porneste(); }
                            else if (ac == 1) { vagonClasaI[optiunile].Opreste(); }
                            else { Console.WriteLine("Optiune inexistenta!"); }
                        }
                        else { Console.WriteLine($"Vagonul {optiunile} are masa de {vagon[optiunile].Masa} kg si a fost fabricat in anul {vagon[optiunile].AnFabricatie} iar tipul vagonului nu este atribuit"); }
                    }

                }
                else { Console.WriteLine("Optiune inexistenta!"); }
                Console.WriteLine("Doriti sa accesati alta functie? Da(1) Nu(0)");
                int stopper = int.Parse(Console.ReadLine());
                if(stopper == 1) { executa = true; }
                else { executa = false; }

            }
        }
    }

    
}
