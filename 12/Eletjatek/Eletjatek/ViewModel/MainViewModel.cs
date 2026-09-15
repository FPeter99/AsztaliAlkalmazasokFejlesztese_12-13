using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Eletjatek.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        class MyCommand : ICommand
        {
            Action action;
            public MyCommand(Action action) 
            {
                this.action = action;
            }
            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter) => true;


            public void Execute(object? parameter) => action();

        }
        public int[] Meretek { get; init; } = Enumerable.Range(5, 16).ToArray();
        public int Rows { get; set; } = 20;
        public int Cols { get; set; } = 20;

        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand CreateNew { get; init; }
        public ICommand Save { get; init; }
        public MainWindow Context { get; set; }
        void SaveTable()
        {
            using var output = new StreamWriter($"Elatjatek_{Context.ChekBoxGrid.Rows}x{Context.ChekBoxGrid.Columns}.txt");
            for (int i = 0; i < Context.ChekBoxGrid.Rows; i++)
            {
                for (int j = 0; j < Context.ChekBoxGrid.Columns; j++)
                {
                    var cb = (Context.ChekBoxGrid.Children[i * Context.ChekBoxGrid.Columns + j] as CheckBox)!;
                    output.Write(cb.IsChecked ?? true ? '1' : '0');
                }
                output.WriteLine();
            }
        }
        void CreateNewTable() 
        {
            Context.ChekBoxGrid.Children.Clear();
            Context.ChekBoxGrid.Rows = Rows;
            Context.ChekBoxGrid.Columns = Cols;

            for (int i = 0; i < Rows; i++) 
            {
                for (int j = 0; j < Cols; j++) 
                {
                    var cb = new CheckBox();
                    Context.ChekBoxGrid.Children.Add(cb);
                }
            }
        }
        public MainViewModel() 
        {
            CreateNew = new MyCommand(CreateNewTable);
            Save = new MyCommand(SaveTable);
        }
    }
}
