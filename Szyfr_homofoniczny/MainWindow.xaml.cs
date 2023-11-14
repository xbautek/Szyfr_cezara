﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Szyfr_cezara
{
    public partial class MainWindow : Window
    {
        // Utwórz mapę homofoniczną dla polskiego alfabetu
        private Dictionary<char, List<string>> homophonicMap = new Dictionary<char, List<string>>
        {
            {'a', new List<string> { "&b", "ś2", "8-", "gg", "1'", "77", "c<", "N9" }},
            {'ą', new List<string> { "/l" }},
            {'b', new List<string> { "sd" }},
            {'c', new List<string> { "u[", "]u", "zd", "aj" }},
            {'ć', new List<string> { "bb" }},
            {'d', new List<string> { "16", "()", ";r" }},
            {'e', new List<string> { "RR", "łG", "21", "!@", "3v", "h&", "ń@", ";;" }},
            {'ę', new List<string> { "o!" }},
            {'f', new List<string> { "!o" }},
            {'g', new List<string> { "+@" }},
            {'h', new List<string> { "5'" }},
            {'i', new List<string> { "97", "x#", "g$", "t^", "u*", "67", "63", "pi" }},
            {'j', new List<string> { "he", "jt" }},
            {'k', new List<string> { "[s", "n)", "u-", "94" }},
            {'l', new List<string> { "!ł", "Ój" }},
            {'ł', new List<string> { "y%", "@." }},
            {'m', new List<string> { "03", "%%", ";6" }},
            {'n', new List<string> { "'@", "4d", "v6", "gh", "qi", "nŃ" }},
            {'ń', new List<string> { "(F" }},
            {'o', new List<string> { "f7", "=-", "m#", "n.", "ńB", "uj", "&k", "wg" }},
            {'ó', new List<string> { "62" }},
            {'p', new List<string> { "40", "0!", "21" }},
            {'q', new List<string> { "€)" }},
            {'r', new List<string> { "ść", "si", "€9", "qc", "nq" }},
            {'s', new List<string> { "07", "aS", "MW", "Gs" }},
            {'ś', new List<string> { "73" }},
            {'t', new List<string> { "/!", "ii", "^ń", "rO" }},
            {'u', new List<string> { "**", "24", "xV"}},
            {'v', new List<string> { "^^" }},
            {'w', new List<string> { "%D", "fl", "mA", "rz", "2;" }},
            {'x', new List<string> { "oł" }},
            {'y', new List<string> { "ye", "xD", "'€", "oT" }},
            {'z', new List<string> { "f;", "xR", ".ó", "pŚ", "Dx", "eL" }},
            {'ź', new List<string> { "vh" }},
            {'ż', new List<string> { "@f" }}
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Szyfruj_Click(object sender, RoutedEventArgs e)
        {
            string szyfr = do_szyfru.Text;
            zaszyfrowane.Text = Szyfruj(szyfr);
        }

        private void Deszyfruj_Click(object sender, RoutedEventArgs e)
        {
            string zaszyfrowany = do_odszyfru.Text;
            odszyfrowane.Text = Deszyfruj(zaszyfrowany);
        }

        public string Szyfruj(string tekst)
        {
            if (string.IsNullOrEmpty(tekst))
            {
                return string.Empty;
            }

            var nospace = tekst.Replace(" ", "");

            StringBuilder zaszyfrowanyTekst = new StringBuilder();

            foreach (char character in nospace.ToLower())  // Zamień na małe litery, aby zachować spójność
            {
                if (homophonicMap.ContainsKey(character))
                {
                    List<string> substitutes = homophonicMap[character];
                    Random random = new Random();
                    int randomIndex = random.Next(substitutes.Count);
                    zaszyfrowanyTekst.Append(substitutes[randomIndex]);
                }
                else
                {
                    // Jeśli znak nie znajduje się w mapie homofonicznej, zachowaj go niezmienionego.
                    zaszyfrowanyTekst.Append(character);
                }
            }

            return zaszyfrowanyTekst.ToString();
        }

        public string Deszyfruj(string zaszyfrowanyTekst)
        {
            if (string.IsNullOrEmpty(zaszyfrowanyTekst))
            {
                return string.Empty;
            }

            // Odwrotność szyfrowania homofonicznego byłoby dość skomplikowane.
            // W praktyce konieczne jest przechowywanie mapy odwrotnej (od zastąpień do liter) 
            // i korzystanie z niej do deszyfrowania. Proszę o zrozumienie, że poniższy kod to tylko przykład.

            StringBuilder odszyfrowanyTekst = new StringBuilder();

            string cipher = "";
            for(int i = 0; i< zaszyfrowanyTekst.Length; i += 2)
            {
                cipher = $"{zaszyfrowanyTekst[i]}{zaszyfrowanyTekst[i+1]}";

                foreach (var entry in homophonicMap)
                {
                    if (entry.Value.Contains(cipher))
                    {
                        odszyfrowanyTekst.Append(entry.Key);
                        break;
                    }
                }
                cipher = "";
            }

            return odszyfrowanyTekst.ToString();
        }
    }
}
