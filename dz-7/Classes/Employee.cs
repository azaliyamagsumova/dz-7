using dz_7.Enums;

namespace dz_7.Classes
{
    public class Employee
    {
        private string _name;
        private string _position;
        private TaskType _taskType;
        private List<Employee> _managers;

        public string Name
        {
            get { return _name; }
        }

        public string Position
        {
            get { return _position; }
        }

        public TaskType TaskType
        {
            get { return _taskType; }
        }

        /// <summary>
        /// Создает сотрудника
        /// </summary>
        public Employee(string name, string position, TaskType taskType)
        {
            _name = name;
            _position = position;
            _taskType = taskType;
            _managers = new List<Employee>();
        }

        /// <summary>
        /// Добавляет непосредственного руководителя сотрудника
        /// </summary>
        public void AddManager(Employee manager)
        {
            if (manager != null && !_managers.Contains(manager))
            {
                _managers.Add(manager);
            }
        }

        /// <summary>
        /// Проверяет, является ли указанный сотрудник непосредственным руководителем
        /// </summary>
        public bool IsManager(Employee employee)
        {
            return _managers.Contains(employee);
        }

        /// <summary>
        /// Выводит информацию о сотруднике
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine($"{_name} — {_position}");
        }
    }
}