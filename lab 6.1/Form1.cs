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
            }



            writer.Close();
            fs.Close();
        }
    }    
}
