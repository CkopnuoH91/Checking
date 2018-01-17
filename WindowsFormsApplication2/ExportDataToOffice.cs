using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Exel = Microsoft.Office.Interop.Excel;

namespace Сhecking
{
    class ExportDataToExсel
    {
        public void CreateExelDocument(DataGridView D1, DataGridView D2)
        {
            Exel.Application ExcelApp = new Exel.Application();
            try
            {               
                Exel.Workbook ExcelWorkBook = ExcelApp.Workbooks.Add();
                Exel.Worksheet ExcelWorkSheet = (Exel.Worksheet)ExcelWorkBook.Sheets[1];

                ExcelApp.DisplayAlerts = false;
                ExcelWorkSheet.get_Range("A1", "Z2000").Clear();
                ExcelWorkSheet.get_Range("A1", "Z2000").NumberFormat = "@";
                for (int i = 0; i < D1.RowCount; i++)
                {
                    for (int j = 0; j < D1.ColumnCount; j++)
                    {
                        ExcelWorkSheet.Cells[i + 1, j + 1] = D1[j, i].Value;
                    }
                }
                ExcelWorkSheet.get_Range("A1", "Z2000").NumberFormat = "General";
                ExcelWorkSheet.get_Range("A1", "Z2000").EntireColumn.AutoFit();

                ExcelWorkSheet = (Exel.Worksheet)ExcelWorkBook.Sheets[2];
                ExcelWorkSheet.get_Range("A1", "Z2000").Clear();
                ExcelWorkSheet.get_Range("A1", "Z2000").NumberFormat = "@";
                for (int i = 0; i < D2.RowCount; i++)
                {
                    for (int j = 0; j < D2.ColumnCount; j++)
                    {
                        ExcelWorkSheet.Cells[i + 1, j + 1] = D2[j, i].Value;
                    }
                }
                ExcelWorkSheet.get_Range("A1", "Z2000").NumberFormat = "General";
                ExcelWorkSheet.get_Range("A1", "Z2000").EntireColumn.AutoFit();

                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }
            catch 
            {
                MessageBox.Show("При создании документа возникла ошибка\nУбедитесь что перед запуском не возникает никаких диалоговых окон.", 
                    "При создании файла MS Exel возникла ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExcelApp.Quit();
            }                  
        }
    }

    class ExportDataToWord
    { 
        public void CreateVerificationCertificate(string txt8, DateTimePicker dtp1, DateTimePicker dtp2, 
            string txt1, string txt2, string txt3, string txt4, string txt5, string txt6, string txt7)
        {
            Word.Application wordApplication = new Word.Application();
            wordApplication.Visible = false;

            try
            {
                var wordDocument = wordApplication.Documents.Open(Application.StartupPath + @"\Program Files\Свидетельство о поверке.doc");
                var sh = wordDocument.Shapes;

                ReplaceTextInShape("{свидетельство №:}", txt8, sh[1]);
                ReplaceTextInShape("{дата поверки}", dtp1.Value.ToLongDateString(), sh[1]);
                ReplaceTextInShape("{действительно до}", dtp2.Value.ToLongDateString(), sh[1]);

                ReplaceTextInShape("{наименование}", txt1, sh[3]);
                ReplaceTextInShape("{номер}", txt2, sh[3]);
                ReplaceTextInShape("{тип}", txt3, sh[3]);
                ReplaceTextInShape("{диапазон измерений}", txt4, sh[3]);

                if (txt5.IndexOf('^') != -1)
                {
                    string degree;
                    string str = txt5;
                    int FromIndex;
                    int Len;
                    FromIndex = str.IndexOf('(') + 1;
                    Len = str.IndexOf(')') - FromIndex;
                    degree = str.Substring(FromIndex, Len);
                    str = str.Remove(str.IndexOf('^'));
                    str = str.Replace('*', '∙');
                    ReplaceTextInShape("{класс точности}", str + degree, sh[3]);
                    Word.Range rng = sh[3].TextFrame.TextRange;
                    int startIn = rng.Text.IndexOf(str) + str.Length;
                    rng.SetRange(startIn, startIn + degree.Length);
                    rng.Select();
                    rng.FormattedText.Font.Superscript = 1;
                }
                else 
                {
                    ReplaceTextInShape("{класс точности}", txt5, sh[3]);
                }

                ReplaceTextInShape("{владелец}", txt6, sh[3]);
                ReplaceTextInShape("{поверитель}", txt7, sh[3]);

                wordApplication.Visible = true;
            }
            catch
            {
                MessageBox.Show("При создании документа возникла ошибка\nПроверьте наличие файла в папке шаблонов",
                    "При создании файла MS Word возникла ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                wordApplication.Quit();
            }
        }

        public void CreateTheConclusionAboutUnfitness(DateTimePicker dtp1, string txt1,
            string txt2, string txt3, string txt4, string txt5, string txt6, RichTextBox rtb)
        {
            var wordApplication = new Word.Application();
            wordApplication.Visible = false;

            try
            {
                var wordDocument = wordApplication.Documents.Open(Application.StartupPath + @"\Program Files\Заключение о непригодности.doc");
                var sh = wordDocument.Shapes;
               
                ReplaceTextInShape("{Заключение №:}", txt1, sh[1]);
                ReplaceTextInShape("{Представленный на проверку:}", txt2, sh[2]);
                ReplaceTextInShape("{Номер:}", txt3, sh[3]);
                ReplaceTextInShape("{Принадлежащий:}", txt4, sh[4]);
                if (rtb.Lines.Length == 0)
                {
                    ReplaceTextInShape("{Причины непригодности:}", "", sh[5]);
                }
                else 
                {
                    ReplaceTextInShape("{Причины непригодности:}", rtb.Lines[0], sh[5]);
                }
                if (rtb.Lines.Length == 2)
                {
                    ReplaceTextInShape("{Причины непригодности2:}", rtb.Lines[1], sh[6]);
                }
                else
                {
                    ReplaceTextInShape("{Причины непригодности2:}", "", sh[6]);
                }        
                ReplaceTextInShape("{Руководитель:} ", txt5, sh[11]);
                ReplaceTextInShape("{Поверитель:}", txt6, sh[8]);
                wordApplication.Visible = true;
            }
            catch
            {
                MessageBox.Show("При создании документа возникла ошибка\nПроверьте наличие файла в папке шаблонов",
                    "При создании файла MS Word возникла ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                wordApplication.Quit();
            }
        }

        public void CreateProtocol(DateTimePicker dtp1, string txt1,
            string txt2, string txt3, string txt4, string txt5, string txt6,
            List<List<double>> list, ResistanceBox ResB, string Corresponds) 
        {
            var wordApplication = new Word.Application();
            wordApplication.Visible = false;

            try
            {
                var wordDocument = wordApplication.Documents.Open(Application.StartupPath + @"\Program Files\Протокол.doc");

                ReplaceTextInDocument("{Протокол №:}", txt1, wordDocument);
                ReplaceTextInDocument("{Тип:}", txt2, wordDocument);
                ReplaceTextInDocument("{Номер:}", txt3, wordDocument);
                if (txt4.IndexOf('^') != -1)
                {
                    string degree;
                    string str = txt4;
                    int FromIndex;
                    int Len;
                    FromIndex = str.IndexOf('(') + 1;
                    Len = str.IndexOf(')') - FromIndex;
                    degree = str.Substring(FromIndex, Len);
                    str = str.Remove(str.IndexOf('^'));
                    str = str.Replace('*', '∙');
                    ReplaceTextInDocument("{Класс точности:}", str + degree, wordDocument);
                    Word.Range rng = wordDocument.Content;
                    int startIn = rng.Text.IndexOf(str) + str.Length;
                    rng.SetRange(startIn, startIn + degree.Length);
                    rng.Select();
                    rng.FormattedText.Font.Superscript = 1;
                }
                else
                {
                    ReplaceTextInDocument("{Класс точности:}", txt4, wordDocument);
                }


                ReplaceTextInDocument("{Предоставленный на поверку:}", txt5, wordDocument);
                ReplaceTextInDocument("{Дата поверки:}", dtp1.Value.ToLongDateString(), wordDocument);
                ReplaceTextInDocument("{Поверитель:}", txt6, wordDocument);

                ReplaceTextInDocument("{Протокол №:}", txt1, wordDocument);
                ReplaceTextInDocument("{Тип:}", txt2, wordDocument);
                ReplaceTextInDocument("{Номер:}", txt3, wordDocument);
                ReplaceTextInDocument("{не/соответствует}", Corresponds, wordDocument);


                Word.Table table = wordDocument.Tables[2];

                if ((ResB as ResistanceBox2) != null)
                {
                    InsertNullRes(table, list[0], 2);
                    InsertNullRes(table, list[1], 5);
                    list.RemoveAt(1);
                    list.RemoveAt(0);

                }
                else
                {
                    table.Rows[1].Delete();
                    table.Rows[3].Delete();
                    table.Rows[3].Delete();
                    table.Rows[3].Delete();
                    InsertNullRes(table, list[0], 1);
                    list.RemoveAt(0);
                }
                table.PreferredWidth = 560;
                Word.Table table3 = wordDocument.Tables[3];

                double DecadeValue = ResB.MinResistance;
                for (int i = 0; i < ResB.NumberDecade; i++)
                {
                    table3.Columns.Add();
                    table3.Cell(2, i + 2).Range.Text = "x " + DecadeValue.ToString();
                    DecadeValue *= 10;
                }

                for (int i = table3.Columns.Count; i > 2; i--)
                {
                    Word.Cell firstCell = table3.Cell(1, i);
                    Word.Cell currCell = table3.Cell(1, i - 1);
                    if (currCell.ColumnIndex != firstCell.ColumnIndex)
                    {
                        firstCell.Merge(currCell);
                    }
                }

                table3.Cell(1, 1).Merge(table3.Cell(2, 1));
                table3.Cell(1, 1).Range.Text = "Номер ступени";
                table3.Cell(1, 2).Range.Text = "Действительное значение сопротивления, Ом";

                int maxCount = list[0].Count;
                foreach (var lis in list)
                {
                    if (lis.Count > maxCount)
                    {
                        maxCount = lis.Count;
                    }
                }

                for (int i = 0; i < maxCount; i++)
                {
                    table3.Rows.Add();
                    table3.Cell(i + 3, 1).Range.Text = (i + 1).ToString();
                }

                int rowIndex = 0;
                int columnsIndex = 2;
                foreach (var item in list)
                {
                    foreach (var lis in item)
                    {
                        table3.Cell(rowIndex++ + 3, columnsIndex).Range.Text = lis.ToString();
                    }
                    columnsIndex++;
                    rowIndex = 0;
                }
                table3.PreferredWidth = 560;
                wordApplication.Visible = true;

            }
            catch
            {
                MessageBox.Show("При создании документа возникла ошибка\nПроверьте наличие файла в папке шаблонов",
                    "При создании файла MS Word возникла ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                wordApplication.Quit();
            }
        }

        /// <summary>
        /// Вставка данных о нулевом сопротивлении в таблицу
        /// </summary>
        /// <param name="table">Таблица в которую производится вставка</param>
        /// <param name="li">Лист с данными</param>
        /// <param name="rowIndex">Номер строки для вставки</param>
        private void InsertNullRes(Word.Table table, List<double> li, int rowIndex) 
        {
            if (li.Count == 1)
            {
                table.Cell(rowIndex, 1).Range.InsertAfter(" " + li[0].ToString() + " Ом");
            }
            else if (li.Count == 2)
            {
                table.Cell(rowIndex, 1).Range.InsertAfter(" " + li[0].ToString() + " Ом");
                table.Cell(rowIndex + 1, 1).Range.InsertAfter(" " + li[1].ToString() + " Ом");
            }
            else if (li.Count == 3)
            {
                table.Cell(rowIndex, 1).Range.InsertAfter(" " + li[0].ToString() + " Ом");
                table.Cell(rowIndex + 1, 1).Range.InsertAfter(" " + li[1].ToString() + " Ом");
                table.Cell(rowIndex, 2).Range.InsertAfter(" " + li[2].ToString() + " Ом");
            }
            else
            {
                table.Cell(rowIndex, 1).Range.InsertAfter(" " + li[0].ToString() + " Ом");
                table.Cell(rowIndex + 1, 1).Range.InsertAfter(" " + li[1].ToString() + " Ом");
                table.Cell(rowIndex, 2).Range.InsertAfter(" " + li[2].ToString() + " Ом");
                table.Cell(rowIndex + 1, 2).Range.InsertAfter(" " + li[3].ToString() + " Ом");
            }


            table.Cell(rowIndex, 3).Range.InsertAfter(" " + (li.Sum() / li.Count).ToString() + " Ом");
            table.Cell(rowIndex + 1, 3).Range.InsertAfter(" " + (li.Max() - li.Min()).ToString() + " Ом");
        }

        /// <summary>
        /// Метод поиска и замены одной строки на другую в надписях
        /// </summary>
        /// <param name="_findText">Строка которую нужно заменить</param>
        /// <param name="_replaceWith">Строка которой нужно заменить</param>
        /// <param name="Sh">Надпись, в которой производится замена</param>
        private void ReplaceTextInShape(string _findText, string _replaceWith, Word.Shape Sh)
        {
            var txtRange = Sh.TextFrame.TextRange;
            txtRange.Find.Execute(FindText: _findText, ReplaceWith: _replaceWith);
        }

        /// <summary>
        /// Метод поиска и замены одной строки на другую в документе
        /// </summary>
        /// <param name="_findText">Строка которую нужно заменить</param>
        /// <param name="_replaceWith">Строка которой нужно заменить</param>
        /// <param name="Doc">Документ в котором производится замена</param>
        private void ReplaceTextInDocument(string _findText, string _replaceWith, Word.Document Doc)
        {
            var txtRange = Doc.Content;
            txtRange.Find.Execute(FindText: _findText, ReplaceWith: _replaceWith);
        }


    }


   

   
    

}
