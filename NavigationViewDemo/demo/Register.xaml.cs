using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using NavigationViewDemo.Service;
using Newtonsoft.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NavigationViewDemo.demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        private int valiGender;
        private AccountService accountService = new AccountService();
        public Register()
        {
            this.InitializeComponent();
        }
          
    

       



        //check phone la chu hay la so
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        //check phone tuwr 10-12
        public static Boolean checkPhoneNumber(string phone)
        {
            var passValidation = new Regex(@"^([0-9]{10,12})$");/// từ 10-12 số

            return passValidation.IsMatch(phone);
        }

        //check email
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        //check gender
        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            switch (rb.Name)
            {
                case "male":
                    valiGender = 1;
                    break;
                case "female":
                    valiGender = 2;
                    break;
                case "other":
                    valiGender = 3;
                    break;
            }

        }








        private async void Registration_Click(object sender, RoutedEventArgs e)
        {
            //check validate
            var fname = txtFname.Text;
            var lname = txtLname.Text;
            var password = txtPassword.Password.ToString();
            var address = txtAddress.Text;
            var phone = txtPhone.Text;
            var avatar = txtAvatar.Text;
            var email = txtEmail.Text;

            var intro = Introduction.Text;



            //fname
            if (String.IsNullOrEmpty(fname))
            {
                msgFnameErr.Text = "Please Enter the First Name!";

            }
            else
            {
                msgFnameErr.Text = "";

            }

            //lname
            if (String.IsNullOrEmpty(lname))
            {
                msgLnameErr.Text = "Please Enter the Last Name!";

            }
            else
            {
                msgLnameErr.Text = "";

            }


            //password
            if (String.IsNullOrEmpty(password))
            {
                msgPasswordErr.Text = "Please Enter the Password!";

            }
            else if (password.Length < 8)
            {
                msgPasswordErr.Text = "Password must contains least 8 characters";

            }
            else
            {
                msgPasswordErr.Text = "";

            }


            //address
            if (String.IsNullOrEmpty(address))
            {
                msgAddressErr.Text = "Please Enter the Address!";

            }
            else
            {
                msgAddressErr.Text = "";

            }

            //phone
            if (String.IsNullOrEmpty(phone))
            {
                msgPhoneErr.Text = "Please Enter the Phone!";

            }
            else if (IsNumber(phone) == false)
            {
                msgPhoneErr.Text = "Please Enter the numbers!";

            }
            else if (checkPhoneNumber(phone) == false)
            {
                msgPhoneErr.Text = "Phone number with 10 to 12 digits!";

            }
            else
            {
                msgPhoneErr.Text = "";

            }
            //avatar
            if (String.IsNullOrEmpty(avatar))
            {
                msgAvatarErr.Text = "Please Enter the Avatar!";

            }
            else
            {
                msgAvatarErr.Text = "";

            }

            //gender
            if (valiGender==null)
            {
                msgGenderErr.Text = "Please Enter the Gender!";

            }
            else
            {
                msgGenderErr.Text = "";


            }
            //email

            if (String.IsNullOrEmpty(email))
            {
                msgEmailErr.Text = "Please Enter the Email!";

            }
            else if (IsValidEmail(email) == false)
            {
                msgEmailErr.Text = "Your email must contains @";


            }
            else
            {
                msgEmailErr.Text = "";

            }
            //birthday
            if (birthday.SelectedDate == null)
            {
                msgBirthdayErr.Text = "Please Enter the Birthday!";

            }
            else
            {
                msgBirthdayErr.Text = "";

            }

            //introduction
            if (String.IsNullOrEmpty(intro))
            {
                msgIntroductionErr.Text = "Please Enter the Introduction!";

            }
            else
            {
                msgIntroductionErr.Text = "";

            }
            if (intro != "")
            {

                //string -> json
                var account = new Entity.Account()
                {
                    Id = 1,
                    firstName = fname,
                    lastName = lname,
                    password = password,
                    address = address,
                    gender = valiGender,
                    phone = phone,
                    avatar = avatar,
                    email = email,
                    birthday = birthday.SelectedDate.ToString(),
                    introduction = intro,



                };
              var result= await accountService.Process(account);
                ContentDialog contentDialog = new ContentDialog();
                if (result)
                {
                    contentDialog.Title = "action success";
                    contentDialog.Content = "create account success!";
                }
                else
                {
                    contentDialog.Title = "action fails";
                    contentDialog.Content = "please try again!";
                }
                contentDialog.CloseButtonText = "OK";
                contentDialog.ShowAsync();
               

            }










        }


    }
}


