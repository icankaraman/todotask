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
using System.Windows.Navigation;
using System.Windows.Shapes;
using todolist.EntityModel;

namespace todolist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ToDoDbContext db = new ToDoDbContext();
        private readonly string hash = "ick94";

        private void ValidateLines()
        {
            if (String.IsNullOrEmpty(txtUserName.Text))
                MessageBox.Show("Please fill UserName line!");

            else if (String.IsNullOrEmpty(pwdUser.Password))
                MessageBox.Show("Please fill password line!");
            else
                UserEnter();
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

        private void btnsign_Click(object sender, RoutedEventArgs e)
        {
            SignInWindow signup = new SignInWindow();
            signup.Show();
            this.Close();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            ValidateLines();

        }

        public void UserEnter()
        {
            byte[] data = Encoding.UTF8.GetBytes(pwdUser.Password);
            var hashPass = CryptPassword(data);
            var user = db.Users.AsQueryable().Where(x => x.Name.Equals(txtUserName.Text) && x.Password.Equals(hashPass)).FirstOrDefault();
            if(user != null)
            {
                MessageBox.Show("Login Success.");
                var listWindow = new ListWindow();
                listWindow.Show();
                listWindow.GetUser(user);
                this.Close();
            }
            else
            {
                MessageBox.Show("Login Failed. Please check your username or password");
            }
        }
    }
}
