using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data.Entities
{
    public class Owner
    {
        [Required]
        [MaxLength (50)]
        public int Id { get; set; }

        [Required]
        [MaxLength(13)]
        [Display(Name = "Cédula")]
        public string Document { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Firts Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Fixed Phone")]
        public string FixedPhone { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Cells Phone")]
        public string CellsPhone { get; set; }
               
        public string Address { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

        public ICollection<Property> Properties { get; set; }
        public ICollection<Contract> Contracts { get; set; }

    }
}
