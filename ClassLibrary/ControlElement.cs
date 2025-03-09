namespace ClassLibrary
{
    public class ControlElement : IInit, IComparable<ControlElement>, ICloneable
    {
        protected static readonly Random random = new Random(); // Для случайной генерации

        protected IdNumber _idNumber;
        protected int _id;
        protected double _x;
        protected double _y; 

        // Свойство для IdNumber
        public IdNumber ID
        {
            get => _idNumber;
            set => _idNumber = value;
        }

        // Свойство для Id с проверкой
        public int Id
        {
            get => _id;
            set
            {
                if (value < 1 || value > 1000)
                    throw new ArgumentException("Id должен быть в диапазоне от 1 до 1000");
                _id = value;
            }
        }

        // Свойство для X с проверкой
        public double X
        {
            get => _x;
            set
            {
                if (value < 0 || value > 1920)
                    throw new ArgumentException("Координата X должна быть в пределах Full HD (0-1920)");
                _x = value;
            }
        }

        // Свойство для Y с проверкой
        public double Y
        {
            get => _y;
            set
            {
                if (value < 0 || value > 1080)
                    throw new ArgumentException("Координата Y должна быть в пределах Full HD (0-1080)");
                _y = value;
            }
        }

        // Конструктор по умолчанию
        public ControlElement()
        {
            _idNumber = new IdNumber(0);
            _id = 0;
            _x = 0;
            _y = 0;
        }

        // Конструктор с параметрами
        public ControlElement(int id1, int id2, double x, double y)
        {
            ID = new IdNumber(id1);
            Id = id2;
            X = x;
            Y = y;
        }

        // Конструктор глубокого копирования
        public ControlElement(ControlElement other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other), "Аргумент не может быть null");

            ID = new IdNumber(other.ID.Id);
            Id = other.Id;
            X = other.X;
            Y = other.Y;
        }

        // Невиртуальный метод для получения базовой информации об объекте
        public string Show()
        {
            return $"ID: {ID}, Id: {Id}, X: {X}, Y: {Y}";
        }

        // Виртуальный метод для получения расширенной информации об объекте
        public virtual string ShowVirtual()
        {
            return $"ID: {ID}, Id: {Id}, X: {X}, Y: {Y}";
        }

        // Виртуальный метод для ручного ввода информации об объекте
        public virtual void Init()
        {
            int id1 = 0;
            int id2 = 0;
            double x = 0;
            double y = 0;

            // Ввод ID (IdNumber)
            Console.WriteLine("Введите ID (от 1 до 1000):");
            while (!int.TryParse(Console.ReadLine(), out id1) || id1 < 1 || id1 > 1000)
            {
                Console.WriteLine("Ошибка! Введите ID от 1 до 1000:");
            }
            ID = new IdNumber(id1);

            // Ввод Id (обычный int)
            Console.WriteLine("Введите Id (от 1 до 1000):");
            while (!int.TryParse(Console.ReadLine(), out id2) || id2 < 1 || id2 > 1000)
            {
                Console.WriteLine("Ошибка! Введите Id от 1 до 1000:");
            }
            Id = id2;

            // Ввод координаты X
            Console.WriteLine("Введите координату X (0-1920):");
            while (!double.TryParse(Console.ReadLine(), out x) || x < 0 || x > 1920)
            {
                Console.WriteLine("Ошибка! Введите X от 0 до 1920:");
            }
            X = x;

            // Ввод координаты Y
            Console.WriteLine("Введите координату Y (0-1080):");
            while (!double.TryParse(Console.ReadLine(), out y) || y < 0 || y > 1080)
            {
                Console.WriteLine("Ошибка! Введите Y от 0 до 1080:");
            }
            Y = y;
        }

        // Виртуальный метод для формирования объектов со случайной генерацией
        public virtual void RandomInit()
        {
            ID = new IdNumber(random.Next(1, 1001));
            Id = random.Next(1, 1001);
            X = Math.Round(random.NextDouble() * 1920, 2);
            Y = Math.Round(random.NextDouble() * 1080, 2);
        }

        // Метод для сравнения двух объектов класса ControlElement
        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is ControlElement))
                return false;

            ControlElement other = (ControlElement)obj;
            return ID.Equals(other.ID) && Id == other.Id && X == other.X && Y == other.Y;
        }

        // Метод для преобразования в строку (базовый вывод)
        public override string ToString()
        {
            return $"ID: {ID}, Id: {Id}, X: {X}, Y: {Y}"; 
        }

        // Метод для сравнения по ID
        public int CompareTo(ControlElement? other)
        {
            if (other is null)
                return -1;

            return Id.CompareTo(other.Id);
        }

        // Метод для клонирования
        public virtual object Clone()
        {
            return new ControlElement(this);
        }

        // Метод для поверхностного копирования
        public object ShallowCopy()
        {
            return MemberwiseClone();
        }
    }
}