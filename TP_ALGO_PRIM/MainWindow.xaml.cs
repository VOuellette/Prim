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
                    Button tile = new Button();

                    if (row == 0 && col == 0)
                        tile.Background = Brushes.LawnGreen;
                    else if (row == solution.dim.y - 1 && col == solution.dim.x - 1)
                        tile.Background = Brushes.DarkRed;
                    else
                        tile.Background = Brushes.White;

                    tile.BorderBrush = Brushes.Black;
                    Thickness thickness = new Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 };
                    


                    Node node = solution.nodes[row, col];
                    List<NodeLink> links = node.links;

                    if(links.Count > 0)
                    {
                        foreach(NodeLink link in links)
                        {
                            switch (link.direction)
                            {
                                case Direction.Top:
                                    thickness.Top = 0;
                                    break;
                                case Direction.Right:
                                    thickness.Right = 0;
                                    break;
                                case Direction.Left:
                                    thickness.Left = 0;
                                    break;
                                case Direction.Bottom:
                                    thickness.Bottom = 0;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    if (node.linkFrom != null)
                    {
                        switch (node.linkFrom.direction)
                        {
                            case Direction.Top:
                                thickness.Bottom = 0;
                                break;
                            case Direction.Right:
                                thickness.Left = 0;
                                break;
                            case Direction.Left:
                                thickness.Right = 0;
                                break;
                            case Direction.Bottom:
                                thickness.Top = 0;
                                break;
                            default:
                                break;
                        }
                    }
                    tile.BorderThickness = thickness;
                    Grid.SetRow(tile, row);
                    Grid.SetColumn(tile, col);
                    labGrid.Children.Add(tile);
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
                longueur = 15;
                hauteur = 15;
            }
        }

    }
}
