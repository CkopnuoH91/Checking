using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Ivi.Visa.Interop;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;

namespace Сhecking
{
    public partial class Form1 : Form
    {
        private Ivi.Visa.Interop.FormattedIO488 ioDmm;

        public int indexOfList;
        public ResistanceBox ShowtInExportForm;
        public ResistanceBoxes R = new ResistanceBoxes();
        public List<List<double>> listExport;

        public Form1()
        {
            InitializeComponent();
            ioDmm = new FormattedIO488();
            SetAccessForClosed();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            R.DefaultDevice();
            R.ShowModel(listBox1);
            listBox1.SelectedIndex = 0;
            comboBoxAutoSize.SelectedIndex = 6;
            comboBoxAutoSizeData.SelectedIndex = 6;
            NoSort(dataGridView1);
            NoSort(dataGridView2);

            if (AvailablePort())
            {
                comboBoxNumberPort.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Нет доступных COM портов", "Наличие доступных портов", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void NoSort(DataGridView D)
        {
            foreach (DataGridViewColumn column in D.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void Initialize_Click(object sender, EventArgs e)
        {
            try
            {           
                ResourceManager grm = new ResourceManager();
                ioDmm.IO = (IMessage)grm.Open(this.txtAddress.Text, AccessMode.NO_LOCK, 2000, "");
                checkBoxConnect.Checked = true;
                checkBoxConnect.Text = "Подключено";
                checkBoxConnect.ForeColor = Color.Green;
                checkBoxConnect.BackColor = Color.GreenYellow;
            }
            catch (SystemException)
            {
                MessageBox.Show("Не удалось открыть соединение по адресу: " + this.txtAddress.Text  + "\nПроверьте наличие физического подключения и правильность настроек COM-порта", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxConnect.Checked = false;
                checkBoxConnect.Text = "Не установлено";
                checkBoxConnect.ForeColor = Color.Red;
                checkBoxConnect.BackColor = Color.Pink;
                ioDmm.IO = null;
                return;
            }
            SetAccessForOpened();
        }

        private void SetAccessForClosed()
        {
            groupBoxMeasure.Enabled = false;
            buttonConnect.Enabled = true;
            CloseConnect.Enabled = false;
        }

        private void SetAccessForOpened() 
        {
            groupBoxMeasure.Enabled = true;
            buttonConnect.Enabled = false;
            CloseConnect.Enabled = true;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            try
            {
                ioDmm.IO.Close();
                SetAccessForClosed();
            }
            catch 
            {
                MessageBox.Show("Невозможно закрыть соединение", "Закрытие соединения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          

            checkBoxConnect.Checked = false;
            checkBoxConnect.Text = "Отключен";
            checkBoxConnect.ForeColor = Color.Red;
            checkBoxConnect.BackColor = Color.Pink;
        }

        public void ShowInfoAndMakeColumns(DataGridView D)
        {
            int NumberOfColumns = 1;

            D.Columns.Clear();
            foreach (ResistanceBox ResBox in R.GetListOfResistanceBoxes)
            {
                if (listBox1.SelectedItem.ToString() == ResBox.Model)
                {
                    ResBox.Show(listBox2);
                    NumberOfColumns = ResBox.NumberDecade;

                    if ((ResBox as ResistanceBox2) != null)
                    {
                        D.Columns.Add("Ro", "Ro,Ом (на зажимах №1)");
                        D.Columns.Add("Ro", "Ro,Ом (на зажимах №2)");
                    }
                    else
                    {
                        D.Columns.Add("Ro", "Ro,Ом");
                    }
                }
            }
            for (int i = 1; i <= NumberOfColumns; i++)
            {
                D.Columns.Add("Decade" + i.ToString(), "Декада №" + i.ToString());
            }
            D.CurrentCell = D[0, 0];
        }

        private string MeasureFun()
        {
            try
            {
                ioDmm.WriteString("SYSTem:REMote", true);
                ioDmm.WriteString("CONF:FRES", true);
                ioDmm.WriteString("SENS:FRES:OCOM ON", true);
                ioDmm.WriteString("SENS:FRES:NPLC 10", true);

                if (checkBoxNull.Checked)
                {
                    ioDmm.WriteString("FRES:NULL:STAT ON", true);
                }
                else
                {
                    ioDmm.WriteString("FRES:NULL:STAT OFF", true);
                }
                ioDmm.WriteString("READ?", true);
                Pause(3000);
                return ioDmm.ReadNumber(IEEEASCIIType.ASCIIType_R4, true).ToString();
            }
            catch
            {
                return "Ошибка";
            }
        }

        private string MeasureFun2()
        {
            try
            {
                ioDmm.WriteString("READ?", true);
                Pause(3000);
                return ioDmm.ReadNumber(IEEEASCIIType.ASCIIType_R4, true).ToString();
            }
            catch
            {
                return "Ошибка";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            timer1.Start();
            button1.Visible = false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            timer2.Interval = 10;
            timer2.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panel1.Width < 300)
            {
                panel1.Width += 10;
            }
            else
            {
                timer1.Stop();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (panel1.Width > 0)
            {
                panel1.Width -= 10;
            }
            else
            {
                timer2.Stop();
                button1.Visible = true;
            }
        }

        private void buttonMeasure_Click(object sender, EventArgs e)
        {
            ShowForStartMeasure();

            if (dataGridView1.CurrentCell.RowIndex >= dataGridView1.Rows.Count - 1)
            {
                dataGridView1.Rows.Insert(dataGridView1.CurrentCell.RowIndex);
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index - 1].Cells[dataGridView1.CurrentCell.ColumnIndex];
            }

            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[dataGridView1.CurrentCell.ColumnIndex].Value = MeasureFun();
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index + 1].Cells[dataGridView1.CurrentCell.ColumnIndex];
            
            ShowForStopMeasure();
        }

        private void buttonMeasureHalfAuto_Click(object sender, EventArgs e)
        {
            ioDmm.WriteString("SYSTem:REMote", true);
            ioDmm.WriteString("CONF:FRES", true);
            ioDmm.WriteString("SENS:FRES:OCOM ON", true);
            

            if (checkBoxNull.Checked)
            {
                ioDmm.WriteString("FRES:NULL:STAT ON", true);
            }
            else
            {
                ioDmm.WriteString("FRES:NULL:STAT OFF", true);
            }

            ShowForStartMeasure();

            int pause = (int)numericUpDownTime.Value - 3;
            for (int i = 0; i < numericUpDownNumberMeasure.Value; i++)
            {

                
                if (buttonStopMeasure.Enabled == false)
                {
                    buttonStopMeasure.Enabled = true;
                    break;
                }

                if (dataGridView1.CurrentCell.RowIndex >= dataGridView1.Rows.Count - 1)
                {
                    dataGridView1.Rows.Insert(dataGridView1.CurrentCell.RowIndex);
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index - 1].Cells[dataGridView1.CurrentCell.ColumnIndex];
                }

                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[dataGridView1.CurrentCell.ColumnIndex].Value = MeasureFun2();
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index + 1].Cells[dataGridView1.CurrentCell.ColumnIndex];
                Pause(pause * 1000);
                
                
            }
            ShowForStopMeasure();
        }
        
        private void ShowForStartMeasure()
        {
            buttonMeasureHalfAuto.Enabled = false;
            buttonStopMeasure.Enabled = true;
            buttonAdd.Enabled = false;
            buttonEdit.Enabled = false;
            buttonDel.Enabled = false;
            buttonDefaultRb.Enabled = false;
            buttonSave.Enabled = false;
            buttonLoad.Enabled = false;
            buttonUpDate.Enabled = false;
            buttonMeasure.Enabled = false;
        }

        private void ShowForStopMeasure()
        {
            buttonMeasureHalfAuto.Enabled = true;
            buttonStopMeasure.Enabled = false;
            buttonAdd.Enabled = true;
            buttonEdit.Enabled = true;
            buttonDel.Enabled = true;
            buttonDefaultRb.Enabled = true;
            buttonSave.Enabled = true;
            buttonLoad.Enabled = true;
            buttonUpDate.Enabled = true;
            buttonMeasure.Enabled = true;
        }

        private void Pause(int value)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < value)
                Application.DoEvents();
        }

        private delegate string MeasureDelegate();

        private void buttonStopMeasure_Click(object sender, EventArgs e)
        {
            buttonStopMeasure.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowInfoAndMakeColumns(dataGridView1);
            NoSort(dataGridView1);
            NoSort(dataGridView2);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            dataGridView2.Columns.Clear();
            buttonProtocol.Enabled = false;
            buttonVerificationCertificate.Enabled = false;
            buttonTheConclusionAboutUnfitness.Enabled = false;
            buttonExel.Enabled = false;
            if (tabControl1.SelectedIndex == 1 && FillDataGridView2())
            {
                NoSort(dataGridView2);
            }
            else
            {
                tabControl1.SelectedIndex = 0;
            }
        }
        private void ShowResultCheck() 
        {
            if (IsTestSuccessful())
            {
                MessageBox.Show("Поверка пройдена успешно\nДля продолжения нажмите 'OK'",
                    "Результат поверки", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButtonsForCheckTrue();
            }
            else
            {
                MessageBox.Show("Поверка не пройдена. Обнаружены несоответствия\nДля продолжения нажмите 'OK'",
                    "Результат поверки", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButtonsForCheckFalse();
            }
        }

        private void buttonCheckResult_Click(object sender, EventArgs e)
        {
            ShowResultCheck();
        }

        private void EnableButtonsForCheckTrue()
        {
            buttonProtocol.Enabled = true;
            buttonVerificationCertificate.Enabled = true;
            buttonTheConclusionAboutUnfitness.Enabled = false;
            buttonExel.Enabled = true;

        }
        private void EnableButtonsForCheckFalse()
        {
            buttonProtocol.Enabled = true;
            buttonVerificationCertificate.Enabled = false;
            buttonTheConclusionAboutUnfitness.Enabled = true;
            buttonExel.Enabled = true;
        }

        private bool FillDataGridView2() 
        {
            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("Rnom", "Rном.,Ом");
            dataGridView2.Columns.Add("Rd", "Rд.,Ом");
            dataGridView2.Columns.Add("r_otn", "r%");
            dataGridView2.Columns.Add("R_ab", "∆R,Ом");
            dataGridView2.Columns.Add("R_mdR", "R-∆R,Ом");
            dataGridView2.Columns.Add("R_pdR", "R+∆R,Ом");
            dataGridView2.Columns.Add("Сonclusion", "Заключение");

            ResistanceBox R1 = R.FindResistanceBoxInListBox(listBox1);

            List<List<double>> lis = new List<List<double>>();

            double k = 0;

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                lis.Add(new List<double>());
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    if (dataGridView1[i, j].Value != null && dataGridView1[i, j].Value.ToString() != "")
                    {
                        double.TryParse(dataGridView1[i, j].Value.ToString(), out k);
                        lis[i].Add(k);
                    }
                }
            }

            int indexLine = 0;
            int showColumnsCount;

            if ((R1 as ResistanceBox2) != null)
            {
                if (lis[0].Count == 0)
                {
                    MessageBox.Show("Внимание! Нет данных в столбце: 'Ro на зажимах №1'\nВведите данные и повторите попытку", "Заполнение данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (lis[0].Count > 4)
                {
                    lis[0].RemoveRange(4, lis[0].Count - 4);
                }
                dataGridView2.Rows.Add();
                dataGridView2[1, indexLine++].Value = "Ro на зажимах №1";
                ShowNullRes(dataGridView2, lis[0], ref indexLine, ((ResistanceBox2)R1).NullResistance, ((ResistanceBox2)R1).VariationNullResistance);
                if (lis[1].Count == 0)
                {
                    MessageBox.Show("Внимание! Нет данных в столбце: 'Ro на зажимах №2'\nВведите данные и повторите попытку", "Заполнение данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (lis[1].Count > 4)
                {
                    lis[1].RemoveRange(4, lis[1].Count - 4);
                }
                dataGridView2.Rows.Add();
                dataGridView2[1, indexLine++].Value = "Ro на зажимах №2";
                ShowNullRes(dataGridView2, lis[1], ref indexLine, ((ResistanceBox2)R1).NullResistance2, ((ResistanceBox2)R1).VariationNullResistance2);
                showColumnsCount = 2;
            }
            else
            {
                if (lis[0].Count == 0)
                {
                    MessageBox.Show("Внимание! Нет данных в столбце: 'Ro'\nВведите данные и повторите попытку", "Заполнение данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (lis[0].Count > 4)
                {
                    lis[0].RemoveRange(4, lis[0].Count - 4);
                }
                dataGridView2.Rows.Add();
                dataGridView2[1, indexLine++].Value = "Ro";
                ShowNullRes(dataGridView2, lis[0], ref indexLine, R1.NullResistance, R1.VariationNullResistance);
                showColumnsCount = 1;
            }

            int kz = 1;

            double km = R1.MinResistance;
            for (int i = showColumnsCount; i < lis.Count; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2[0, indexLine++].Value = "Декада №" + kz++.ToString();
                ShowDec(dataGridView2, lis[i], R1, ref indexLine, km);
                km *= 10;
            }
            ShowtInExportForm = R1;
            listExport = lis;
            return true;
        }
        private string GetFormatString() 
        {
            string numberOfCharacters = "0.";

            for (int i = 0; i < numericUpDownCapacity.Value; i++)
            {
                numberOfCharacters += "0";
            }
            return numberOfCharacters;
        }
        private void ShowNullRes(DataGridView D, List<double> lstDec, ref int line, double NR, double VarNR)
        {
            string FormatString = GetFormatString();

            foreach (double dm in lstDec)
            {
                dataGridView2.Rows.Add();
                dataGridView2[1, line].Value = dm.ToString();
                line++;
            }
            
            dataGridView2.Rows.Add();
            dataGridView2[1, line].Value = lstDec.Min().ToString(FormatString);
            dataGridView2[0, line++].Value = "Rmin=";
            dataGridView2.Rows.Add();
            dataGridView2[1, line].Value = lstDec.Max().ToString(FormatString);
            dataGridView2[0, line++].Value = "Rmax=";
            dataGridView2.Rows.Add();
            dataGridView2[1, line].Value = (lstDec.Sum() / lstDec.Count).ToString(FormatString);

            double f;
            double.TryParse(dataGridView2[1, line].Value.ToString(), out f);
            if (f > NR)
            {
                dataGridView2[1, line].Style.BackColor = Color.Red;
                dataGridView2[6, line].Style.BackColor = Color.Red;
                dataGridView2[6, line].Value = "больше на " + (f - NR).ToString(FormatString);
            }
            else
            {
                dataGridView2[1, line].Style.BackColor = Color.LimeGreen;
                dataGridView2[6, line].Style.BackColor = Color.LimeGreen;
                dataGridView2[6, line].Value = "Соответствует";
            }

            dataGridView2[0, line++].Value = "Rср.=";
            dataGridView2.Rows.Add();
            dataGridView2[1, line].Value = (lstDec.Max() - lstDec.Min()).ToString(FormatString);

            double f1;
            double.TryParse(dataGridView2[1, line].Value.ToString(), out f1);
            if (f1 > VarNR)
            {
                dataGridView2[1, line].Style.BackColor = Color.Red;
                dataGridView2[6, line].Style.BackColor = Color.Red;
                dataGridView2[6, line].Value = "больше на " + (f1 - VarNR).ToString(FormatString);
            }
            else
            {
                dataGridView2[1, line].Style.BackColor = Color.LimeGreen;
                dataGridView2[6, line].Style.BackColor = Color.LimeGreen;
                dataGridView2[6, line].Value = "Соответствует";
            }

            dataGridView2[0, line++].Value = "Rвар.=";
        }
        private void ShowDec(DataGridView D, List<double> lstDec, ResistanceBox ResB, ref int line, double km)
        {
            double resist = 0;
            double _relativeError = 0;
            double _absoluteError = 0;
            double lowerLimit = 0;
            double upperLimit = 0;

            string FormatString = GetFormatString();

            foreach (double resistanceValue in lstDec)
            {
                resist += km;
                dataGridView2.Rows.Add();
                dataGridView2[0, line].Value = resist.ToString();
                dataGridView2[1, line].Value = resistanceValue.ToString();
                _relativeError = ResB.RelativeError(resist, ResB.ConstantABC);
                dataGridView2[2, line].Value = _relativeError.ToString(FormatString);
                _absoluteError = _relativeError * resist / 100;
                dataGridView2[3, line].Value = _absoluteError.ToString(FormatString);

                lowerLimit = resist - _absoluteError;
                upperLimit = resist + _absoluteError;

                dataGridView2[4, line].Value = lowerLimit.ToString(FormatString);
                dataGridView2[5, line].Value = upperLimit.ToString(FormatString);

                if (resistanceValue < lowerLimit)
                {
                    dataGridView2[1, line].Style.BackColor = Color.Red;
                    dataGridView2[6, line].Style.BackColor = Color.Red;
                    dataGridView2[6, line].Value = "меньше на " + (lowerLimit - resistanceValue).ToString(FormatString);
                }
                else if (resistanceValue > upperLimit)
                {
                    dataGridView2[1, line].Style.BackColor = Color.Red;
                    dataGridView2[6, line].Style.BackColor = Color.Red;
                    dataGridView2[6, line].Value = "больше на " + (resistanceValue - upperLimit).ToString(FormatString);
                }
                else
                {
                    dataGridView2[1, line].Style.BackColor = Color.LimeGreen;
                    dataGridView2[6, line].Style.BackColor = Color.LimeGreen;
                    dataGridView2[6, line].Value = "Соответствует";
                }
                line++;
            }
        }
        private bool IsTestSuccessful()
        {
            bool testIsSuccessful = true;
            foreach (DataGridViewRow Row in dataGridView2.Rows)
            {
                if ((Row.Cells[6].Style.BackColor == Color.Red))
                {
                    testIsSuccessful = false;
                }
            }
            return testIsSuccessful;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddResistanceBox add = new AddResistanceBox();
            add.DefaultParams();
            add.ShowDialog(this);
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ResistanceBox ResistBox = R.FindResistanceBoxInListBox(listBox1);

            indexOfList = R.GetListOfResistanceBoxes.IndexOf(ResistBox);

            AddResistanceBox edit = new AddResistanceBox();
            edit.EditResistanceBox(ResistBox);
            edit.buttonAdd.Text = "Сохранить";
            edit.Text = "Редактирование прибора";
            edit.ShowDialog(this);
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Внимание!\nДанное действие удалит из текущего списка магазинов сопротивления выбранную модель.\nДля удаления нажмите Ок, для выхода Отмена", "Удаление выбранной модели", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                R.DeleteRb(R.FindResistanceBoxInListBox(listBox1));
                listBox1.Items.Clear();
                R.ShowModel(listBox1);
                if (listBox1.Items.Count != 0)
                {
                    listBox1.SelectedIndex = 0;
                }
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Внимание!\nДанное действие сохранит текущий список магазинов сопротивления в файл Rbtxt.txt.\nЕсли такой файл уже существует, то произойдет его перезапись с заменой более старых значений на новые.\nДля сохранения нажмите Ок, для выхода Отмена", "Запись в файл", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter file = new StreamWriter(@"Rbtxt.txt", false))
                    {
                        R.SaveToFile(file);
                    }
                    MessageBox.Show("Сохранение списка магазинов сопротивления прошло успешно", "Запись в файл", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("При добавлении данных в файл возникла ошибка!", "Запись в файл", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Внимание!\nДанное действие загрузит список магазинов сопротивления расположенный в файле Rbtxt.txt с заменой текущего списка магазинов сопротивления.\nДля загрузки нажмите Ок, для выхода Отмена", "Чтение из файла", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                R.ClearList();
                try
                {
                    using (StreamReader file = new StreamReader(@"Rbtxt.txt", false))
                    {
                        while (!file.EndOfStream)
                        {
                            if (file.ReadLine().Trim() == "[1]")
                            {
                                ResistanceBox f = new ResistanceBox();
                                R.AddRb(f.Read(file));
                            }
                            else
                            {
                                ResistanceBox2 f2 = new ResistanceBox2();
                                R.AddRb(f2.Read(file));
                            }
                        }
                        listBox1.Items.Clear();
                        R.ShowModel(listBox1);
                    }
                    listBox1.SelectedIndex = 0;
                }
                catch
                {
                    MessageBox.Show("При загрузке данных из файла произошла ошибка", "Ошибка чтения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonUpDate_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            R.ShowModel(listBox1);
            if (listBox1.Items.Count != 0)
            {
                listBox1.SelectedIndex = 0;
            }
        }
        private void buttonDefaultRb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Внимание!\nДанное действие восстановит список магазинов сопротивления по умолчанию с заменой текущего списка\nСписок магазинов сопротивления по умолчанию содержит следующие модели:\nP4834\nP4831\nP327\nMCP-60M\nMCP-60\nP33\nP4830/1\nP4830/2\nMCP-63\nДля восстановления нажмите Ок, для выхода Отмена", "Восстановление списока магазинов сопротивления по умолчанию", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    R.ClearList();
                    listBox1.Items.Clear();
                    R.DefaultDevice();
                    R.ShowModel(listBox1);
                    MessageBox.Show("Восстановление списка магазинов сопротивления по умолчанию прошло успешно", "Восстановление списка магазинов сопротивления", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Невозможно восстановить список магазинов сопротивления по умолчанию", "Восстановление списка магазинов сопротивления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void numericUpDownCapacity_ValueChanged(object sender, EventArgs e)
        {
            FillDataGridView2(); 
        }
        private void comboBoxAutoSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoResizeColumnsData(comboBoxAutoSize.SelectedIndex, dataGridView2);
        }
        private void comboBoxAutoSizeData_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoResizeColumnsData(comboBoxAutoSizeData.SelectedIndex, dataGridView1);
        }
        private void AutoResizeColumnsData(int SelectedIndex, DataGridView dgv) 
        {
            switch (SelectedIndex)
            {
                case 0:
                    dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case 1:
                    dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                    break;
                case 2:
                    dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
                    break;
                case 3:
                    dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                    break;
                case 4:
                    dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader);
                    break;
                case 5:
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv.AutoResizeColumns();
                    break;
                case 6:
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    dgv.AutoResizeColumns();
                    break;

                default: MessageBox.Show("Невозможно выровнять столбцы. Попробуйте другое выравнивание", "Ошибка выравнивания", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    break;
            }
        }
        private void buttonProtocol_Click(object sender, EventArgs e)
        {
            Protocol CreateProtocol = new Protocol();
            CreateProtocol.ShowDialog(this);
        }
        private void buttonVerificationCertificate_Click(object sender, EventArgs e)
        {
            TheСertificateOnCheckingForm СertificateForm = new TheСertificateOnCheckingForm();
            СertificateForm.ShowDialog(this);
        }
        private void buttonTheConclusionAboutUnfitness_Click(object sender, EventArgs e)
        {
            TheConclusionAboutUnfitnessForm CreateConclusionForm = new TheConclusionAboutUnfitnessForm();
            CreateConclusionForm.ShowDialog(this);
        }
        private void buttonExel_Click(object sender, EventArgs e)
        {
            ExportDataToExсel exportDataToExel = new ExportDataToExсel();
            exportDataToExel.CreateExelDocument(dataGridView1, dataGridView2);
        }
        private void buttonClearCell_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectedCells[0].Value = "";
        }

        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                try
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
                catch 
                {
                    MessageBox.Show("Нельзя удалить еще не существующую строку", "Удаление строки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }          
        }

        /// <summary>
        /// Метод проверки доступности COM портов
        /// </summary>
        /// <returns> Возвращает true если найден хотя бы один порт, иначе false.</returns>
        private bool AvailablePort()
        {
            //Переменная состояния доступных портов
            //true в случае успешного получения 
            //false если порты не найдены
            bool available = false;

            //Производим проверку массива имен последовательных портов на возможность доступа
            //Функция SerialPort.GetPortNames() возвращает массив имен
            foreach (string str in SerialPort.GetPortNames())
            {
                try
                {
                    SerialPort Port = new SerialPort(str);

                    //Открываем новое соединение последовательного порта
                    Port.Open();

                    //Выполняем проверку полученного порта
                    //true, если последовательный порт открыт, в противном случае — false.
                    //Значение по умолчанию — false.
                    if (Port.IsOpen)
                    {
                        //Если порт открыт то добавляем его в comboBox
                        comboBoxNumberPort.Items.Add(str);

                        //Закрываем соединение порта, присваиваем свойству 
                        //System.IO.Ports.SerialPort.IsOpen значение false и уничтожаем 
                        //внутренний объект System.IO.Stream.
                        Port.Close();

                        //возвращаем true для состояния получения портов
                        available = true;
                    }
                }

                //Если не удалось открыть порт, то он уже занят и при добавлении будет помечен как COMX(занят)     
                catch (UnauthorizedAccessException)
                {
                    comboBoxNumberPort.Items.Add(str + "(занят)");
                }

                //Ловим все ошибки и отображаем, что открытых портов не найдено  
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Error - No Ports available",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //возвращаем состояние получения портов
            return available;
        }

        private void comboBoxNumberPort_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtAddress.Text = "ASRL" + comboBoxNumberPort.SelectedItem.ToString()[3].ToString() + "::INSTR";
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа 'Поверка' предназначена для поверки многозначных мер электрического сопротивления\n"
                + "Разработчик: Котченко Виктор Николаевич 2014г.\nКонтактная информация:\nтел.: +375259994711"
                + "\ne-mail: ckopnuoh_victor@mail.ru", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}