namespace ClassLibrary
{
    public class Button : ControlElement
    {
        protected string _text;

        // Свойство для текста с проверкой
        public string Text
        {
            get => _text;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Текст на кнопке не может быть пустым");
                _text = value;
            }
        }

        // Конструктор по умолчанию
        public Button() : base()
        {
            _text = "Unnamed";
        }

        // Конструктор с параметрами
        public Button(int id1, int id2, double x, double y, string text) : base(id1, id2, x, y)
        {
            Text = text;
        }

        // Конструктор глубокого копирования
        public Button(Button other) : base(other)
        {
            Text = other.Text;
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите текст на кнопке:");
            Text = Console.ReadLine();
        }

        public override void RandomInit()
        {
            base.RandomInit();
            string[] texts = { "Нажми меня", "Отправить", "Отмена", "ОК" };
            Text = texts[random.Next(texts.Length)];
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is Button))
                return false;

            Button other = (Button)obj;
            return base.Equals(obj) && Text == other.Text;
        }

        public override object Clone()
        {
            return new Button(this);
        }
        public new string Show()
        {
            string baseString = base.ShowVirtual();
            return $"{baseString}, Текст на кнопке: {Text}";
        }

        // Виртуальный метод для получения расширенной информации об объекте
        public override string ShowVirtual()
        {
            string baseString = base.ShowVirtual();
            return $"{baseString}, Текст на кнопке: {Text}";
        }
    }
}