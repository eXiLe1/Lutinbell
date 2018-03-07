using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Lutinbell_Manager.ViewModels.Website;

namespace Lutinbell_Manager.ViewModels.Website
{
    class WebsiteNavigationViewModel : INotifyPropertyChanged
    {
        public ICommand ReviewsCommand { get => _reviewsCommand; set => _reviewsCommand = value; }
        public ICommand TestCommand { get => _testCommand; set => _testCommand = value; }

        private object selectedViewModel;
        private ICommand _reviewsCommand;
        private ICommand _testCommand;

        public object SelectedViewModel => selectedViewModel;

        public void SetSelectedViewModel(object value)
        {
            selectedViewModel = value; OnPropertyChanged("SelectedViewModel");
        }

        public WebsiteNavigationViewModel()
        {
            ReviewsCommand = new BaseCommand(OpenReviews);

            TestCommand = new BaseCommand(OpenTest);
        }

        private void OpenReviews(object obj)
        {
            SetSelectedViewModel(new ReviewsViewModel());
        }

        private void OpenTest(object obj)
        {
            SetSelectedViewModel(new TestViewModel());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class BaseCommand : ICommand
    {
        private Predicate<object> _canExecute;
        private Action<object> _method;

        public BaseCommand(Action<object> method)
            : this(method, null)
        {
        }

        public BaseCommand(Action<object> method, Predicate<object> canExecute)
        {
            _method = method;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _method.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }
    }
}
