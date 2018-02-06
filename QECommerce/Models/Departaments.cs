using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QECommerce.Models
{
    public class Departaments
    {
        [Key]
        [Display(Name = "Departamento")]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nome")]
        [MaxLength(50, ErrorMessage = "O campo {0} recebe no máximo 50 caracteres.")]
        [Index("Departament_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Company> Company { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<WareHouse> WareHouse { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Provider> Provider { get; set; }
    }
}