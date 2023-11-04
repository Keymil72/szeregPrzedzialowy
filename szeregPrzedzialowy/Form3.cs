namespace szeregPrzedzialowy
{
    public partial class Form3 : Form
    {
        List<float> szeregSzczegolowy = new List<float>();
        List<float> szeregSzczegolowyPosortowany = new List<float>();
        int iloscPrzedzialow = 10;
        public Form3(List<float> szSzczegolowy, List<float> szSzczegolowyPosortowany, int intervals)
        {
            InitializeComponent();
            this.FormClosing += Form3_FormClosing;
            szeregSzczegolowy = szSzczegolowy;
            szeregSzczegolowyPosortowany = szSzczegolowyPosortowany;
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
            for (int i = 0; i < ni.Count; i++)
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
            float q1 = xiMin[q1Pozycja] + (ilosc / 4f - nsk[q1Pozycja - 1]) / (nsk[q1Pozycja] - nsk[q1Pozycja - 1]) * zakresPrzedzialow;

            // wzór me = x0 + (Nme - nsk-1) / n0 * h0
            float me = xiMin[mePozycja] + (ilosc / 2f - nsk[mePozycja - 1]) / (nsk[mePozycja] - nsk[mePozycja - 1]) * zakresPrzedzialow;

            // wzór q3 = x0 + (Nq3 - nsk-1) / n0 * h0
            float q3 = xiMin[q3Pozycja] + (ilosc / 4f * 3f - nsk[q3Pozycja - 1]) / (nsk[q3Pozycja] - nsk[q3Pozycja - 1]) * zakresPrzedzialow;

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

        private void CloseApp(object sender, EventArgs e)
        {
            this.Close();
            // Zamknięcie wszystkich okien
            Application.OpenForms[0].Close();
        }
    }
}
