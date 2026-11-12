using dz_7.Enums;

namespace dz_7.Classes
{
    public class Company
    {
        private List<Employee> _employees;

        public List<Employee> Employees
        {
            get { return _employees; }
        }

        /// <summary>
        /// Создает организацию и устанавливает иерархию сотрудников
        /// </summary>
        public Company()
        {
            _employees = new List<Employee>();

            // Руководство компании
            Employee timur = new Employee("Тимур", "Генеральный директор", TaskType.Руководство);
            Employee rashid = new Employee("Рашид", "Финансовый директор", TaskType.Руководство);
            Employee oilham = new Employee("О Ильхам", "Директор по автоматизации", TaskType.Руководство);
            rashid.AddManager(timur);
            oilham.AddManager(timur);

            // Бухгалтерия
            Employee lucas = new Employee("Лукас", "Главный бухгалтер", TaskType.Бухгалтерия);
            lucas.AddManager(rashid);

            // Руководство отдела информационных технологий
            Employee orkady = new Employee("Оркадий", "Начальник отдела информационных технологий", TaskType.Начальство);
            Employee volodya = new Employee("Володя", "Заместитель начальника отдела информационных технологий", TaskType.Начальство);

            orkady.AddManager(oilham);
            volodya.AddManager(oilham);

            // Сектор системщиков
            Employee ilshat = new Employee("Ильшат", "Начальник сектора системщиков", TaskType.Системщики);
            Employee ivanych = new Employee("Иваныч", "Заместитель начальника сектора системщиков", TaskType.Системщики);
            Employee ilya = new Employee("Илья", "Системщик", TaskType.Системщики);
            Employee vitya = new Employee("Витя", "Системщик", TaskType.Системщики);
            Employee zhenya = new Employee("Женя", "Системщик", TaskType.Системщики);

            ilshat.AddManager(orkady);
            ilshat.AddManager(volodya);

            ivanych.AddManager(ilshat);

            ilya.AddManager(ivanych);
            vitya.AddManager(ivanych);
            zhenya.AddManager(ivanych);

            // Сектор разработчиков
            Employee sergey = new Employee("Сергей", "Начальник сектора разработчиков", TaskType.Разработчики);
            Employee laysan = new Employee("Ляйсан", "Заместитель начальника сектора разработчиков", TaskType.Разработчики);
            Employee marat = new Employee("Марат", "Разработчик", TaskType.Разработчики);
            Employee dina = new Employee("Дина", "Разработчик", TaskType.Разработчики);
            Employee ildar = new Employee("Ильдар", "Разработчик", TaskType.Разработчики);
            Employee anton = new Employee("Антон", "Разработчик", TaskType.Разработчики);

            sergey.AddManager(orkady);
            sergey.AddManager(volodya);

            laysan.AddManager(sergey);

            marat.AddManager(laysan);
            dina.AddManager(laysan);
            ildar.AddManager(laysan);
            anton.AddManager(laysan);

            // Добавление сотрудников в общий список
            _employees.Add(timur);
            _employees.Add(rashid);
            _employees.Add(oilham);
            _employees.Add(lucas);
            _employees.Add(orkady);
            _employees.Add(volodya);

            _employees.Add(ilshat);
            _employees.Add(ivanych);
            _employees.Add(ilya);
            _employees.Add(vitya);
            _employees.Add(zhenya);

            _employees.Add(sergey);
            _employees.Add(laysan);
            _employees.Add(marat);
            _employees.Add(dina);
            _employees.Add(ildar);
            _employees.Add(anton);
        }

        /// <summary>
        /// Выводит список сотрудников с номерами
        /// </summary>
        public void PrintEmployees()
        {
            for (int i = 0; i < _employees.Count; i++)
            {
                Console.Write($"{i + 1, 2}. ");
                _employees[i].PrintInfo();
            }
        }

        /// <summary>
        /// Назначает задачу сотруднику, если ее дает непосредственный руководитель
        /// </summary>
        public void AssignTask(WorkTask task, Employee sender, Employee receiver)
        {
            Console.WriteLine($"\nОт сотрудника {sender.Name} даётся задача \'{task.Name}\' сотруднику {receiver.Name}");

            if (receiver.TaskType != task.TaskType)
            {
                Console.WriteLine("Сотрудник не относится к категории, для которой предназначена задача");
                return;
            }

            if (receiver.IsManager(sender))
                Console.WriteLine($"{receiver.Name} принимает задачу");
            else
                Console.WriteLine($"{receiver.Name} отказывается выполнять задачу. Это не её(его) непосредственный руководитель");
        }
    }
}