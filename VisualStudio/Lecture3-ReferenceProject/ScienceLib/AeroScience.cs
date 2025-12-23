using CommonLib;

namespace ScienceLib
{
    public class AeroScience
    {
        public string GetInfoPub()
        {
            return "This is AeroScience Library";
        }

        private string GetInfoPri()
        {
            return "This is Private AeroScience Library";
        }

        internal string GetInfoPro()
        {
            return "This is Protected AeroScience Library";
        }

    }
}
