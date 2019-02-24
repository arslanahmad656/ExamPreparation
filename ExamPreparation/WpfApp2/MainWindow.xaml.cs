using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private BlockingCollection<string> _collection;
        private int _pushSpeed;
        private int _popSpeed;
        
        public MainWindow()
        {
            InitializeComponent();
            _collection = new BlockingCollection<string>();
            AttachEvents();
            AdjustSpeed();
        }

        private void AdjustSpeed()
        {
            _pushSpeed = int.Parse(txtBox_AddSpeed.Text);
            _popSpeed = int.Parse(txtBox_RemoveSpeed.Text);
        }

        private void FillCollection()
        {
            ParallelEnumerable.Range(1, 10).Select(i => i.ToString()).ToList().ForEach(s => _collection.Add(s));
        }

        private void AttachEvents()
        {
            btn_Fill.Click += (sender, eventArgs) => FillCollection();
            btn_Read.Click += (sender, eventArgs) => StartReading();
            btn_AppendSingle.Click += (sender, eventArgs) => AppendSingle();
            btn_AppendBulk.Click += (sender, eventArgs) => StartAdding();
            btn_ClearText.Click += (sender, eventArgs) => ClearText();
            btn_AdjustSpeed.Click += (sender, eventArgs) => AdjustSpeed();
        }

        private void RemoveSingle()
        {
            Task.Run(() =>
            {
                var s = _collection.Take();
                Dispatcher.Invoke(() => txtBox_Current.Text = s);
            });
        }

        private void ClearText()
        {
            txtBox_All.Clear();
        }

        private void AppendSingle()
        {
            Task.Run(() =>
            {
                Dispatcher.Invoke(() =>
                {
                    var s = txtBox_Add.Text;
                    _collection.Add(s);
                });
            });
        }

        private void StartReading()
        {
            Task.Run(() =>
            {
                //while (true)
                //{
                //    var s = _collection.Take();
                //    System.Threading.Thread.Sleep(_popSpeed);
                //    Dispatcher.Invoke(() => txtBox_All.Text += "  " + s);
                //}
                foreach (var item in _collection.GetConsumingEnumerable())
                {
                    System.Threading.Thread.Sleep(_popSpeed);
                    Dispatcher.Invoke(() => txtBox_All.Text += "  " + item);
                }
            });
        }

        private void StartAdding()
        {
            Task.Run(() =>
            {
                var random = new Random();
                //int i = 1000;
                while (true)
                {
                    System.Threading.Thread.Sleep(_pushSpeed);
                    var s = random.Next(_pushSpeed).ToString();
                    _collection.Add(s);
                    //i--;
                }
            });
        }
    }
}
