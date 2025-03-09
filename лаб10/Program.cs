using ClassLibrary;
using ClassLibraryWeather;

namespace ла610
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем массив объектов из лаб 9 и 10
            IInit[] objects = new IInit[15];
            Random rand = new Random();

            // Метод для добавления элемента в массив на случайную позицию
            void AddRandomly(IInit item)
            {
                int randomIndex;
                do
                {
                    randomIndex = rand.Next(objects.Length);
                } while (objects[randomIndex] != null);
                objects[randomIndex] = item;
            }

            // Заполнение объектами класса Weather
            for (int i = 0; i < 5; i++)
            {
                Weather weather = new Weather();
                weather.RandomInit();
                AddRandomly(weather);
            }

            // Заполнение объектами класса Button
            for (int i = 0; i < 5; i++)
            {
                Button button = new Button();
                button.RandomInit();
                AddRandomly(button);
            }

            // Заполнение объектами класса CheckboxButton
            for (int i = 0; i < 3; i++)
            {
                CheckboxButton checkboxButton = new CheckboxButton();
                checkboxButton.RandomInit();
                AddRandomly(checkboxButton);
            }

            // Заполнение объектами класса TextField
            for (int i = 0; i < 2; i++)
            {
                TextField textField = new TextField();
                textField.RandomInit();
                AddRandomly(textField);
            }

            // Вывод при помощи обычного метода
            Console.WriteLine("Вывод при помощи обычного метода (первые 10 объектов управления):");
            int controlElementCount = 0;
            for (int i = 0; i < objects.Length && controlElementCount < 10; i++)
            {
                if (objects[i] is ControlElement controlElement)
                {
                    Console.WriteLine(controlElement.Show());
                    controlElementCount++;
                }
            }

            // Вывод при помощи виртуального метода (все объекты управления)
            Console.WriteLine("\nВывод при помощи виртуального метода (все объекты управления):");
            foreach (var obj in objects)
            {
                if (obj is ControlElement controlElement)
                {
                    Console.WriteLine(controlElement.ShowVirtual());
                }
            }

            // Подсчет количества объектов каждого типа
            int weatherCount = 0, buttonCount = 0, checkboxButtonCount = 0, textFieldCount = 0;
            foreach (var obj in objects)
            {
                if (obj is Weather)
                    weatherCount++;
                else if (obj is CheckboxButton)
                    buttonCount++;
                else if (obj is TextField)
                    checkboxButtonCount++;
                else if (obj is Button)
                    textFieldCount++;
            }

            // Используем статические функции для запросов
            buttonCount = CountButtons(objects);
            Console.WriteLine($"\nКоличество кнопок: {buttonCount}");

            Console.WriteLine($"Тексты текстовых полей с подсказкой:");
            PrintTextFieldTextsWithHint(objects);

            Console.WriteLine("Элементы управления на координате X = 500:");
            PrintControlElementsAtX500(objects);

            // Вывод массива из объектов разных классов (15 объектов)
            Console.WriteLine("\nВывод массива из объектов разных классов (15 объектов):");
            int randomChoice;
            foreach (var obj in objects)
            {
                randomChoice = rand.Next(1, 3);
                if (randomChoice == 1)
                {
                    Console.WriteLine(obj);
                }
                
                if (randomChoice== 2 && obj is ControlElement controlElement)
                {
                    Console.WriteLine(controlElement.ShowVirtual());
                }
            }

            // Подсчет количества объектов каждого типа
            Console.WriteLine($"\nКоличество объектов Weather: {weatherCount}");
            Console.WriteLine($"Количество объектов Button: {buttonCount}");
            Console.WriteLine($"Количество объектов CheckboxButton: {checkboxButtonCount}");
            Console.WriteLine($"Количество объектов TextField: {textFieldCount}");

            // Создаем массив для элементов управления
            ControlElement[] controlElements = new ControlElement[objects.Length];
            int controlIndex = 0;

            // Заполняем массив элементами управления
            foreach (var obj in objects)
            {
                if (obj is ControlElement controlElement)
                {
                    controlElements[controlIndex++] = controlElement;
                }
            }

            // Сортировка элементов управления по id
            Array.Sort(controlElements, 0, controlIndex);
            Console.WriteLine("\nЭлементы управления, отсортированные по id:");
            for (int i = 0; i < controlIndex; i++)
            {
                randomChoice = rand.Next(1, 3);
                if (randomChoice == 1)
                {
                    Console.WriteLine(controlElements[i]);
                }
                else
                {
                    Console.WriteLine(controlElements[i].ShowVirtual());
                }

            }

            // Бинарный поиск по id
            ControlElement findMe = controlElements[5];
            Console.WriteLine($"\nЭлемент, который ищется: {findMe}");
            int index = Array.BinarySearch(controlElements, 0, controlIndex, findMe);
            Console.WriteLine($"Индекс найденного элемента: {index}");

            // Сортировка элементов управления по координате X
            Array.Sort(controlElements, 0, controlIndex, new SortByCoordinateX());
            Console.WriteLine("\nЭлементы управления, отсортированные по координате X:");
            for (int i = 0; i < controlIndex; i++)
            {
                randomChoice = rand.Next(1, 3);
                if (randomChoice == 1)
                {
                    Console.WriteLine(controlElements[i]);
                }
                else
                {
                    Console.WriteLine(controlElements[i].ShowVirtual());
                }

            }

            // Бинарный поиск по координате X
            findMe = controlElements[5]; // Пример: ищем 6-й элемент
            Console.WriteLine($"\nЭлемент, который ищется: {findMe}");
            index = Array.BinarySearch(controlElements, 0, controlIndex, findMe, new SortByCoordinateX());
            Console.WriteLine($"Индекс найденного элемента: {index}");

            // Демонстрация клонирования
            TextField original = new TextField { Id = 456, X = 500, Y = 400, Hint = "Введите имя", Text = "42" };
            TextField shallowCopy = (TextField)original.ShallowCopy();
            TextField deepCopy = (TextField)original.Clone();

            Console.WriteLine("\nДо изменения значения у ссылочного поля:");
            Console.WriteLine("Оригинал: " + original);
            Console.WriteLine("Клон: " + deepCopy);
            Console.WriteLine("Копия: " + shallowCopy);

            // Изменяем оригинал
            original.ID.Id = 52;

            Console.WriteLine("\nПосле изменения значения у ссылочного поля:");
            Console.WriteLine("Оригинал: " + original);
            Console.WriteLine("Клон: " + deepCopy);
            Console.WriteLine("Копия: " + shallowCopy);
        }

        // Запрос 1: Количество кнопок
        public static int CountButtons(IInit[] objects)
        {
            int count = 0;
            foreach (var obj in objects)
            {
                if (obj is Button btn)
                {
                    count++;
                }
            }
            return count;
        }

        // Запрос 2: Тексты текстовых полей с подсказкой
        public static void PrintTextFieldTextsWithHint(object[] objects)
        {
            foreach (var obj in objects)
            {
                if (obj is TextField textField && !string.IsNullOrEmpty(textField.Hint))
                {
                    Console.WriteLine(textField.Text);
                }
            }
        }

        // Запрос 3: Элементы управления на координате X = 500
        public static void PrintControlElementsAtX500(object[] objects)
        {
            foreach (var obj in objects)
            {
                if (obj is ControlElement controlElement && controlElement.X == 500)
                {
                    Console.WriteLine(controlElement);
                }
            }
        }
    }
}
