using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lakotron.ViewModels
{
    public class PaymentViewModel
    {
        [Required(ErrorMessage = "Please, Enter Name")]
        [MaxLength(30, ErrorMessage = "Name can't be greater then 30 chars")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, Enter CardNumber")]
        [MaxLength(16, ErrorMessage = "Invalid Card Number")]
        [MinLength(16, ErrorMessage = "Invalid Card Number")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Please, Enter ExpirationDate")]
        [MaxLength(5, ErrorMessage = "Invalid Expiration Date")]
        [MinLength(5, ErrorMessage = "Invalid Expiration Date")]
        public string ExpirationDate { get; set; }

        [Required(ErrorMessage = "Please, Enter ErrorMessage")]
        public int SecurityCode { get; set; }

        public string Error { get; set; }
    }
}
