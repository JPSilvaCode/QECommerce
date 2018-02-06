using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QECommerce.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nome")]
        [MaxLength(50, ErrorMessage = "O campo {0} recebe no máximo 50 caracteres.")]
        [Index("Departament_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Telefone")]
        [MaxLength(20, ErrorMessage = "O campo {0} recebe no máximo 50 caracteres.")]       
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Endereço")]
        [MaxLength(100, ErrorMessage = "O campo {0} recebe no máximo 50 caracteres.")]
        public string Address { get; set; }
       
        [Display(Name = "Imagem")]      
        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Departamento")]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Cidade")]
        public int CityId { get; set; }        

        public virtual Departaments Departaments { get; set; }
        public virtual City Cities { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<Tax> Tax { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<WareHouse> WareHouse { get; set; }
        //public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<CompanyCustomer> CompanyCustomers { get; set; }
        public virtual ICollection<CompanyProvider> CompanyProviders { get; set; }
        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}