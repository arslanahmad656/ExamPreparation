using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Events.Account
{
    class Account
    {
        private decimal balance;
        private readonly string _title;
        private readonly object _lock = new object();

        public event EventHandler<AccountEventArgs> OnBalanceChanged = delegate { };

        public decimal Balance
        {
            get => balance;
            private set
            {
                balance = value >= 0M ? value : throw new ArgumentOutOfRangeException("Balance must be a valid figure.");
            }
        }

        public string Title => _title;

        public Account(string title, decimal initialDeposit)
        {
            Balance = initialDeposit;
            _title = title;
        }

        public void Credit(decimal amount)
        {
            var previous = Balance;
            lock (_lock)
            {
                Balance = amount >= 0 ? Balance + amount : throw new ArgumentOutOfRangeException("Amount must be a valid figure.");
            }

            OnBalanceChanged(this, new AccountEventArgs(previous, Balance));
        }

        public void Debit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Amount must be a valid figure.");
            }

            if (Balance - amount < 0)
            {
                throw new ArgumentOutOfRangeException("Not enough balance.");
            }

            var previous = Balance;
            lock (_lock)
            {
                Balance = Balance - amount;
            }

            OnBalanceChanged(this, new AccountEventArgs(previous, Balance));
        }

        public override string ToString()
            => $"Account Title: {Title}{Environment.NewLine}Account Balance: {Balance.ToString("C2", System.Globalization.CultureInfo.CurrentCulture)}";
    }
}
