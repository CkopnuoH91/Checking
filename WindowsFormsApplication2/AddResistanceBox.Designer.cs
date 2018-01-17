namespace Сhecking
{
    partial class AddResistanceBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddResistanceBox));
            this.labelDevice = new System.Windows.Forms.Label();
            this.labelAccuracy = new System.Windows.Forms.Label();
            this.labelNumberDecade = new System.Windows.Forms.Label();
            this.labelMaxResistance = new System.Windows.Forms.Label();
            this.labelMinResistance = new System.Windows.Forms.Label();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.labelHumidity = new System.Windows.Forms.Label();
            this.labelPressure = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.labelVariationNullResistance = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maskedTextBoxPressure = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxHumidity = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxTemperature = new System.Windows.Forms.MaskedTextBox();
            this.labelNullResistance = new System.Windows.Forms.Label();
            this.labelTypeDevice = new System.Windows.Forms.Label();
            this.comboBoxTypeDevice = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxDevice = new System.Windows.Forms.TextBox();
            this.textBoxAccuracy = new System.Windows.Forms.TextBox();
            this.nUDNumberDecade = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonType5 = new System.Windows.Forms.RadioButton();
            this.radioButtonType4 = new System.Windows.Forms.RadioButton();
            this.radioButtonType3 = new System.Windows.Forms.RadioButton();
            this.labelC = new System.Windows.Forms.Label();
            this.radioButtonType1 = new System.Windows.Forms.RadioButton();
            this.labelB = new System.Windows.Forms.Label();
            this.radioButtonType2 = new System.Windows.Forms.RadioButton();
            this.labelA = new System.Windows.Forms.Label();
            this.numericUpDownC = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownB = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownA = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRmin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRmax = new System.Windows.Forms.NumericUpDown();
            this.labelRo1 = new System.Windows.Forms.Label();
            this.labelRo2 = new System.Windows.Forms.Label();
            this.numericUDRo1 = new System.Windows.Forms.NumericUpDown();
            this.numericUDRo2 = new System.Windows.Forms.NumericUpDown();
            this.numericUDVarRo1 = new System.Windows.Forms.NumericUpDown();
            this.numericUDVarRo2 = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDNumberDecade)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDRo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDRo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDVarRo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDVarRo2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDevice
            // 
            this.labelDevice.AutoSize = true;
            this.labelDevice.Location = new System.Drawing.Point(12, 47);
            this.labelDevice.Name = "labelDevice";
            this.labelDevice.Size = new System.Drawing.Size(48, 13);
            this.labelDevice.TabIndex = 0;
            this.labelDevice.Text = "Прибор:";
            // 
            // labelAccuracy
            // 
            this.labelAccuracy.AutoSize = true;
            this.labelAccuracy.Location = new System.Drawing.Point(12, 72);
            this.labelAccuracy.Name = "labelAccuracy";
            this.labelAccuracy.Size = new System.Drawing.Size(112, 13);
            this.labelAccuracy.TabIndex = 1;
            this.labelAccuracy.Text = "Класс точности, c/d:";
            // 
            // labelNumberDecade
            // 
            this.labelNumberDecade.AutoSize = true;
            this.labelNumberDecade.Location = new System.Drawing.Point(12, 110);
            this.labelNumberDecade.Name = "labelNumberDecade";
            this.labelNumberDecade.Size = new System.Drawing.Size(75, 13);
            this.labelNumberDecade.TabIndex = 2;
            this.labelNumberDecade.Text = "Число декад:";
            // 
            // labelMaxResistance
            // 
            this.labelMaxResistance.AutoSize = true;
            this.labelMaxResistance.Location = new System.Drawing.Point(12, 161);
            this.labelMaxResistance.Name = "labelMaxResistance";
            this.labelMaxResistance.Size = new System.Drawing.Size(121, 13);
            this.labelMaxResistance.TabIndex = 3;
            this.labelMaxResistance.Text = "Верхний предел Rmax:";
            // 
            // labelMinResistance
            // 
            this.labelMinResistance.AutoSize = true;
            this.labelMinResistance.Location = new System.Drawing.Point(12, 135);
            this.labelMinResistance.Name = "labelMinResistance";
            this.labelMinResistance.Size = new System.Drawing.Size(116, 13);
            this.labelMinResistance.TabIndex = 4;
            this.labelMinResistance.Text = "Нижний предел Rmin:";
            // 
            // labelTemperature
            // 
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Location = new System.Drawing.Point(6, 30);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(77, 13);
            this.labelTemperature.TabIndex = 5;
            this.labelTemperature.Text = "Температура:";
            // 
            // labelHumidity
            // 
            this.labelHumidity.AutoSize = true;
            this.labelHumidity.Location = new System.Drawing.Point(168, 30);
            this.labelHumidity.Name = "labelHumidity";
            this.labelHumidity.Size = new System.Drawing.Size(66, 13);
            this.labelHumidity.TabIndex = 6;
            this.labelHumidity.Text = "Влажность:";
            // 
            // labelPressure
            // 
            this.labelPressure.AutoSize = true;
            this.labelPressure.Location = new System.Drawing.Point(321, 30);
            this.labelPressure.Name = "labelPressure";
            this.labelPressure.Size = new System.Drawing.Size(61, 13);
            this.labelPressure.TabIndex = 7;
            this.labelPressure.Text = "Давление:";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(6, 16);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(130, 13);
            this.labelType.TabIndex = 8;
            this.labelType.Text = "Выберите тип формулы:";
            // 
            // labelVariationNullResistance
            // 
            this.labelVariationNullResistance.AutoSize = true;
            this.labelVariationNullResistance.Location = new System.Drawing.Point(259, 136);
            this.labelVariationNullResistance.Name = "labelVariationNullResistance";
            this.labelVariationNullResistance.Size = new System.Drawing.Size(232, 13);
            this.labelVariationNullResistance.TabIndex = 9;
            this.labelVariationNullResistance.Text = "Вариация начального сопротивления Rвар.:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.maskedTextBoxPressure);
            this.groupBox1.Controls.Add(this.maskedTextBoxHumidity);
            this.groupBox1.Controls.Add(this.maskedTextBoxTemperature);
            this.groupBox1.Controls.Add(this.labelTemperature);
            this.groupBox1.Controls.Add(this.labelHumidity);
            this.groupBox1.Controls.Add(this.labelPressure);
            this.groupBox1.Location = new System.Drawing.Point(15, 314);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 69);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Нормальные условия поверки";
            // 
            // maskedTextBoxPressure
            // 
            this.maskedTextBoxPressure.Location = new System.Drawing.Point(389, 27);
            this.maskedTextBoxPressure.Mask = "00-000.0 кПа";
            this.maskedTextBoxPressure.Name = "maskedTextBoxPressure";
            this.maskedTextBoxPressure.Size = new System.Drawing.Size(73, 20);
            this.maskedTextBoxPressure.TabIndex = 21;
            // 
            // maskedTextBoxHumidity
            // 
            this.maskedTextBoxHumidity.Location = new System.Drawing.Point(242, 27);
            this.maskedTextBoxHumidity.Mask = "00-00%";
            this.maskedTextBoxHumidity.Name = "maskedTextBoxHumidity";
            this.maskedTextBoxHumidity.Size = new System.Drawing.Size(73, 20);
            this.maskedTextBoxHumidity.TabIndex = 20;
            // 
            // maskedTextBoxTemperature
            // 
            this.maskedTextBoxTemperature.Location = new System.Drawing.Point(89, 27);
            this.maskedTextBoxTemperature.Mask = "00±00°С";
            this.maskedTextBoxTemperature.Name = "maskedTextBoxTemperature";
            this.maskedTextBoxTemperature.Size = new System.Drawing.Size(73, 20);
            this.maskedTextBoxTemperature.TabIndex = 19;
            // 
            // labelNullResistance
            // 
            this.labelNullResistance.AutoSize = true;
            this.labelNullResistance.Location = new System.Drawing.Point(259, 110);
            this.labelNullResistance.Name = "labelNullResistance";
            this.labelNullResistance.Size = new System.Drawing.Size(261, 13);
            this.labelNullResistance.TabIndex = 11;
            this.labelNullResistance.Text = "Среднее значение начального сопротивления Rо:";
            // 
            // labelTypeDevice
            // 
            this.labelTypeDevice.AutoSize = true;
            this.labelTypeDevice.Location = new System.Drawing.Point(10, 20);
            this.labelTypeDevice.Name = "labelTypeDevice";
            this.labelTypeDevice.Size = new System.Drawing.Size(74, 13);
            this.labelTypeDevice.TabIndex = 12;
            this.labelTypeDevice.Text = "Тип прибора:";
            // 
            // comboBoxTypeDevice
            // 
            this.comboBoxTypeDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTypeDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeDevice.FormattingEnabled = true;
            this.comboBoxTypeDevice.Items.AddRange(new object[] {
            "С одним значением Ro",
            "С двумя значениями Ro"});
            this.comboBoxTypeDevice.Location = new System.Drawing.Point(133, 17);
            this.comboBoxTypeDevice.Name = "comboBoxTypeDevice";
            this.comboBoxTypeDevice.Size = new System.Drawing.Size(574, 21);
            this.comboBoxTypeDevice.TabIndex = 1;
            this.comboBoxTypeDevice.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypeDevice_SelectedIndexChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(590, 352);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(117, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxDevice
            // 
            this.textBoxDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDevice.Location = new System.Drawing.Point(133, 44);
            this.textBoxDevice.Name = "textBoxDevice";
            this.textBoxDevice.Size = new System.Drawing.Size(574, 20);
            this.textBoxDevice.TabIndex = 2;
            // 
            // textBoxAccuracy
            // 
            this.textBoxAccuracy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAccuracy.Location = new System.Drawing.Point(133, 69);
            this.textBoxAccuracy.Name = "textBoxAccuracy";
            this.textBoxAccuracy.Size = new System.Drawing.Size(574, 20);
            this.textBoxAccuracy.TabIndex = 3;
            // 
            // nUDNumberDecade
            // 
            this.nUDNumberDecade.Location = new System.Drawing.Point(134, 108);
            this.nUDNumberDecade.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDNumberDecade.Name = "nUDNumberDecade";
            this.nUDNumberDecade.Size = new System.Drawing.Size(120, 20);
            this.nUDNumberDecade.TabIndex = 4;
            this.nUDNumberDecade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.radioButtonType5);
            this.groupBox2.Controls.Add(this.radioButtonType4);
            this.groupBox2.Controls.Add(this.radioButtonType3);
            this.groupBox2.Controls.Add(this.labelC);
            this.groupBox2.Controls.Add(this.radioButtonType1);
            this.groupBox2.Controls.Add(this.labelB);
            this.groupBox2.Controls.Add(this.radioButtonType2);
            this.groupBox2.Controls.Add(this.labelA);
            this.groupBox2.Controls.Add(this.labelType);
            this.groupBox2.Controls.Add(this.numericUpDownC);
            this.groupBox2.Controls.Add(this.numericUpDownB);
            this.groupBox2.Controls.Add(this.numericUpDownA);
            this.groupBox2.Location = new System.Drawing.Point(15, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(692, 123);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Допускаемое отклонение, в % :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Введите константы:";
            // 
            // radioButtonType5
            // 
            this.radioButtonType5.AutoSize = true;
            this.radioButtonType5.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonType5.Image")));
            this.radioButtonType5.Location = new System.Drawing.Point(531, 43);
            this.radioButtonType5.Name = "radioButtonType5";
            this.radioButtonType5.Size = new System.Drawing.Size(51, 31);
            this.radioButtonType5.TabIndex = 15;
            this.radioButtonType5.TabStop = true;
            this.radioButtonType5.UseVisualStyleBackColor = true;
            this.radioButtonType5.CheckedChanged += new System.EventHandler(this.radioButtonType5_CheckedChanged);
            // 
            // radioButtonType4
            // 
            this.radioButtonType4.AutoSize = true;
            this.radioButtonType4.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonType4.Image")));
            this.radioButtonType4.Location = new System.Drawing.Point(413, 31);
            this.radioButtonType4.Name = "radioButtonType4";
            this.radioButtonType4.Size = new System.Drawing.Size(112, 50);
            this.radioButtonType4.TabIndex = 14;
            this.radioButtonType4.TabStop = true;
            this.radioButtonType4.UseVisualStyleBackColor = true;
            this.radioButtonType4.CheckedChanged += new System.EventHandler(this.radioButtonType4_CheckedChanged);
            // 
            // radioButtonType3
            // 
            this.radioButtonType3.AutoSize = true;
            this.radioButtonType3.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonType3.Image")));
            this.radioButtonType3.Location = new System.Drawing.Point(299, 33);
            this.radioButtonType3.Name = "radioButtonType3";
            this.radioButtonType3.Size = new System.Drawing.Size(108, 48);
            this.radioButtonType3.TabIndex = 13;
            this.radioButtonType3.TabStop = true;
            this.radioButtonType3.UseVisualStyleBackColor = true;
            this.radioButtonType3.CheckedChanged += new System.EventHandler(this.radioButtonType3_CheckedChanged);
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Location = new System.Drawing.Point(385, 91);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(22, 13);
            this.labelC.TabIndex = 37;
            this.labelC.Text = "c =";
            // 
            // radioButtonType1
            // 
            this.radioButtonType1.AutoSize = true;
            this.radioButtonType1.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonType1.Image")));
            this.radioButtonType1.Location = new System.Drawing.Point(24, 33);
            this.radioButtonType1.Name = "radioButtonType1";
            this.radioButtonType1.Size = new System.Drawing.Size(149, 50);
            this.radioButtonType1.TabIndex = 11;
            this.radioButtonType1.TabStop = true;
            this.radioButtonType1.UseVisualStyleBackColor = true;
            this.radioButtonType1.CheckedChanged += new System.EventHandler(this.radioButtonType1_CheckedChanged);
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(253, 91);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(22, 13);
            this.labelB.TabIndex = 36;
            this.labelB.Text = "b =";
            // 
            // radioButtonType2
            // 
            this.radioButtonType2.AutoSize = true;
            this.radioButtonType2.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonType2.Image")));
            this.radioButtonType2.Location = new System.Drawing.Point(179, 29);
            this.radioButtonType2.Name = "radioButtonType2";
            this.radioButtonType2.Size = new System.Drawing.Size(114, 57);
            this.radioButtonType2.TabIndex = 12;
            this.radioButtonType2.TabStop = true;
            this.radioButtonType2.UseVisualStyleBackColor = true;
            this.radioButtonType2.CheckedChanged += new System.EventHandler(this.radioButtonType2_CheckedChanged);
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Location = new System.Drawing.Point(119, 91);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(22, 13);
            this.labelA.TabIndex = 35;
            this.labelA.Text = "a =";
            // 
            // numericUpDownC
            // 
            this.numericUpDownC.DecimalPlaces = 10;
            this.numericUpDownC.Increment = new decimal(new int[] {
            1,
            0,
            0,
            655360});
            this.numericUpDownC.Location = new System.Drawing.Point(413, 89);
            this.numericUpDownC.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDownC.Name = "numericUpDownC";
            this.numericUpDownC.Size = new System.Drawing.Size(92, 20);
            this.numericUpDownC.TabIndex = 18;
            // 
            // numericUpDownB
            // 
            this.numericUpDownB.DecimalPlaces = 10;
            this.numericUpDownB.Increment = new decimal(new int[] {
            1,
            0,
            0,
            655360});
            this.numericUpDownB.Location = new System.Drawing.Point(281, 89);
            this.numericUpDownB.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDownB.Name = "numericUpDownB";
            this.numericUpDownB.Size = new System.Drawing.Size(92, 20);
            this.numericUpDownB.TabIndex = 17;
            // 
            // numericUpDownA
            // 
            this.numericUpDownA.DecimalPlaces = 10;
            this.numericUpDownA.Increment = new decimal(new int[] {
            1,
            0,
            0,
            655360});
            this.numericUpDownA.Location = new System.Drawing.Point(147, 89);
            this.numericUpDownA.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDownA.Name = "numericUpDownA";
            this.numericUpDownA.Size = new System.Drawing.Size(92, 20);
            this.numericUpDownA.TabIndex = 16;
            this.numericUpDownA.ThousandsSeparator = true;
            // 
            // numericUpDownRmin
            // 
            this.numericUpDownRmin.DecimalPlaces = 4;
            this.numericUpDownRmin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numericUpDownRmin.Location = new System.Drawing.Point(134, 133);
            this.numericUpDownRmin.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDownRmin.Name = "numericUpDownRmin";
            this.numericUpDownRmin.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownRmin.TabIndex = 5;
            // 
            // numericUpDownRmax
            // 
            this.numericUpDownRmax.DecimalPlaces = 4;
            this.numericUpDownRmax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numericUpDownRmax.Location = new System.Drawing.Point(134, 159);
            this.numericUpDownRmax.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDownRmax.Name = "numericUpDownRmax";
            this.numericUpDownRmax.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownRmax.TabIndex = 6;
            // 
            // labelRo1
            // 
            this.labelRo1.AutoSize = true;
            this.labelRo1.Location = new System.Drawing.Point(523, 92);
            this.labelRo1.Name = "labelRo1";
            this.labelRo1.Size = new System.Drawing.Size(89, 13);
            this.labelRo1.TabIndex = 26;
            this.labelRo1.Text = "На зажимах №1";
            // 
            // labelRo2
            // 
            this.labelRo2.AutoSize = true;
            this.labelRo2.Location = new System.Drawing.Point(618, 92);
            this.labelRo2.Name = "labelRo2";
            this.labelRo2.Size = new System.Drawing.Size(89, 13);
            this.labelRo2.TabIndex = 27;
            this.labelRo2.Text = "На зажимах №2";
            this.labelRo2.Visible = false;
            // 
            // numericUDRo1
            // 
            this.numericUDRo1.DecimalPlaces = 4;
            this.numericUDRo1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numericUDRo1.Location = new System.Drawing.Point(526, 108);
            this.numericUDRo1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUDRo1.Name = "numericUDRo1";
            this.numericUDRo1.Size = new System.Drawing.Size(86, 20);
            this.numericUDRo1.TabIndex = 7;
            // 
            // numericUDRo2
            // 
            this.numericUDRo2.DecimalPlaces = 4;
            this.numericUDRo2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numericUDRo2.Location = new System.Drawing.Point(618, 108);
            this.numericUDRo2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUDRo2.Name = "numericUDRo2";
            this.numericUDRo2.Size = new System.Drawing.Size(89, 20);
            this.numericUDRo2.TabIndex = 9;
            this.numericUDRo2.Visible = false;
            // 
            // numericUDVarRo1
            // 
            this.numericUDVarRo1.DecimalPlaces = 5;
            this.numericUDVarRo1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.numericUDVarRo1.Location = new System.Drawing.Point(526, 134);
            this.numericUDVarRo1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUDVarRo1.Name = "numericUDVarRo1";
            this.numericUDVarRo1.Size = new System.Drawing.Size(86, 20);
            this.numericUDVarRo1.TabIndex = 8;
            // 
            // numericUDVarRo2
            // 
            this.numericUDVarRo2.DecimalPlaces = 5;
            this.numericUDVarRo2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.numericUDVarRo2.Location = new System.Drawing.Point(618, 134);
            this.numericUDVarRo2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUDVarRo2.Name = "numericUDVarRo2";
            this.numericUDVarRo2.Size = new System.Drawing.Size(89, 20);
            this.numericUDVarRo2.TabIndex = 10;
            this.numericUDVarRo2.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolTip1.ForeColor = System.Drawing.Color.Red;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.toolTip1.ToolTipTitle = "Внимание";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(590, 323);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(117, 23);
            this.buttonAdd.TabIndex = 38;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // AddResistanceBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 392);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.numericUDVarRo2);
            this.Controls.Add(this.numericUDVarRo1);
            this.Controls.Add(this.numericUDRo2);
            this.Controls.Add(this.numericUDRo1);
            this.Controls.Add(this.labelRo2);
            this.Controls.Add(this.labelRo1);
            this.Controls.Add(this.numericUpDownRmax);
            this.Controls.Add(this.numericUpDownRmin);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.nUDNumberDecade);
            this.Controls.Add(this.textBoxAccuracy);
            this.Controls.Add(this.textBoxDevice);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.comboBoxTypeDevice);
            this.Controls.Add(this.labelTypeDevice);
            this.Controls.Add(this.labelNullResistance);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelVariationNullResistance);
            this.Controls.Add(this.labelMinResistance);
            this.Controls.Add(this.labelMaxResistance);
            this.Controls.Add(this.labelNumberDecade);
            this.Controls.Add(this.labelAccuracy);
            this.Controls.Add(this.labelDevice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddResistanceBox";
            this.Text = "Добавление прибора";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDNumberDecade)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDRo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDRo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDVarRo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDVarRo2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDevice;
        private System.Windows.Forms.Label labelAccuracy;
        private System.Windows.Forms.Label labelNumberDecade;
        private System.Windows.Forms.Label labelMaxResistance;
        private System.Windows.Forms.Label labelMinResistance;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.Label labelHumidity;
        private System.Windows.Forms.Label labelPressure;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelVariationNullResistance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelNullResistance;
        private System.Windows.Forms.Label labelTypeDevice;
        private System.Windows.Forms.ComboBox comboBoxTypeDevice;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxDevice;
        private System.Windows.Forms.TextBox textBoxAccuracy;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPressure;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxHumidity;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTemperature;
        private System.Windows.Forms.NumericUpDown nUDNumberDecade;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonType3;
        private System.Windows.Forms.RadioButton radioButtonType1;
        private System.Windows.Forms.RadioButton radioButtonType2;
        private System.Windows.Forms.NumericUpDown numericUpDownRmin;
        private System.Windows.Forms.NumericUpDown numericUpDownRmax;
        private System.Windows.Forms.Label labelRo1;
        private System.Windows.Forms.Label labelRo2;
        private System.Windows.Forms.NumericUpDown numericUDRo1;
        private System.Windows.Forms.NumericUpDown numericUDRo2;
        private System.Windows.Forms.NumericUpDown numericUDVarRo1;
        private System.Windows.Forms.NumericUpDown numericUDVarRo2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown numericUpDownA;
        private System.Windows.Forms.NumericUpDown numericUpDownB;
        private System.Windows.Forms.NumericUpDown numericUpDownC;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.RadioButton radioButtonType5;
        private System.Windows.Forms.RadioButton radioButtonType4;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button buttonAdd;
    }
}