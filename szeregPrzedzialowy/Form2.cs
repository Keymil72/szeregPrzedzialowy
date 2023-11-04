namespace szeregPrzedzialowy
{
    public partial class Form2 : Form
    {
        List<float> szeregSzczegolowy = new List<float>();
        List<float> szeregSzczegolowyPosortowany = new List<float>();
        public Form2(string filePath)
        {
            InitializeComponent();
            string path = filePath;
            ReadFile(path);
        }

        // Wczytanie danych z pliku o podanej ścieżce
        void ReadFile(string path)
        {
            StreamReader reader = new StreamReader(path);

            string line = "";
            int errorCount = 0;

            // Wczytanie danych do listy
            while ((line = reader.ReadLine()) != null)
            {
                // Jeśli nie uda się przekonwertować na float, to zwiększamy licznik błędów i kontynuuj
                if (!float.TryParse(line, out float result))
                {
                    errorCount++;
                    continue;
                }
                // Jeśli uda się przekonwertować, to dodajemy do listy
                szeregSzczegolowy.Add(result);
            }
            // zamykamy reader
            reader.Close();

            // Stworzenie listy posortowanej i sortowanie
            szeregSzczegolowyPosortowany.AddRange(szeregSzczegolowy);
            szeregSzczegolowyPosortowany.Sort();

            // Wyświetlenie danych
            lBData.Items.Add($"Ilość poprawnych elementów: {szeregSzczegolowy.Count}");
            lBData.Items.Add($"Ilość błędów: {errorCount}");
            for (int i = 0; i < szeregSzczegolowy.Count; i++)
            {
                lBData.Items.Add(String.Format("{0,24}|{1,24}", szeregSzczegolowy[i], szeregSzczegolowyPosortowany[i]));
            }
        }

        // Przejście do kolejnego okna
        private void SubmitData(object sender, EventArgs e)
        {
            // Otwarcie nowego okna Form3
            Form3 form3 = new Form3(szeregSzczegolowy, szeregSzczegolowyPosortowany, (int)nUDIntervalCount.Value);
            form3.Show();
            // Zamknięcie aktualnego okna
            this.Close();
        }

        // Funkcja do wyświetlania danych w kolumnach
    }
}
