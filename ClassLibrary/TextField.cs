namespace ClassLibrary
{
    public class TextField : ControlElement, ICloneable
    {
        protected string _hint;
        protected string _text;

        // Свойство для подсказки с проверкой
        public string Hint
        {
            get => _hint;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Подсказка не может быть пустой");
                _hint = value;
            }
        }

        // Свойство для текста
        public string Text
        {
            get => _text;
            set => _text = value;
        }

        // Конструктор по умолчанию
        public TextField() : base()
        {
            _hint = "NameLess";
            _text = "";
        }

        // Конструктор с параметрами
        public TextField(int id1, int id2, double x, double y, string hint, string text) : base(id1, id2, x, y)
        {
            Hint = hint;
            Text = text;
        }

        // Конструктор глубокого копирования
        public TextField(TextField other) : base(other)
        {
            Hint = other.Hint;
            Text = other.Text;
        }

        public new string Show()
        {
            string baseString = base.ShowVirtual();
            return $"{baseString}, Подсказка: {Hint}, Текст: {Text}";
        }

        public override string ShowVirtual()
        {
            string baseString = base.ShowVirtual();
            return $"{baseString}, Подсказка: {Hint}, Текст: {Text}";
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите подсказку:");
            Hint = Console.ReadLine();
            Console.WriteLine("Введите текст:");
            Text = Console.ReadLine();
        }

        public override void RandomInit()
        {
            base.RandomInit();
            string[] hints = { "Введите имя", "Введите пароль", "Введите email" };
            Hint = hints[random.Next(hints.Length)];
            Text = random.Next(1, 100).ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is TextField))
                return false;

            TextField other = (TextField)obj;
            return base.Equals(obj) && Hint == other.Hint && Text == other.Text;
        }

        public override object Clone()
        {
            return new TextField(this);
        }
    }
}