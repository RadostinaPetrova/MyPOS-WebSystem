namespace WebAppSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.CreditAmount = InitialCreditAmount;
        }

        [Required]
        public int CreditAmount { get; set; }
    }
}
