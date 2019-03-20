using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pict
{
    public partial class Form1 : Form
    {
        string[] word = new string[20];
        int wordSize = 0;
        string url;
        string[] wordData = new string[10000];
        int wordDataSize = 0;


        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "https://pictsense.com/dic/n18620";
        }

        private void Button1_Click(object sender, EventArgs e)
        {//url
            url = textBox1.Text;
            GetWord();
        }

        private void Button2_Click(object sender, EventArgs e)
        {//go
            if (textBox22.Text != "")wordSize = int.Parse(textBox22.Text);
            if (textBox2.Text != "")word[0] = textBox2.Text;
            if (textBox3.Text != "") word[1] = textBox3.Text;
            if (textBox4.Text != "") word[2] = textBox4.Text;
            if (textBox5.Text != "") word[3] = textBox5.Text;
            if (textBox6.Text != "") word[4] = textBox6.Text;
            if (textBox7.Text != "") word[5] = textBox7.Text;
            if (textBox8.Text != "") word[6] = textBox8.Text;
            if (textBox9.Text != "") word[7] = textBox9.Text;
            if (textBox10.Text != "") word[8] = textBox10.Text;
            if (textBox11.Text != "") word[9] = textBox11.Text;
            if (textBox12.Text != "") word[10] = textBox12.Text;
            if (textBox13.Text != "") word[11] = textBox13.Text;
            if (textBox14.Text != "") word[12] = textBox14.Text;
            if (textBox15.Text != "") word[13] = textBox15.Text;
            if (textBox16.Text != "") word[14] = textBox16.Text;
            if (textBox17.Text != "") word[15] = textBox17.Text;
            if (textBox18.Text != "") word[16] = textBox18.Text;
            if (textBox19.Text != "") word[17] = textBox19.Text;
            if (textBox20.Text != "") word[18] = textBox20.Text;
            if (textBox21.Text != "") word[19] = textBox21.Text;
            
            for(int i = 0; i < wordSize; i++)
            {
                if (word[i] == null)
                {
                    Console.Write("------------------------------------------------------------------");
                }
                else
                {
                    Console.Write(word[i]);
                }
            }
            Console.WriteLine();
            SearchWord();
        }

        private void Button3_Click(object sender, EventArgs e)
        {//reset

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";

            for(int i = 0; i < 20; i++)
            {
                word[i] = null;
            }
        }

        private void GetWord()
        {
            var client = new RestClient();
            var request = new RestRequest();
            client.BaseUrl = new Uri(url);
            request.Method = Method.GET;
            client.UserAgent = ("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100");
            var response = client.Execute(request);
            string str = response.Content;

            int start = str.IndexOf("\"words\"");
            int end = str.IndexOf("try");
            str = str.Substring(start+9, end-start-56);

            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == '<')
                {
                    if (str[i + 1] == '/')
                    {
                        wordDataSize++;
                        continue;
                    }
                    continue;
                }
                if (str[i] == '/') continue;
                if (str[i] == '>') continue;
                if (str[i] == 'l') continue;
                if (str[i] == 'i') continue;

                wordData[wordDataSize] += str[i];

            }
            

            for(int i = 0; i < wordDataSize; i++)
            {
                Console.WriteLine(wordData[i]);
            }

            //Console.WriteLine(str);

        }

        private void SearchWord()
        {
            string labelOutput = "";
            for(int i = 0; i < wordDataSize; i++)
            {
                if (wordSize != wordData[i].Length) continue;
                if (MatchWord(wordData[i]) == false)
                {
                    continue;
                }

                labelOutput += wordData[i]+"\n";
                Console.WriteLine(wordData[i]);
            }
            label1.Text = labelOutput;

        }


        private bool MatchWord(string str)
        {
            string tmp;
           
            for (int i = 0; i < wordSize; i++)
            {
                if (word[i] == null) continue;
                tmp =str[i].ToString();

                if (tmp != word[i])
                {
                    return false;
                }

            }
            return true;
        }

    }
}
