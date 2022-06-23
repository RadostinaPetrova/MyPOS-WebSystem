namespace WebAppSystem.Models.Transactions
{
    using System.ComponentModel.DataAnnotations;
    using static WebAppSystem.Data.DataConstants;

    public class TransactionInputModel
    {
        [Required(ErrorMessage = "Credit amount is required")]
        [Range(MinSendCreditAmount, MaxSendCreditAmount, ErrorMessage = "Credit amount must be valid")]
        public int CreditAmount { get; set; }

        [Required(ErrorMessage = "The recipient’s mobile number is required")]
        [RegularExpression(@"(\+359)[0-9]{9}\b", ErrorMessage = "The mobile number is not valid")]
        public string RecipientPhoneNumber { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [StringLength(MessageMaxLength, ErrorMessage = "Description should be between {2} and {1} symbols.", MinimumLength = MessageMinLength)]
        public string Message { get; set; }
    }
}
