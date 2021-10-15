﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Pokedex_FormationMobile.Tools
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propName = "") //nom de la prop a modifier
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        }

        protected virtual void SetValue<T>(ref T oldValue, T newValue, [CallerMemberName] string propName = "")
        {
            if (!EqualityComparer<T>.Default.Equals(oldValue, newValue))
            {
                oldValue = newValue;
                OnPropertyChanged(propName);
            }
        }
    }
}
