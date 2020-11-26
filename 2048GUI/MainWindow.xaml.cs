using System;
using System.Collections.Generic;
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
using _2048;

namespace _2048GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game Game;
        public MainWindow()
        {
            InitializeComponent();
            Game = new Game(5);
            int size = Game.Grid.Size;
            update();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
            switch (e.Key)
            {
                case Key.Left:
                    Game.Shift(Direction.Left);
                    break;
                case Key.Right:
                    Game.Shift(Direction.Right);
                    break;
                case Key.Up:
                    Game.Shift(Direction.Up);
                    break;
                case Key.Down:
                    Game.Shift(Direction.Down);
                    break;
            }

            update();
        }

        private void update() 
        {
            Score.Text = "Score : " + Game.ToString();
            int size = Game.Grid.Size;
            gameGrid.Children.Clear();
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    Cell cell = Game.Grid.cells[y, x];
                    Label label = new Label();
                    label.Background = getColorBackground(cell.Number);
                    label.Foreground = getColorForeground(cell.Number);

                    System.Windows.Controls.Grid.SetColumn(label, x);
                    System.Windows.Controls.Grid.SetRow(label, y);
                    label.Content = cell;
                    gameGrid.Children.Add(label);
                }
            }
        }

        private Brush getColorForeground(int number)
        {
            if (number < 8)
                return Brushes.Black;
            return Brushes.White;
        }

        private Brush getColorBackground(int number)
        {
            switch (number)
            {
                case 0:
                    return (Brush)(new BrushConverter().ConvertFrom("#cdc1b4"));
                case 2:
                    return (Brush)(new BrushConverter().ConvertFrom("#eee4da"));
                case 4:
                    return (Brush)(new BrushConverter().ConvertFrom("#ede0c8"));
                case 8:
                    return (Brush)(new BrushConverter().ConvertFrom("#f2b179"));
                case 16:
                    return (Brush)(new BrushConverter().ConvertFrom("#f59563"));
                case 32:
                    return (Brush)(new BrushConverter().ConvertFrom("#f67c5f"));
                case 64:
                    return (Brush)(new BrushConverter().ConvertFrom("#f65e3b"));
                case 128:
                    return (Brush)(new BrushConverter().ConvertFrom("#edcf72"));
                case 256:
                    return (Brush)(new BrushConverter().ConvertFrom("#edcc61"));
                case 512:
                    return (Brush)(new BrushConverter().ConvertFrom("#edc850"));
                case 1024:
                    return (Brush)(new BrushConverter().ConvertFrom("#edc53f"));
                case 2048:
                    return (Brush)(new BrushConverter().ConvertFrom("#edc22e"));
                default:
                    return (Brush)(new BrushConverter().ConvertFrom("#edc22e"));
            }
        }
    }
}
