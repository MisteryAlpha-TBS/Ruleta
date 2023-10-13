using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruleta.Clases
{
    internal class estadisticas
    {
        public int ganancia;
        public int tiradas;
        public int tiradasRed;
        public int tiradasBlack;
        public int tiradasPar;
        public int tiradasImpar;
        public int win;
        public int lose;
        public int[] num;
        

        public estadisticas(int ganancia)
        {
            this.win = 0;
            this.lose = 0;
            this.ganancia = ganancia;
            this.tiradas = 0;
            this.tiradasRed = 0;
            this.tiradasBlack = 0;
            this.tiradasPar = 0;
            this.tiradasImpar = 0;
            this.num = new int[0];
        }
    }

}
