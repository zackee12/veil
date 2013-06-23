using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace veil
{
    public partial class FormPasswordGenerator : Form
    {
        const int NUM_PASSWORDS = 15;
        const int MIN_WORD_SIZE = 2;
        const int MAX_WORD_SIZE = 8;
        private MaskedTextBox maskedTB;

        public FormPasswordGenerator(MaskedTextBox tb)
        {
            InitializeComponent();
            maskedTB = tb;
        }

        // build list of valid chars and use random number to pick from list

        private List<string> GeneratePasswords()
        {
            var passwords = new List<string>();
            var validChar = new List<char>();
            if (checkBoxBrackets.Checked == true) validChar.AddRange("()[]{}<>".ToArray());
            if (checkBoxDigits.Checked == true) validChar.AddRange("1234567890".ToArray());
            if (checkBoxLower.Checked == true) validChar.AddRange("abcdefghijklmnopqrstuvwxyz".ToArray());
            if (checkBoxPunctuation.Checked == true) validChar.AddRange(@",.?;:'""".ToArray());
            if (checkBoxSpace.Checked == true) validChar.Add(' ');
            if (checkBoxSpecial.Checked == true) validChar.AddRange("!@#$%^&*".ToArray());
            if (checkBoxUnderscore.Checked == true) validChar.Add('_');
            if (checkBoxUpper.Checked == true) validChar.AddRange("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray());
            if (textBoxCustom.TextLength > 0) validChar.AddRange(textBoxCustom.Text.ToArray());
            
            bool genWords = checkBoxWords.Checked;
            int len = (int)numericUpDownLength.Value;

            CryptoRandom cr = new CryptoRandom();

            for (int i = 0; i < NUM_PASSWORDS; i++)
            {
                int strLen = 0;
                string mes = "";
                if (genWords)
                {
                    // generate [word] [filler] [word] [filler] ...
                    
                    bool filler = false;
                    while (strLen < len)
                    {
                        if (filler)
                        {
                            // give 1 to len - strLen characters
                            int loop = cr.Next(1,Math.Min(3, len - strLen));
                            for (int j = 0; j < loop; j++)
                            {
                                mes += validChar[cr.Next(validChar.Count)];
                                strLen++;
                            }
                        }
                        else
                        {
                            // must meet minimum word size
                            if (len - strLen > MIN_WORD_SIZE)
                            {
                                string add = RandomNLengthWord(cr.Next(MIN_WORD_SIZE, (int)Math.Min(MAX_WORD_SIZE, len - strLen)));
                                mes += add;
                                strLen += add.Length;
                            }
                        }
                        filler = !filler;
                    }
                }
                else
                {
                    // generate character by character
                    while (strLen < len)
                    {
                        mes += validChar[cr.Next(validChar.Count)];
                        strLen++;
                    }
                }
                
                
                passwords.Add(mes);
            }


           

            return passwords;
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            listBoxPasswords.Items.Clear();
            List<string>  passwords = GeneratePasswords();
            foreach (string password in passwords)
            {
                listBoxPasswords.Items.Add(password);
            }
        }

        private string RandomNLengthWord(int word_length)
        {
            List<string> file = File.ReadLines("word_list.txt").ToList();
            int lineCount = file.Count;
            CryptoRandom cr = new CryptoRandom();

            int iterations = 0;
            while (iterations < 10000)
            {
                string word = file[cr.Next(lineCount)];
                if (word.Length == word_length)
                {
                    return word;
                }
            }
            return "";
        }

        private List<string> RandomLessThanNLengthWords(int word_length, int number)
        {

            List<string> file = File.ReadLines("word_list.txt").ToList();
            int lineCount = file.Count;
            var list = new List<string>();
            CryptoRandom cr = new CryptoRandom();

            while (list.Count < number)
            {
                string word = file[cr.Next(lineCount)];
                if (word.Length <= word_length)
                {
                    list.Add(word);
                }
            }
            return list;
        }

        private List<string> RandomNToMLengthWords(int length_x1, int length_x2)
        {
            int len = length_x1;
            List<string> file = File.ReadLines("word_list.txt").ToList();
            int lineCount = file.Count;
            var list = new List<string>();
            CryptoRandom cr = new CryptoRandom();

            while (len <= length_x2)
            {
                string word = file[cr.Next(lineCount)];
                if (word.Length == len)
                {
                    list.Add(word);
                    len += 1;
                }
                
            }
            return list;
        }

        private void listBoxPasswords_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxPassword.Text = listBoxPasswords.Text;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            maskedTB.Text = textBoxPassword.Text;
            this.Close();
        }

        private void checkBox_Changed(object sender, EventArgs e)
        {
            // words is excluded
            List<bool> check = new List<bool>(new bool[] {checkBoxBrackets.Checked, checkBoxDigits.Checked, checkBoxLower.Checked, checkBoxPunctuation.Checked, checkBoxSpace.Checked, checkBoxSpecial.Checked, checkBoxUnderscore.Checked });
            int count = check.Count(x => x == true);
            if (textBoxCustom.TextLength > 0) count++;

            if (count > 0)
            {
                buttonGenerate.Enabled = true;
                buttonObfuscate.Enabled = true;
            }
            else
            {
                buttonGenerate.Enabled = false;
                buttonObfuscate.Enabled = false;
            }
        }

        private void buttonObfuscate_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text = LEET(textBoxPassword.Text);
        }

        private string LEET(string phrase)
        {
            phrase = phrase.ToLower();
            List<char> array = phrase.ToArray().ToList();
            CryptoRandom cr = new CryptoRandom();
            List<char> leet = new List<char>();
            string str = "";
            foreach (char c in array)
            {
                switch (c)
                {
                    case 'a':
                        leet = new List<char>("aA4@".ToArray());
                        break;
                    case 'b':
                        leet = new List<char>("bB8@".ToArray());
                        break;
                    case 'c':
                        leet = new List<char>("cC".ToArray());
                        break;
                    case 'd':
                        leet = new List<char>("dD".ToArray());
                        break;
                    case 'e':
                        leet = new List<char>("eE3".ToArray());
                        break;
                    case 'f':
                        leet = new List<char>("fF".ToArray());
                        break;
                    case 'g':
                        leet = new List<char>("gG69".ToArray());
                        break;
                    case 'h':
                        leet = new List<char>("hH#".ToArray());
                        break;
                    case 'i':
                        leet = new List<char>("iI1".ToArray());
                        break;
                    case 'j':
                        leet = new List<char>("jJ".ToArray());
                        break;
                    case 'k':
                        leet = new List<char>("kK".ToArray());
                        break;
                    case 'l':
                        leet = new List<char>("lL1".ToArray());
                        break;
                    case 'm':
                        leet = new List<char>("mM".ToArray());
                        break;
                    case 'n':
                        leet = new List<char>("nN".ToArray());
                        break;
                    case 'o':
                        leet = new List<char>("oO0".ToArray());
                        break;
                    case 'p':
                        leet = new List<char>("pP".ToArray());
                        break;
                    case 'q':
                        leet = new List<char>("qQ".ToArray());
                        break;
                    case 'r':
                        leet = new List<char>("rR".ToArray());
                        break;
                    case 's':
                        leet = new List<char>("sS5$".ToArray());
                        break;
                    case 't':
                        leet = new List<char>("tT7+".ToArray());
                        break;
                    case 'u':
                        leet = new List<char>("uU".ToArray());
                        break;
                    case 'v':
                        leet = new List<char>("vV".ToArray());
                        break;
                    case 'w':
                        leet = new List<char>("wW".ToArray());
                        break;
                    case 'x':
                        leet = new List<char>("xX".ToArray());
                        break;
                    case 'y':
                        leet = new List<char>("yY".ToArray());
                        break;
                    case 'z':
                        leet = new List<char>("zZ2".ToArray());
                        break;
                    default:
                        leet = new List<char>();
                        break;
                }

                if (leet.Count > 0)
                {
                    str += leet[cr.Next(leet.Count)];
                }
                else
                {
                    str += c;
                }
            }

            return str;
        }
    }
}
