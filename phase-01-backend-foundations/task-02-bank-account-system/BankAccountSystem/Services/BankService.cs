using BankAccountSystem.Models;

namespace BankAccountSystem.Services
{
    public class BankService
    {
        private readonly List<BankAccount> accounts = new();
        private readonly List<Transaction> transactions = new();
        public void CreateCustomerAccount()
        {
            Console.Clear();
            string? name;
            string? email;
            string? phone;
            decimal intitalBalance;
            int accountType;
            bool isValid;
            do
            {
                Console.Write("Enter Full Name: ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name is required.");
                }

            } while (string.IsNullOrWhiteSpace(name));
            do
            {
                Console.Write("Enter Email: ");
                email = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(email))
                {
                    Console.WriteLine("Email is required.");
                }
                else if (!email.Contains('@') || !email.Contains('.'))
                {
                    Console.WriteLine("Invalid email format.");
                }

            } while (string.IsNullOrWhiteSpace(email)||!email.Contains('@') || !email.Contains('.'));
            do
            {
                Console.Write("Enter Phone: ");
                phone = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(phone))
                {
                    Console.WriteLine("Phone number is required.");
                }
                else if (phone.Length < 11 || !phone.All(char.IsDigit))
                {
                    Console.WriteLine("Invalid phone number.");
                }

            } while (string.IsNullOrWhiteSpace(phone)||phone.Length < 11 || !phone.All(char.IsDigit));
            do
            {
                Console.Write("Enter initial Balance: ");
                isValid = decimal.TryParse(Console.ReadLine(), out intitalBalance);
                if (!isValid || intitalBalance < 0)
                {
                    Console.WriteLine("Initial balance cannot be negative.");
                }

            } while (!isValid || intitalBalance < 0);
            do
            {
                Console.WriteLine("Enter Account type: ");
                Console.WriteLine("1. Savings");
                Console.WriteLine("2. Current");
                isValid = int.TryParse(Console.ReadLine(), out accountType);
                if (!isValid || (accountType != 1 && accountType != 2))
                {
                    Console.WriteLine("Please enter digit 1 for Savings or digit 2 for current. ");
                }


            } while (!isValid || (accountType != 1 && accountType != 2));

            Customer customer = new Customer
            {
                CustomerId = 1 + accounts.Count,
                FullName = name,
                Email = email,
                PhoneNumber = phone
            };

            BankAccount bankAccount = new BankAccount
            {
                AccountNumber = 100 + accounts.Count,
                Customer = customer,
                CustomerId = customer.CustomerId,
                AccountType = accountType == 1 ? AccountType.Savings : AccountType.Current,
                IsActive = true
            };
            if (intitalBalance > 0)
            {
                bankAccount.Deposit(intitalBalance);
                Transaction transaction = new Transaction()
                {
                    TransactionId = 1 + transactions.Count,
                    TransactionType = TransactionType.Deposit,
                    AccountNumber = bankAccount.AccountNumber,
                    Amount = intitalBalance,
                    TransactionDate = DateTime.Now,
                    Description = "Initial balance is added tp the account.",
                    BalanceAfterTransaction = bankAccount.Balance
                };

                transactions.Add(transaction);

            }
            accounts.Add(bankAccount);
            Console.WriteLine($"Account with number {bankAccount.AccountNumber} created successfully.");

        }

        public void DepositMoney()
        {
            Console.Clear();
            bool isvalid;
            int accountNo;
            BankAccount? account = null;

            do
            {
                Console.Write("Enter account number: ");
                isvalid = int.TryParse(Console.ReadLine(), out accountNo);
                if (isvalid)
                    account = accounts.FirstOrDefault(a => a.AccountNumber == accountNo);
                if (!isvalid || account == null)
                {
                    Console.WriteLine("Invalid Account Number.");
                }
            } while (!isvalid || account == null);

            decimal amount;
            do
            {
                Console.Write("Enter Amount: ");
                isvalid = decimal.TryParse(Console.ReadLine(), out amount);
                if (!isvalid)
                    Console.WriteLine("Invalid Amount.");
                else if (amount <= 0)
                    Console.WriteLine("Amount must be positive.");
            } while (!isvalid || amount <= 0);

            bool succeed = account.Deposit(amount);

            if (succeed)
            {
                decimal newBalance = account.Balance;



                Transaction transaction = new Transaction()
                {
                    TransactionId = 1 + transactions.Count,
                    TransactionType = TransactionType.Deposit,
                    AccountNumber = accountNo,
                    Amount = amount,
                    TransactionDate = DateTime.Now,
                    Description = "A new Deposit Transaction.",
                    BalanceAfterTransaction = newBalance
                };

                transactions.Add(transaction);

                Console.WriteLine($"Deposit completed successfully.");
                Console.WriteLine($"Current Balance: {account.Balance:C}");
            }
            else
            {
                Console.WriteLine("Failed to make deposit");
            }


        }

        public void WithdrawMoney()
        {
            Console.Clear();
            bool isvalid;
            int accountNo;
            BankAccount? account = null;

            do
            {
                Console.Write("Enter account number: ");
                isvalid = int.TryParse(Console.ReadLine(), out accountNo);
                if (isvalid)
                    account = accounts.FirstOrDefault(a => a.AccountNumber == accountNo);
                if (!isvalid || account == null)
                {
                    Console.WriteLine("Invalid Account Number.");
                }
            } while (!isvalid || account == null);

            decimal amount;
            do
            {
                Console.Write("Enter Amount: ");
                isvalid = decimal.TryParse(Console.ReadLine(), out amount);
                if (!isvalid)
                    Console.WriteLine("Invalid Amount.");
                else if (amount <= 0)
                    Console.WriteLine("Amount must be positive.");
                else if (amount > account.Balance)
                    Console.WriteLine("Amount must not exceed balance");
            } while (!isvalid || amount <= 0 || amount > account.Balance);

            bool succeed = account.Withdraw(amount);

            if (succeed)
            {
                Transaction transaction = new Transaction()
                {
                    TransactionId = 1 + transactions.Count,
                    TransactionType = TransactionType.Withdraw,
                    AccountNumber = accountNo,
                    Amount = amount,
                    TransactionDate = DateTime.Now,
                    Description = "A new Withdraw Transaction.",
                    BalanceAfterTransaction = account.Balance
                };

                transactions.Add(transaction);

                Console.WriteLine($"Withdraw completed successfully.");
                Console.WriteLine($"Current Balance: {account.Balance:C}");
            }
            else
            {
                Console.WriteLine("Failed to make Withdraw");
            }

        }

        public void TransferMoney()
        {
            Console.Clear();
            bool isvalid;
            int sourceAccountNo;
            int destinationAccountNo;
            BankAccount? sourceAccount = null;
            BankAccount? destinationAccount = null;

            do
            {
                Console.Write("Enter source account number: ");
                isvalid = int.TryParse(Console.ReadLine(), out sourceAccountNo);
                if (isvalid)
                    sourceAccount = accounts.FirstOrDefault(a => a.AccountNumber == sourceAccountNo);
                if (!isvalid || sourceAccount == null)
                {
                    Console.WriteLine("Invalid Account Number.");
                }
            } while (!isvalid || sourceAccount == null);
            do
            {
                Console.Write("Enter destination account number: ");
                isvalid = int.TryParse(Console.ReadLine(), out destinationAccountNo);
                if (isvalid)
                    destinationAccount = accounts.FirstOrDefault(a => a.AccountNumber == destinationAccountNo);
                if (destinationAccountNo == sourceAccountNo)
                {
                    Console.WriteLine("Source and Destination account can not be the same ");
                }
                if (!isvalid || destinationAccount == null)
                {
                    Console.WriteLine("Invalid Account Number.");
                }
            } while (!isvalid || destinationAccount == null || destinationAccountNo == sourceAccountNo);
            decimal amount;
            do
            {
                Console.Write("Enter Amount: ");
                isvalid = decimal.TryParse(Console.ReadLine(), out amount);
                if (!isvalid)
                    Console.WriteLine("Invalid Amount.");
                else if (amount <= 0)
                    Console.WriteLine("Amount must be positive.");
                else if (amount > sourceAccount.Balance)
                    Console.WriteLine("Source amount is not enough.");
            } while (!isvalid || amount <= 0 || amount > sourceAccount.Balance);

            bool sourceSucceed = sourceAccount.Withdraw(amount);



            if (sourceSucceed)
            {
                destinationAccount.Deposit(amount);

                Transaction transaction = new Transaction()
                {
                    TransactionId = 1 + transactions.Count,
                    TransactionType = TransactionType.TransferOut,
                    AccountNumber = sourceAccountNo,
                    Amount = amount,
                    TransactionDate = DateTime.Now,
                    Description = $"Transfer {amount} to account {destinationAccountNo}",
                    BalanceAfterTransaction = sourceAccount.Balance
                };

                transactions.Add(transaction);


                Transaction destinationTransaction = new Transaction()
                {
                    TransactionId = 1 + transactions.Count,
                    TransactionType = TransactionType.TransferIn,
                    AccountNumber = destinationAccountNo,
                    Amount = amount,
                    TransactionDate = DateTime.Now,
                    Description = $"Transfer {amount} from account {sourceAccountNo}",
                    BalanceAfterTransaction = destinationAccount.Balance
                };

                transactions.Add(destinationTransaction);

                Console.WriteLine($"Transfer completed successfully..");
            }
            else
            {
                Console.WriteLine("Transfer failed.");
            }





        }

        public void ViewAccountDetails()
        {
            Console.Clear();
            bool isvalid;
            int accountNo;
            BankAccount? account = null;
            do
            {
                Console.Write("Enter account number: ");
                isvalid = int.TryParse(Console.ReadLine(), out accountNo);
                if (isvalid)
                    account = accounts.FirstOrDefault(a => a.AccountNumber == accountNo);
                if (!isvalid || account == null)
                {
                    Console.WriteLine("Invalid Account Number.");
                }
            } while (!isvalid || account == null);
            string status = account.IsActive ? "Active" : "Not Active";
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Account number: {account.AccountNumber}");
            Console.WriteLine($"Customer name : {account.Customer.FullName}");
            Console.WriteLine($"Email         : {account.Customer.Email}");
            Console.WriteLine($"Phone         : {account.Customer.PhoneNumber}");
            Console.WriteLine($"Type          : {account.AccountType}");
            Console.WriteLine($"Balance       : {account.Balance:C}");
            Console.WriteLine($"Created Date  : {account.CreatedAt:dd/MM/yyyy}");
            Console.WriteLine($"Status        : {status}");
            Console.WriteLine("--------------------------------------------------");


        }

        public void ViewTransactionHistory()
        {
            Console.Clear();
            bool isvalid;
            int accountNo;
            BankAccount? account = null;
            do
            {
                Console.Write("Enter account number: ");
                isvalid = int.TryParse(Console.ReadLine(), out accountNo);
                if (isvalid)
                    account = accounts.FirstOrDefault(a => a.AccountNumber == accountNo);
                if (!isvalid || account == null)
                {
                    Console.WriteLine("Invalid Account Number.");
                }
            } while (!isvalid || account == null);
            var selectedTransactions = transactions.Where(t => t.AccountNumber == accountNo).OrderByDescending(t => t.TransactionDate);
            if (!selectedTransactions.Any())
                Console.WriteLine("No Transcations Found.");
            else
            {
                foreach (var transaction in selectedTransactions)
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"Type          : {transaction.TransactionType}");
                    Console.WriteLine($"Amount        : {transaction.Amount:C}");
                    Console.WriteLine($"Date          : {transaction.TransactionDate:dd/MM/yyyy}");
                    Console.WriteLine($"Description   : {transaction.Description}");
                    Console.WriteLine($"Balance After Transaction   : {transaction.BalanceAfterTransaction:C}");


                }
                Console.WriteLine("---------------------------------------------");
            }

        }

        public void ViewAllAccounts()
        {
            Console.Clear();
            if (!accounts.Any())
            {
                Console.WriteLine("No Accounts Creadted");
                return;
            }

            else
            {
                Console.WriteLine("-------------- All Accounts -----------------");
                foreach (var account in accounts)
                {
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine($"Account number: {account.AccountNumber}");
                    Console.WriteLine($"Customer name : {account.Customer.FullName}");
                    Console.WriteLine($"Type          : {account.AccountType}");
                    Console.WriteLine($"Balance       : {account.Balance:C}");
                    Console.WriteLine($"Status        : {(account.IsActive ? "Active" : "Not Active")}");
                    Console.WriteLine("-----------------------------------------------------");
                }
            }
        }
    }
}