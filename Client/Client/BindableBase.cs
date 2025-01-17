﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client
{
    public class BindableBase : INotifyPropertyChanged
    {

        public bool isToolTipVisible = false;

        public bool IsToolTipVisible
        {
            get { return isToolTipVisible; }
            set { isToolTipVisible = value; }
        }

        protected virtual void SetProperty<T>(ref T member, T val,
           [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, val)) return;

            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
