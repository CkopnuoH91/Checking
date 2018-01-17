using System;
using System.Windows.Forms;

namespace Сhecking
{
    public partial class TheСertificateOnCheckingForm : Form
    {
        public TheСertificateOnCheckingForm()
        {
            InitializeComponent();
        }

        private void TheСertificateOnCheckingForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = dateTimePicker1.Value.AddYears(1);

            if ((Owner as Form1) != null)
            { 
                textBox3.Text = ((Form1)Owner).ShowtInExportForm.Model;
                textBox4.Text = "до " + ((Form1)Owner).ShowtInExportForm.MaxResistance.ToString() + " Ом";
                textBox5.Text = ((Form1)Owner).ShowtInExportForm.Accuracy;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCreateDocument_Click(object sender, EventArgs e)
        {

            if(textBox1.Text == "")
            {
                MessageBox.Show("Поле 'Наименование средства измерений:' не задано", "Пустое поле", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Поле '№:' не задано", "Пустое поле", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("Поле 'Тип:' не задано", "Пустое поле", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox4.Text == "")
            {
                MessageBox.Show("Поле 'Диапазон измерений:' не задано", "Пустое поле", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox5.Text == "")
            {
                MessageBox.Show("Поле 'Класс точности (погрешность):' не задано", "Пустое поле", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox6.Text == "")
            {
                MessageBox.Show("Поле 'Владелец:' не задано", "Пустое поле", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox7.Text == "")
            {
                MessageBox.Show("Поле 'Поверитель:' не задано", "Пустое поле", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ExportDataToWord ExpW = new ExportDataToWord();
            ExpW.CreateVerificationCertificate(textBox8.Text, dateTimePicker1,
                dateTimePicker2, textBox1.Text, textBox2.Text, textBox3.Text,
                textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);
        }
    }
}
