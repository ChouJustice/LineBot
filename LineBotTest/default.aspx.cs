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
        const string channelAccessToken = "KBiJiq5PXoHTky/p0FpEKVMG70yCTaq62LItF5z3nJFxoA7m7FOF/ZwPka0o0T0wW8zcYJnZ+R3Ti7GKzQCIAbPTAvXpVS1QtiS2xTmnuYu+aGuIVfGJxoDKpTzNo5pHjPV8i0Z3YD0vkEJp4saf1AdB04t89/1O/w1cDnyilFU=";
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