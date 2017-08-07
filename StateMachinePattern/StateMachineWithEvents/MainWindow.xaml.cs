using System;
using System.Collections.Generic;
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
using StateMachine.Annotations;
using StateMachine.Common;
using StateMachineWithEvents.Types;

namespace StateMachineWithEvents
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private StateMachine.Common.StateMachine<AmountOfStates, MainWindow> _stateMachine;


        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            _stateMachine = new StateMachine<AmountOfStates, MainWindow>(AmountOfStates.None);
            _stateMachine.PropertyChanged += OnPropertyChanged;
            _stateMachine[AmountOfStates.Few].OnVerifyState(wnd => wnd.SliderValue < 100);
            _stateMachine[AmountOfStates.Lot].OnVerifyState(wnd => wnd.SliderValue >= 100 && wnd.SliderValue <= 500);
            _stateMachine[AmountOfStates.Many].OnVerifyState(wnd => wnd.SliderValue > 500);

            StateName = String.Join(",", _stateMachine.CurrentState);

            this.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (sender == _stateMachine && args.PropertyName.Equals(nameof(_stateMachine.CurrentState)))
            {
                StateName = String.Join(",", _stateMachine.CurrentState);
            }
            else if (args.PropertyName.Equals(nameof(SliderValue)))
            {
                _stateMachine.FindState(this);
            }
        }

        private string _statename;

        public string StateName
        {
            get { return _statename; }
            set
            {
                if (!String.Equals(_statename, value))
                {
                    _statename = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _slidervalue;

        public double SliderValue
        {
            get { return _slidervalue; }
            set
            {
                if (Math.Abs(_slidervalue - value) > 0.1)
                {
                    _slidervalue = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
