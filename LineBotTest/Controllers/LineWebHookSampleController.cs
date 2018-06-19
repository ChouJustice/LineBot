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
        const string channelAccessToken = "KBiJiq5PXoHTky/p0FpEKVMG70yCTaq62LItF5z3nJFxoA7m7FOF/ZwPka0o0T0wW8zcYJnZ+R3Ti7GKzQCIAbPTAvXpVS1QtiS2xTmnuYu+aGuIVfGJxoDKpTzNo5pHjPV8i0Z3YD0vkEJp4saf1AdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId = "U206f5da89ebc3fceca67fefc26521d1e";

        List<string> DannSession = new List<string>()
        {
            "我知道堅持很難，一個人的動力會不夠。因此，你要把自己放在一個一起努力的環境、一起拚命的環境、一個有比你厲害的人的環境。",
            "忘掉你是學生，不再有考試.學分.成績。當你有目標，時間是自主安排時，就會過得充實有意義。",
            "每位老師及同學們，你們都會出現在 Build School 回憶錄的第87頁!",
            "我希望每位同學，都能向你的家人說說這6個月發生的故事，就好像男人總能隨時講講當兵時的豐功偉業及趣事一樣，說說你是多麼認真在學習程式，有個很明確的目標，還有很多可愛的同學，以及你心中的「林真心」! 有目標又認真地過好每一天，你的生命自然就會精彩!",
            "如果有一天我掛了，請你們把在 Build School 發生的點點滴滴，講給我兒子聽、講給我家人聽。好啦。我希望我兒子能以我為榮。就讓我滿足一下虛榮心吧!",
            "我的兒子，Ian、小二、八歲。\n\n曾經，我帶著他，來到 Build School 的NASA，說說同學們如何認真在寫程式，每天作業及練習都要寫到晚上 11點，假日還要繼續練。一天他放學回家，「爸爸，可不可以給我你的名片?」我說:「要名片做什麼?」「因為今天在安親班上課，每個小朋友要講爸爸媽媽的職業。」「我和全班講說，我爸爸是校長。」「結果老師還有同學們都不相信，以為我在開玩笑。」「我明天要帶你的名片去給他們看。我爸是Build School 校長，教學生寫app的」",
            "我問你們如何分工，負責什麼時，每個人請「直球對決」，要講得清楚又自信，就像你自介一樣。以後功成名就，可以請Twice在Build School辦演唱會嗎？",
            "不溝通是最糟的，這也是履歷中呈現你個人團隊合作及領導的能力。忘掉你曾經搞喳的專題，一人唱獨角的專題，互相抱怨的專題，這次MVC專題，當成故事，當成例子，當成是自我介紹的案例，絶對是面試加分。我說的話不信?好，有一天你功成名就了，請在自傳提到Build School",
            "我想說:「你們一定要懂得感謝每一位 Build School 指導你們的老師，以及支持Build School 許多校內師長，用行動、用口語、用你的投入學習、用與老師的互動表示。這些都不是天上掉下來的，請保持一個感恩的心，隨時比一個愛心」",
            "我常常會聽你們在課堂上如何發問、如何清楚描述你的問題，就好像今晚有人問到，購物車如何檢查庫存及可訂購量。這就是表達的能力。大部份的表達技巧都是可以先模仿、再重覆練習。",
            "我希望你「忘掉自己是學生，你每天的生活不再為了課表/學分/分數，為你接下來的每一天做好規畫，今天要做什麼，明天要做什麼，你未來要做什麼。心中很清楚，有個很明確的目標!」",
            "這週，你們的心情三溫暖!看到各位這星期拚命的模樣，我很感動也很驕傲。創Build School以來，我想證明一件事，天賦沒有你想像的重要，只要夠努力，用對的學習方法，就可以幹掉一半的人了。一次不行就兩次，兩次不行就再試，不要害怕困難，再加上好的導師，高強度的學習環境，懂得learn how to learn....",
            "不能口語表達就練，口語不善長就寫，寫還不行就看github。github不行就回家吃自己。",
            "請心臟大顆一點，以後還有更大條的等著你們。尤其是男生，我對你們會特別嚴格，我期待不論是面試官或是老師問你們話時，就「直球對決」吧 。不要閃，自信的講出來。「很善長就說，很想要就說，很不會就說，很厲害就說」",
            "雖然你們沒辦法重回大一了，但想想若你能回到大一，每天都用在Build School 的學習方法及態度，你現在是誰? 未來你們離開 Build School 請繼續保持下去，不能停止學習，當個主動積極的學習者。",
            "「星期一早上，我預感不少人請假、或晚到。因此在此公告: 以後連假及重要假日前一天、後一天，都不用上課。Yeh!!!! 不用與人塞車，也不用擔心買不到票。這樣最好，我回老家還可以晚點來」",
            "同學你們要請假，從來沒有過問你們，但沒有任何通知就默默離開，例如早上來、下午不來也沒有通知，坦白說，很沒有禮貌。那以後我也可以上課到中午，下午就不來了。",
            "等你遇過更大條的事，你就會成長，心也會更強，抗壓性也更高。我也常常在提醒自己，一些小地方，但對現在的你們而言，就是大事。與你們接觸後，也會更常站在你們的角度看事情。也很高興遇見各位，讓我再年輕一次，這就是我最好的人生旅程。",
            "要上緊發條了，無心者、很多外務者、不練習只想快樂學習者 (往專業的學習之路一定會有痛苦之處)，請自行xx，不要互相傷害。",
            "當老師不給題目，你就不練了，當作業完成了，你就以為夠了; 當本週的進度跟上了，你就也不再回頭完成先前的題目。當課堂的內容消化了，你就停下做其它事了。當你完成了題目，你能去看看比你更強的人的寫法嗎?",
            "相信我，持續與堅持就對了，讓當初那些説你做不到的人閉嘴就對了。"
        };

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
                    if (LineEvent.message.type == "text")
                    {   //收到文字
                        //this.ReplyMessage(LineEvent.replyToken, "你說了:" + LineEvent.message.text);
                        if (LineEvent.message.text == "佛系叮嚀" || LineEvent.message.text == "婆媽一句" || LineEvent.message.text == "抽")
                        {
                            var random = new Random().Next(0,DannSession.Count);
                            this.ReplyMessage(LineEvent.replyToken, DannSession[random]);
                        }
                        else if (LineEvent.message.text.Contains("請假") || LineEvent.message.text.Contains("晚點到"))
                        {
                            this.ReplyMessage(LineEvent.replyToken, $"同學你們要請假，但是練習進度也要好好掌握。");
                        }
                        else if (LineEvent.message.text.Contains("要求"))
                        {
                            var SearchkeywordsIndex = LineEvent.message.text.IndexOf("求");
                            var Searchkeywords = "";
                            foreach (var item in LineEvent.message.text.Skip(SearchkeywordsIndex + 1))
                            {
                                Searchkeywords += item;
                            }
                            this.ReplyMessage(LineEvent.replyToken, $"好，但是以後給我爬進靈堂!!!\nhttp://www.google.com/search?q=" + Searchkeywords);
                        }
                    }
                    //if (LineEvent.message.type == "sticker") //收到貼圖
                    //    this.ReplyMessage(LineEvent.replyToken, 1, 2);
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
