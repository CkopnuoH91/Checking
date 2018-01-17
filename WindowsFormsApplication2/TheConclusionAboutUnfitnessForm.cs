using System;
using System.Windows.Forms;

namespace Сhecking
{
    public partial class TheConclusionAboutUnfitnessForm : Form
    {
        public TheConclusionAboutUnfitnessForm()
        {
            InitializeComponent();
        }

        private void TheConclusionAboutUnfitnessForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            textBoxDirec.Text = "В. И. Зайцев";
            textBoxName.Text = "Магазин сопротивления " + (Owner as Form1).ShowtInExportForm.Model;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            ExportDataToWord ExpW = new ExportDataToWord();
            ExpW.CreateTheConclusionAboutUnfitness(dateTimePicker1, 
                textBoxConclusionNumber.Text, textBoxName.Text, textBoxNumber.Text,
                textBoxOwner.Text, textBoxDirec.Text, textBoxPoveritel.Text, richTextBoxReasons);
        }


    }
}
