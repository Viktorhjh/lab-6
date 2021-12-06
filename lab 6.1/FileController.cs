using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6._1
{
    class FileController
    {
        string path;
        public string readInt()
        {
            int current, count = 0;
            int[] data;
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryReader reader = new BinaryReader(fs);                           
            data = new int[2];
            while (reader.PeekChar() != -1)
            {
                count++;
            }
            data = new int[count];
                foreach (int i in data)
                {
                    data[i] = reader.Read();
                }
            reader.Close();
            fs.Close();
            return string.Join("", data);
        }

        public void writeInt(string[] input)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(fs);
            foreach (string current in input)
            {
                writer.Write(Convert.ToInt32(current));
            }
            writer.Close();
            fs.Close();
        }

        public void setPath(string path)
        {
            this.path = path;
        }
    }
}
