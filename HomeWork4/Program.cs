namespace HomeWork4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var counter = new Counter();

            var handler1 = new Handler1();
            var handler2 = new Handler2();

            counter.Notify += handler1.Alert;
            counter.Notify += handler2.Alert;

            counter.Increment();
        }
    }
}