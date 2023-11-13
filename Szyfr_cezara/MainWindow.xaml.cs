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
using static System.Net.Mime.MediaTypeNames;

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

        private void Szyfruj_Click(object sender, RoutedEventArgs e)
        {
            string szyfr = do_szyfru.Text;

            if (kluczyk.SelectedItem != null)
            {
                if (int.TryParse(((ComboBoxItem)kluczyk.SelectedItem).Content.ToString(), out int wybranyKlucz))
                {
                    zaszyfrowane.Text = SzyfrujCezarem(szyfr, wybranyKlucz);
                }
                else
                {
                    MessageBox.Show("Nie można przekonwertować wybranego klucza na liczbę całkowitą.");
                }
            }
            else
            {
                MessageBox.Show("Musisz w comboboxie coś wybrać!");
            }
        }

        public string SzyfrujCezarem(string tekst, int klucz)
        {
            string alfa = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";

            if (string.IsNullOrEmpty(tekst))
            {
                return string.Empty;
            }

            StringBuilder zaszyfrowanyTekst = new StringBuilder();

            foreach (char znak in tekst)
            {
                if (char.IsLetter(znak))
                {
                    for(int i = 0; i < 35; i++)
                    {
                        if (alfa[i] == znak)
                        {
                            zaszyfrowanyTekst.Append(alfa[(i+klucz)%35]);
                        }
                    }
                }
                else if (char.IsWhiteSpace(znak))
                {
                    continue;
                }
                else if (!char.IsLetter(znak))
                {
                    MessageBox.Show("Wprowadź ciąg znaków składający się tylko z liter!");
                    do_szyfru.Text = "";
                    break;
                }
            }

            return zaszyfrowanyTekst.ToString();
        }

        public string DeszyfrujCezarem(string zaszyfrowanyTekst, int klucz)
        {
            string alfa = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";

            if (string.IsNullOrEmpty(zaszyfrowanyTekst))
            {
                return string.Empty;
            }

            StringBuilder odszyfrowanyTekst = new StringBuilder();

            foreach (char znak in zaszyfrowanyTekst)
            {
                if (char.IsLetter(znak))
                {
                    for (int i = 0; i < 35; i++)
                    {
                        if (alfa[i] == znak)
                        {
                            odszyfrowanyTekst.Append(alfa[(i - klucz < 0 ? 35 + i - klucz : i - klucz)]);
                        }
                    }
                }
                else if (char.IsWhiteSpace(znak))
                {
                    continue;
                }
                else if(!char.IsLetter(znak))
                {
                    MessageBox.Show("Wprowadź ciąg znaków składający się tylko z liter!");
                    do_odszyfru.Text = "";
                    break;
                }
            }

            return odszyfrowanyTekst.ToString();
        }



        private void Deszyfruj_Click(object sender, RoutedEventArgs e)
        {
            string zaszyfrowany = do_odszyfru.Text;

            if (kluczyk_Copy.SelectedItem != null)
            {
                if (int.TryParse(((ComboBoxItem)kluczyk_Copy.SelectedItem).Content.ToString(), out int wybranyKlucz))
                {
                    odszyfrowane.Text = DeszyfrujCezarem(zaszyfrowany, wybranyKlucz);
                }
                else
                {
                    MessageBox.Show("Nie można przekonwertować wybranego klucza na liczbę całkowitą.");
                }
            }
            else
            {
                MessageBox.Show("Musisz w comboboxie coś wybrać!");
            }
        }
    }
}
