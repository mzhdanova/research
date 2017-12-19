using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Input_lib;
using HMMQPN_Model;
using System.IO;
using HSMPQApplication.InverseProblem;
using HSMPQApplication.ExperimentManager;
using HSMPQApplication.Model;

namespace HMMQPN_Visual
{
    public partial class MainForm : Form
    {
        private string filestr = "";
        public MainForm()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            SaveBtn.Enabled = false;
            GenerateBtn.Enabled = false;

        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                //здесь должен быть блок вывода на экран данных из файла
                //1. вызов функции выбора данных их файла
                //2. заполнение окошек.
                //HMM_QPN OpenModel = new HMM_QPN(openFileDialog1.FileName);
                //int n =OpenModel.A.GetLength(0);
                //TextBox[,] tbMatrA = new TextBox[n,n];
                //int LeftPos = 0;
                //int TopVal = 0;
                //int HeightVal = 10;
                //int WidthVal = 20;
                //int Interval = 5;
                //for (int i=0;i<n;i++)
                //    for (int j = 0; j < n; j++)
                //    {
                //        tbMatrA[i,j]=new TextBox();
                //        tbMatrA[i, j].Text = OpenModel.A[i, j].ToString();
                //        tbMatrA[i, j].Left = LeftPos + WidthVal + Interval;
                //        tbMatrA[i, j].Width = WidthVal;
                //        tbMatrA[i, j].Top = HeightVal + TopVal + Interval;
                //        LeftPos = tbMatrA[i, j].Left;

                //    }




            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader f = File.OpenText(openFileDialog1.FileName);
                string Buf = f.ReadToEnd();
                textBox1.Text = Buf;
                textBox1.Enabled = true;
                SaveBtn.Enabled = true;
                GenerateBtn.Enabled = true;
                filestr = openFileDialog1.FileName;
                lbFileNameValue.Text = filestr;
                f.Close();
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (filestr != "")
            {
                StreamWriter sw = new StreamWriter(File.Create(filestr));
                sw.Write(textBox1.Text);
                sw.Close();
            }
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(File.Create(saveFileDialog1.FileName));
                    sw.Write(textBox1.Text);
                    sw.Close();
                    GenerateBtn.Enabled = true;
                    filestr = saveFileDialog1.FileName;
                    lbFileNameValue.Text = filestr;
                }
            }
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader f = File.OpenText("template.txt");
                string Buf = f.ReadToEnd();
                textBox1.Text = Buf;
                textBox1.Enabled = true;
                SaveBtn.Enabled = true;

                filestr = "";
                lbFileNameValue.Text = filestr;
                f.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Не найден файл шаблона");
            }

        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            HMM_QPN Model = new HMM_QPN(filestr);
            int seq_length;
            if (int.TryParse(textBox3.Text, out seq_length))
            {
                if (Model.IsCorrect() == 1)
                {
                    panel1.Enabled = false;
                    textBox1.Enabled = false;
                    DateTime startTime = DateTime.Now;
                    DateTime endTime;
                    Model.StartGenerator(seq_length, HSMPQApplication.Mode.Release, HSMPQApplication.PRNGMode.Random);
                    endTime = DateTime.Now;
                    TimeSpan employedTime = endTime - startTime;
                    lbEmployedTime.Text = "Время, затраченное на генерацию " + employedTime.ToString();
                    panel1.Enabled = true;
                    textBox1.Enabled = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        StreamReader f = File.OpenText("res.txt");
                        string Buf = f.ReadToEnd();
                        StreamWriter sw = new StreamWriter(File.Create(saveFileDialog1.FileName));
                        sw.Write(Buf);
                        sw.Close();
                        f.Close();

                    }
                }
                else if (Model.IsCorrect() == 3)
                {
                    MessageBox.Show("Для параметров не выполняются необходимые условия стохастичности");
                }
                else if (Model.IsCorrect() == 4)
                {
                    MessageBox.Show("Для параметров не выполняются необходимые условия адаптированности");
                }
                else if (Model.IsCorrect() == 0)
                {
                    MessageBox.Show("Размерности вводимых параметров не соответствуют");
                }
                else if (Model.IsCorrect() == 2)
                {
                    MessageBox.Show("Не все параметры заданы");
                }
            }
            else MessageBox.Show("Введите длину последовательости ошибок");
        }

        private void ChooseModelBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                label1.Text = openFileDialog2.FileName;
                if (label2.Text != "")
                {
                    CountProbBtn.Enabled = true;
                    label4.Visible = true;
                    textBox2.Visible = true;
                }
            }
        }

        private void ChooseSeqBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                label2.Text = openFileDialog2.FileName;
                if (label1.Text != "")
                {
                    CountProbBtn.Enabled = true;
                    label4.Visible = true;
                    textBox2.Visible = true;
                }
            }
        }

        private void CountProbBtn_Click(object sender, EventArgs e)
        {
            HMM_QPN Model = new HMM_QPN(label1.Text);
            if (Model.IsCorrect() == 1)
            {
                int smbnubmer = 10;
                if (textBox2.Text != "")
                {
                    try
                    {
                        smbnubmer = int.Parse(textBox2.Text);
                    }
                    catch (Exception)
                    {
                    }
                };
                int[] res = new int[smbnubmer+1];
                try
                {
                    res = HMM_PSM.GetOutputSequence(label2.Text, smbnubmer);
                }
                catch (Exception)
                {
                    MessageBox.Show("Желаемая длина последовательности превышает размер файла");
                    return;
                }
                panel3.Enabled = false;

                if (radioButton1.Checked)
                {
                    //try
                    //{
                    Likelihood lk = new Likelihood(res, Model);
                    //label3.Text = lk.Probability(res.Length - 1).ToString();
                    label3.Text = lk.FullProbability(res.Length - 1).ToString();

                    //}
                    //catch (Exception)
                    //    { MessageBox.Show("В процессе расчета возникла ошибка!"); };
                    panel3.Enabled = true;
                }
                else 
                {
                    if (radioButton2.Checked)
                    {
                        LikelihoodSimple lk = new LikelihoodSimple(res, Model);
                        //label3.Text = lk.Probability(res.Length - 1).ToString();
                        label3.Text = lk.Probability(res.Length - 1).ToString();
                        panel3.Enabled = true;
                    }
                    else
                    {
                        if (tbSegmentNumber.Text != "")
                        {
                            int segment_size = 0;
                            if (Int32.TryParse(tbSegmentNumber.Text,out segment_size))
                            {
                                LikelihoodSplit ls = new LikelihoodSplit(segment_size);
                                double [] result = ls.calculateSplitedLikelihood(Model, res);
                                double total = 0;
                                tbSplitResultDetails.Text = "";
                                for (int i=0; i<result.Length;i++)
                                {
                                    tbSplitResultDetails.Text += "P[O(" + i * segment_size + "," + ((i+1) * segment_size) + ")] = " + result[i] + "\r\n"; 
                                    total+=result[i]; 
                                }
                                label3.Text = (total/result.Length).ToString();
                                panel3.Enabled = true;
                            }
                            else MessageBox.Show("Размер сегмента разбиения должен быть целым");
                        }
                        else MessageBox.Show("Задайте размер сегмента разбиения");
                    }
                }
            }
            else MessageBox.Show("Модель задана некорректно");

        }

        private void btAnChose_Click(object sender, EventArgs e)
        {
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                label6.Text = openFileDialog3.FileName;
                btCountAverage.Enabled = true;
            }
        }

        private void btCountAverage_Click(object sender, EventArgs e)
        {
            lbAnResult.Visible = true;
            int smbnubmer = 10;
            if (textBox4.Text != "")
            {
                try
                {
                    smbnubmer = int.Parse(textBox4.Text);
                }
                catch (Exception)
                {
                }
            }
            int[] res = new int[smbnubmer];
            try
            {
                res = HMM_PSM.GetOutputSequenceFromZero(label6.Text, smbnubmer);
                lbAnResult.Text = HMM_PSM.AverageErrorProbability(res).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Желаемая длина последовательности превышает размер файла");
                return;
            }
        }

        private void btSaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(File.Create(saveFileDialog1.FileName));
                sw.Write(textBox1.Text);
                sw.Close();
                GenerateBtn.Enabled = true;
                filestr = saveFileDialog1.FileName;
                lbFileNameValue.Text = filestr;
            }

        }

        private void btChooseModelsFolder_Click(object sender, EventArgs e)
        {
            if (folderDialogModels.ShowDialog() == DialogResult.OK)
            {
                lbModelsFolderPath.Text = folderDialogModels.SelectedPath;
            }
        }

        private void btChooseSequencesFolder_Click(object sender, EventArgs e)
        {
            if (folderDialogSequences.ShowDialog() == DialogResult.OK)
            {
                lbSequencesFolderPath.Text = folderDialogSequences.SelectedPath;
            }
        }

        private void btStartExperiment_Click(object sender, EventArgs e)
        {
            if (lbSequencesFolderPath.Text != "" && lbModelsFolderPath.Text != "" && tbExperimentSegmentsLength.Text != "" && tbExperimentSequencesLength.Text != "")
            {
                int segmentSize = Int32.Parse(tbExperimentSegmentsLength.Text);//добавить проверку
                int sequenceLength = Int32.Parse(tbExperimentSequencesLength.Text);//добавить проверку
                if (segmentSize <= sequenceLength)
                {
                    CrossModelComputationPreparator preparator = new CrossModelComputationPreparator(lbModelsFolderPath.Text, lbSequencesFolderPath.Text);
                    List<ModelObject> modelsList = preparator.getModelsList();
                    List<SequenceObject> sequencesList = preparator.getSequencesList(sequenceLength);
                    CrossModelComputation computor = new CrossModelComputation(modelsList, sequencesList, segmentSize);
                    List<CrossModelComputationResultItem> probabilities = computor.compute();
                    string[,] matr = CrossModelComputation.computationResultsAsMatrix(probabilities);
                    string s = "";
                    for (int i = 0; i < matr.GetLength(0); i++)
                    {
                        for (int j = 0; j < matr.GetLength(1); j++)
                        {
                            s += matr[i, j] + ",";
                        }
                        s += "\r\n";
                    }
                    List<CrossModelComputationResultItem> mmis = computor.computeMaximumMutialInformationDistances(probabilities);
                    string[,] matr2 = CrossModelComputation.computationResultsAsMatrix(mmis);
                    string s2 = "\r\n";
                    for (int i = 0; i < matr2.GetLength(0); i++)
                    {
                        for (int j = 0; j < matr2.GetLength(1); j++)
                        {
                            s2 += matr2[i, j] + ",";
                        }
                        s2 += "\r\n";
                    }
                    OutStreamer os = new OutStreamer("sas.txt", FileOpenMode.RewriteMode);
                    os.StringToFile(s+s2);
                    if (saveFileDialogExperiment.ShowDialog() == DialogResult.OK)
                    {
                        StreamReader f = File.OpenText("sas.txt");
                        string Buf = f.ReadToEnd();
                        StreamWriter sw = new StreamWriter(File.Create(saveFileDialogExperiment.FileName));
                        sw.Write(Buf);
                        sw.Close();
                        f.Close();
                    }
                }
                else MessageBox.Show("Размер сегмента разбиения не должен превышать длину последовательности");
            }
            else MessageBox.Show("Не все параметры заданы");
        }

        private void btOMCSelectModel_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                lbOMCModelPath.Text = openFileDialog2.FileName;
            }
        }

        private void btOMCSelectSequence_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                lbOMCSequencePath.Text = openFileDialog2.FileName;
            }
        }

        private void btOMCCalculateProbability_Click(object sender, EventArgs e)
        {
            if (lbOMCModelPath.Text != "" && lbOMCSequencePath.Text != "" && tbOMCSegmentLength.Text != ""&&tbOMCSequenceLength.Text!="")
            {
                int segmentSize = Int32.Parse(tbOMCSegmentLength.Text);//добавить проверку
                int sequenceLength = Int32.Parse(tbOMCSequenceLength.Text);//добавить проверку
            HMM_QPN Model = new HMM_QPN(lbOMCModelPath.Text);
            if (Model.IsCorrect() == 1)
            {
                                int[] res = new int[sequenceLength+1];
                try
                {
                    res = HMM_PSM.GetOutputSequence(lbOMCSequencePath.Text, sequenceLength);
                }
                catch (Exception)
                {
                    MessageBox.Show("Желаемая длина последовательности превышает размер файла");
                    return;
                }
                    ModelObject model = new ModelObject(lbOMCModelPath.Text, Model);
                    SequenceObject sequence = new SequenceObject(lbOMCSequencePath.Text, res);
                    OneModelComputation computor = new OneModelComputation(model, sequence, segmentSize, sequenceLength);
                    List<double> probabilities = computor.compute();

                    string s = "Model: " + model.ModelName + "\r\n Sequence: " + sequence.SequenceName + "\r\n Sequence length: " + sequenceLength + "\r\n Segment size: " + segmentSize + "\r\n";
                    for (int i = 0; i < probabilities.Count(); i++)
                    {
                        s += probabilities.ElementAt(i)+",";
                    }
                     OutStreamer os = new OutStreamer("omc.txt",FileOpenMode.RewriteMode);
                
                    os.StringToFile(s);
                    if (saveFileDialogExperiment.ShowDialog() == DialogResult.OK)
                    {
                        StreamReader f = File.OpenText("omc.txt");
                        string Buf = f.ReadToEnd();
                        StreamWriter sw = new StreamWriter(File.Create(saveFileDialogExperiment.FileName));
                        sw.Write(Buf);
                        sw.Close();
                        f.Close();
                    }
                }
                else MessageBox.Show("Модель некорректна");
            }
            else MessageBox.Show("Не все параметры заданы");

        }

        private void btChooseModelFerguson_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                lbModelFerguson.Text = openFileDialog2.FileName;
            }
        }

        private void btChooseSequenceFerguson_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                lbSequenceFerguson.Text = openFileDialog2.FileName;
            }
        }

        private void btGenerateFerguson_Click(object sender, EventArgs e)
        {
            FergusonModel Model = new FergusonModel(lbModelFerguson.Text);
            int seq_length;
            if (int.TryParse(tbGeneratedSequenceLengthFerguson.Text, out seq_length))
            {
                if (Model.IsCorrect() == 1)
                {
                    DateTime startTime = DateTime.Now;
                    DateTime endTime;
                    Model.StartGenerator(seq_length, HSMPQApplication.Mode.Release, HSMPQApplication.PRNGMode.Random);
                    endTime = DateTime.Now;
                    TimeSpan employedTime = endTime - startTime;
                   // lbEmployedTime.Text = "Время, затраченное на генерацию " + employedTime.ToString();
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        StreamReader f = File.OpenText("res.txt");
                        string Buf = f.ReadToEnd();
                        StreamWriter sw = new StreamWriter(File.Create(saveFileDialog1.FileName));
                        sw.Write(Buf);
                        sw.Close();
                        f.Close();

                    }
                }
                else if (Model.IsCorrect() == 0)
                {
                    MessageBox.Show("Размерности вводимых параметров не соответствуют");
                }
            }
            else MessageBox.Show("Введите длину последовательости ошибок");
        }

        private void btCalculateFerguson_Click(object sender, EventArgs e)
        {
            FergusonModel Model = new FergusonModel(lbModelFerguson.Text);
            if (Model.IsCorrect() == 1)
            {
                int smbnubmer = 10;
                if (tbSequenceLengthFerguson.Text != "")
                {
                    try
                    {
                        smbnubmer = int.Parse(tbSequenceLengthFerguson.Text);
                    }
                    catch (Exception)
                    {
                    }
                };
                int[] res = new int[smbnubmer + 1];
                try
                {
                    res = HMM_PSM.GetOutputSequence(lbSequenceFerguson.Text, smbnubmer);
                }
                catch (Exception)
                {
                    MessageBox.Show("Желаемая длина последовательности превышает размер файла");
                    return;
                }
                panel3.Enabled = false;

                    LikelihoodFerguson lk = new LikelihoodFerguson(res, Model);
                    tbProbabilityFerguson.Text = lk.FullProbability(res.Length - 1).ToString();
                   // tbProbabilityFerguson.Text = lk.Probability(res.Length - 1).ToString();
                string s="";
                    for (int i = 0; i < lk.alpha.GetLength(0);i++ )
                        for (int j = 0; j < lk.alpha.GetLength(1); j++)
                            for (int k = 0; k < lk.alpha.GetLength(2); k++)
                    {
                                s+="alpha("+i+", "+j+", "+k+")="+lk.alpha[i,j,k].ToString()+"\r\n";
                            }
                    tbAlphaFerg.Text = s;

            }
            else MessageBox.Show("Модель задана некорректно");
        }











    }
}
