using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string sometext;
        public string SomeText
        {
            get { return sometext; }
            set
            {
                sometext = value;
                OnPropertyChanged();
            }
        }
        public Car MyCar { get; set; }
        public ObservableCollection<Car> Cars { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Cars = new ObservableCollection<Car>
            {
             new Car
             {
                Model = "Evo 9",
                Vendor = "Mitsubishi",
                Year = 2008
            },
             new Car
             {
                Model = "WRX",
                Vendor = "Subaru",
                Year = 2008
            },
             new Car
             {
                Model = "Supra",
                Vendor = "Toyota",
                Year = 2004
            },
            };


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["PrimaryColor"] = Brushes.Goldenrod;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyCar.Model = "Testla";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var car = new Car
            {
                Model = "TrackHawk",
                Vendor = "Jeep",
                Year = 2020
            };
            Cars.Add(car);
        }

        private void listbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var info = new Info();
            info.InfoCar = (sender as ListBox).SelectedItem as Car;
            info.ShowDialog();
        }
    }
}
