using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace paymybill.web.app.Models
{
    public class RegisteredBills
    {
        public int id { get; set; }

        [ForeignKey("BillTypes")]
        [Display(Name ="Bill Type")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Select bill type")]
        public int TypeId { get; set; }

        [ForeignKey("BillCompanies")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Select billing company")]
        [Display(Name = "Bill Company")]
        public int CompanyId { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name ="Bill Amount")]
        [Column(TypeName ="decimal(18,2)")]
        public decimal Amount { get; set; }

        [Display(Name = "Nick name")]
        public string BillNick { get; set; }

        //[RegularExpression]
        //[ForeignKey("Consumers")]
        [StringLength(11, ErrorMessage = "Enter valid mobile number", MinimumLength = 11)]
        [Display(Name = "Mobile Number")]
        public string ConsumerId { get; set; }

        [Required(ErrorMessage = "Enter Consumer/Reference number")]
        [Display(Name ="Consumer/Reference number")]
        public string ReferenceNumber { get; set; }

        public bool isActive { get; set; }

        public virtual Consumers Consumers { get; set; }
        public virtual BillTypes BillTypes { get; set; }
        public virtual BillCompanies BillCompanies { get; set; }

    }
}
