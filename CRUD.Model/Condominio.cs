using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model
{
    public class Condominio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Bairro { get; set; }
        public ICollection<Familia> Familias { get; set; }
    }
}
