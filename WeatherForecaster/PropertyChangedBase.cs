using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecaster
{
    [Magic]
    /// <summary>
    /// Class  for simplify implementation of INotifyPropertyChanged
    /// </summary>
    public abstract class PropertyChangedBase : INotifyPropertyChanged
    {
        protected virtual void RaisePropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    /// <summary>
    /// Attribute for KindOfMagic MSBuild task
    /// </summary>
    class MagicAttribute : Attribute { }
}
