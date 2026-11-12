using tumakov_lab.Classes;
using tumakov_lab.Enums;

namespace tumakov_lab
{
    internal class Program
    {
        public static decimal ReadDecimal(string prompt)
        {
            decimal balance;
            bool isValid;
            do
            {
                Console.Write(prompt);
                isValid = decimal.TryParse(Console.ReadLine(), out balance);
                if (!isValid)
                    Console.WriteLine("Ошибка! Введите корректное число");
            } while (!isValid);
            return balance;
        }

        public static int ReadInt(string prompt)
        {
            int number;
            bool isValid;
            do
            {
                Console.Write(prompt);
                isValid = int.TryParse(Console.ReadLine(), out number);
                if (!isValid)
                    Console.WriteLine("Ошибка! Введите корректное число");
            } while (!isValid);
            return number;
        }

        #region Упражнение 8.1
        public static void Task81()
        {
            Console.WriteLine("\nУпражнение 8.1");
            BankAccount account = new BankAccount();
            account.Balance = ReadDecimal("Введите баланс счета: ");
            Console.Write("Введите название выбранного счета (текущий, сберегательный): ");
            string accountType;
            do
            {
                accountType = Console.ReadLine().ToLower();

                if (accountType != "текущий" && accountType != "сберегательный")
                    Console.Write("Ошибка! Введите тип счета корректно: ");

            } while (accountType != "текущий" && accountType != "сберегательный");

            if (accountType == "текущий")
                account.AccountType = BankAccountType.Текущий;
            else
                account.AccountType = BankAccountType.Сберегательный;

            Console.WriteLine("\nИнформация о счете: ");
            account.PrintBankAccount();

            Console.WriteLine("\nПроверка перевода между счетами 2 и 3:");

            BankAccount account1 = new BankAccount();
            BankAccount account2 = new BankAccount();

            account1.Balance = ReadDecimal("Введите баланс второго счета: ");
            account2.Balance = ReadDecimal("Введите баланс третьего счета: ");

            Console.WriteLine("\nСчета до перевода:");
            account1.PrintBankAccount();
            account2.PrintBankAccount();

            BankAccount accountFrom;
            BankAccount accountTo;
            int fromNumber;
            int toNumber;

            do
            {
                fromNumber = ReadInt("\nВведите номер счета, с которого нужно перевести деньги: ");

                if (fromNumber == account1.AccountNumber)
                    accountFrom = account1;
                else if (fromNumber == account2.AccountNumber)
                    accountFrom = account2;
                else
                {
                    accountFrom = null;
                    Console.WriteLine("Такого счета нет. Попробуйте еще раз");
                }

            } while (accountFrom == null);

            do
            {
                toNumber = ReadInt("Введите номер счета, на который нужно перевести деньги: ");

                if (toNumber == account1.AccountNumber)
                    accountTo = account1;
                else if (toNumber == account2.AccountNumber)
                    accountTo = account2;
                else
                {
                    accountTo = null;
                    Console.WriteLine("Такого счета нет. Попробуйте еще раз");
                }

                if (accountTo == accountFrom)
                {
                    Console.WriteLine("Нельзя переводить деньги на тот же счет");
                    accountTo = null;
                }

            } while (accountTo == null);

            decimal transfer = ReadDecimal("Введите сумму перевода: ");

            accountTo.Transfer(accountFrom, transfer);

            Console.WriteLine("\nИнформация о счетах после перевода:");
            account1.PrintBankAccount();
            account2.PrintBankAccount();
        }
        #endregion

        #region Упражнение 8.2
        /// <summary>
        /// Переворачивает строку
        /// </summary>
        public static string ReverseString(string text)
        {
            string result = String.Empty;

            for (int i = text.Length - 1; i >= 0; i--)
                result += text[i];
            return result;
        }

        public static void Task82()
        {
            Console.WriteLine("\nУпражнение 8.2");
            Console.Write("Введите строку, состоящую из букв: ");
            string text = Console.ReadLine();
            string reversedText = ReverseString(text);
            Console.WriteLine($"Строка в обратном порядке: {reversedText}");
        }
        #endregion

        #region Упражнение 8.3
        public static void Task83()
        {
            Console.WriteLine("\nУпражнение 8.3");
            Console.Write("Введите имя исходного файла (включая расширение): ");
            string fileName = Console.ReadLine();
            string filePath = $"..\\..\\..\\Files\\{fileName}";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Ошибка! Файл с таким названием не существует");
                return;
            }

            string text = File.ReadAllText(filePath);
            text = text.ToUpper();
            string outputFilePath = "..\\..\\..\\Files\\Output.txt";
            File.WriteAllText(outputFilePath, text);
            Console.WriteLine($"Результат записан в файл \"Output.txt\"");
        }
        #endregion

        #region Упражнение 8.4
        /// <summary>
        /// проверяет, реализует ли объект интерфейс IFormattable и выводит его значение в формате
        /// </summary>
        public static void CheckIFormattable(object value)
        {
            if (value is IFormattable)
            {
                string typeName = value.GetType().Name;
                Console.WriteLine($"\nОбъект {typeName} со значением '{value}' реализует интерфейс IFormattable");
                IFormattable formattable = value as IFormattable;
                Console.WriteLine($"Форматированное значение: {formattable.ToString("F2", null)}");
            }
            else
                Console.WriteLine("\nОбъект не реализует интерфейс IFormattable");
        }

        public static void Task84()
        {
            Console.WriteLine("\nУпражнение 8.4");
            int number = 25;
            double decimalNumber = 12.3456;
            string text = "Hello";

            CheckIFormattable(number);
            CheckIFormattable(decimalNumber);
            CheckIFormattable(text);
        }
        #endregion

        #region Домашнее задание 8.1
        /// <summary>
        /// выделяет адрес электронной почты из строки, удаляя фио и разделитель #
        /// </summary>
        public static void SearchMail(ref string s)
        {
            int index = s.IndexOf("#");
            if (index != -1)
                s = s.Substring(index + 1).Trim();
        }

        public static void TaskDz81()
        {
            Console.WriteLine("\nДомашнее задание 8.1");
            string filePath = "..\\..\\..\\Files\\EmailInput.txt";
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i++)
                SearchMail(ref lines[i]);

            string outputFilePath = "..\\..\\..\\Files\\EmailOutput.txt";
            File.WriteAllLines(outputFilePath, lines);
            Console.WriteLine("Список адресов электронных почт записан в \"EmailOutput.txt\"");
        }
        #endregion

        #region Домашнее задание 8.2
        public static void TaskDz82()
        {
            Console.WriteLine("\nДомашнее задание 8.2");
            List<Song> songs = new List<Song>();

            Song song1 = new Song()
            {
                Name = "SUIAYSU",
                Author = "Stray Kids"
            };
            songs.Add(song1);

            Song song2 = new Song()
            {
                Name = "ai no katachi",
                Author = "Asa"
            };
            songs.Add(song2);
            song2.Prev = song1;

            Song song3 = new Song()
            {
                Name = "Supersonic",
                Author = "Oasis"
            };
            songs.Add(song3);
            song3.Prev = song2;

            Song song4 = new Song()
            {
                Name = "Beauty And A Beat",
                Author = "Justin Bieber"
            };
            songs.Add(song4);
            song4.Prev = song3;

            Song song5 = new Song();
            Console.Write("Введите название песни: ");
            song5.Name = Console.ReadLine();
            Console.Write("Введите автора песни: ");
            song5.Author = Console.ReadLine();
            songs.Add(song5);
            song5.Prev = song4;

            Console.WriteLine("\nСписок песен: ");
            foreach (Song song in songs)
                song.PrintSong();

            Console.WriteLine("\nСравнение первой и второй песни: ");
            if (songs[0].Equals(songs[1]))
                Console.WriteLine("Песни 1 и 2 одинаковые");
            else
                Console.WriteLine("Песни 1 и 2 разные");
        }
        #endregion

        static void Main(string[] args)
        {
            Task81();
            Task82();
            Task83();
            Task84();
            TaskDz81();
            TaskDz82();
        }
    }
}