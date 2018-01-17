using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Сhecking
{
    /// <summary>
    /// 
    /// </summary>
    public class ResistanceBoxes
    {
        List<ResistanceBox> ListOfResistanceBoxes = new List<ResistanceBox>();

        /// <summary>
        /// Список магазинов сопротивления
        /// </summary>
        public List<ResistanceBox> GetListOfResistanceBoxes
        {
            get { return ListOfResistanceBoxes; }
        }

        /// <summary>
        /// Список магазинов сопротивления по умолчанию
        /// </summary>
        public void DefaultDevice()
        {
            Formuls Formula = new Formuls();

            ResistanceBox2 P4834 = new ResistanceBox2("P4834", "0,02/2,5*10^(-7)", 8, "20±2°С", "25-80%", "84-106,7кПа");
            P4834.MinResistance = 0.01;
            P4834.MaxResistance = 111111.1;
            P4834.NullResistance = 0.012;
            P4834.NullResistance2 = 0.024;
            P4834.VariationNullResistance = 0.0012;
            P4834.VariationNullResistance2 = 0.0024;
            P4834.RelativeError = new Func<double, double[], double>(Formula.Formula1);
            P4834.ConstantABC = new double[] { 0.02, 0.00000025, 1000000 };
            ListOfResistanceBoxes.Add(P4834);

            ResistanceBox2 P4831 = new ResistanceBox2("P4831", "0,02/2,0*10^(-6)", 7, "20±2°С", "25-80%", "84-106,7кПа");
            P4831.MinResistance = 0.01;
            P4831.MaxResistance = 111111.10;
            P4831.NullResistance = 0.021;
            P4831.NullResistance2 = 0.021;
            P4831.VariationNullResistance = 0.0021;
            P4831.VariationNullResistance2 = 0.0021;
            P4831.RelativeError = new Func<double, double[], double>(Formula.Formula1);
            P4831.ConstantABC = new double[] { 0.02, 0.000002, P4831.MaxResistance };
            ListOfResistanceBoxes.Add(P4831);

            ResistanceBox P327 = new ResistanceBox("P327", "0,01/1,5*10^(-6)", 6, "20±1°С", "25-80%", "84-106,7кПа");
            P327.MinResistance = 0.1;
            P327.MaxResistance = 111111.0;
            P327.NullResistance = 0.012;
            P327.VariationNullResistance = 0.001;
            P327.RelativeError = new Func<double, double[], double>(Formula.Formula1);
            P327.ConstantABC = new double[] { 0.01, 0.0000015, P327.MaxResistance };
            ListOfResistanceBoxes.Add(P327);

            ResistanceBox MCP_60M = new ResistanceBox("MCP-60M", "0,02", 6, "20±2°С", "25-80%", "84-106,7кПа");
            MCP_60M.MinResistance = 0.01;
            MCP_60M.MaxResistance = 11111.1;
            MCP_60M.NullResistance = 0.018;
            MCP_60M.VariationNullResistance = 0.002;
            MCP_60M.RelativeError = new Func<double, double[], double>(Formula.Formula3);
            MCP_60M.ConstantABC = new double[] { 0.02, 0.02, MCP_60M.NumberDecade };
            ListOfResistanceBoxes.Add(MCP_60M);

            ResistanceBox MCP_60 = new ResistanceBox("MCP-60", "0,02", 6, "20±2°С", "25-80%", "84-106,7кПа");
            MCP_60.MinResistance = 0.01;
            MCP_60.MaxResistance = 11111.1;
            MCP_60.NullResistance = 0.011;
            MCP_60.VariationNullResistance = 0.0025;
            MCP_60.RelativeError = new Func<double, double[], double>(Formula.Formula3);
            MCP_60.ConstantABC = new double[] { 0.02, 0.1, 1 };
            ListOfResistanceBoxes.Add(MCP_60);

            ResistanceBox P33 = new ResistanceBox("P33", "0,2/6*10^(-6)", 6, "20±2°С", "25-80%", "84-106,7кПа");
            P33.MinResistance = 0.1;
            P33.MaxResistance = 99999.9;
            P33.NullResistance = 0.06;
            P33.VariationNullResistance = 0.006;
            P33.RelativeError = new Func<double, double[], double>(Formula.Formula1);
            P33.ConstantABC = new double[] { 0.2, 0.000006, P33.MaxResistance };
            ListOfResistanceBoxes.Add(P33);

            ResistanceBox2 P4830_1 = new ResistanceBox2("P4830/1", "0,05/2,5*10^(-5)", 6, "20±2°С", "25-80%", "84-106,7кПа");
            P4830_1.MinResistance = 0.01;
            P4830_1.MaxResistance = 12222.21;
            P4830_1.NullResistance = 0.03;
            P4830_1.NullResistance2 = 0.02;
            P4830_1.VariationNullResistance = 0.003;
            P4830_1.VariationNullResistance2 = 0.002;
            P4830_1.RelativeError = new Func<double, double[], double>(Formula.Formula1);
            P4830_1.ConstantABC = new double[] { 0.05, 0.000025, P4830_1.MaxResistance };
            ListOfResistanceBoxes.Add(P4830_1);

            ResistanceBox2 P4830_2 = new ResistanceBox2("P4830/2", "0,05/2,5*10^(-6)", 6, "20±2°С", "25-80%", "84-106,7кПа");
            P4830_2.MinResistance = 0.1;
            P4830_2.MaxResistance = 122222.1;
            P4830_2.NullResistance = 0.03;
            P4830_2.NullResistance2 = 0.015;
            P4830_2.VariationNullResistance = 0.003;
            P4830_2.VariationNullResistance2 = 0.0015;
            P4830_2.RelativeError = new Func<double, double[], double>(Formula.Formula1);
            P4830_2.ConstantABC = new double[] { 0.05, 0.0000025, P4830_2.MaxResistance };
            ListOfResistanceBoxes.Add(P4830_2);

            ResistanceBox MCP_63 = new ResistanceBox("MCP-63", "0,05/4*10^(-6)", 7, "20±2°С", "25-80%", "84-106,7кПа");
            MCP_63.MinResistance = 0.01;
            MCP_63.MaxResistance = 111111.1;
            MCP_63.NullResistance = 0.035;
            MCP_63.VariationNullResistance = 0.0035;
            MCP_63.RelativeError = new Func<double, double[], double>(Formula.Formula4);
            MCP_63.ConstantABC = new double[] { 0.05, 0.000004, MCP_63.MaxResistance };
            ListOfResistanceBoxes.Add(MCP_63);

            //ResistanceBox P40103 = new ResistanceBox("Р40103", "0,1", 1, "20±2°С", "25-80%", "84-106,7кПа");
            //P40103.MinResistance = 0.01;
            //P40103.MaxResistance = 111111.1;
            //P40103.NullResistance = 0.035;
            //P40103.VariationNullResistance = 0.0035;
            //P40103.RelativeError = new Func<double, double[], double>(Formula.Formula5);
            //P40103.ConstantABC = new double[] { 0.1 };
            //ListOfResistanceBoxes.Add(P40103);



        }

        /// <summary>
        /// Добавляет новый магазин сопротивления в список
        /// </summary>
        /// <param name="res">Добавляемый магазин сопротивления</param>
        public void AddRb(ResistanceBox res)
        {
            ListOfResistanceBoxes.Add(res);
        }
        /// <summary>
        /// Заменяет магазин сопротивления с указанным индексом
        /// </summary>
        /// <param name="index"></param>
        /// <param name="res"></param>
        public void Replace(int index, ResistanceBox res)
        {
            ListOfResistanceBoxes.RemoveAt(index);
            ListOfResistanceBoxes.Insert(index, res);
        }

        /// <summary>
        /// Отображает список магазинов сопротивления в указанном компоненте ListBox
        /// </summary>
        /// <param name="L"></param>
        public void ShowModel(ListBox L)
        {
            foreach (ResistanceBox ResBox in ListOfResistanceBoxes)
            {
                L.Items.Add(ResBox.Model);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearList()
        {
            ListOfResistanceBoxes.Clear();
        }

        /// <summary>
        /// Сохраняет список магазинов
        /// </summary>
        /// <param name="file"></param>
        public void SaveToFile(StreamWriter file)
        {
            foreach (var item in ListOfResistanceBoxes)
            {
                item.Save(file);
            }
        }

        public void DeleteRb(ResistanceBox res)
        {
            ListOfResistanceBoxes.Remove(res);
        }

        public ResistanceBox FindResistanceBoxInListBox(ListBox L)
        {
            ResistanceBox Rb = new ResistanceBox();
            foreach (ResistanceBox ResBox in ListOfResistanceBoxes)
            {
                if (ResBox.Model == L.SelectedItem.ToString())
                {
                    Rb = ResBox;
                }
            }
            return Rb;
        }

    }


    public class ResistanceBox
    {
        public Func<double, double[], double> RelativeError;

        public string Model { get; set; }
        public string Accuracy { get; set; }
        public int NumberDecade { get; set; }
        public double NullResistance { get; set; }
        public double VariationNullResistance { get; set; }
        public double MinResistance { get; set; }
        public double MaxResistance { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public string Pressure { get; set; }
        public double[] ConstantABC { get; set; }

        public ResistanceBox()
        {
        }

        public ResistanceBox(string Model)
        {
            this.Model = Model;
        }

        public ResistanceBox(string Model, string Accuracy, int NumberDecade,
            string Temperature, string Humidity, string Pressure)
            : this(Model)
        {
            this.Accuracy = Accuracy;
            this.NumberDecade = NumberDecade;
            this.Temperature = Temperature;
            this.Humidity = Humidity;
            this.Pressure = Pressure;
        }

        public virtual void Show(ListBox L)
        {
            L.Items.Clear();
            L.Items.Add("Модель: " + Model.ToString());
            L.Items.Add("Класс точности, c/d: " + Accuracy.ToString());
            L.Items.Add("Число декад: " + NumberDecade.ToString());
            L.Items.Add("Нижний предел Rmin: " + MinResistance.ToString() + " Ом");
            L.Items.Add("Верхний предел Rmax: " + MaxResistance.ToString() + " Ом");
            L.Items.Add("Среднее значение Rо: " + NullResistance.ToString() + " Ом");
            L.Items.Add("Вариация Rвар.: " + VariationNullResistance.ToString() + " Ом");
            L.Items.Add("Температура: " + Temperature.ToString());
            L.Items.Add("Влажность: " + Humidity.ToString());
            L.Items.Add("Давление: " + Pressure.ToString());

            string str = "";
            switch (RelativeError.Method.ToString())
            {
                case "Double Formula1(Double, Double[])":
                    str = "±[" + ConstantABC[0].ToString() + "+" + ConstantABC[1].ToString() + "·(" + ConstantABC[2].ToString() + "/R-1)]";
                    break;
                case "Double Formula2(Double, Double[])":
                    str = "±[" + ConstantABC[0].ToString() + "+" + ConstantABC[1].ToString() + "/R-1]";
                    break;
                case "Double Formula3(Double, Double[])":
                    str = "±[" + ConstantABC[0].ToString() + "+" + ConstantABC[1].ToString() + "·(" + ConstantABC[2].ToString() + "/R)]";
                    break;
                case "Double Formula4(Double, Double[])":
                    str = "±[" + ConstantABC[0].ToString() + "+" + ConstantABC[1].ToString() + "·(" + ConstantABC[2].ToString() + "/R)]";
                    break;
                case "Double Formula5(Double, Double[])":
                    str = "±[" + ConstantABC[0].ToString() + "]";
                    break;
                default: str = "Ошибка при выводе формулы";
                    break;
            }
            L.Items.Add("Отклонение в %: " + str);
        }

        public virtual string GetIdString()
        {
            return "[1]";
        }

        public virtual void Save(StreamWriter sw)
        {
            sw.WriteLine(this.GetIdString());
            sw.WriteLine(this.Model);
            sw.WriteLine(this.Accuracy);
            sw.WriteLine(this.NumberDecade.ToString());
            sw.WriteLine(this.MinResistance.ToString());
            sw.WriteLine(this.MaxResistance.ToString());
            sw.WriteLine(this.NullResistance.ToString());
            sw.WriteLine(this.VariationNullResistance.ToString());
            sw.WriteLine(this.Temperature);
            sw.WriteLine(this.Humidity);
            sw.WriteLine(this.Pressure);
            sw.WriteLine(this.RelativeError.Method.ToString());
            foreach (var item in this.ConstantABC)
            {
                sw.Write(item.ToString() + ";");
            }
            sw.WriteLine();
        }
        protected void FirstPartRead(ResistanceBox Rb, StreamReader sr)
        {
            Rb.Model = sr.ReadLine().Trim();
            Rb.Accuracy = sr.ReadLine().Trim();
            Rb.NumberDecade = Convert.ToInt32(sr.ReadLine().Trim());

            double MinResistance;
            double.TryParse(sr.ReadLine().Trim(), out MinResistance);
            Rb.MinResistance = MinResistance;

            double MaxResistance;
            double.TryParse(sr.ReadLine().Trim(), out MaxResistance);
            Rb.MaxResistance = MaxResistance;

            double NullResistance;
            double.TryParse(sr.ReadLine().Trim(), out NullResistance);
            Rb.NullResistance = NullResistance;

            double VariationNullResistance;
            double.TryParse(sr.ReadLine().Trim(), out VariationNullResistance);
            Rb.VariationNullResistance = VariationNullResistance;
        }

        protected void SecondPartRead(ResistanceBox Rb, StreamReader sr)
        {
            Rb.Temperature = sr.ReadLine().Trim();
            Rb.Humidity = sr.ReadLine().Trim();
            Rb.Pressure = sr.ReadLine().Trim();

            Formuls formuls = new Formuls();
            string formula = sr.ReadLine();
            string[] constants = sr.ReadLine().Trim().Split(';');
            Rb.ConstantABC = new double[constants.Length - 1];

            for (int i = 0; i < constants.Length - 1; i++)
            {
                double d;
                double.TryParse(constants[i], out d);
                Rb.ConstantABC[i] = d;
            }

            switch (formula)
            {
                case "Double Formula1(Double, Double[])":
                    Rb.RelativeError = new Func<double, double[], double>(formuls.Formula1);

                    break;
                case "Double Formula2(Double, Double[])":
                    Rb.RelativeError = new Func<double, double[], double>(formuls.Formula2);
                    break;
                case "Double Formula3(Double, Double[])":
                    Rb.RelativeError = new Func<double, double[], double>(formuls.Formula3);
                    break;
                case "Double Formula4(Double, Double[])":
                    Rb.RelativeError = new Func<double, double[], double>(formuls.Formula4);
                    break;
                case "Double Formula5(Double, Double[])":
                    Rb.RelativeError = new Func<double, double[], double>(formuls.Formula5);
                    break;
                default:
                    break;
            }
        }

        public virtual ResistanceBox Read(StreamReader sr)
        {
            ResistanceBox Rb = new ResistanceBox();
            FirstPartRead(Rb, sr);
            SecondPartRead(Rb, sr);
            return Rb;
        }
    }

    class ResistanceBox2 : ResistanceBox
    {
        public double NullResistance2 { get; set; }
        public double VariationNullResistance2 { get; set; }

        public ResistanceBox2()
        {

        }

        public ResistanceBox2(string Model, string Accuracy, int NumberDecade,
            string Temperature, string Humidity, string Pressure)
            : base(Model, Accuracy, NumberDecade, Temperature, Humidity, Pressure)
        {
        }

        public override void Show(ListBox L)
        {
            base.Show(L);
            L.Items.RemoveAt(6);
            L.Items.RemoveAt(5);
            L.Items.Insert(5, "Среднее значение Rо(на зажимах №1): " + NullResistance.ToString() + " Ом");
            L.Items.Insert(6, "Вариация Rвар.(на зажимах №1): " + VariationNullResistance.ToString() + " Ом");
            L.Items.Insert(7, "Среднее значение Rо(на зажимах №2): " + NullResistance2.ToString() + " Ом");
            L.Items.Insert(8, "Вариация Rвар.(на зажимах №2): " + VariationNullResistance2.ToString() + " Ом");
        }

        public override string GetIdString()
        {
            return "[2]";
        }

        public override void Save(StreamWriter sw)
        {
            sw.WriteLine(this.GetIdString());
            sw.WriteLine(this.Model);
            sw.WriteLine(this.Accuracy);
            sw.WriteLine(this.NumberDecade.ToString());
            sw.WriteLine(this.MinResistance.ToString());
            sw.WriteLine(this.MaxResistance.ToString());
            sw.WriteLine(this.NullResistance.ToString());
            sw.WriteLine(this.VariationNullResistance.ToString());
            sw.WriteLine(this.NullResistance2.ToString());
            sw.WriteLine(this.VariationNullResistance2.ToString());
            sw.WriteLine(this.Temperature);
            sw.WriteLine(this.Humidity);
            sw.WriteLine(this.Pressure);
            sw.WriteLine(this.RelativeError.Method.ToString());
            foreach (var item in this.ConstantABC)
            {
                sw.Write(item.ToString() + ";");
            }
            sw.WriteLine();
        }

        public override ResistanceBox Read(StreamReader sr)
        {
            ResistanceBox2 Rb = new ResistanceBox2();
            FirstPartRead(Rb, sr);
            double NullResistance2;
            double.TryParse(sr.ReadLine().Trim(), out NullResistance2);
            Rb.NullResistance2 = NullResistance2;

            double VariationNullResistance2;
            double.TryParse(sr.ReadLine().Trim(), out VariationNullResistance2);
            Rb.VariationNullResistance2 = VariationNullResistance2;
            SecondPartRead(Rb, sr);

            return Rb;
        }
    }

    class Formuls
    {

        public double Formula1(double R, params double[] param)
        {
            return param[0] + param[1] * (param[2] / R - 1);
        }

        public double Formula2(double R, params double[] param)
        {
            return param[0] + param[1] / R - 1;
        }

        public double Formula3(double R, params double[] param)
        {
            return param[0] + param[1] * param[2] / R;
        }

        public double Formula4(double R, params double[] param)
        {
            return param[0] + param[1] * (param[2] / R);
        }

        public double Formula5(double R, params double[] param)
        {
            return param[0];
        }
    }
}
