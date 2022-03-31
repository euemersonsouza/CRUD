using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model
{
    public class Familia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Apto { get; set; }
        public int Id_Condominio { get; set; }
        public ICollection<Morador> Moradores { get; set; }
        public Condominio Condominio { get; set;}
    }
}
