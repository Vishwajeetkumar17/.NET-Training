namespace CommonLib
{
    public abstract class LoginApps
    {
        public abstract void Login(string uName, string password);
        public abstract void Logout();

        public bool LoginStatus()
        {
            return true;
        }
    }
}
