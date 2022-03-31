using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model
{
    public class Morador
    {
        public int Id { get; set; }
        public int Id_Familia { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Familia Familia { get; set; }
    }
}
