namespace IMultipleInheritance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Visistor visitor = new Visistor();
            IVegEater vegEater = visitor;
            INonVegEater nonVegEater = visitor;

            visitor.EatVeggies();
            visitor.EatNonVeggies();
            vegEater.GetTaste();
            nonVegEater.GetTaste();
            visitor.Visit();
        }
    }
}
