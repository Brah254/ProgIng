using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form1 : Form
    {
        public List<int> sizes = new List<int>();
        //public List<double> xarray = new List<double>();
        //public List<double> yarray = new List<double>();
        //public List<double> garray = new List<double>();
        public List<string> datData = new List<string>();
        private List<List<double>> matrix = new List<List<double>>();
        public Form1()
        {
            InitializeComponent();
           
            textBox6.Multiline = true;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            double left = double.Parse(textBox1.Text);
            double right = double.Parse(textBox2.Text);
            double step = double.Parse(textBox3.Text);
            Xgenerate xs = new Xgenerate(left, right, step);
            double[] xmass = xs.Xgen(left, right, step);
            double[] ymass = new double[xmass.Length];
            for (int i = 0; i < ymass.Length; i++)
            {
                ymass[i] = xmass.Min() + (random.NextDouble() * (xmass.Max() - xmass.Min()));
            }
            for (int i = 0; i < xmass.Length; i++)
            {
                listBox1.Items.Add(xmass[i]);
            }

            for (int i = 0; i < ymass.Length; i++)
            {
                listBox2.Items.Add(Math.Round(ymass[i], 1));
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateNewTab();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void CreateNewTab()
        {
            // Создаем новую вкладку
            TabPage newTabPage = new TabPage("Набор" + (tabControl1.TabCount + 1));

            // Создаем новые экземпляры элементов управления
            TextBox newTextBox1 = new TextBox();
            TextBox newTextBox2 = new TextBox();
            TextBox newTextBox3 = new TextBox();
            Button newButton = new Button();
            ListBox newListBox = new ListBox(); // Создаем новый листбокс
            ListBox newListBox2 = new ListBox();
            ListBox newListBox3 = new ListBox();
            Label newLabel1 = new Label(); // Создаем новые подписи
            Label newLabel2 = new Label();
            Label newLabel3 = new Label();
            Label newLabel4 = new Label();
            Label newLabel5 = new Label();
            Label newLabel6 = new Label();
            Button newButton2 = new Button(); // Создаем новые кнопки

            // Настройка позиции элементов управления
            newTextBox1.Location = textBox1.Location;
            newTextBox2.Location = textBox2.Location;
            newTextBox3.Location = textBox3.Location;
            newButton.Location = button1.Location;
            newListBox.Location = listBox1.Location; // Устанавливаем позицию листбокса
            newListBox2.Location = listBox2.Location;
            newListBox3.Location = listBox3.Location;
            newLabel1.Location = label1.Location; // Устанавливаем позиции подписей
            newLabel2.Location = label2.Location;
            newLabel3.Location = label3.Location;
            newLabel4.Location = label4.Location;
            newLabel5.Location = label5.Location;
            newLabel6.Location = label7.Location;
            newButton2.Location = button2.Location; // Устанавливаем позицию кнопки

            // Настройка размеров элементов управления
            newTextBox1.Size = textBox1.Size;
            newTextBox2.Size = textBox2.Size;
            newTextBox3.Size = textBox3.Size;
            newButton.Size = button1.Size;
            newListBox.Size = listBox1.Size; // Устанавливаем размер листбокса
            newListBox2.Size = listBox2.Size;
            newListBox3.Size = listBox3.Size;
            newLabel1.Size = label1.Size; // Устанавливаем размеры подписей
            newLabel2.Size = label2.Size;
            newLabel3.Size = label3.Size;
            newLabel4.Size = label4.Size;
            newLabel5.Size = label5.Size;
            newLabel6.Size = label7.Size;
            newButton2.Size = button2.Size; // Устанавливаем размер кнопки

            // Устанавливаем текст для подписей
            newLabel1.Text = label1.Text;
            newLabel2.Text = label2.Text;
            newLabel3.Text = label3.Text;
            newLabel4.Text = label4.Text;
            newLabel5.Text = label5.Text;
            newLabel6.Text = label7.Text;

            // Устанавливаем текст для кнопок
            newButton.Text = button1.Text;
            newButton2.Text = button2.Text;

            // Добавляем обработчик события для кнопки
            newButton.Click += (sender, e) =>
            {
                Random random = new Random();
                double left = double.Parse(newTextBox1.Text);
                double right = double.Parse(newTextBox2.Text);
                double step = double.Parse(newTextBox3.Text);
                Xgenerate xs = new Xgenerate(left, right, step);
                double[] xmass = xs.Xgen(left, right, step);
                double[] ymass = new double[xmass.Length];
                double[] gresults = new double[xmass.Length * ymass.Length];
                for (int i = 0; i < xmass.Length; i++)
                {
                    ymass[i] = xmass.Min() + (random.NextDouble() * (xmass.Max() - xmass.Min()));
                }
                foreach (double value in xmass)
                {
                    newListBox.Items.Add(value); // Добавляем значения в листбокс

                }
                foreach (double value in ymass)
                {
                    newListBox2.Items.Add(value); // Добавляем значения в листбокс
                }
                MyFunctions ganswer = new MyFunctions(xmass, ymass);
                for (int i = 0; i < xmass.Length; i++)
                {
                    for (int j = 0; j < ymass.Length; j++)
                    {


                        gresults[i] = ganswer.func1(xmass[i], ymass[j]);
                        newListBox3.Items.Add(gresults[i]);

                    }
                }

                sizes.Add(xmass.Length);
                sizes.Add(ymass.Length);
                sizes.Add(gresults.Length);

            };

            // Добавляем элементы управления на новую вкладку
            newTabPage.Controls.Add(newTextBox1);
            newTabPage.Controls.Add(newTextBox2);
            newTabPage.Controls.Add(newTextBox3);
            newTabPage.Controls.Add(newButton);
            newTabPage.Controls.Add(newListBox); // Добавляем листбокс на новую вкладку
            newTabPage.Controls.Add(newListBox2);
            newTabPage.Controls.Add(newListBox3);
            newTabPage.Controls.Add(newLabel1); // Добавляем подписи на новую вкладку
            newTabPage.Controls.Add(newLabel2);
            newTabPage.Controls.Add(newLabel3);
            newTabPage.Controls.Add(newLabel4);
            newTabPage.Controls.Add(newLabel5);
            newTabPage.Controls.Add(newLabel6);
            newTabPage.Controls.Add(newButton2); // Добавляем кнопку на новую вкладку

            // Добавляем новую вкладку на TabControl
            tabControl1.TabPages.Add(newTabPage);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<string[]> allTabData = GetTabData();
            string filePath = "C:\\TEHOLOGIIPROGRAMMIROVANIA\\laba6\\lab6\\lab6\\d.txt"; // Укажите путь к файлу

            SaveDataToFile(allTabData, filePath);

        }

        private List<string[]> GetTabData()
        {
            List<string[]> allData = new List<string[]>();

            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                List<string> tabData = new List<string>();

                foreach (Control control in tabPage.Controls)
                {
                    if (control is ListBox listBox)
                    {
                        foreach (var item in listBox.Items)
                        {
                            tabData.Add(item.ToString());
                        }
                    }
                    // Добавьте обработку других типов элементов управления, если необходимо
                }

                allData.Add(tabData.ToArray());
            }

            return allData;
        }

        private void SaveDataToFile(List<string[]> data, string filePath)
        {
            int f = 0;
            int g = 0;
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var tabData in data)
                {
                    foreach (var item in tabData)
                    {
                        if (f == sizes[g])
                        {
                            writer.WriteLine();
                            g++;
                            f = 0;
                        }
                        writer.WriteLine(item);
                        f++;

                    }
                    //  writer.WriteLine(); // Добавляем пустую строку между данными в разных вкладках
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string inputFileName = "C:\\TEHOLOGIIPROGRAMMIROVANIA\\laba6\\lab6\\lab6\\d.txt"; // Имя входного файла
            string outputDirectory = @"C:\TEHOLOGIIPROGRAMMIROVANIA\Test"; // Путь к директории для сохранения файлов
            string outputFileNamePrefix = "G"; // Префикс имени выходных файлов
            string fileName = "myProgram.log";
            string fileErrorName = "myErrors.log";
            string fullpathfilename = Path.Combine(outputDirectory, fileName);
            string fullpatherrorname = Path.Combine(outputDirectory, fileErrorName);

            using (FileStream fs = File.Create(fullpatherrorname))
            {

            }

            // Чтение данных из входного файла
            List<double> xValues = new List<double>();
            List<double> yValues = new List<double>();
            List<double> gValues = new List<double>();
            List<string> datfiles = new List<string>();

            using (StreamReader reader = new StreamReader(inputFileName))
            {
                string line;
                double temp;
                int f = 0;
                int q = 0;
                int savefirstx = 0;
                int enter = 0;
                int smesh = 0;
                while ((line = reader.ReadLine()) != null || f == 3 || line == null)
                {


                    if (line == null)
                    {
                        f++;
                    }

                    if ((line != "") && (f == 0))
                    {

                        xValues.Add(double.Parse(line));
                    }
                    else if (line == "")
                    {
                        f++;
                        continue;
                    }
                    else if ((line != "") && (f == 1))
                    {
                        if (line == null)
                        {
                            break;
                        }
                        yValues.Add(double.Parse(line));
                    }
                    else if ((line != "") && (f == 2))
                    {
                        gValues.Add(double.Parse(line));
                    }
                    else if (f == 3)
                    {

                        string outputFileName = Path.Combine(outputDirectory, $"{outputFileNamePrefix}{q + 1:D4}.rez"); // Формирование пути к выходному файлу
                        datfiles.Add($"{outputFileNamePrefix}{q + 1:D4}.rez");
                        using (StreamWriter writer = new StreamWriter(outputFileName))
                        {
                            // Запись заголовка таблицы
                            writer.Write("\ty\\x");
                            foreach (double x in xValues)
                            {
                                writer.Write($";\t\t {x}");
                            }
                            writer.WriteLine();

                            // Запись значений G(x, y)
                            for (int j = 0; j < yValues.Count; j++)
                            {
                                writer.Write($"{yValues[j]}");
                                foreach (double g in gValues)
                                {

                                    if (enter == xValues.Count)
                                    {
                                        writer.WriteLine();
                                        smesh -= (j + 1) * enter;
                                        enter = 0;
                                        break;
                                    }
                                    else if (smesh < 0)
                                    {
                                        smesh++;
                                        continue;
                                    }

                                    writer.Write($"; {g}");
                                    enter++;
                                }
                                writer.WriteLine();
                            }

                            using (StreamWriter er = new StreamWriter(fullpatherrorname))
                            {
                                int iter = 0;
                                er.WriteLine($"{outputFileNamePrefix}{q + 1:D4}.rez");
                                er.WriteLine("Function is y/cos(1/x^2)");
                                foreach (double g in gValues)
                                {
                                    if (gValues[iter].ToString() == "не число")
                                    {
                                        er.Write($"X = {xValues[iter]} ");
                                        er.Write($"Y = {yValues[iter]}");
                                    }
                                    iter++;
                                }
                                er.WriteLine("Деление на ноль");
                            }
                            xValues.Clear();
                            if (line != null)
                            {
                                xValues.Add(double.Parse(line));
                            }
                            enter = 0;
                            smesh = 0;
                            yValues.Clear();
                            gValues.Clear();
                            writer.Close();
                        }
                        q++;
                        f = 0;
                    }

                }
            }

            using (FileStream fs = File.Create(fullpathfilename))
            {

            }
            using (StreamWriter sw = new StreamWriter(fullpathfilename))
            {
                sw.WriteLine("SetCalculator V1.0");
                sw.WriteLine("Variant 22");
                sw.WriteLine($"{DateTime.Now}");
                sw.WriteLine("Function is y/cos(1/x^2)");
                sw.Write("Результаты вычисления наборов сохрнанены в файлах");
                foreach (string dat in datfiles)
                {
                    sw.Write($",{dat} ");
                }
            }




        }


        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "DAT files (*.dat)|*.dat|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Считываем строки из выбранного файла
                    string[] lines = File.ReadAllLines(openFileDialog.FileName);

                    // Очищаем список перед добавлением новых данных
                    datData.Clear();

                    // Добавляем строки в List<string>, предварительно разделив значения по запятым
                    foreach (string line in lines)
                    {
                        string[] values = line.Split(',');
                        datData.Add(string.Join("\t", values));
                    }

                    // Делаем что-то с данными в dataList

                    foreach (string data in datData)
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "REZ files (*.rez)|*.rez";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                try
                {
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                List<double> row = new List<double>();
                                string[] values = line.Split(';');
                                foreach (string value in values)
                                {
                                    if (double.TryParse(value.Trim(), out double number))
                                    {
                                        row.Add(number);
                                    }
                                    else
                                    {
                                        // Обработка ошибки: например, игнорирование недопустимых значений или вывод сообщения об ошибке
                                        MessageBox.Show($"Убрано не число: {value}");
                                      
                                        
                                    }
                                }
                                matrix.Add(row);
                            }
                        }
                        sr.Close();
                       
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading the file: " + ex.Message);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int startRow = int.Parse(textBox4.Text);
            int endRow = int.Parse(textBox5.Text);
            int startCol = int.Parse(textBox7.Text);
            int endCol = int.Parse(textBox8.Text);

            if (startRow < 0 || endRow >= matrix.Count || startCol < 0 || endCol >= matrix[0].Count ||
    startRow > endRow || startCol > endCol)
            {
                MessageBox.Show("Некорректные границы подматрицы.");
                return;
            }

            StringBuilder result = new StringBuilder();

            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCol; j <= endCol; j++)
                {
                    result.Append(matrix[i][j]);
                    if (j < endCol) // Добавить табуляцию, кроме последнего элемента в строке
                        result.Append("\t\t");
                }
                result.AppendLine(); // Добавить перевод строки после каждой строки
            }

            textBox6.Text = result.ToString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
