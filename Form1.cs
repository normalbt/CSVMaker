using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVMaker
{
    public partial class Form1 : Form
    {
        private static int maxLevel
        { get; set; }
        private static int expMultiflier
        { get; set; }
        private static int engrams
        { get; set; }

        public void changeText(string s) // this method changes text of TextBox
        {
            textBox.Text = s;
        }

        public async Task ExampleAsync() // this method make strings : x;x;x
        {
            Console.WriteLine(int.MaxValue);

            int[] var1 = new int[maxLevel];
            int[] var2 = new int[maxLevel];
            int[] var3 = new int[maxLevel];
            string s1 = "";


            for (int i = 1; i < var1.Length; i++)
            {
                var1[i] = i;

                double k = (100000 * Math.Log(i, 2) / 2) * expMultiflier;

                if (k > 0 && k < int.MaxValue)
                {
                    var2[i] = Convert.ToInt32(k);
                }
                else
                {
                    var2[i] = 1000;
                }

                var3[i] = engrams;

                Console.Write($"{var1[i]};{var2[i]};{var3[i]}\n");

                s1 = s1 + var1[i].ToString() + ";" +
                     var2[i].ToString() + ";" +
                     var3[i].ToString() + "\n";
            }

            string lines = s1;

            string path = Directory.GetCurrentDirectory();

            Console.WriteLine(path);

                await Task.Delay(1000);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "outputFile.csv")))
            {
                await outputFile.WriteAsync(lines);
                changeText("Done!");
                button1.Enabled = true;
            }


        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int[] numList = new int[10000];
            for (int i=1;i<numList.Length;i++)
            {
                numList[i] = i + 1;

                cboBox.Items.Add(i);
            }

            expMultiflier = 1;

            engrams = 5;

            rbX1.Checked = true;

            rben5.Checked = true;
        }

        private void cboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            maxLevel = Convert.ToInt32(cboBox.SelectedItem) + 1;
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            changeText("waiting...");
            button1.Enabled = false;

            Task t = ExampleAsync();

            //Console.WriteLine("Image");
            //t.Wait();
        }

        private void rbX1_Click(object sender, EventArgs e)
        {
            expMultiflier = 1;
        }

        private void rbX2_Click(object sender, EventArgs e)
        {
            expMultiflier = 2;
        }

        private void rbX3_Click(object sender, EventArgs e)
        {
            expMultiflier = 3;
        }

        private void rben5_Click(object sender, EventArgs e)
        {
            engrams = 5;
        }

        private void rben10_Click(object sender, EventArgs e)
        {
            engrams = 10;
        }

        private void rben20_Click(object sender, EventArgs e)
        {
            engrams = 20;
        }
    }
}
