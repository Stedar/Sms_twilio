using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
namespace Sms_twilio
{
    public partial class MainPage : ContentPage
    {
        string OTPcode;
        
        public MainPage()
        {
            InitializeComponent();
            
        }
         void OnSendButtonClicked(object sender, EventArgs e)
        {
            Random generator = new Random();
            OTPcode = generator.Next(0, 9999).ToString("D4");

            // Find your Account Sid and Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
             string accountSid = "AC2c4aa2621409e48e705d75b8e104787d";
             string authToken = "d7f87a2ffe2d7bbe107d7e610b21c196";

             TwilioClient.Init(accountSid, authToken);

             var message = MessageResource.Create(
                 body: "YCODE: " + OTPcode,
                 from: new Twilio.Types.PhoneNumber("+12056600386"),
                 to: new Twilio.Types.PhoneNumber(PhoneEntry.Text)
             );

             Console.WriteLine(message.Sid);  
        }
        void OnOTPButtonClicked(object sender, EventArgs e)
        {
            result_OTP.Text = "111";
            if (OTPcode == OTPEntry.Text)
                result_OTP.Text = "CORRECT!";
            else
                result_OTP.Text = "WRONG!";


        }

    }
}
