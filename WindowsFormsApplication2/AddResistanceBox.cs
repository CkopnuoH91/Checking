using System;
using System.Windows.Forms;

namespace Сhecking
{
    public partial class AddResistanceBox : Form
    {
        public AddResistanceBox()
        {
            InitializeComponent();
        }
        public void EditResistanceBox(ResistanceBox ResBox)
        {
            if((ResBox as ResistanceBox2) != null){
                comboBoxTypeDevice.SelectedIndex = 1;
                numericUDRo1.Value = (decimal)ResBox.NullResistance;
                numericUDRo2.Value = (decimal)((ResistanceBox2)ResBox).NullResistance2;
                numericUDVarRo1.Value = (decimal)ResBox.VariationNullResistance;
                numericUDVarRo2.Value = (decimal)((ResistanceBox2)ResBox).VariationNullResistance2;
            }
            else
            {
                comboBoxTypeDevice.SelectedIndex = 0;
                numericUDRo1.Value = (decimal)ResBox.NullResistance;
                numericUDVarRo1.Value = (decimal)ResBox.VariationNullResistance;
            }

            textBoxDevice.Text = ResBox.Model;
            textBoxAccuracy.Text = ResBox.Accuracy;
            nUDNumberDecade.Value = (decimal)ResBox.NumberDecade;
            numericUpDownRmin.Value = (decimal)ResBox.MinResistance;
            numericUpDownRmax.Value = (decimal)ResBox.MaxResistance;
            maskedTextBoxTemperature.Text = ResBox.Temperature;
            maskedTextBoxHumidity.Text = ResBox.Humidity;
            maskedTextBoxPressure.Text = ResBox.Pressure;
            
            switch (ResBox.RelativeError.Method.Name.Trim())
            {
                case "Formula1":
                    {
                        radioButtonType1.Checked = true;
                        numericUpDownA.Value = (decimal)ResBox.ConstantABC[0];
                        numericUpDownB.Value = (decimal)ResBox.ConstantABC[1];
                        numericUpDownC.Value = (decimal)ResBox.ConstantABC[2];
                        break;
                    }
                    
                case "Formula2":
                    {
                        radioButtonType2.Checked = true;
                        numericUpDownA.Value = (decimal)ResBox.ConstantABC[0];
                        numericUpDownB.Value = (decimal)ResBox.ConstantABC[1];
                        break;
                    }
                case "Formula3":
                    {
                        radioButtonType3.Checked = true;
                        numericUpDownA.Value = (decimal)ResBox.ConstantABC[0];
                        numericUpDownB.Value = (decimal)ResBox.ConstantABC[1];
                        numericUpDownC.Value = (decimal)ResBox.ConstantABC[2];
                        break;
                    }
                    
                case "Formula4":
                    {
                        radioButtonType4.Checked = true;
                        numericUpDownA.Value = (decimal)ResBox.ConstantABC[0];
                        numericUpDownB.Value = (decimal)ResBox.ConstantABC[1];
                        numericUpDownC.Value = (decimal)ResBox.ConstantABC[2];
                        break;
                    }
                    
                case "Formula5":
                    {
                        radioButtonType5.Checked = true;
                        numericUpDownA.Value = (decimal)ResBox.ConstantABC[0];
                    }
                    break;
                default: MessageBox.Show("При загрузке данных о формуле произошла ошибка", "Ошибка загрузки данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;
            }

        }
        public void DefaultParams()
        {
            comboBoxTypeDevice.SelectedIndex = 0;
            maskedTextBoxHumidity.Text = "25-80%";
            maskedTextBoxPressure.Text = "84-106.7%";
            radioButtonType1.Checked = true;
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void comboBoxTypeDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTypeDevice.SelectedIndex == 0)
                SelectedOneNullResistance();
            else SelectedTwoNullResistance();
        }
        private void SelectedOneNullResistance()
        {
            labelRo1.Visible = false;
            labelRo2.Visible = false;
            numericUDRo2.Visible = false;
            numericUDVarRo2.Visible = false;
        }
        private void SelectedTwoNullResistance()
        {
            labelRo1.Visible = true;
            labelRo2.Visible = true;
            numericUDRo2.Visible = true;
            numericUDVarRo2.Visible = true;
        }
        private void VisibleB() 
        {
            labelB.Visible = true;
            numericUpDownB.Visible = true;
        }
        private void radioButtonType1_CheckedChanged(object sender, EventArgs e)
        {
            VisibleB(); 
            labelC.Text = "c =";
            SelectedType134();
            numericUpDownC.Value = 0;
        }
        private void radioButtonType2_CheckedChanged(object sender, EventArgs e)
        {
            VisibleB(); 
            labelC.Visible = false;
            numericUpDownC.Visible = false;
        }
        private void radioButtonType3_CheckedChanged(object sender, EventArgs e)
        {
            VisibleB(); 
            labelC.Text = "m =";
            SelectedType134();
            numericUpDownC.Value = nUDNumberDecade.Value;
        }
        private void radioButtonType4_CheckedChanged(object sender, EventArgs e)
        {
            VisibleB();
            labelC.Text = "c =";
            SelectedType134();
            numericUpDownC.Value = 0;
        }
        private void radioButtonType5_CheckedChanged(object sender, EventArgs e)
        {
            labelB.Visible = false;
            labelC.Visible = false;
            numericUpDownB.Visible = false;
            numericUpDownC.Visible = false;
        }
        private void SelectedType134()
        {
            labelC.Visible = true;
            numericUpDownC.Visible = true;
        }
        private double[] SelectedFormulsType134(double[] constants)
        {
            constants[0] = (double)numericUpDownA.Value;
            constants[1] = (double)numericUpDownB.Value;
            constants[2] = (double)numericUpDownC.Value;

            return constants;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ResistanceBox Rb;
            Formuls Formula = new Formuls();
            
            if (comboBoxTypeDevice.SelectedIndex == 0)
            {
                Rb = new ResistanceBox();
            }
            else
            {
                Rb = new ResistanceBox2();
            }

            if (textBoxDevice.Text == "")
            {
                toolTip1.Show("Введите модель магазина сопротивлений", textBoxDevice, 3000);
                return;
            }
            else
            {
                Rb.Model = textBoxDevice.Text;
            }

            if (textBoxAccuracy.Text == "")
            {
                toolTip1.Show("Введите класс точности прибора", textBoxAccuracy, 3000);
                return;
            }
            else
            {
                Rb.Accuracy = textBoxAccuracy.Text;
            }

            Rb.NumberDecade = (int)nUDNumberDecade.Value;
            Rb.MinResistance = (double)numericUpDownRmin.Value;
            Rb.MaxResistance = (double)numericUpDownRmax.Value;

            if (comboBoxTypeDevice.SelectedIndex == 0)
            {
                Rb.NullResistance = (double)numericUDRo1.Value;
                Rb.VariationNullResistance = (double)numericUDVarRo1.Value;
            }
            else
            {
                Rb.NullResistance = (double)numericUDRo1.Value;
                Rb.VariationNullResistance = (double)numericUDVarRo1.Value;
                (Rb as ResistanceBox2).NullResistance2 = (double)numericUDRo2.Value;
                (Rb as ResistanceBox2).VariationNullResistance2 = (double)numericUDVarRo2.Value;
            }

            double[] constants = new double[3];

            if (radioButtonType1.Checked)
            {
                constants = new double[3];
                constants = SelectedFormulsType134(constants);
                Rb.RelativeError = new Func<double, double[], double>(Formula.Formula1);
            }

            if (radioButtonType2.Checked)
            {
                constants = new double[2];
                constants[0] = (double)numericUpDownA.Value;
                constants[1] = (double)numericUpDownB.Value;
                Rb.RelativeError = new Func<double, double[], double>(Formula.Formula2);
            }

            if (radioButtonType3.Checked)
            {
                constants = new double[3];
                constants = SelectedFormulsType134(constants);
                Rb.RelativeError = new Func<double, double[], double>(Formula.Formula3);
            }

            if (radioButtonType4.Checked)
            {
                constants = new double[3];
                constants = SelectedFormulsType134(constants);
                Rb.RelativeError = new Func<double, double[], double>(Formula.Formula4);
            }

            if (radioButtonType5.Checked)
            {
                constants = new double[1];
                constants[0] = (double)numericUpDownA.Value;
                Rb.RelativeError = new Func<double, double[], double>(Formula.Formula5);
            }
            Rb.ConstantABC = constants;
            Rb.Temperature = maskedTextBoxTemperature.Text;
            Rb.Humidity = maskedTextBoxHumidity.Text;
            Rb.Pressure = maskedTextBoxPressure.Text;
             
            Form1 f = Owner as Form1;

            if (f != null)
            {
                if (this.Text == "Редактирование прибора")
                {
                    f.R.Replace(f.indexOfList, Rb);
                    f.listBox1.Items.Clear();
                    f.R.ShowModel(f.listBox1);
                    f.listBox1.SelectedIndex = f.indexOfList;
                }

                else 
                {
                    f.listBox1.Items.Clear();
                    f.R.AddRb(Rb);
                    f.R.ShowModel(f.listBox1);
                    f.listBox1.SelectedIndex = 0;
                }
            }

            Close();
        }
    }
}
