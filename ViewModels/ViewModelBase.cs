using AvaloniaTest.Utilities;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AvaloniaTest.ViewModels
{
    public abstract class ViewModelBase : ObservableObject, INotifyDataErrorInfo
    {
        private ValidationManager _validationManager = new ValidationManager();

        public bool HasErrors => _validationManager.HasErrors;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged
        {
            add { _validationManager.ErrorsChanged += value; }
            remove { _validationManager.ErrorsChanged -= value; }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return _validationManager.GetErrors(propertyName);
        }

        protected void AddError(string propertyName, string error)
        {
            _validationManager.AddError(propertyName, error);
        }

        protected void ClearErrors(string propertyName)
        {
            _validationManager.ClearErrors(propertyName);
        }

        protected void ValidateProperty<T>(Func<T, FluentValidation.Results.ValidationResult> validationFunc, T value, string propertyName)
        {
            ClearErrors(propertyName);

            var result = validationFunc(value);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    AddError(propertyName, error.ErrorMessage);
                }
            }
        }
    }
}
