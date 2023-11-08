using Microsoft.WindowsAPICodePack.Dialogs;
using Spire.Xls;

namespace szeregPrzedzialowy
{
    public partial class Form3 : Form
    {
        // deklaracja list szeregu szczeółowego nie posortowanego
        List<float> szeregSzczegolowy = new List<float>();

        // deklaracja list szeregu szczegółowego posortowanego
        List<float> szeregSzczegolowyPosortowany = new List<float>();

        // deklaracja list ni (ilość elementów w przedziale)
        List<int> ni = new List<int>();

        // deklaracja list xi*ni (iloczyn średniej przedziału i ilości elementów w przedziale)
        List<float> xiNi = new List<float>();

        // deklaracja list nsk (ilość elementów skumulowana)
        List<int> nsk = new List<int>();

        // deklaracja list xiMin (minimalne wartości przedziałów)
        List<float> xiMin = new List<float>();

        // deklaracja list xiMax (maksymalne wartości przedziałów)
        List<float> xiMax = new List<float>();

        int iloscPrzedzialow = 10;

        float q1;
        float me;
        float q3;

        public Form3(List<float> szSzczegolowy, List<float> szSzczegolowyPosortowany, int intervals)
        {
            InitializeComponent();
            tBFilePath.Text = "Nie wybrano pliku";
            this.FormClosing += Form3_FormClosing;
            szeregSzczegolowy = szSzczegolowy;
            szeregSzczegolowyPosortowany = szSzczegolowyPosortowany;


            // deklaracja zmiennej ilosc (ilość elementów w szeregu szczegółowym)
            int ilosc = szeregSzczegolowyPosortowany.Count;

            // deklaracja zmiennej ilośćPrzedziałów (ilość przedziałów w szeregu przedziałowym)
            iloscPrzedzialow = intervals;

            // deklaracja zmiennej max (maksymalna wartość w szeregu szczegółowym)
            float max = szeregSzczegolowyPosortowany.Max();

            // deklaracja zmiennej min (minimalna wartość w szeregu szczegółowym)
            float min = szeregSzczegolowyPosortowany.Min();

            // deklaracja zmiennej minPrzedzialu (minimalna wartość najmniejszego przedziału - dla ułatwienia operacji)
            float minPrzedzialu = min - 0.1f;

            float zakresLicz = Math.Abs(max) + Math.Abs(min);

            float maxPrzedzialuPierwszego = min + zakresLicz / iloscPrzedzialow;


            // ustawienie przedziału dolnego xi[0] (dla ułatwienia operacji)
            xiMin.Add(minPrzedzialu);

            xiMax.Add((float)Math.Round(maxPrzedzialuPierwszego, 2));
            // ustawienie przedziału górnego xi
            for (int i = 1; i < iloscPrzedzialow; i++)
                xiMax.Add((float)Math.Round(xiMax[i - 1] + zakresLicz / iloscPrzedzialow, 2));

            // ustawienie przedziału dolnego xi
            for (int i = 0; i < iloscPrzedzialow - 1; i++)
                xiMin.Add((float)Math.Round(xiMax[i], 2));


            // ilość elementów w przedziale ni
            for (int i = 0; i < iloscPrzedzialow; i++)
            {
                // deklaracja zmiennej x (ilość elementów w przedziale)
                int x = 0;
                for (int j = 0; j < szeregSzczegolowyPosortowany.Count; j++)
                {
                    // jeśli element jest w przedziale to zwiększ x
                    if (szeregSzczegolowyPosortowany[j] > xiMin[i] && szeregSzczegolowyPosortowany[j] <= xiMax[i])
                        x++;
                }
                // dodanie x do listy ni
                ni.Add(x);
            }

            // iloczyn średniej przedziału i ilości elementów w przedziale xi*ni
            xiNi.Add((float)Math.Round(((xiMin[0] + 0.1f) + xiMax[0]) / 2 * ni[0], 2));
            for (int i = 1; i < ni.Count; i++)
                xiNi.Add((float)Math.Round((xiMin[i] + xiMax[i]) / 2 * ni[i], 2));

            // dodanie pierwszego elementu do listy nsk[0]
            nsk.Add(ni[0]);
            // dodanie kolejnych elementów do listy nsk
            for (int i = 1; i < ni.Count; i++)
                nsk.Add(nsk[i - 1] + ni[i]);

            // zakres przedziałów
            float zakresPrzedzialow = xiMax[1] - xiMin[1];

            // pozycje kwartylów
            int q1Pozycja = -1;
            int mePozycja = -1;
            int q3Pozycja = -1;

            // obliczanie pozycji kwartylów i mediany
            for (int i = 0; i < nsk.Count; i++)
            {
                // jeśli pozycja kwartyla 1 nie została jeszcze obliczona
                if (q1Pozycja == -1)
                {
                    // jeśli ilość elementów w przedziale jest większa lub równa 1/4 (pozycja kwartyla 1) ilości elementów w szeregu szczegółowym
                    if (nsk[i] >= ilosc / 4)
                        q1Pozycja = i;
                }

                // jeśli pozycja mediany nie została jeszcze obliczona
                if (mePozycja == -1)
                {
                    // jeśli ilość elementów w przedziale jest większa lub równa 1/2 (pozycja mediany) ilości elementów w szeregu szczegółowym
                    if (nsk[i] >= ilosc / 2)
                        mePozycja = i;
                }

                // jeśli pozycja kwartyla 3 nie została jeszcze obliczona
                if (q3Pozycja == -1)
                {
                    // jeśli ilość elementów w przedziale jest większa lub równa 3/4 (pozycja kwartyla 3) ilości elementów w szeregu szczegółowym
                    if (nsk[i] >= ilosc / 4f * 3f)
                        q3Pozycja = i;
                }

            }

            // wzór q1 = x0 + (Nq1 - nsk-1) / n0 * h0
            q1 = xiMin[q1Pozycja] + (ilosc / 4f - nsk[q1Pozycja - 1]) / (nsk[q1Pozycja] - nsk[q1Pozycja - 1]) * zakresPrzedzialow;

            // wzór me = x0 + (Nme - nsk-1) / n0 * h0
            me = xiMin[mePozycja] + (ilosc / 2f - nsk[mePozycja - 1]) / (nsk[mePozycja] - nsk[mePozycja - 1]) * zakresPrzedzialow;

            // wzór q3 = x0 + (Nq3 - nsk-1) / n0 * h0
            q3 = xiMin[q3Pozycja] + (ilosc / 4f * 3f - nsk[q3Pozycja - 1]) / (nsk[q3Pozycja] - nsk[q3Pozycja - 1]) * zakresPrzedzialow;

            // wyświetlenie wyników
            lBEndPointData.Items.Add($"ilość przedziałów: {iloscPrzedzialow}");
            lBEndPointData.Items.Add($"ilość danych: {ilosc}");
            lBEndPointData.Items.Add($"zakres przedziałów: {zakresPrzedzialow}");
            lBEndPointData.Items.Add("");

            // stworzenie tabeli danych
            lBEndPointData.Items.Add("+━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━+");
            lBEndPointData.Items.Add($"|        xi       |   ni  |     xi*ni     |   nsk    |");
            lBEndPointData.Items.Add("|━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━|");
            lBEndPointData.Items.Add(String.Format("|{0,17}|{1,7}|{2,15}|{3,10}|", $"[{xiMin[0] + 0.1f} - {xiMax[0]}]", ni[0], xiNi[0], nsk[0]));
            for (int i = 1; i < xiMin.Count; i++)
            {
                lBEndPointData.Items.Add(String.Format("|{0,17}|{1,7}|{2,15}|{3,10}|", $"[{xiMin[i]} - {xiMax[i]}]", ni[i], xiNi[i], nsk[i]));


            }
            lBEndPointData.Items.Add("+━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━+");

            // reszta wyników
            lBEndPointData.Items.Add("");
            lBEndPointData.Items.Add($"min: {min}");
            lBEndPointData.Items.Add($"kwartyl 1: {q1}");
            lBEndPointData.Items.Add($"mediana: {me}");
            lBEndPointData.Items.Add($"kwartyl 3: {q3}");
            lBEndPointData.Items.Add($"max: {max}");
            lBEndPointData.Items.Add("");
        }

        // zamknięcie wszystkich okien
        private void Form3_FormClosing(object? sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CloseApp()
        {
            this.Close();
            // Zamknięcie wszystkich okien
            Application.OpenForms[0].Close();
        }

        private void FileLoad(object sender, EventArgs e)
        {
            // otwarcie okna dialogowego wyboru pliku danych (.txt)
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path;

            // jeśli wybrano plik
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                // przypisanie ścieżki do zmiennej path
                tBFilePath.Text = dialog.FileName;
                path = dialog.FileName;


                SaveToExcelFile(path);
            }
            else
            {
                // wyświetlenie komunikatu o błędzie
                tBFilePath.Text = "Nie wybrano pliku";
            }
        }

        private void SaveToExcelFile(string path)
        {
            Workbook workbook = new Workbook();
            workbook.Worksheets.Clear();

            Worksheet sheet = workbook.Worksheets.Add("Szereg przedziałowy");
            sheet.Range[1, 1].Text = "Szereg szczegółowy";
            sheet.Range[1, 2].Value = "Szereg szczegółowy posortowany";
            sheet.Range["J2"].Value = "Ilość liczb ";
            sheet.Range["K2"].Value2 = szeregSzczegolowyPosortowany.Count;
            sheet.Range["J4"].Value = "Kwartyl 1 ";
            sheet.Range["K4"].Value2 = q1;
            sheet.Range["J5"].Value = "Mediana ";
            sheet.Range["K5"].Value2 = me;
            sheet.Range["J6"].Value = "Kwartyl 3 ";
            sheet.Range["K6"].Value2 = q3;
            sheet.Range["J8"].Value = "Wartość minimalna ";
            sheet.Range["K8"].Value2 = szeregSzczegolowyPosortowany.Min();
            sheet.Range["J9"].Value = "Wartość maksymalna ";
            sheet.Range["K9"].Value2 = szeregSzczegolowyPosortowany.Max();
            CellRange range = sheet.Range["D1:H1"];
            CellRange range2 = sheet.Range["D2:E2"];
            range.Merge();
            range2.Merge();

            range.Style.HorizontalAlignment = HorizontalAlignType.Center;
            range2.Style.HorizontalAlignment = HorizontalAlignType.Center;

            sheet.Range["D1"].Value = "Szereg przedziałowy";
            sheet.Range["D2"].Value = "xi";
            sheet.Range["F2"].Value = "ni";
            sheet.Range["G2"].Value = "xi*ni";
            sheet.Range["H2"].Value = "nsk";

            for (int i = 0; i < szeregSzczegolowy.Count; i++)
            {
                sheet.Range[i + 2, 1].Value2 = szeregSzczegolowy[i];
                sheet.Range[i + 2, 2].Value2 = szeregSzczegolowyPosortowany[i];
            }

            for (int i = 0; i < ni.Count; i++)
            {
                sheet.Range[i + 3, 4].Value2 = xiMin[i];
                sheet.Range[i + 3, 5].Value2 = xiMax[i];
                sheet.Range[i + 3, 6].Value2 = ni[i];
                sheet.Range[i + 3, 7].Value2 = xiNi[i];
                sheet.Range[i + 3, 8].Value2 = nsk[i];
            }

            sheet.Range["D3"].Value2 = xiMin[0] + 0.1f;


            sheet.AllocatedRange.AutoFitColumns();
            CellRange range3 = sheet.Range["D3:H11"];
            range3.ColumnWidth = 15;

            path = Path.Combine(path, "SzeregPrzedzialowy.xlsx");
            try
            {
                workbook.SaveToFile(path, ExcelVersion.Version2016);
                CloseApp();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }

        }
    }
}
