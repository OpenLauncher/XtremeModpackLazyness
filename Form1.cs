using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace XtremeModpackLazyness
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
if (!openFileDialog1.CheckFileExists) {
    FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate);
    fs.Close();
}
string file = AppDomain.CurrentDomain.BaseDirectory.ToString() + "example.xml";
Console.Write(file);
                Console.Write(openFileDialog1.FileName);
var result = File.ReadAllLines(file)
     .Select(m => m.Substring(0, Math.Min(600, m.Length)));
File.WriteAllLines(openFileDialog1.FileName, result);
string text = File.ReadAllText(openFileDialog1.FileName);
File.WriteAllText(openFileDialog1.FileName, text);
            
        }
        public static string GetHash(string pathSrc)
        {


            String md5Result;
            StringBuilder sb = new StringBuilder();
            MD5 md5Hasher = MD5.Create();

            using (FileStream fs = File.OpenRead(pathSrc))
            {
                foreach (Byte b in md5Hasher.ComputeHash(fs))
                    sb.Append(b.ToString("x2").ToLower());
            }

            md5Result = sb.ToString();

            return md5Result;
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] filePaths = Directory.GetFiles(folderBrowserDialog1.SelectedPath);

                foreach (string stl in filePaths)
                {
                    Console.WriteLine(stl);
                   
                    string result = Path.GetFileNameWithoutExtension(stl);
                    string str = Path.GetFileName(stl);
                    StreamWriter file = new StreamWriter(openFileDialog1.FileName, true);
                    if (str.Contains("forge"))
                    {
                        file.Write("<mod url='files/1710/" + str + "' file='" + str + "' download='server' name='" + result + "' type='forge' md5='" + GetHash(stl) + "'/>" + Environment.NewLine);
                    }
                    else
                    {
                        file.Write("<mod url='files/1710/" + str + "' file='" + str + "' download='server' name='" + result + "' type='mods' md5='" + GetHash(stl) + "'/>" + Environment.NewLine);
                    }

                 
                        file.Close();
                }
                StreamWriter files = new StreamWriter(openFileDialog1.FileName, true);
                files.Write("</mods>" + Environment.NewLine);
                files.Write("</version>");
                files.Close();
            }
        }


       


 
    }


}
