using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace AvaloniaTest.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
                ValidateEmail();
            }
        }

        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public bool HasErrors => _errors.Count > 0;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string? propertyName)
        {
            if(_errors.ContainsKey(propertyName))
            {
                return _errors[propertyName];
            }
            return null;
        }

        private void ValidateEmail()
        {
            ClearErrors(nameof(Email));

            if (string.IsNullOrWhiteSpace(Email))
            {
                AddError(nameof(Email), "Email is required");
            }
            else if (!Email.Contains("@"))
            {
                AddError(nameof(Email), "Email is invalid");
            }
        }

        private void AddError(string propertyName, string error)
        {
            if(!_errors.ContainsKey(propertyName))
            {
                _errors[propertyName] = new List<string>();
            }

            _errors[propertyName].Add(error);
            OnErrorsChanged(propertyName);
        }

        private void ClearErrors(string propertyName)
        {
            if(_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }        
    }
}
