using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SynchronizationContext _context;

        public MainWindow()
        {
            InitializeComponent();
            SetSynchronizationContext();
            AttachEventHandlers();
        }

        private void SetSynchronizationContext()
        {
            _context = SynchronizationContext.Current;
        }

        private void AttachEventHandlers()
        {
            btn1.Click += (sender, eventArgs) => SetTextBox1TextWithoutSContext();

            btn2.Click += (sender, eventArgs) => new Thread(() => SetTextBox1TextWithoutSContext()).Start();

            btn3.Click += (sender, eventArgs) => Task.Run(() => SetTextBox1TextWithoutSContext());

            btn4.Click += (sender, eventArgs) => SetTextBox1TextWithSContext();

            btn5.Click += (sender, eventArgs) => new Thread(() => SetTextBox1TextWithSContext()).Start();

            btn6.Click += (sender, eventArgs) => Task.Run(() => SetTextBox1TextWithSContext());

            btn7.Click += (sender, eventArgs) => SetTextBox1TextWithInnerSContext();
        
            btn8.Click += (sender, eventArgs) => new Thread(() => SetTextBox1TextWithInnerSContext()).Start();

            btn9.Click += (sender, eventArgs) => Task.Run(() => SetTextBox1TextWithInnerSContext());
        }

        private void SetTextBox1TextWithInnerSContext()
        {
            try
            {
                var context = SynchronizationContext.Current;
                context.Post(c => SetTextBox1TextWithoutSContext(), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SetTextBox1TextWithSContext()
        {
            try
            {
                _context.Post(c => SetTextBox1TextWithoutSContext(), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SetTextBox1TextWithoutSContext()
        {
            try
            {
                txtBox1.Text = "Value changed!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
