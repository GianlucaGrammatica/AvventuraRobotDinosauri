using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvventuraRobotDinosauri
{
    internal class Componenti
    {
        private string[] PossibleComponentys = {"Ferro", "Uranio", "Acciaio", "Cavi", "Lucine", "Interruttori", "Computer Qauuntistico", "Paperella decorativa"};
        public string Componente { get;}
        public int id;
        Random random = new Random();

        public Componenti() { 
            int index = random.Next(PossibleComponentys.Length);
            Componente = PossibleComponentys[index];
            id = 0;
        }

        public Componenti(int _id)
        {
            int index = random.Next(PossibleComponentys.Length);
            Componente = PossibleComponentys[index];
            id = _id;
        }
    }
}
