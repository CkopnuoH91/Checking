using System;
using System.Windows.Forms;

namespace Сhecking
{
    public partial class Protocol : Form
    {
        public Protocol()
        {
            InitializeComponent();
        }
        private void Protocol_Load(object sender, EventArgs e)
        {
            if ((Owner as Form1) != null)
            {
                textBoxType.Text = ((Form1)Owner).ShowtInExportForm.Model;
                textBoxClassAccuracy.Text = ((Form1)Owner).ShowtInExportForm.Accuracy;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCreateDocument_Click(object sender, EventArgs e)
        {
            string corresponds;
            if ((Owner as Form1).buttonVerificationCertificate.Enabled)
            {
                corresponds = "соответствует";
            }
            else
            {
                corresponds = "не соответствует";
            }
            ExportDataToWord ExpW = new ExportDataToWord();
            ExpW.CreateProtocol(dateTimePicker1, textBoxProtocolNumber.Text,
                textBoxType.Text, textBoxNumber.Text, textBoxClassAccuracy.Text,
                textBoxPredNaProv.Text, textBoxPoveritel.Text,
                (Owner as Form1).listExport, (Owner as Form1).ShowtInExportForm, corresponds);         
        }
    }
}
