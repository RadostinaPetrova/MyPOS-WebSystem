namespace WebAppSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CreditAmount { get; set; }

        //[Required]
        public string SenderId { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        //[Required]
        public string RecipientId { get; set; }

        public virtual ApplicationUser Recipient { get; set; }

        [MaxLength(MessageMaxLength)]
        public string Message { get; set; }

        public DateTime Date { get; set; }
    }
}
