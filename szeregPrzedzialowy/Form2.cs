using System.Text;

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

        void ReadFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                szeregSzczegolowy.Add(float.Parse(line));
            }
            reader.Close();
            szeregSzczegolowyPosortowany.AddRange(szeregSzczegolowy);
            szeregSzczegolowyPosortowany.Sort();

            lBData.Items.Add($"Ilość elementów: {szeregSzczegolowy.Count}");
            for (int i = 0; i < szeregSzczegolowy.Count; i++)
            {
                lBData.Items.Add($"{spaceBetween(szeregSzczegolowy[i], szeregSzczegolowyPosortowany[i])}");
            }
        }

        string spaceBetween(float text1, float text2)
        {
            int midPlace = 19;
            int length1 = text1.ToString().Length;
            int length2 = text2.ToString().Length;

            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            string toReturn = text1.ToString() + sb.Insert(0, " ", midPlace - length1) + "|" + sb2.Insert(0, " ", midPlace - length2) + text2.ToString();
            return toReturn;
        }
    }
}
