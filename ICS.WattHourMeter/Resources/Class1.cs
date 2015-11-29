using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICS.Acquisition;
using ICS.Models;
using ICS.Common;

namespace ICS.WattHourMeter
{
    class Global
    {
        public static ADAM4150 ADAM4150Provider
        {
            get { return (ADAM4150) ClassFactory.GetProvider(equipmentCategory.ADAM4150, ComSetting); }
        }


        static Models.Com.ComSettingModel _ComSetting;

        public static Models.Com.ComSettingModel ComSetting
        {
            get
            {
                if (_ComSetting == null)
                {
                    _ComSetting = new ICS.Common.SettingHelper<Models.Com.ComSettingModel>().GetSetting();
                    _ComSetting.DigitalQuantityCom = "Com2";
                    _ComSetting.AnalogQuantityCom = "Com2";
                    _ComSetting.Watt_hourMeterCom = "Com2";
                }
                return _ComSetting;
            }
        }
    }
}
