using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

using WpfMvvm.Command;
using WpfMvvm.Model;

namespace WpfMvvm.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private readonly Person _person;
        private PersonViewModelCommand _personCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public PersonViewModel()
        {
            _person = new Person()
            {
                Age = 30,
                BirthDate = DateTime.Now.AddYears(-10),
                Gender = 'F',
                Message = "This is a test message.",
                Name = "Yin in 10jqka"
            };
            _personCommand = new PersonViewModelCommand(ActionMethod, IsValid);
        }

        public string UserName
        {
            get => _person.Name;
            set
            {
                if (_person.Name != value)
                {
                    OnPropertyChanged("Name");
                    _person.Name = value;
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string AgeDisplayColor => _person.Age > 30 ? "Red" : "Green";

        public string Gender
        {
            get => _person.Gender.ToString();
            set => _person.Gender = char.Parse(value);
        }

        public string Message
        {
            get => _person.Message;
            set => _person.Message = value;
        }

        public ICommand BtnClick
        {
            get => _personCommand;
        }

        private bool IsValid()
        {
            return true;
        }

        public void ActionMethod()
        {
            UserName = "10086 YINXITEST";
        }
    }
}
