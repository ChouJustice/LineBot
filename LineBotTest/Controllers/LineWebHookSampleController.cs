using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LineBotTest.Controllers
{
    public class LineBotWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        const string channelAccessToken = "4UYSRQcGj2bGqO7FGYKxomPTA5r/wLY0yyZpbcWgi0XYhDne6mMIjg0fGJ7sptzPW8zcYJnZ+R3Ti7GKzQCIAbPTAvXpVS1QtiS2xTmnuYtlcYDlr0strqkQtBGYFyS0q+eR7ISMsWVY7LWVQOT6twdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId= "U206f5da89ebc3fceca67fefc26521d1e";

        [Route("api/LineWebHookSample")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            try
            {
                //設定ChannelAccessToken(或抓取Web.Config)
                this.ChannelAccessToken = channelAccessToken;
                //取得Line Event(範例，只取第一個)
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                //配合Line verify 
                if (LineEvent.replyToken == "00000000000000000000000000000000") return Ok();
                //回覆訊息
                if (LineEvent.type == "message")
                {
                    if (LineEvent.message.type == "text") //收到文字
                        this.ReplyMessage(LineEvent.replyToken, "你說了:" + LineEvent.message.text);
                    if (LineEvent.message.type == "sticker") //收到貼圖
                        this.ReplyMessage(LineEvent.replyToken, 1, 2);
                }
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //如果發生錯誤，傳訊息給Admin
                this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }
    }
}