namespace ClassLibrary
{
    public class SortByCoordinateX : IComparer<ControlElement>
    {
        // Метод для сравнения по координате X
        public int Compare(ControlElement? x, ControlElement? y)
        {
            if (x is null || y is null) // Проверка на null
                throw new ArgumentNullException("Аргументы не могут быть null");

            return x.X.CompareTo(y.X); // Сравнение по свойству X
        }
    }
}