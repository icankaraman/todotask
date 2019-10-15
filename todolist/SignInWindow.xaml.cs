using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using todolist.EntityModel;

namespace todolist
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
        }

        ToDoDbContext db = new ToDoDbContext();
        User userObj = new User();
        private readonly string hash = "ick94";

        public bool ValidateLines(string userName,string password ,string confirmPass)
        {
            if (String.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Please fill UserName area!");
                return false;
            }

            else if (String.IsNullOrEmpty(password) || String.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Please fill password lines!");
                return false;
            }
            else if (password != confirmPass)
            {
                MessageBox.Show("Passwords doesn't match!");
                return false;
            }
            else
            {
                SetUserLines();
                return true;
            }
        }

        public string CryptPassword(byte[] data)
        {
            string hashPassword;
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    hashPassword = Convert.ToBase64String(results, 0, results.Length);
                }
            }
            return hashPassword;
        }
        public void SetUserLines()
        {
            userObj.Name = txtUserName.Text;
            userObj.Password = pwdUser.Password;
            byte[] data = Encoding.UTF8.GetBytes(pwdUser.Password);
            userObj.Password = CryptPassword(data);
            userObj.CreateDate = DateTime.Now;
            userObj.UpdateDate = DateTime.Now;
            db.Users.Add(userObj);
            db.SaveChanges();
            MessageBox.Show("User added!");
            
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        public void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            var userName = txtUserName.Text;
            var password = pwdUser.Password;
            var confirmPass = pwdConfirm.Password;
            ValidateLines(userName,password,confirmPass);
        }

        public void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
