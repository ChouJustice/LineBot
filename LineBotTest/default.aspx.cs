using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LineBotTest
{
    public partial class _default : System.Web.UI.Page
    {
        const string channelAccessToken = "4UYSRQcGj2bGqO7FGYKxomPTA5r/wLY0yyZpbcWgi0XYhDne6mMIjg0fGJ7sptzPW8zcYJnZ+R3Ti7GKzQCIAbPTAvXpVS1QtiS2xTmnuYtlcYDlr0strqkQtBGYFyS0q+eR7ISMsWVY7LWVQOT6twdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId= "U206f5da89ebc3fceca67fefc26521d1e";
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, $"測試 {DateTime.Now.ToString()} ! ");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, 1,2);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, $"同學 給我爬進靈堂!");
        }
    }
}