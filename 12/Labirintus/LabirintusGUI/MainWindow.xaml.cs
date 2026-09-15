using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace LabirintusGUI
{
    public partial class MainWindow : Window
    {
        private int rows;
        private int cols;
        private CheckBox[,] cells;

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 5; i <= 20; i++)
            {
                RowCombo.Items.Add(i);
                ColCombo.Items.Add(i);
            }

            RowCombo.SelectedItem = 12;
            ColCombo.SelectedItem = 12;

            BuildGrid(rows, cols);

            for (int i = 1; i <= 16; i++)
            {
                Nev.Items.Add(i);
            }

            Nev.SelectedItem = 3;
        }

        private void SizeChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RowCombo.SelectedItem == null || ColCombo.SelectedItem == null)
                return;

            rows = (int)RowCombo.SelectedItem;
            cols = (int)ColCombo.SelectedItem;

            BuildGrid(rows, cols);
        }

        private void BuildGrid(int r, int c)
        {
            LabGrid.Rows = r;
            LabGrid.Columns = c;
            LabGrid.Children.Clear();

            cells = new CheckBox[r, c];

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    CheckBox cb = new CheckBox();


                    if ((i == 1 && j == 0) || (i == r -2 && j == c-1))
                    {
                        cb.IsChecked = false;
                        cb.IsEnabled = false;
                    }
                    else if(i == 0 || j == 0 || i == r - 1 || j == c - 1)
                    {
                        cb.IsChecked = true;
                        cb.IsEnabled = false;
                    }



                    cells[i, j] = cb;
                    LabGrid.Children.Add(cb);
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            int id = (int)Nev.SelectedItem;

            string f = $"lab{id}.txt";

            using (StreamWriter sw = new StreamWriter(f))
            {
                for (int i = 0; i < cells.GetLength(0); i++)
                {
                    for (int j = 0; j < cells.GetLength(1); j++)
                    {
                        bool fal = cells[i, j].IsChecked == true;

                        sw.Write(fal ? 'X' : ' ');
                    }

                    sw.WriteLine();
                }
            }

            MessageBox.Show($"Labirintus sikeresen mentve: {f}");
        }
    }
}