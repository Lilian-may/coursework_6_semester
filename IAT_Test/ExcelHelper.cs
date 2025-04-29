using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace IAT_Test
{
    using OfficeOpenXml;
    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    public static class ExcelHelper
    {

        private static int currentRow = -1;
        private static bool isNewParticipant = true;

        public static void ResetParticipantState()
        {
            isNewParticipant = true;
            currentRow = -1;
        }

        public static void SaveResults(string filePath, string gender, int age, string work, string faculty, string studyForm, int course, string video, TimeSpan time, string[] scales)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault() ?? package.Workbook.Worksheets.Add("Results");

                    string[] headers = { "Номер испытуемого", "Пол", "Возраст", "Род занятий", "Факультет", "Форма обучения", "Курс" };
                    string[] emotionLabels = { "Название видео", "Время остановки", "Комфорт", "Сила переживания", "Равнодушие", "Антипатия", "Тревога", "Раздражение", "Печаль", "Удовольствие", "Отторжение" };

                    // Установим заголовки основной информации (если ещё не были записаны)
                    //if (worksheet.Dimension == null || worksheet.Dimension.Rows < 1)
                    //{
                        for (int i = 0; i < headers.Length; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = headers[i];
                            worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        }
                    //}

                    if (isNewParticipant)
                    {
                        int lastUsedRow = worksheet.Dimension?.End?.Row ?? 1;
                        currentRow = lastUsedRow + 1;

                        int participantNumber = currentRow - 1;
                        worksheet.Cells[currentRow, 1].Value = participantNumber;
                        worksheet.Cells[currentRow, 2].Value = gender;
                        worksheet.Cells[currentRow, 3].Value = age;
                        worksheet.Cells[currentRow, 4].Value = work;
                        worksheet.Cells[currentRow, 5].Value = faculty;
                        worksheet.Cells[currentRow, 6].Value = studyForm;
                        worksheet.Cells[currentRow, 7].Value = course;

                        isNewParticipant = false;
                    }

                    // Найдём первую свободную колонку справа от 7-й
                    int col = 8;
                    while (worksheet.Cells[currentRow, col].Value != null) col += 11;

                    // Записываем заголовки блока, если ещё не записаны
                    for (int i = 0; i < emotionLabels.Length; i++)
                    {
                        if (worksheet.Cells[1, col + i].Value == null)
                        {
                            worksheet.Cells[1, col + i].Value = emotionLabels[i];
                            worksheet.Cells[1, col + i].Style.Font.Bold = true;
                        }
                    }

                    // Записываем данные
                    worksheet.Cells[currentRow, col].Value = video;
                    worksheet.Cells[currentRow, col + 1].Value = time.ToString();
                    for (int i = 0; i < scales.Length; i++)
                    {
                        worksheet.Cells[currentRow, col + 2 + i].Value = scales[i];
                    }

                    package.Save();
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Файл результатов занят. Закройте Excel и повторите попытку.");
            }
        }



    }

}
