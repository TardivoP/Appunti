using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Preparazione_verifica_info
{
    internal class Contatto
    {

        private string nome;
        private string tel;




        public  Contatto(string nome, string tel)
        {
          this.Nome=nome;
          this.Tel=tel;

        }

        public string Nome { get => nome; set => nome = value; }
        public string Tel { get => tel; set => tel = value; }


        //public override string ToString()
        //{
        //    return $"{nome}-{tel}";
        //}

    }
}
