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
using MEFCalculatorBL;
using MEFCalculatorBL.Interfaces;

namespace MEFCalculatorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calculator calculator;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += (sender, e) => Initialize();
        }

        private void Initialize()
        {
            calculator = new Calculator();
            var operations = calculator.AvailableOperations;
            var operationDtos = operations.Select(op => new OperationDTO(op)).ToList();
            Cmb_Operation.ItemsSource = operationDtos;
            Cmb_Operation.DisplayMemberPath = "Operation";
            Cmb_Operation.SelectedValuePath = "Operation";
            Btn_Calculate.Click += (sender, e) => SetCalculatedResult();
        }

        private void SetCalculatedResult()
        {
            // since the operation is small, it's safe without using tasks
            try
            {
                var left = double.Parse(Txt_Op1.Text);
                var right = double.Parse(Txt_Op2.Text);
                var operation = Cmb_Operation.SelectedValue.ToString();
                var result = calculator.Calculate(left, right, operation);
                Txt_Result.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    class OperationDTO
    {
        public OperationDTO(string operation)
        {
            Operation = operation;
        }

        public string Operation { get; set; }

        public override string ToString()
        {
            return Operation;
        }
    }
}
