﻿using System;
using System.Web.Mvc;
using Nop.Core.Plugins;
using Nop.Plugin.SMS.Verizon;
using Nop.Plugin.Sms.Verizon.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Sms.Verizon.Controllers
{
    [AdminAuthorize]
    public class SmsVerizonController : BasePluginController
    {
        private readonly VerizonSettings _verizonSettings;
        private readonly ISettingService _settingService;
        private readonly IPluginFinder _pluginFinder;
        private readonly ILocalizationService _localizationService;

        public SmsVerizonController(VerizonSettings verizonSettings,
            ISettingService settingService, IPluginFinder pluginFinder,
            ILocalizationService localizationService)
        {
            this._verizonSettings = verizonSettings;
            this._settingService = settingService;
            this._pluginFinder = pluginFinder;
            this._localizationService = localizationService;
        }

        [ChildActionOnly]
        public ActionResult Configure()
        {
            var model = new SmsVerizonModel();
            model.Enabled = _verizonSettings.Enabled;
            model.Email = _verizonSettings.Email;

            return View("~/Plugins/SMS.Verizon/Views/SmsVerizon/Configure.cshtml", model);
        }

        [ChildActionOnly]
        [HttpPost, ActionName("Configure")]
        [FormValueRequired("save")]
        public ActionResult ConfigurePOST(SmsVerizonModel model)
        {
            if (!ModelState.IsValid)
            {
                return Configure();
            }

            //save settings
            _verizonSettings.Enabled = model.Enabled;
            _verizonSettings.Email = model.Email;
            _settingService.SaveSetting(_verizonSettings);

            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));

            return Configure();
        }

        [ChildActionOnly]
        [HttpPost, ActionName("Configure")]
        [FormValueRequired("test-sms")]
        public ActionResult TestSms(SmsVerizonModel model)
        {
            try
            {
                if (String.IsNullOrEmpty(model.TestMessage))
                {
                    ErrorNotification("Enter test message");
                }
                else
                {
                    var pluginDescriptor = _pluginFinder.GetPluginDescriptorBySystemName("Mobile.SMS.Verizon");
                    if (pluginDescriptor == null)
                        throw new Exception("Cannot load the plugin");
                    var plugin = pluginDescriptor.Instance() as VerizonSmsProvider;
                    if (plugin == null)
                        throw new Exception("Cannot load the plugin");

                    if (!plugin.SendSms(model.TestMessage))
                    {
                        ErrorNotification(_localizationService.GetResource("Plugins.Sms.Verizon.TestFailed"));
                    }
                    else
                    {
                        SuccessNotification(_localizationService.GetResource("Plugins.Sms.Verizon.TestSuccess"));
                    }
                }
            }
            catch(Exception exc)
            {
                ErrorNotification(exc.ToString());
            }

            return View("~/Plugins/SMS.Verizon/Views/SmsVerizon/Configure.cshtml", model);
        }
    }
}