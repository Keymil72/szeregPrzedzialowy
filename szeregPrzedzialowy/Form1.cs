namespace szeregPrzedzialowy
{
    public partial class Form1 : Form
    {
        string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string defaultFileName = "data.txt";
        string path;
        public Form1()
        {
            InitializeComponent();
            tBFilePath.Text = Path.Combine(defaultPath, defaultFileName);
        }

        private void FileLoad(object sender, EventArgs e)
        {
            // otwarcie okna dialogowego wyboru pliku danych (.txt)
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Wybierz plik z danymi (.txt)";
            openFileDialog1.InitialDirectory = Path.Combine(defaultPath, defaultFileName);
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.ShowDialog();

            // je�li wybrano plik
            if (openFileDialog1.FileName != "")
            {
                // przypisanie �cie�ki do zmiennej path
                tBFilePath.Text = openFileDialog1.FileName;
                path = openFileDialog1.FileName;


                // otwarcie nowego okna Form2
                Form2 frm = new Form2(path);
                frm.Show();
                this.Hide();
            }
            // je�li nie wybrano pliku
            else
            {
                // wy�wietlenie komunikatu o b��dzie
                tBFilePath.Text = "Nie wybrano pliku";
            }
        }
    }
}