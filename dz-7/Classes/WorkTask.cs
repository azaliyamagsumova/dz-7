using dz_7.Enums;

namespace dz_7.Classes
{
    public class WorkTask
    {
        private string _name;
        private TaskType _taskType;

        public string Name
        {
            get { return _name; }
        }

        public TaskType TaskType
        {
            get { return _taskType; }
        }

        /// <summary>
        /// Создает задачу с названием и категорией
        /// </summary>
        public WorkTask(string name, TaskType taskType)
        {
            _name = name;
            _taskType = taskType;
        }
    }
}