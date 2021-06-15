using OrchardCore.ContentManagement;
using System.ComponentModel.DataAnnotations;

namespace INZFS.MVC.Models.Core
{
    public class RefrenceNumberPart : ContentPart
    {
        [Required]
        public string FundAbbvreviation { get; set; }

        [Required]
        public string FundRound { get; set; }

        [Required]
        public string AutomatedNumber { get; set; }


    }

}
