using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Utils;

namespace Input_lib
{
    public class InStreamer
    {
        private static System.Globalization.NumberFormatInfo ni = null;
        private string Buf;
        private StreamReader f;
        private void BufferPreparer()//убирает комментарии и лишние пробелы
        {
            SetCommaSeparator();
            Buf = Buf.Replace("\r\n", "\n");
            string[] strings = Buf.Split('\n');
            Buf = "";
            int n = 0;

            for (int i = 0; i < strings.Length; i++)
            {
                n = strings[i].IndexOf("#");
                if (n >= 0)
                    strings[i] = strings[i].Remove(n);
                if (strings[i].CompareTo("") != 0)
                {
                    string[] between_spaces = strings[i].Split(' ');
                    strings[i] = between_spaces[0];
                    for (int j = 1; j < between_spaces.Length; j++)
                    {
                        if (between_spaces[j].CompareTo("") != 0)
                            strings[i] += " " + between_spaces[j];
                    }
                    Buf = Buf + "\n" + strings[i];
                }
            }

            Console.WriteLine(Buf);
        }
        private void SetCommaSeparator()
        {
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.InstalledUICulture;
            ni = (System.Globalization.NumberFormatInfo)ci.NumberFormat.Clone();
            ni.NumberDecimalSeparator = ",";

        }
        public double[,] GetMatrix(string matrix_id)
        {
            int start_pos = Buf.IndexOf("[" + matrix_id + "]") + matrix_id.Length + 3;
            int end_pos = Buf.IndexOf("[", Buf.IndexOf("[" + matrix_id + "]") + 1) - 2;
            if (end_pos - start_pos + 1 > 0)
            {
                string SubBuf = Buf.Substring(start_pos, end_pos - start_pos + 1);
                string[] rows = SubBuf.Split('\n');
                int row_count = rows.Length;
                int column_count = rows[0].Split(' ').Length;
                double[,] res = new double[row_count, column_count];
                for (int i = 0; i < row_count; i++)
                {
                    string[] columns = rows[i].Split(' ');
                    for (int j = 0; j < column_count; j++)
                    {
                        res[i, j] = double.Parse(columns[j], ni);
                    }
                }
                return res;
            }
            else return null;
        }
        public double[][] GetVector(string vector_id)// считывает набор векторов разной длины(для Ro)
        {
            int start_pos = Buf.IndexOf("[" + vector_id + "]") + vector_id.Length + 3;
            int end_pos = Buf.IndexOf("[", Buf.IndexOf("[" + vector_id + "]") + 1) - 2;
            if (end_pos - start_pos + 1 > 0)
            {
                string SubBuf = Buf.Substring(start_pos, end_pos - start_pos + 1);
                string[] rows = SubBuf.Split('\n');
                int row_count = rows.Length;
                int column_count = 0;
                double[][] res = new double[row_count][];
                for (int i = 0; i < row_count; i++)
                {
                    column_count = rows[i].Split(' ').Length;
                    string[] columns = rows[i].Split(' ');
                    res[i] = new double[column_count];
                    for (int j = 0; j < column_count; j++)
                    {
                        res[i][j] = double.Parse(columns[j], ni);
                    }
                }
                return res;
            }
            else return null;
        }

        public DistributionPare[][] GetDistribution(string distribution_id)//считывает ряды распределения длин квазипериодов для всех состояний
        {
            int start_pos = Buf.IndexOf("[" + distribution_id + "]") + distribution_id.Length + 3;
            int end_pos = Buf.IndexOf("[", Buf.IndexOf("[" + distribution_id + "]") + 1) - 2;
            if (end_pos - start_pos + 1 > 0)
            {
                string SubBuf = Buf.Substring(start_pos, end_pos - start_pos + 1);
                string[] rows = SubBuf.Split('\n');
                int row_count = rows.Length;
                int column_count = 0;
                DistributionPare[][] res = new DistributionPare[row_count / 2][];
                int k = 0;
                for (int i = 0; i < row_count - 1; i += 2)
                {
                    column_count = rows[i].Split(' ').Length;
                    string[] values = rows[i].Split(' ');
                    res[k] = new DistributionPare[column_count];
                    string[] probabilities = rows[i + 1].Split(' ');
                    for (int j = 0; j < column_count; j++)
                    {
                        res[k][j] = new DistributionPare(int.Parse(values[j], ni), float.Parse(probabilities[j], ni));
                    }
                    k++;
                }
                return res;
            }
            else return null;
        }
        public float GetNumberValue(string numbervalue_id)//считывает единственное число(для General Per)
        {
            int start_pos = Buf.IndexOf("[" + numbervalue_id + "]") + numbervalue_id.Length + 3;
            int end_pos = Buf.IndexOf("[", Buf.IndexOf("[" + numbervalue_id + "]") + 1) - 2;
            if (end_pos - start_pos + 1 > 0)
            {
                string SubBuf = Buf.Substring(start_pos, end_pos - start_pos + 1);
                string[] rows = SubBuf.Split('\n');
                return float.Parse(rows[0], ni);
            }
            else return -1;
        }

        public double[] GetNumberVector(string numbervector_id)// считывает одномерный вектор, записанный в столбик(для Per)
        {
            int start_pos = Buf.IndexOf("[" + numbervector_id + "]") + numbervector_id.Length + 3;
            int end_pos = Buf.IndexOf("[", Buf.IndexOf("[" + numbervector_id + "]") + 1) - 2;
            if (end_pos - start_pos + 1 > 0)
            {
                string SubBuf = Buf.Substring(start_pos, end_pos - start_pos + 1);
                string[] rows = SubBuf.Split('\n');
                int row_count = rows.Length;
                double[] res = new double[row_count];
                for (int i = 0; i < row_count; i++)
                    res[i] = double.Parse(rows[i], ni);
                return res;
            }
            else return null;
        }

        public int[] GetOutputSequence(int length)// считывает выходную последовательность, дописывает 0 вначало
        {
            string[] rows = Buf.Split(' ');
            int [] res = new int [length+1];
            for (int i = 0; i <length; i++)
                res[i+1] = int.Parse(rows[i], ni);
            return res;
        }

        public int[] GetOutputSequenceFromZero(int length)// считывает выходную последовательность
        {
            string[] rows = Buf.Split(' ');
            int[] res = new int[length];
            for (int i = 0; i < length; i++)
                res[i] = int.Parse(rows[i], ni);
            return res;
        }

        public InStreamer(string filename)
        {
            f = File.OpenText(filename);
            Buf = f.ReadToEnd();
            BufferPreparer();
            f.Close();
        }
        public InStreamer(string filename, int length)//конструктор для считывания выходной последовательности
        {
            f = File.OpenText(filename);
            char[] buffer = new char[length * 2 ];
            f.ReadBlock(buffer, 0, length * 2 - 1);
            for (int i = 0; i < length * 2; i++)
                Buf += buffer[i];
            f.Close();
        }

        ~InStreamer()
        {
            
        }
    }
    public enum FileOpenMode 
    {
        AppendMode,
        RewriteMode
    }
    public class OutStreamer
    {
        private StreamWriter sw;
        public OutStreamer(string filename)
        {
            sw = File.AppendText(filename);
        }
        public OutStreamer(string filename, FileOpenMode openMode)
        {
            if (openMode == FileOpenMode.RewriteMode)
            File.Delete(filename);
            sw = File.AppendText(filename);
        }
        public void SymbolToFile(int s)
        {
            using (sw)
            {
                sw.Write(s.ToString());
                sw.Write(" ");
            }
        }
        public void StringToFile(string s)
        {
            using (sw)
            {
                sw.Write(s.ToString());
                sw.Write(" ");
            }
        }

        public void HMMPQN_ModelToFile(HMMQPN_Model.HMM_QPN model)
        {
            using (sw)
            {
                sw.Write(model.ToString());
            }
        }

        ~OutStreamer()
        {
            using (sw)
            {
                sw.Close();
            }

        }
    }
}
