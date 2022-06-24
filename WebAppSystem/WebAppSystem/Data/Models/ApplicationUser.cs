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
            this.SentTransactions = new HashSet<Transaction>();
            this.ReceivedTransactions = new HashSet<Transaction>();
        }

        [Required]
        public int CreditAmount { get; set; }

       public virtual ICollection<Transaction> SentTransactions { get; set; }

       public virtual ICollection<Transaction> ReceivedTransactions { get; set; }
    }
}
