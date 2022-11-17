using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WinClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            button.Click += Button_Click;

            //BrushConverter brushConverter = new BrushConverter();
            //label.Background = (Brush)brushConverter.ConvertFromString("#00ff00");

            //This returns a BrushConverter, which derives from TypeConverter https://docs.microsoft.com/en-us/dotnet/api/system.windows.media.brushconverter?view=netcore-3.1
            TypeConverter typeConverter = TypeDescriptor.GetConverter(typeof(Brush));

            Brush brush = (Brush)typeConverter.ConvertFromString("#00ff00");
            label.Background = brush;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int limit = Convert.ToInt32(textBox.Text);
            int result = await PrimesCountAsync(limit);
            label.Content = $"{result} prime numbers below {limit}";
        }

        public int PrimesCount(int max)
        {
            return (from n in Enumerable.Range(2, max - 1)
                    where Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)
                    select n).Count();
        }

        public async Task<int> PrimesCountAsync(int limit)
        {
            Func<int> func = () => (
               from n in Enumerable.Range(2, limit).AsParallel()
               where Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)
               select n).Count();
            int result = await Task.Run(func); //returns Task<int>
            return result;
        }
    }
}
