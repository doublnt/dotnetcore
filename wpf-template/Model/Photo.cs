using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace wpf_template.Model
{
    public class Photo : INotifyPropertyChanged
    {
        private string _name { get; set; }
        private string _location { get; set; }
        private bool _isVisible { get; set; }

        public Photo(string name, string location, bool isVisible)
        {
            _name = name;
            _location = location;
            _isVisible = isVisible;
        }

        public override string ToString()
        {
            return $"Name:{ _name}-Location:{_location}IsVisible-{_isVisible}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnProperyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                OnProperyChanged("Name");
            }
        }

        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                OnProperyChanged("Location");
            }
        }

        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                OnProperyChanged("IsVisible");
            }
        }
    }
}
