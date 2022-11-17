using System;
using System.ComponentModel;
using System.Diagnostics;
using WinClient.Primes.Model;

namespace WinClient.Primes.ViewModel
{
    public class PrimesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IPrimesModel primesModel;
        private bool enabled = true;

        public PrimesViewModel(IPrimesModel primesModel)
        {
            this.primesModel = primesModel;
            StartCommand = new CustomCommand(obj => LoadData(), obj => enabled);
        }

        //Bound to Text property of Limit TextBox
        private int limit = 1000;
        public int Limit
        {
            get => limit;
            set
            {
                limit = value;
                LoadData();
            }
        }

        //Bound to Text property of Result TextBlock
        private string result;
        public string Result
        {
            get => result; 
            set
            {
                result = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            }
        }

        //Operations

        public CustomCommand StartCommand { get; private set; }

        private async void LoadData()
        {
            enabled = false;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int count = await primesModel.CountAsync(Limit);
            sw.Stop();
            Result = $"{count} prime numbers. Calculated in {Math.Round(sw.Elapsed.TotalSeconds, 2)} seconds";
            enabled = true;
        }
    }
}
