﻿using Nop.Web.Framework;

namespace Nop.Plugin.Sms.Verizon.Models
{
    public class SmsVerizonModel
    {
        [NopResourceDisplayName("Plugins.Sms.Verizon.Fields.Enabled")]
        public bool Enabled { get; set; }
        
        [NopResourceDisplayName("Plugins.Sms.Verizon.Fields.Email")]
        public string Email { get; set; }

        [NopResourceDisplayName("Plugins.Sms.Verizon.Fields.TestMessage")]
        public string TestMessage { get; set; }
    }
}