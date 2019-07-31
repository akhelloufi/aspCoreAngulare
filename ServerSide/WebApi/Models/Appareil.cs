using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Appareil
    {
            [Key]
            public int ID { get; set; }

            //[index("codeapp", IsUnique = true)]
            public string CodeAppareil { get; set; }
            public string NomAppareil { get; set; }
            //

            public DateTime DateAchat { get; set; }
            public DateTime DateFabrication { get; set; }
            public DateTime DerniereDateUtilisation { get; set; }
            public String NatureMaladieTraitent { get; set; }
            public double prixAchat { get; set; }
            //-Fréquence d utilisation : quotidienne ,semaine , mensuel.
            public String FrequenceUtilisation { get; set; }
            public string ConditionUtilisation { get; set; }

            public int HopitalID { get; set; }

    }
}
