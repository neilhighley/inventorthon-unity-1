using System;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace CortanaUnity
{
    public class ToastNotificationHelper
    {
        #region HelperMethods
        static int ToastCount = 0;

        public static void SendToast(object sender, EventArgs e)
        {
            //Check notificationsettings status from user device
            if (CanSendToasts())
            {
                MakingToastNotification("Toast_with_Popup: ", "Notitification " + ToastCount++, "T" + ToastCount.ToString(), "G1", true);
            }
        }

        public static bool CanSendToasts()
        {
            bool canSend = true;
            var NotifierStatus = ToastNotificationManager.CreateToastNotifier();
            //Check Notification settings status 
            if (NotifierStatus.Setting != NotificationSetting.Enabled)
            {
                string ReasonMessage = "unknown error";
                switch (NotifierStatus.Setting)
                {
                    case NotificationSetting.DisabledByGroupPolicy:
                        ReasonMessage = "An administrator has disabled all notifications on this computer through group policy. The group policy setting overrides the user's setting.";
                        break;
                    case NotificationSetting.DisabledByManifest:
                        ReasonMessage = "To send a toast from app,developer must be set Toast Capable option to 'Yes' from 'Application Tab' of Package.appxmanifest file.";
                        break;
                    case NotificationSetting.DisabledForApplication:
                        ReasonMessage = "The user has disabled notifications for this app.";
                        break;
                    case NotificationSetting.DisabledForUser:
                        ReasonMessage = "The user or administrator has disabled all notifications for this user on this computer.";
                        break;
                }
                canSend = false;
            }
            return canSend;
        }
        public static void MakingToastNotification(string ToastTitle, string ToastBody, string strTag, string strGroup, bool IsToastPopUpRequired)
        {
            // Using the ToastText02 toast template.This template contains a maximum of two text elements. The first text element is treated as a header text and is always bold.
            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;

            // Retrieve the content part of the toast so we can change the text.
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            //Find the text component of the content
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");

            // Set the text on the toast. 
            // The first line of text in the ToastText02 template is treated as header text, and will be bold.
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(ToastTitle));//Toast notification title
            toastTextElements[1].AppendChild(toastXml.CreateTextNode(ToastBody + " (Tag:" + strTag + ", Group:" + strGroup + ")"));//Toast notification body

            // Set the duration on the toast
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");
            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(10);

            //Check Toast popup required to display
            if (!IsToastPopUpRequired)
            {
                toast.SuppressPopup = true;//to send notification directly to action center without displaying a popup on phone.
            }

            //Note: Tag & Group properties are optional,but these are userful for delete/update particular notification from app
            toast.Tag = strTag;
            toast.Group = strGroup;

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
        #endregion

    }
}
