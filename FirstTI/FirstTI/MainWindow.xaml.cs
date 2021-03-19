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
using System.Text.RegularExpressions;

namespace FirstTI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EncryptClick(object sender, RoutedEventArgs e)
        {
            switch (MethodBox.SelectedIndex)
            {
                case 0:
                    DecryptionBox.Text = RailFence.Encipher(EncryptionBox.Text, KeyBox.SelectedIndex + 1);
                    break;
                case 1:
                    DecryptionBox.Text = Column.Encipher(EncryptionBox.Text, KeyTextBox.Text);
                    break;
                case 2:
                    DecryptionBox.Text = RotatingLattice.Encipher(EncryptionBox.Text);
                    break;
                default:
                    DecryptionBox.Text = Caesar.Encipher(EncryptionBox.Text, KeyBox.SelectedIndex + 1);
                    break;
            }

            EncryptionBox.Text = "";
        }

        private void DecryptClick(object sender, RoutedEventArgs e)
        {
            switch (MethodBox.SelectedIndex)
            {
                case 0:
                    EncryptionBox.Text = RailFence.Decipher(DecryptionBox.Text, KeyBox.SelectedIndex + 1);
                    break;
                case 1:
                    EncryptionBox.Text = Column.Decipher(DecryptionBox.Text, KeyTextBox.Text);
                    break;
                case 2:
                    EncryptionBox.Text = RotatingLattice.Decipher(DecryptionBox.Text);
                    break;
                default:
                    EncryptionBox.Text = Caesar.Decipher(DecryptionBox.Text, KeyBox.SelectedIndex + 1);
                    break;
            }

            DecryptionBox.Text = "";
        }

        private void MethodChange(object sender, EventArgs e)
        {
            if (MethodBox.SelectedIndex == 1)
            {
                KeyTextBox.Visibility = Visibility.Visible;
                SecondKeyText.Visibility = Visibility.Visible;

                KeyBox.Visibility = Visibility.Hidden;
                FirstKeyText.Visibility = Visibility.Hidden;
            }
            else if (KeyTextBox != null)
            {
                KeyTextBox.Visibility = Visibility.Hidden;
                SecondKeyText.Visibility = Visibility.Hidden;

                KeyBox.Visibility = Visibility.Visible;
                FirstKeyText.Visibility = Visibility.Visible;
            }   
        }

        private void EncryptionInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".IndexOf(e.Text) > 0;
        }

        private void DecryptionInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".IndexOf(e.Text) > 0;
        }

        private void KeyInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(e.Text) < 0;
        }
    }
}
