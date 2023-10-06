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

namespace Szyfr_cezara
{
    /// <summary
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string szyfr = do_szyfru.Text;

            if (kluczyk.SelectedItem != null && int.TryParse(kluczyk.SelectedItem.ToString(), out int wybranyKlucz))
            {
                // Wywołaj funkcję SzyfrujCezarem z wybranym kluczem
                zaszyfrowane.Text = SzyfrujCezarem(szyfr, wybranyKlucz);
            }
            else
            {
                MessageBox.Show("Musisz w comboboxie coś wybrać!");
            }
        }//Convert.ToInt32(kluczyk.SelectedValue)

        public string SzyfrujCezarem(string tekst, int klucz)
        {
            if (string.IsNullOrEmpty(tekst))
            {
                return string.Empty;
            }

            // Przygotuj pusty string do przechowania zaszyfrowanego tekstu
            StringBuilder zaszyfrowanyTekst = new StringBuilder();

            // Przesuń każdy znak w tekście o podany klucz
            foreach (char znak in tekst)
            {
                if (char.IsLetter(znak))
                {
                    char startChar = char.IsUpper(znak) ? 'A' : 'a';
                    zaszyfrowanyTekst.Append((char)(((znak - startChar + klucz) % 26) + startChar));
                }
                else if (char.IsWhiteSpace(znak))
                {
                    continue;
                }
                else
                {
                    // Jeśli znak nie jest literą, zachowaj go bez zmiany
                    zaszyfrowanyTekst.Append(znak);
                }
            }

            return zaszyfrowanyTekst.ToString();
        }
    }
}
