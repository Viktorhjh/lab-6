using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_6._1
{
    public partial class Form1 : Form
    {     
        string path;
        int choose;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Open
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            path = openFileDialog1.FileName;           
            textBox1.Text = path;
            textBox1.Visible = true;
        }

        //Save
        private void saveToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            writeInt();
        }

        //Read
        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            readInt();                       
        }

        //End
        private void endToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            choose = comboBox1.SelectedIndex;
        }
        public void readInt()
        {
            richTextBox1.Clear();
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryReader reader = new BinaryReader(fs);
            try
            {
                while(reader.PeekChar() > -1)
                {
                    switch (choose)
                    {
                        case 0:
                            richTextBox1.Text += reader.ReadInt32();                            
                            break;

                        case 1:
                            richTextBox1.Text += reader.ReadDouble();
                            break;

                        case 2:
                            richTextBox1.Text += reader.ReadInt32();
                            richTextBox1.Text += "\n" + reader.ReadDouble();
                            richTextBox1.Text += "\n" + reader.ReadString();
                            break;

                        case 3:
                            richTextBox1.Text += reader.ReadString();
                            richTextBox1.Text += "\n" + reader.ReadString();
                            richTextBox1.Text += "\n" + reader.ReadString();
                            richTextBox1.Text += "\n" + reader.ReadDouble();
                            richTextBox1.Text += "\n" + reader.ReadDouble();
                            break;

                        case 4:
                            int countInt = reader.ReadInt32();
                            int countDouble = reader.ReadInt32();
                            for(int i = 0; i < countInt; i++)
                            {
                                richTextBox1.Text += reader.ReadInt32() + " ";
                            }
                            richTextBox1.Text += "\n";
                            for (int i = 0; i < countDouble; i++)
                            {
                                richTextBox1.Text += reader.ReadDouble() + " ";
                            }
                            break;
                        
                        case 5:
                            int countPerson = reader.ReadInt32();
                            for(int i = 0; i < countPerson/5; i++)
                            {
                                richTextBox1.Text += reader.ReadString();
                                richTextBox1.Text += "\n" + reader.ReadString();
                                richTextBox1.Text += "\n" + reader.ReadString();
                                richTextBox1.Text += "\n" + reader.ReadDouble();
                                richTextBox1.Text += "\n" + reader.ReadDouble() + "\n";
                            }
                            break;
                    }                                        
                }
            }
            catch
            {

            }
            reader.Close();
            fs.Close();
        }       
        public void writeInt()
        {
            string[] data = richTextBox1.Text.Split(' ', '\n');
            FileStream fs = new FileStream(path, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(fs);
            switch (choose)
            {
                case 0:
                    foreach (string current in data)
                    {
                        writer.Write(Convert.ToInt32(current));
                    }
                    break;
                case 1:
                    foreach (string current in data)
                    {
                        writer.Write(Convert.ToDouble(current));
                    }
                    break;

                case 2:                    
                    writer.Write(Convert.ToInt32(data[0]));
                    writer.Write(Convert.ToDouble(data[1]));
                    writer.Write(Convert.ToString(data[2]));
                    break;

                case 3:
                    writer.Write(Convert.ToString(data[0]));
                    writer.Write(Convert.ToString(data[1]));
                    writer.Write(Convert.ToString(data[2]));
                    writer.Write(Convert.ToDouble(data[3]));
                    writer.Write(Convert.ToDouble(data[4]));
                    break;

                case 4:
                    string[] numbers = richTextBox1.Text.Split('\n');
                    string[] intNumbers = numbers[0].Split(' ');                    
                    string[] doubleNumbers = numbers[1].Split(' ');
                    writer.Write(intNumbers.Length);
                    writer.Write(doubleNumbers.Length);
                    foreach (var current in intNumbers)
                    {
                        writer.Write(Convert.ToInt32(current));
                    }
                    foreach (var current in doubleNumbers)
                    {
                        writer.Write(Convert.ToDouble(current));
                    }
                    break;

                case 5:
                    string[] count = richTextBox1.Text.Split('\n');
                    writer.Write(count.Length);
                    for(int i = 0; i < count.Length-5; i += 5)
                    {
                        writer.Write(Convert.ToString(data[i]));
                        writer.Write(Convert.ToString(data[i+1]));
                        writer.Write(Convert.ToString(data[i+2]));
                        writer.Write(Convert.ToDouble(data[i+3]));
                        writer.Write(Convert.ToDouble(data[i+4]));
                    }
                    
                    break;
            }

            writer.Close();
            fs.Close();
        }
    }    
}
