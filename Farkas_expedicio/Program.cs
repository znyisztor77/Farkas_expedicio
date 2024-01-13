using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Farkas_expedicio
{
    internal class Program
    {

        struct Expedicio
        {
            public int Nap { get; set; }
            public int Amator { get; set; }
            public string Uzenet { get; set; }

        }

        static void Main(string[] args)
        {

            Console.WriteLine("Farkas expediciós feladat:");
            int db = 0;
            string fajlnev = ("veetel.txt");

            Console.WriteLine("1. feladat: ");
            List<Expedicio> expedicio = Adatokbeolvas(fajlnev);

            Console.WriteLine("2. feladat: ");
            Console.WriteLine("Az első üzenetet rögzítője:" + expedicio[0].Amator);
            Console.WriteLine("Az utolsó üzenetet rögzítője:" + expedicio[expedicio.Count - 1].Amator);
            
            Console.WriteLine("3. feladat: ");
            farkasKeres(expedicio);

            Console.WriteLine("4. feladat: ");

            
            /*for(int i = 0; i < expedicio.Count; i++)
            {
                Console.WriteLine($"{expedicio[i].Nap}, {expedicio[i].Amator}");
                 
            }*/
            statisztika(expedicio);
            Console.ReadKey();
        }

        private static void statisztika(List<Expedicio> expedicio)
        {
            int [] amatorDarab = new int[12];
            int db = 0;            
            int nap = 1;

            while (nap <= 11)
            {
                for(int i = 0; i<expedicio.Count; i++)
                {
                    if (expedicio[i].Nap == nap)
                    {
                        db++;
            
                    }
                }
                amatorDarab[nap] = db;
                db = 0;

                nap++;
            }
                       
            // A feladat kiírása
            for(int i = 1;i < amatorDarab.Length; i++)
             {
                 Console.WriteLine($"{i}. napon {amatorDarab[i]}  rádióamtőr."); 
             }
        }

        private static void farkasKeres(List<Expedicio> expedicio)
        {            
            for(int i = 0; i< expedicio.Count; i++)
            {
                if (expedicio[i].Uzenet.Contains("farkas"))
                {
                    Console.WriteLine($"{expedicio[i].Nap}. nap: {expedicio[i].Amator}. rádióamtőr.");
                    Console.Write("Az üzenet amelyik tartalmazza a farkas szót:  ");
                    Console.WriteLine(expedicio[i].Uzenet);

                }
            }
            

           

        }

        private static List<Expedicio> Adatokbeolvas(string fajlnev)
        {
            List<Expedicio> expedicio = new List<Expedicio>();
            string sor;
            string[] sorok;

            if (!File.Exists(fajlnev))
            {
                Console.WriteLine("Nincs adat");
            }
            else
            {
                Console.WriteLine("Fájl tartalma beolvasva!");
                using (StreamReader sr = new StreamReader(fajlnev))
                {
                    int darab = 0;                    
                    while (!sr.EndOfStream)
                    {
                        Expedicio expediciok = new Expedicio();
                                            
                        sor = sr.ReadLine();
                        sorok = sor.Split(' ');
                        string temp = sr.ReadLine();
                        if (darab % 2 == 0)
                        {
                            expediciok.Nap = int.Parse(sorok[0]);
                            expediciok.Amator = int.Parse(sorok[1]);
                            expediciok.Uzenet = temp;
                            expedicio.Add(expediciok);
                        }
                    
                    darab++;

                    }
                }           
               
            }
                return expedicio;
        }
       
    }
}
