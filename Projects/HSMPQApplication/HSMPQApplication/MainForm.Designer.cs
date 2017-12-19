namespace HMMQPN_Visual
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.модельИсточникаОшибокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.методПодбораМоделиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.tpAnalise = new System.Windows.Forms.TabPage();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbAnResult = new System.Windows.Forms.Label();
            this.btCountAverage = new System.Windows.Forms.Button();
            this.btAnChose = new System.Windows.Forms.Button();
            this.tpMethod = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSegmentNumber = new System.Windows.Forms.TextBox();
            this.tbSplitResultDetails = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ChooseModelBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ChooseSeqBtn = new System.Windows.Forms.Button();
            this.CountProbBtn = new System.Windows.Forms.Button();
            this.tpHMM = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbFileNameValue = new System.Windows.Forms.Label();
            this.lbFileName = new System.Windows.Forms.Label();
            this.btSaveAs = new System.Windows.Forms.Button();
            this.lbEmployedTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.CreateBtn = new System.Windows.Forms.Button();
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.OpenBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tpExperiment = new System.Windows.Forms.TabPage();
            this.tbExperimentSegmentsLength = new System.Windows.Forms.TextBox();
            this.tbExperimentSequencesLength = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btStartExperiment = new System.Windows.Forms.Button();
            this.btChooseSequencesFolder = new System.Windows.Forms.Button();
            this.btChooseModelsFolder = new System.Windows.Forms.Button();
            this.lbSequencesFolderPath = new System.Windows.Forms.Label();
            this.lbModelsFolderPath = new System.Windows.Forms.Label();
            this.tpOneModelComputation = new System.Windows.Forms.TabPage();
            this.lbOMCSequenceLength = new System.Windows.Forms.Label();
            this.tbOMCSequenceLength = new System.Windows.Forms.TextBox();
            this.btOMCCalculateProbability = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.tbOMCSegmentLength = new System.Windows.Forms.TextBox();
            this.lbOMCSequencePath = new System.Windows.Forms.Label();
            this.lbOMCModelPath = new System.Windows.Forms.Label();
            this.btOMCSelectModel = new System.Windows.Forms.Button();
            this.btOMCSelectSequence = new System.Windows.Forms.Button();
            this.folderDialogModels = new System.Windows.Forms.FolderBrowserDialog();
            this.folderDialogSequences = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialogExperiment = new System.Windows.Forms.SaveFileDialog();
            this.tpFerguson = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.tbSequenceLengthFerguson = new System.Windows.Forms.TextBox();
            this.btChooseModelFerguson = new System.Windows.Forms.Button();
            this.btChooseSequenceFerguson = new System.Windows.Forms.Button();
            this.btGenerateFerguson = new System.Windows.Forms.Button();
            this.btCalculateFerguson = new System.Windows.Forms.Button();
            this.lbModelFerguson = new System.Windows.Forms.Label();
            this.lbSequenceFerguson = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbGeneratedSequenceLengthFerguson = new System.Windows.Forms.TextBox();
            this.tbProbabilityFerguson = new System.Windows.Forms.TextBox();
            this.tbAlphaFerg = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.tpAnalise.SuspendLayout();
            this.tpMethod.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpHMM.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tpExperiment.SuspendLayout();
            this.tpOneModelComputation.SuspendLayout();
            this.tpFerguson.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.toolStripMenuItem1,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(65, 31);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(170, 30);
            this.создатьToolStripMenuItem.Text = "Создать";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(170, 30);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(170, 30);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(167, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(170, 30);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // модельИсточникаОшибокToolStripMenuItem
            // 
            this.модельИсточникаОшибокToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.запускToolStripMenuItem,
            this.параметрыToolStripMenuItem});
            this.модельИсточникаОшибокToolStripMenuItem.Name = "модельИсточникаОшибокToolStripMenuItem";
            this.модельИсточникаОшибокToolStripMenuItem.Size = new System.Drawing.Size(247, 31);
            this.модельИсточникаОшибокToolStripMenuItem.Text = "Модель источника ошибок";
            // 
            // запускToolStripMenuItem
            // 
            this.запускToolStripMenuItem.Name = "запускToolStripMenuItem";
            this.запускToolStripMenuItem.Size = new System.Drawing.Size(179, 30);
            this.запускToolStripMenuItem.Text = "Запуск";
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(179, 30);
            this.параметрыToolStripMenuItem.Text = "Параметры";
            // 
            // методПодбораМоделиToolStripMenuItem
            // 
            this.методПодбораМоделиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.запускToolStripMenuItem1});
            this.методПодбораМоделиToolStripMenuItem.Name = "методПодбораМоделиToolStripMenuItem";
            this.методПодбораМоделиToolStripMenuItem.Size = new System.Drawing.Size(221, 31);
            this.методПодбораМоделиToolStripMenuItem.Text = "Метод подбора модели";
            // 
            // запускToolStripMenuItem1
            // 
            this.запускToolStripMenuItem1.Name = "запускToolStripMenuItem1";
            this.запускToolStripMenuItem1.Size = new System.Drawing.Size(139, 30);
            this.запускToolStripMenuItem1.Text = "Запуск";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(93, 31);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.модельИсточникаОшибокToolStripMenuItem,
            this.методПодбораМоделиToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1184, 37);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            // 
            // tpAnalise
            // 
            this.tpAnalise.Controls.Add(this.textBox4);
            this.tpAnalise.Controls.Add(this.label7);
            this.tpAnalise.Controls.Add(this.label6);
            this.tpAnalise.Controls.Add(this.lbAnResult);
            this.tpAnalise.Controls.Add(this.btCountAverage);
            this.tpAnalise.Controls.Add(this.btAnChose);
            this.tpAnalise.Location = new System.Drawing.Point(4, 29);
            this.tpAnalise.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpAnalise.Name = "tpAnalise";
            this.tpAnalise.Size = new System.Drawing.Size(1362, 933);
            this.tpAnalise.TabIndex = 2;
            this.tpAnalise.Text = "Средства анализа последовательности";
            this.tpAnalise.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(405, 192);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(112, 26);
            this.textBox4.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 192);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(234, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Длина последовательности: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(538, 72);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 20);
            this.label6.TabIndex = 8;
            // 
            // lbAnResult
            // 
            this.lbAnResult.AutoSize = true;
            this.lbAnResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAnResult.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbAnResult.Location = new System.Drawing.Point(573, 255);
            this.lbAnResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAnResult.Name = "lbAnResult";
            this.lbAnResult.Size = new System.Drawing.Size(0, 37);
            this.lbAnResult.TabIndex = 7;
            this.lbAnResult.Visible = false;
            // 
            // btCountAverage
            // 
            this.btCountAverage.Enabled = false;
            this.btCountAverage.Location = new System.Drawing.Point(405, 335);
            this.btCountAverage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCountAverage.Name = "btCountAverage";
            this.btCountAverage.Size = new System.Drawing.Size(363, 35);
            this.btCountAverage.TabIndex = 6;
            this.btCountAverage.Text = "Рассчитать среднюю вероятность ошибки";
            this.btCountAverage.UseVisualStyleBackColor = true;
            this.btCountAverage.Click += new System.EventHandler(this.btCountAverage_Click);
            // 
            // btAnChose
            // 
            this.btAnChose.Location = new System.Drawing.Point(78, 57);
            this.btAnChose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btAnChose.Name = "btAnChose";
            this.btAnChose.Size = new System.Drawing.Size(266, 35);
            this.btAnChose.TabIndex = 3;
            this.btAnChose.Text = "Выбрать последовательность";
            this.btAnChose.UseVisualStyleBackColor = true;
            this.btAnChose.Click += new System.EventHandler(this.btAnChose_Click);
            // 
            // tpMethod
            // 
            this.tpMethod.Controls.Add(this.panel3);
            this.tpMethod.Location = new System.Drawing.Point(4, 29);
            this.tpMethod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpMethod.Name = "tpMethod";
            this.tpMethod.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpMethod.Size = new System.Drawing.Size(1362, 933);
            this.tpMethod.TabIndex = 1;
            this.tpMethod.Text = "Метод подбора СМ QP-модели";
            this.tpMethod.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.tbSegmentNumber);
            this.panel3.Controls.Add(this.tbSplitResultDetails);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.ChooseModelBtn);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.ChooseSeqBtn);
            this.panel3.Controls.Add(this.CountProbBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 5);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1354, 923);
            this.panel3.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(78, 638);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Размер сегмента";
            // 
            // tbSegmentNumber
            // 
            this.tbSegmentNumber.Location = new System.Drawing.Point(272, 638);
            this.tbSegmentNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSegmentNumber.Name = "tbSegmentNumber";
            this.tbSegmentNumber.Size = new System.Drawing.Size(148, 26);
            this.tbSegmentNumber.TabIndex = 10;
            // 
            // tbSplitResultDetails
            // 
            this.tbSplitResultDetails.Location = new System.Drawing.Point(606, 602);
            this.tbSplitResultDetails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSplitResultDetails.Multiline = true;
            this.tbSplitResultDetails.Name = "tbSplitResultDetails";
            this.tbSplitResultDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSplitResultDetails.Size = new System.Drawing.Size(667, 266);
            this.tbSplitResultDetails.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(74, 405);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(342, 143);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите способ вычисления";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(10, 105);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(300, 24);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Полный с разбиением на сегменты";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(10, 68);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(131, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Упрощенный";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(10, 31);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(94, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Полный";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 354);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(313, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Число элементов последовательности";
            this.label4.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(564, 349);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(259, 26);
            this.textBox2.TabIndex = 6;
            this.textBox2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(504, 251);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 120);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 3;
            // 
            // ChooseModelBtn
            // 
            this.ChooseModelBtn.Location = new System.Drawing.Point(74, 112);
            this.ChooseModelBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChooseModelBtn.Name = "ChooseModelBtn";
            this.ChooseModelBtn.Size = new System.Drawing.Size(286, 35);
            this.ChooseModelBtn.TabIndex = 0;
            this.ChooseModelBtn.Text = "Выбрать модель";
            this.ChooseModelBtn.UseVisualStyleBackColor = true;
            this.ChooseModelBtn.Click += new System.EventHandler(this.ChooseModelBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(504, 448);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 29);
            this.label3.TabIndex = 5;
            // 
            // ChooseSeqBtn
            // 
            this.ChooseSeqBtn.Location = new System.Drawing.Point(74, 243);
            this.ChooseSeqBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChooseSeqBtn.Name = "ChooseSeqBtn";
            this.ChooseSeqBtn.Size = new System.Drawing.Size(286, 35);
            this.ChooseSeqBtn.TabIndex = 1;
            this.ChooseSeqBtn.Text = "Выбрать последовательность";
            this.ChooseSeqBtn.UseVisualStyleBackColor = true;
            this.ChooseSeqBtn.Click += new System.EventHandler(this.ChooseSeqBtn_Click);
            // 
            // CountProbBtn
            // 
            this.CountProbBtn.Location = new System.Drawing.Point(272, 557);
            this.CountProbBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CountProbBtn.Name = "CountProbBtn";
            this.CountProbBtn.Size = new System.Drawing.Size(554, 35);
            this.CountProbBtn.TabIndex = 2;
            this.CountProbBtn.Text = "Рассчитать вероятность";
            this.CountProbBtn.UseVisualStyleBackColor = true;
            this.CountProbBtn.Click += new System.EventHandler(this.CountProbBtn_Click);
            // 
            // tpHMM
            // 
            this.tpHMM.Controls.Add(this.panel2);
            this.tpHMM.Controls.Add(this.panel1);
            this.tpHMM.Location = new System.Drawing.Point(4, 29);
            this.tpHMM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpHMM.Name = "tpHMM";
            this.tpHMM.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpHMM.Size = new System.Drawing.Size(1362, 933);
            this.tpHMM.TabIndex = 0;
            this.tpHMM.Text = "Скрытая марковская QP-модель";
            this.tpHMM.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1354, 777);
            this.panel2.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1354, 777);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1354, 777);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbFileNameValue);
            this.panel1.Controls.Add(this.lbFileName);
            this.panel1.Controls.Add(this.btSaveAs);
            this.panel1.Controls.Add(this.lbEmployedTime);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.CreateBtn);
            this.panel1.Controls.Add(this.GenerateBtn);
            this.panel1.Controls.Add(this.OpenBtn);
            this.panel1.Controls.Add(this.SaveBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(4, 782);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1354, 146);
            this.panel1.TabIndex = 5;
            // 
            // lbFileNameValue
            // 
            this.lbFileNameValue.AutoSize = true;
            this.lbFileNameValue.Location = new System.Drawing.Point(118, 9);
            this.lbFileNameValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFileNameValue.Name = "lbFileNameValue";
            this.lbFileNameValue.Size = new System.Drawing.Size(0, 20);
            this.lbFileNameValue.TabIndex = 10;
            // 
            // lbFileName
            // 
            this.lbFileName.AutoSize = true;
            this.lbFileName.Location = new System.Drawing.Point(9, 9);
            this.lbFileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(100, 20);
            this.lbFileName.TabIndex = 9;
            this.lbFileName.Text = "Имя файла:";
            // 
            // btSaveAs
            // 
            this.btSaveAs.Location = new System.Drawing.Point(376, 103);
            this.btSaveAs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSaveAs.Name = "btSaveAs";
            this.btSaveAs.Size = new System.Drawing.Size(144, 35);
            this.btSaveAs.TabIndex = 8;
            this.btSaveAs.Text = "Сохранить как";
            this.btSaveAs.UseVisualStyleBackColor = true;
            this.btSaveAs.Click += new System.EventHandler(this.btSaveAs_Click);
            // 
            // lbEmployedTime
            // 
            this.lbEmployedTime.AutoSize = true;
            this.lbEmployedTime.Location = new System.Drawing.Point(46, 68);
            this.lbEmployedTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEmployedTime.Name = "lbEmployedTime";
            this.lbEmployedTime.Size = new System.Drawing.Size(0, 20);
            this.lbEmployedTime.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(688, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(234, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Длина последовательности: ";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(986, 9);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(112, 26);
            this.textBox3.TabIndex = 5;
            // 
            // CreateBtn
            // 
            this.CreateBtn.Location = new System.Drawing.Point(10, 105);
            this.CreateBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(112, 35);
            this.CreateBtn.TabIndex = 1;
            this.CreateBtn.Text = "Создать";
            this.CreateBtn.UseVisualStyleBackColor = true;
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.Location = new System.Drawing.Point(668, 105);
            this.GenerateBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(429, 35);
            this.GenerateBtn.TabIndex = 4;
            this.GenerateBtn.Text = "Сгенерировать последовательность ошибок";
            this.GenerateBtn.UseVisualStyleBackColor = true;
            this.GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // OpenBtn
            // 
            this.OpenBtn.Location = new System.Drawing.Point(132, 105);
            this.OpenBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(112, 35);
            this.OpenBtn.TabIndex = 2;
            this.OpenBtn.Text = "Открыть";
            this.OpenBtn.UseVisualStyleBackColor = true;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(254, 105);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(112, 35);
            this.SaveBtn.TabIndex = 3;
            this.SaveBtn.Text = "Сохранить";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tpHMM);
            this.tabMain.Controls.Add(this.tpMethod);
            this.tabMain.Controls.Add(this.tpAnalise);
            this.tabMain.Controls.Add(this.tpExperiment);
            this.tabMain.Controls.Add(this.tpOneModelComputation);
            this.tabMain.Controls.Add(this.tpFerguson);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1370, 966);
            this.tabMain.TabIndex = 1;
            // 
            // tpExperiment
            // 
            this.tpExperiment.Controls.Add(this.tbExperimentSegmentsLength);
            this.tpExperiment.Controls.Add(this.tbExperimentSequencesLength);
            this.tpExperiment.Controls.Add(this.label10);
            this.tpExperiment.Controls.Add(this.label9);
            this.tpExperiment.Controls.Add(this.btStartExperiment);
            this.tpExperiment.Controls.Add(this.btChooseSequencesFolder);
            this.tpExperiment.Controls.Add(this.btChooseModelsFolder);
            this.tpExperiment.Controls.Add(this.lbSequencesFolderPath);
            this.tpExperiment.Controls.Add(this.lbModelsFolderPath);
            this.tpExperiment.Location = new System.Drawing.Point(4, 29);
            this.tpExperiment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpExperiment.Name = "tpExperiment";
            this.tpExperiment.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpExperiment.Size = new System.Drawing.Size(1362, 933);
            this.tpExperiment.TabIndex = 3;
            this.tpExperiment.Text = "Серии экспериментов";
            this.tpExperiment.UseVisualStyleBackColor = true;
            // 
            // tbExperimentSegmentsLength
            // 
            this.tbExperimentSegmentsLength.Location = new System.Drawing.Point(622, 311);
            this.tbExperimentSegmentsLength.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbExperimentSegmentsLength.Name = "tbExperimentSegmentsLength";
            this.tbExperimentSegmentsLength.Size = new System.Drawing.Size(148, 26);
            this.tbExperimentSegmentsLength.TabIndex = 8;
            // 
            // tbExperimentSequencesLength
            // 
            this.tbExperimentSequencesLength.Location = new System.Drawing.Point(622, 263);
            this.tbExperimentSequencesLength.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbExperimentSequencesLength.Name = "tbExperimentSequencesLength";
            this.tbExperimentSequencesLength.Size = new System.Drawing.Size(148, 26);
            this.tbExperimentSequencesLength.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(90, 315);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(217, 20);
            this.label10.TabIndex = 6;
            this.label10.Text = "Длина сегмента разбиения";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(90, 268);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(356, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "Длина анализируемых последовательностей";
            // 
            // btStartExperiment
            // 
            this.btStartExperiment.Location = new System.Drawing.Point(336, 386);
            this.btStartExperiment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btStartExperiment.Name = "btStartExperiment";
            this.btStartExperiment.Size = new System.Drawing.Size(414, 35);
            this.btStartExperiment.TabIndex = 4;
            this.btStartExperiment.Text = "Старт экперимента";
            this.btStartExperiment.UseVisualStyleBackColor = true;
            this.btStartExperiment.Click += new System.EventHandler(this.btStartExperiment_Click);
            // 
            // btChooseSequencesFolder
            // 
            this.btChooseSequencesFolder.Location = new System.Drawing.Point(90, 192);
            this.btChooseSequencesFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btChooseSequencesFolder.Name = "btChooseSequencesFolder";
            this.btChooseSequencesFolder.Size = new System.Drawing.Size(438, 35);
            this.btChooseSequencesFolder.TabIndex = 3;
            this.btChooseSequencesFolder.Text = "Указать путь к каталогу последовательностей";
            this.btChooseSequencesFolder.UseVisualStyleBackColor = true;
            this.btChooseSequencesFolder.Click += new System.EventHandler(this.btChooseSequencesFolder_Click);
            // 
            // btChooseModelsFolder
            // 
            this.btChooseModelsFolder.Location = new System.Drawing.Point(90, 72);
            this.btChooseModelsFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btChooseModelsFolder.Name = "btChooseModelsFolder";
            this.btChooseModelsFolder.Size = new System.Drawing.Size(438, 35);
            this.btChooseModelsFolder.TabIndex = 2;
            this.btChooseModelsFolder.Text = "Указать путь к каталогу моделей";
            this.btChooseModelsFolder.UseVisualStyleBackColor = true;
            this.btChooseModelsFolder.Click += new System.EventHandler(this.btChooseModelsFolder_Click);
            // 
            // lbSequencesFolderPath
            // 
            this.lbSequencesFolderPath.AutoSize = true;
            this.lbSequencesFolderPath.Location = new System.Drawing.Point(618, 208);
            this.lbSequencesFolderPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSequencesFolderPath.Name = "lbSequencesFolderPath";
            this.lbSequencesFolderPath.Size = new System.Drawing.Size(0, 20);
            this.lbSequencesFolderPath.TabIndex = 1;
            // 
            // lbModelsFolderPath
            // 
            this.lbModelsFolderPath.AutoSize = true;
            this.lbModelsFolderPath.Location = new System.Drawing.Point(618, 88);
            this.lbModelsFolderPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbModelsFolderPath.Name = "lbModelsFolderPath";
            this.lbModelsFolderPath.Size = new System.Drawing.Size(0, 20);
            this.lbModelsFolderPath.TabIndex = 0;
            // 
            // tpOneModelComputation
            // 
            this.tpOneModelComputation.Controls.Add(this.lbOMCSequenceLength);
            this.tpOneModelComputation.Controls.Add(this.tbOMCSequenceLength);
            this.tpOneModelComputation.Controls.Add(this.btOMCCalculateProbability);
            this.tpOneModelComputation.Controls.Add(this.label13);
            this.tpOneModelComputation.Controls.Add(this.tbOMCSegmentLength);
            this.tpOneModelComputation.Controls.Add(this.lbOMCSequencePath);
            this.tpOneModelComputation.Controls.Add(this.lbOMCModelPath);
            this.tpOneModelComputation.Controls.Add(this.btOMCSelectModel);
            this.tpOneModelComputation.Controls.Add(this.btOMCSelectSequence);
            this.tpOneModelComputation.Location = new System.Drawing.Point(4, 29);
            this.tpOneModelComputation.Name = "tpOneModelComputation";
            this.tpOneModelComputation.Padding = new System.Windows.Forms.Padding(3);
            this.tpOneModelComputation.Size = new System.Drawing.Size(1362, 933);
            this.tpOneModelComputation.TabIndex = 4;
            this.tpOneModelComputation.Text = "Серия экпериментов на одной последовательности";
            this.tpOneModelComputation.UseVisualStyleBackColor = true;
            // 
            // lbOMCSequenceLength
            // 
            this.lbOMCSequenceLength.AutoSize = true;
            this.lbOMCSequenceLength.Location = new System.Drawing.Point(137, 314);
            this.lbOMCSequenceLength.Name = "lbOMCSequenceLength";
            this.lbOMCSequenceLength.Size = new System.Drawing.Size(226, 20);
            this.lbOMCSequenceLength.TabIndex = 13;
            this.lbOMCSequenceLength.Text = "Длина последовательности";
            // 
            // tbOMCSequenceLength
            // 
            this.tbOMCSequenceLength.Location = new System.Drawing.Point(571, 314);
            this.tbOMCSequenceLength.Name = "tbOMCSequenceLength";
            this.tbOMCSequenceLength.Size = new System.Drawing.Size(184, 26);
            this.tbOMCSequenceLength.TabIndex = 12;
            // 
            // btOMCCalculateProbability
            // 
            this.btOMCCalculateProbability.Location = new System.Drawing.Point(137, 432);
            this.btOMCCalculateProbability.Name = "btOMCCalculateProbability";
            this.btOMCCalculateProbability.Size = new System.Drawing.Size(400, 48);
            this.btOMCCalculateProbability.TabIndex = 11;
            this.btOMCCalculateProbability.Text = "Рассчитать вероятности";
            this.btOMCCalculateProbability.UseVisualStyleBackColor = true;
            this.btOMCCalculateProbability.Click += new System.EventHandler(this.btOMCCalculateProbability_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(137, 350);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 20);
            this.label13.TabIndex = 10;
            this.label13.Text = "Длина сегмента";
            // 
            // tbOMCSegmentLength
            // 
            this.tbOMCSegmentLength.Location = new System.Drawing.Point(571, 350);
            this.tbOMCSegmentLength.Name = "tbOMCSegmentLength";
            this.tbOMCSegmentLength.Size = new System.Drawing.Size(184, 26);
            this.tbOMCSegmentLength.TabIndex = 9;
            // 
            // lbOMCSequencePath
            // 
            this.lbOMCSequencePath.AutoSize = true;
            this.lbOMCSequencePath.Location = new System.Drawing.Point(567, 249);
            this.lbOMCSequencePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOMCSequencePath.Name = "lbOMCSequencePath";
            this.lbOMCSequencePath.Size = new System.Drawing.Size(0, 20);
            this.lbOMCSequencePath.TabIndex = 8;
            // 
            // lbOMCModelPath
            // 
            this.lbOMCModelPath.AutoSize = true;
            this.lbOMCModelPath.Location = new System.Drawing.Point(567, 118);
            this.lbOMCModelPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOMCModelPath.Name = "lbOMCModelPath";
            this.lbOMCModelPath.Size = new System.Drawing.Size(0, 20);
            this.lbOMCModelPath.TabIndex = 7;
            // 
            // btOMCSelectModel
            // 
            this.btOMCSelectModel.Location = new System.Drawing.Point(137, 110);
            this.btOMCSelectModel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btOMCSelectModel.Name = "btOMCSelectModel";
            this.btOMCSelectModel.Size = new System.Drawing.Size(286, 35);
            this.btOMCSelectModel.TabIndex = 5;
            this.btOMCSelectModel.Text = "Выбрать модель";
            this.btOMCSelectModel.UseVisualStyleBackColor = true;
            this.btOMCSelectModel.Click += new System.EventHandler(this.btOMCSelectModel_Click);
            // 
            // btOMCSelectSequence
            // 
            this.btOMCSelectSequence.Location = new System.Drawing.Point(137, 241);
            this.btOMCSelectSequence.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btOMCSelectSequence.Name = "btOMCSelectSequence";
            this.btOMCSelectSequence.Size = new System.Drawing.Size(286, 35);
            this.btOMCSelectSequence.TabIndex = 6;
            this.btOMCSelectSequence.Text = "Выбрать последовательность";
            this.btOMCSelectSequence.UseVisualStyleBackColor = true;
            this.btOMCSelectSequence.Click += new System.EventHandler(this.btOMCSelectSequence_Click);
            // 
            // tpFerguson
            // 
            this.tpFerguson.Controls.Add(this.tbAlphaFerg);
            this.tpFerguson.Controls.Add(this.tbProbabilityFerguson);
            this.tpFerguson.Controls.Add(this.label12);
            this.tpFerguson.Controls.Add(this.tbGeneratedSequenceLengthFerguson);
            this.tpFerguson.Controls.Add(this.lbSequenceFerguson);
            this.tpFerguson.Controls.Add(this.lbModelFerguson);
            this.tpFerguson.Controls.Add(this.btCalculateFerguson);
            this.tpFerguson.Controls.Add(this.btGenerateFerguson);
            this.tpFerguson.Controls.Add(this.label11);
            this.tpFerguson.Controls.Add(this.tbSequenceLengthFerguson);
            this.tpFerguson.Controls.Add(this.btChooseModelFerguson);
            this.tpFerguson.Controls.Add(this.btChooseSequenceFerguson);
            this.tpFerguson.Location = new System.Drawing.Point(4, 29);
            this.tpFerguson.Name = "tpFerguson";
            this.tpFerguson.Padding = new System.Windows.Forms.Padding(3);
            this.tpFerguson.Size = new System.Drawing.Size(1362, 933);
            this.tpFerguson.TabIndex = 5;
            this.tpFerguson.Text = "Модель Фергюсона";
            this.tpFerguson.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(170, 319);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(313, 20);
            this.label11.TabIndex = 11;
            this.label11.Text = "Число элементов последовательности";
            // 
            // tbSequenceLengthFerguson
            // 
            this.tbSequenceLengthFerguson.Location = new System.Drawing.Point(665, 314);
            this.tbSequenceLengthFerguson.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSequenceLengthFerguson.Name = "tbSequenceLengthFerguson";
            this.tbSequenceLengthFerguson.Size = new System.Drawing.Size(259, 26);
            this.tbSequenceLengthFerguson.TabIndex = 10;
            // 
            // btChooseModelFerguson
            // 
            this.btChooseModelFerguson.Location = new System.Drawing.Point(175, 66);
            this.btChooseModelFerguson.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btChooseModelFerguson.Name = "btChooseModelFerguson";
            this.btChooseModelFerguson.Size = new System.Drawing.Size(286, 35);
            this.btChooseModelFerguson.TabIndex = 8;
            this.btChooseModelFerguson.Text = "Выбрать модель";
            this.btChooseModelFerguson.UseVisualStyleBackColor = true;
            this.btChooseModelFerguson.Click += new System.EventHandler(this.btChooseModelFerguson_Click);
            // 
            // btChooseSequenceFerguson
            // 
            this.btChooseSequenceFerguson.Location = new System.Drawing.Point(175, 242);
            this.btChooseSequenceFerguson.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btChooseSequenceFerguson.Name = "btChooseSequenceFerguson";
            this.btChooseSequenceFerguson.Size = new System.Drawing.Size(286, 35);
            this.btChooseSequenceFerguson.TabIndex = 9;
            this.btChooseSequenceFerguson.Text = "Выбрать последовательность";
            this.btChooseSequenceFerguson.UseVisualStyleBackColor = true;
            this.btChooseSequenceFerguson.Click += new System.EventHandler(this.btChooseSequenceFerguson_Click);
            // 
            // btGenerateFerguson
            // 
            this.btGenerateFerguson.Location = new System.Drawing.Point(665, 183);
            this.btGenerateFerguson.Name = "btGenerateFerguson";
            this.btGenerateFerguson.Size = new System.Drawing.Size(285, 37);
            this.btGenerateFerguson.TabIndex = 12;
            this.btGenerateFerguson.Text = "Генерировать";
            this.btGenerateFerguson.UseVisualStyleBackColor = true;
            this.btGenerateFerguson.Click += new System.EventHandler(this.btGenerateFerguson_Click);
            // 
            // btCalculateFerguson
            // 
            this.btCalculateFerguson.Location = new System.Drawing.Point(673, 392);
            this.btCalculateFerguson.Name = "btCalculateFerguson";
            this.btCalculateFerguson.Size = new System.Drawing.Size(277, 37);
            this.btCalculateFerguson.TabIndex = 13;
            this.btCalculateFerguson.Text = "Рассчитать вероятность";
            this.btCalculateFerguson.UseVisualStyleBackColor = true;
            this.btCalculateFerguson.Click += new System.EventHandler(this.btCalculateFerguson_Click);
            // 
            // lbModelFerguson
            // 
            this.lbModelFerguson.AutoSize = true;
            this.lbModelFerguson.Location = new System.Drawing.Point(661, 81);
            this.lbModelFerguson.Name = "lbModelFerguson";
            this.lbModelFerguson.Size = new System.Drawing.Size(0, 20);
            this.lbModelFerguson.TabIndex = 15;
            // 
            // lbSequenceFerguson
            // 
            this.lbSequenceFerguson.AutoSize = true;
            this.lbSequenceFerguson.Location = new System.Drawing.Point(661, 257);
            this.lbSequenceFerguson.Name = "lbSequenceFerguson";
            this.lbSequenceFerguson.Size = new System.Drawing.Size(0, 20);
            this.lbSequenceFerguson.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(171, 126);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(234, 20);
            this.label12.TabIndex = 18;
            this.label12.Text = "Длина последовательности: ";
            // 
            // tbGeneratedSequenceLengthFerguson
            // 
            this.tbGeneratedSequenceLengthFerguson.Location = new System.Drawing.Point(665, 126);
            this.tbGeneratedSequenceLengthFerguson.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGeneratedSequenceLengthFerguson.Name = "tbGeneratedSequenceLengthFerguson";
            this.tbGeneratedSequenceLengthFerguson.Size = new System.Drawing.Size(259, 26);
            this.tbGeneratedSequenceLengthFerguson.TabIndex = 17;
            // 
            // tbProbabilityFerguson
            // 
            this.tbProbabilityFerguson.Location = new System.Drawing.Point(175, 403);
            this.tbProbabilityFerguson.Name = "tbProbabilityFerguson";
            this.tbProbabilityFerguson.Size = new System.Drawing.Size(243, 26);
            this.tbProbabilityFerguson.TabIndex = 19;
            // 
            // tbAlphaFerg
            // 
            this.tbAlphaFerg.Location = new System.Drawing.Point(174, 463);
            this.tbAlphaFerg.Multiline = true;
            this.tbAlphaFerg.Name = "tbAlphaFerg";
            this.tbAlphaFerg.Size = new System.Drawing.Size(244, 195);
            this.tbAlphaFerg.TabIndex = 20;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 966);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Расчетная система";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tpAnalise.ResumeLayout(false);
            this.tpAnalise.PerformLayout();
            this.tpMethod.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpHMM.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tpExperiment.ResumeLayout(false);
            this.tpExperiment.PerformLayout();
            this.tpOneModelComputation.ResumeLayout(false);
            this.tpOneModelComputation.PerformLayout();
            this.tpFerguson.ResumeLayout(false);
            this.tpFerguson.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem модельИсточникаОшибокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem методПодбораМоделиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.TabPage tpAnalise;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbAnResult;
        private System.Windows.Forms.Button btCountAverage;
        private System.Windows.Forms.Button btAnChose;
        private System.Windows.Forms.TabPage tpMethod;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ChooseModelBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ChooseSeqBtn;
        private System.Windows.Forms.Button CountProbBtn;
        private System.Windows.Forms.TabPage tpHMM;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbEmployedTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button CreateBtn;
        private System.Windows.Forms.Button GenerateBtn;
        private System.Windows.Forms.Button OpenBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.Button btSaveAs;
        private System.Windows.Forms.Label lbFileNameValue;
        private System.Windows.Forms.Label lbFileName;
        private System.Windows.Forms.TextBox tbSplitResultDetails;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbSegmentNumber;
        private System.Windows.Forms.TabPage tpExperiment;
        private System.Windows.Forms.Button btStartExperiment;
        private System.Windows.Forms.Button btChooseSequencesFolder;
        private System.Windows.Forms.Button btChooseModelsFolder;
        private System.Windows.Forms.Label lbSequencesFolderPath;
        private System.Windows.Forms.Label lbModelsFolderPath;
        private System.Windows.Forms.FolderBrowserDialog folderDialogModels;
        private System.Windows.Forms.FolderBrowserDialog folderDialogSequences;
        private System.Windows.Forms.TextBox tbExperimentSegmentsLength;
        private System.Windows.Forms.TextBox tbExperimentSequencesLength;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExperiment;
        private System.Windows.Forms.TabPage tpOneModelComputation;
        private System.Windows.Forms.Label lbOMCSequencePath;
        private System.Windows.Forms.Label lbOMCModelPath;
        private System.Windows.Forms.Button btOMCSelectModel;
        private System.Windows.Forms.Button btOMCSelectSequence;
        private System.Windows.Forms.Button btOMCCalculateProbability;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbOMCSegmentLength;
        private System.Windows.Forms.Label lbOMCSequenceLength;
        private System.Windows.Forms.TextBox tbOMCSequenceLength;
        private System.Windows.Forms.TabPage tpFerguson;
        private System.Windows.Forms.Label lbSequenceFerguson;
        private System.Windows.Forms.Label lbModelFerguson;
        private System.Windows.Forms.Button btCalculateFerguson;
        private System.Windows.Forms.Button btGenerateFerguson;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbSequenceLengthFerguson;
        private System.Windows.Forms.Button btChooseModelFerguson;
        private System.Windows.Forms.Button btChooseSequenceFerguson;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbGeneratedSequenceLengthFerguson;
        private System.Windows.Forms.TextBox tbProbabilityFerguson;
        private System.Windows.Forms.TextBox tbAlphaFerg;
    }
}

