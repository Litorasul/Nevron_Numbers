namespace Nevron_Numbers.Data
{
    public class Model
    {
        public int Number { get; }
        public Model()
        {
            Number = new Random().Next(1, 1000);
        }
    }
}
