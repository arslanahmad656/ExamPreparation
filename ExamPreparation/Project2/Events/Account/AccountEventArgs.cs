using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Events.Account
{
    class AccountEventArgs : EventArgs
    {
        public AccountEventArgs(decimal previous, decimal current)
        {
            PreviousBalance = previous >= 0 ? previous : throw new ArgumentOutOfRangeException($"Balance must be a valid figure.");
            CurrentBalance = current >= 0 ? current : throw new ArgumentOutOfRangeException($"Balance must be a valid figure.");
            TransactionAmount = CurrentBalance - PreviousBalance;
            TransactionType = CurrentBalance > PreviousBalance ? TransactionType.Credit : TransactionType.Debit;
        }

        public TransactionType TransactionType { get; private set; }

        public decimal PreviousBalance { get; private set; }

        public decimal CurrentBalance { get; private set; }

        public decimal TransactionAmount { get; private set; }

        public override string ToString()
            => $"{TransactionType} transaction of {TransactionAmount.ToString("C2", System.Globalization.CultureInfo.CurrentCulture)}." +
                $"{Environment.NewLine}Previous Balance: {PreviousBalance.ToString("C2", System.Globalization.CultureInfo.CurrentCulture)}" +
                $"{Environment.NewLine}Current Balance: {CurrentBalance.ToString("C2", System.Globalization.CultureInfo.CurrentCulture)}";
    }

    enum TransactionType
    {
        Debit,
        Credit
    }
}
