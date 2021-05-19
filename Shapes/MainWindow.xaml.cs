using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Shapes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Shape> Shapes { get; } = new();
        public MainWindow()
        {
            InitializeComponent();

            Shapes.Clear();

            DataContext = this;
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            string selected = comboBox.Text;

            if (selected == "Circle")
            {
                if (double.TryParse(textBoxRadius.Text, out double r))
                {
                    Shapes.Add(new Shape() { Name = "Circle", Radius = r, Area = Math.Round(Math.PI * Math.Pow(r, 2), 2) });
                }
                else MessageBox.Show("Invalid inputs for type Circle", "Error");
            }
            else if (selected == "Rectangle")
            {
                if (double.TryParse(textBoxSideA.Text, out double a) && double.TryParse(textBoxSideB.Text, out double b))
                {
                    Shapes.Add(new Shape() { Name = "Rectangle", SideA = a, SideB = b, Area = Math.Round(a * b, 2) });
                }
                else MessageBox.Show("Invalid inputs for type Rectangle", "Error");
            }
            else if (selected == "Triangle")
            {
                if (double.TryParse(textBoxSideA.Text, out double a) && double.TryParse(textBoxHeight.Text, out double h))
                {
                    Shapes.Add(new Shape() { Name = "Triangle", SideA = a, Height = h, Area = Math.Round((a * h) / 2, 2) });
                }
                else MessageBox.Show("Invalid inputs for type Triangle", "Error");
            }

            double sumOfAreas = 0;
            foreach (var shape in Shapes)
            {
                sumOfAreas += shape.Area;
            }
            textBlockArea.Text = Convert.ToString(sumOfAreas);
        }
    }
}
