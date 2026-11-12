using dz_7.Classes;
using dz_7.Enums;

namespace dz_7
{
    internal class Program
    {
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

        static void Main(string[] args)
        {
            Company company = new Company();

            List<WorkTask> tasks = new List<WorkTask>()
            {
                new WorkTask("Настроить локальную сеть", TaskType.Системщики),
                new WorkTask("Разработать программу для бухгалтерии", TaskType.Разработчики),
                new WorkTask("Подготовить отчет отдела", TaskType.Начальство)
            };

            Console.WriteLine("Список задач: ");
            for (int i = 0; i < tasks.Count; i++)
                Console.WriteLine($"{i + 1}. {tasks[i].Name} ({tasks[i].TaskType})");

            int taskNumber;
            do
            {
                taskNumber = ReadInt("Выберите задачу: ");

                if (taskNumber < 1 || taskNumber > tasks.Count)
                    Console.WriteLine("Такой задачи нет. Попробуйте еще раз");

            } while (taskNumber < 1 || taskNumber > tasks.Count);

            WorkTask selectedTask = tasks[taskNumber - 1];
            Console.WriteLine("\nСписок сотрудников: ");
            company.PrintEmployees();

            int senderNumber;
            do
            {
                senderNumber = ReadInt("\nКто назначает задачу? Введите номер сотрудника: ");

                if (senderNumber < 1 || senderNumber > company.Employees.Count)
                    Console.WriteLine("Такого сотрудника нет. Попробуйте еще раз");

            } while (senderNumber < 1 || senderNumber > company.Employees.Count);

            Employee sender = company.Employees[senderNumber - 1];

            int receiverNumber;
            do
            {
                receiverNumber = ReadInt("\nКому назначается задача? Введите номер сотрудника: ");

                if (receiverNumber < 1 || receiverNumber > company.Employees.Count)
                    Console.WriteLine("Такого сотрудника нет. Попробуйте еще раз");

            } while (receiverNumber < 1 || receiverNumber > company.Employees.Count);

            Employee receiver = company.Employees[receiverNumber - 1];
            company.AssignTask(selectedTask, sender, receiver);
        }
    }
}