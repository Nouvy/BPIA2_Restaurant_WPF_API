using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPIA2_Restaurant_WPF_API.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Places { get; set; }
        public List<Commande> Commandes { get; set; }
    }
}
