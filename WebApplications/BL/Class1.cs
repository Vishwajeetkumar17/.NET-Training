using DALRevProj;

namespace BL
{
    public class UserBL
    {
        public static string RevName()
        {
            string name = DALRevProj.DALRevPrj.GetAllData();
            return name;
        }
    }
}
