using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace BankAccountSystem.Models
{
    public class BankAccount
    {
        public int AccountNumber { get; set; }

        public Customer Customer { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        public decimal Balance { get; private set; }

        public AccountType AccountType { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsActive { get; set; }

        public List<Transaction> Transactions { get; set; } = new();

        public bool Deposit(decimal amount)
        {
            if (amount <= 0)
                return false;

            Balance += amount;
            return true;


        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
                return false;
            if (Balance < amount)
                return false;

            Balance -= amount;
            return true;
        }



    }
}