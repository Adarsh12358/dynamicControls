using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamicControls
{
    public class BaseViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propName)
        {
            // /sad/f /asdf/ 

            ///asd fsa/f 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
