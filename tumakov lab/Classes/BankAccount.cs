using tumakov_lab.Enums;

namespace tumakov_lab.Classes
{
    public class BankAccount
    {
        private static int _nextAccountNumber = 1;

        private int _accountNumber;
        private decimal _balance;
        private BankAccountType _accountType;

        public int AccountNumber
        {
            get { return _accountNumber; }
        }

        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public BankAccountType AccountType
        {
            get { return _accountType; }
            set { _accountType = value; }
        }

        /// <summary>
        /// Создает банковский счет с уникальным номером
        /// </summary>
        public BankAccount()
        {
            _accountNumber = GenerateAccountNumber();
        }

        /// <summary>
        /// Генерирует следующий номер счета
        /// </summary>
        /// <returns>Уникальный номер счета</returns>
        private static int GenerateAccountNumber()
        {
            int accountNumber = _nextAccountNumber;
            _nextAccountNumber++;
            return accountNumber;
        }

        public BankAccount(int accountNumber, decimal balance, BankAccountType accountType)
        {
            _accountNumber = accountNumber;
            _balance = balance;
            _accountType = accountType;
        }

        /// <summary>
        /// Метод, который позволяет положить деньги на счет
        /// </summary>
        /// <param name="amount">Сумма пополнения</param>
        /// <exception cref="ArgumentException">Выбрасывается, если переданная сумма меньше или равна нулю</exception>
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма пополнения должна быть больше нуля");
            _balance += amount;
            //return _balance;
        }

        /// <summary>
        /// Метод, который позволяет снять деньги со счёта, если баланса достаточно
        /// </summary>
        /// <param name="amount">Сумма снятия</param>
        /// <exception cref="ArgumentException">Выбрасывается, если снимаемая сумма меньше или равна нулю</exception>
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма, снимаемая со счета, должна быть больше нуля");
            if (_balance >= amount)
            {
                _balance -= amount;
                Console.WriteLine("Деньги успешно сняты!");
            }
            else
                Console.WriteLine("Недостаточно средств на счете");
        }

        /// <summary>
        /// Метод для перечисления денег с одного счета на другой
        /// </summary>
        /// <param name="accountFrom">аккаунт с которого переводят</param>
        /// <param name="amount">сумма перечисления</param>
        public void Transfer(BankAccount accountFrom, decimal amount)
        {
            if (accountFrom == null)
                throw new ArgumentNullException(nameof(accountFrom));

            if (amount <= 0)
                throw new ArgumentException("Сумма перевода должна быть больше нуля");

            if (accountFrom == this)
                throw new ArgumentException("Нельзя переводить деньги на тот же счет");

            if (accountFrom._balance >= amount)
            {
                accountFrom.Withdraw(amount);
                Deposit(amount);
                Console.WriteLine("Перевод успешно выполнен!");
            }
            else
                Console.WriteLine("Недостаточно средств для перевода");
        }

        public void PrintBankAccount()
        {
            Console.WriteLine($"Номер счета: {AccountNumber}, баланс: {Balance}, тип счета: {AccountType}");
        }
    }
}
