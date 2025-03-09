namespace ClassLibrary
{
    public class CheckboxButton : Button
    {
        protected bool _isSelected;

        // Свойство для состояния выбора
        public bool IsSelected
        {
            get => _isSelected;
            set => _isSelected = value;
        }

        // Конструктор по умолчанию
        public CheckboxButton() : base()
        {
            _isSelected = false;
        }

        // Конструктор с параметрами
        public CheckboxButton(int id1, int id2, double x, double y, string text, bool isSelected) : base(id1, id2, x, y, text)
        {
            IsSelected = isSelected;
        }

        // Конструктор глубокого копирования
        public CheckboxButton(CheckboxButton other) : base(other)
        {
            IsSelected = other.IsSelected;
        }
        public new string Show()
        {
            string baseString = base.ShowVirtual();
            return $"{baseString}, Выбрана: {IsSelected}";
        }
        public override string ShowVirtual()
        {
            string baseString = base.ShowVirtual();
            return $"{baseString}, Выбрана: {IsSelected}";
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Выбрана ли кнопка? (true/false):");
            while (!bool.TryParse(Console.ReadLine(), out _isSelected))
            {
                Console.WriteLine("Ошибка! Введите true или false:");
            }
        }

        public override void RandomInit()
        {
            base.RandomInit();
            IsSelected = random.Next(2) == 1;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is CheckboxButton))
                return false;

            CheckboxButton other = (CheckboxButton)obj;
            return base.Equals(obj) && IsSelected == other.IsSelected;
        }

        public override object Clone()
        {
            return new CheckboxButton(this);
        }
    }
}