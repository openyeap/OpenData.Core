﻿namespace OpenData.Framework.Core.Wechat.Models
{
    public class UserAccessTokenResultModel : WechatJsonResultModel
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string openid { get; set; }
        public string scope { get; set; }
    }
}