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

        public string SenderId { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        public string RecepientId { get; set; }

        public virtual ApplicationUser Recepient { get; set; }

        [MaxLength(MessageMaxLength)]
        public string Message { get; set; }

        public DateTime Date { get; set; }
    }
}
