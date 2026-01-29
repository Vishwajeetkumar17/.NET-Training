namespace PersonDetail
{
    public interface IPersonalDetail
    {
        string GetWelcomeNote(string name);
        string GetFarewellNote(string name);
    }

    public class Person : IPersonalDetail
    {
        public string GetWelcomeNote(string name)
        {
            return $"Welcome, {name}!";
        }
        public string GetFarewellNote(string name)
        {
            return $"Goodbye, {name}!";
        }
    }
}
