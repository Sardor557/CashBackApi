using DevExpress.XtraBars.Alerter;
using DevExpress.XtraSplashScreen;
using System;
using System.Windows.Forms;

namespace CashBackApi.ControlPanel.Utils
{
    public class WaitFormManager
    {
        public static void Show()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(WaitForm1));
            }
            catch (Exception)
            {
                // Console.WriteLine(ee.Message);
            }
        }

        public static void Close()
        {
            try
            {
                SplashScreenManager.CloseForm();
            }
            catch (Exception)
            {
                // Console.WriteLine(ee.Message);
            }
        }
    }

    public class AlertMessage
    {
        public static void ShowAlertError(Form CurMainForm, string mes)
        {
            try
            {
                var box = new AlertControl();
                var ai = new AlertInfo("Ошибка", mes);
                box.AutoFormDelay = 3000;
                box.AllowHotTrack = false;
                box.FormDisplaySpeed = AlertFormDisplaySpeed.Slow;
                box.FormLocation = AlertFormLocation.BottomRight;
                box.AutoHeight = true;
                box.FormMaxCount = 3;
                box.Show(CurMainForm, ai);
            }
            catch (Exception)
            {
            }
        }

        public static void Show(Form CurMainForm, string mes, string caption = "Информация")
        {
            try
            {
                var box = new AlertControl();
                var ai = new AlertInfo(caption, mes);
                box.AutoFormDelay = 3000;
                box.AllowHotTrack = false;
                box.FormDisplaySpeed = AlertFormDisplaySpeed.Moderate;
                box.FormLocation = AlertFormLocation.BottomRight;
                box.AutoHeight = true;
                box.Show(CurMainForm, ai);
            }
            catch (Exception)
            {
            }
        }

    }
}
