using System;
using System.Collections.Generic;
using System.Linq;
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

namespace CipherArm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] armAlphabetarr;
        private string[] armAphabetArrDecrypt;
        public MainWindow()
        {
            InitializeComponent();
            GenerateShift();
            //load();
        }

        private void GenerateShift()
        {
            for(int i = 1; i <=39; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = i.ToString();
                Shift.Items.Add(item);
            }
        }

        private void load()
        {
            string armAlphabet = "ա բ գ դ ե զ է բ թ ժ ի լ խ ծ կ հ ձ ղ ճ մ յ ն շ ո չ պ ջ ռ ս վ տ ր ց ու փ ք և օ ֆ";
            armAlphabetarr = armAlphabet.Split(' ');
            armAphabetArrDecrypt = new string[armAlphabetarr.Length];

            //Console.WriteLine("Here is an alphabet: ");

            foreach (string s in armAlphabetarr)
            {
                armAphabet.Text += s + ", ";
            }

            //Console.WriteLine("Enter a key:");
            int key = Shift.SelectedIndex;

            int j = 0;
            for (int i = key; i < armAlphabetarr.Length; i++)
            {
                armAphabetArrDecrypt[j++] = armAlphabetarr[i];
            }

            j = 0;
            for (int l = armAlphabetarr.Length - 5; l < armAphabetArrDecrypt.Length; l++)
            {
                armAphabetArrDecrypt[l] = armAlphabetarr[j++];
            }

            //Console.WriteLine("Here is an alphabet for decryption: ");

            foreach (string s in armAphabetArrDecrypt)
            {
                armAphabetDecrypt.Text += s + ", ";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string plainText = PlainText.Text.ToString();
            int key = Shift.SelectedIndex;
            string encryptedText = Encrypt(plainText, key);
            EncryptedText.Text = encryptedText;
        }

        private string Encrypt(string message, int key)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in message)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'Ա' : 'ա';
                    char encryptedChar = (char)(((c + key - offset) % 39) + offset);

                    sb.Append(encryptedChar);
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        private void notFinished()
        {
            string plainText = PlainText.Text.ToString();
            string encryptedText = "";

            if (!string.IsNullOrEmpty(plainText))
            {
                for (int i = 0; i < plainText.Length; i++)
                {
                    string k = plainText[i].ToString();

                    foreach (string s in armAphabetArrDecrypt)
                    {
                        if (s == k)
                        {
                            encryptedText += s;
                            break;
                        }
                        continue;
                    }
                }
            }
        }


        private void Shift_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            load();
            textInputStack.Visibility = Visibility.Visible;
        }
    }
}
