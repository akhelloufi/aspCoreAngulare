using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Admin
    {
        //        Donne d administrateur :
        //-Numéro de carte Nationale
        //-Nom
        //-Prénom
        //-Rôle/Spécialité
        //-TEL 
        //-EMAIL
        //-Password

        [Key]
        public int ID { get; set; }
        // [Index(IsUnique=true)]
        public string Cin { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Role { get; set; }//specialite

        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
         
        [ForeignKey("AdminID")]
        public ICollection<Hospital> Hopitals { get; set; }
    }
}
