using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TP_ALGO_PRIM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Settings settings = new();
        GameController gc;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = settings;
            
            Init();
        }

        internal void DrawGraph(Graph solution)
        {
            labGrid.Children.Clear();
            labGrid.RowDefinitions.Clear();
            labGrid.ColumnDefinitions.Clear();

            // On la grille du labyrinthe
            for (int i = 0; i < settings.hauteur; i++)
                labGrid.RowDefinitions.Add(new RowDefinition());

            for (int i = 0; i < settings.longueur; i++)
                labGrid.ColumnDefinitions.Add(new ColumnDefinition());

            // On affiche les nodes
            for (int row = 0; row < solution.dim.y; row++)
            {
                for(int col = 0; col < solution.dim.x; col++)
                {
                    Rectangle rect = new Rectangle();
                    int lol = new Random().Next(0, 255);
                    rect.Fill = new SolidColorBrush(Color.FromArgb((byte)lol, 0, 0, 0));

                    if(solution.nodes[row, col].links.Count > 0)
                    {

                    }

                    Grid.SetRow(rect, row);
                    Grid.SetColumn(rect, col);
                    labGrid.Children.Add(rect);
                }
            }
        }

        public void Init()
        {
            // Do interface stuff :)
        }

        public void GenererLabyrinthe(object sender, RoutedEventArgs e)
        {
            this.gc = new GameController(this, new Dimension(settings.longueur, settings.hauteur));
            this.gc.GenererLabyrinthe();
        }

        private class Settings
        {
            public int longueur { get; set; }
            public int hauteur { get; set; }
            public Settings()
            {
                longueur = 10;
                hauteur = 5;
            }
        }

    }
}
