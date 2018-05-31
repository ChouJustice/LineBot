using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LineBot
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot("7zfpG/Fb/aajqbvoiqz3ROEi80dn18n0W5d01FLpOh8vW5MKNhGdggy6yn1Bsx5/W8zcYJnZ+R3Ti7GKzQCIAbPTAvXpVS1QtiS2xTmnuYvkUyKT3Wu81+aNrpjmBMOotIob/dPEZ4aLEdVYywiKBwdB04t89/1O/w1cDnyilFU=");

            bot.PushMessage("U206f5da89ebc3fceca67fefc26521d1e", "Testxxxxxx");
        }
    }
}