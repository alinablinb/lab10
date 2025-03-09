namespace ClassLibrary
{
    public class IdNumber
    {
        private int id;

        public int Id
        {
            get => id;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("\nНомер не может быть меньше нуля");
                id = value;
            }
        }

        public IdNumber(int number = 0)
        {
            Id = number;
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is IdNumber number
                   && Id == number.Id;
        }
    }
}