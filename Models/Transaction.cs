using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        public bool IsIncome { get; set; }
        public string? Note { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public decimal GetAmount()
        {
            if (!IsIncome)
            {
                return -Amount;
            }
            return Amount;
        }
    }
}
