namespace tumakov_lab.Classes
{
    public class Song
    {
        private string _name;
        private string _author;
        private Song _prev;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public Song Prev
        {
            get { return _prev; }
            set { _prev = value; }
        }

        public void PrintSong()
        {
            Console.WriteLine(Title());
        }

        public string Title()
        {
            return $"{_name} - {_author}";
        }

        /// <summary>
        /// Сравнивает две песни
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public override bool Equals(object d)
        {
            if (d is Song song)
                return _name == song._name && _author == song._author;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_name, _author);
        }
    }
}