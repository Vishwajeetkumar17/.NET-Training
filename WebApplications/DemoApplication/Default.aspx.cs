using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.PreInit += Page_PreInit;
            Page.Init += Page_Init;
            Page.InitComplete += Page_InitComplete;
        }

        private void Page_PreInit(object sender, EventArgs e)
        {

        }

        private void Page_Init(object sender, EventArgs e)
        {
            
        }

        private void Page_InitComplete(object sender, EventArgs e)
        {
            
        }
    }
}