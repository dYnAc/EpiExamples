using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace EpiExamples.Models.People
{
    [ContentType(DisplayName = "Person Content", GUID = "c41959cf-efc1-4e5f-b79d-78d3b8e5af13")]
    public class PersonContent : StandardContentBase // Inherits from a different class PageData or BlockData 
    {
        [Required]
        [Display(Name = "First Name", Order = 10)]
        public virtual string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name", Order = 20)]
        public virtual string LastName { get; set; }

        [CultureSpecific]
        [Required]
        [Display(Name = "Job Position", Order = 30)]
        public virtual string JobPosition { get; set; }

        [Required]
        [Display(Name = "Age", Order = 40)]
        public virtual int AddressLine2 { get; set; }
    }
}