using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPIA2_Restaurant_WPF_API.Models
{
    public class Commande
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public float TotalHT { get; set; }
        public float TotalTTC { get; set; }
        public List<Menu> Menus { get; set; }
        public List<Article> Articles { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}
