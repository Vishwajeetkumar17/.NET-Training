namespace Delegates
{
    public delegate void RectDelegate(double height, double width);
    public class Program
    {
        public void RectArea(double height, double width)
        {
            Console.WriteLine("Area of Reactangle : " + height * width);
        }

        public void RectPerimeter(double height, double width)
        {
            Console.WriteLine("Perimeter of Rectangle : " + 2 * (height + width));
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            RectDelegate rect = new RectDelegate(p.RectArea);
            rect += new RectDelegate(p.RectPerimeter);

            rect(10, 20);
        }
    }
}
