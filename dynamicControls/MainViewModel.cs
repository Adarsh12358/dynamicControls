using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamicControls
{
    public class Specification : BaseViewModel
    {

        public Specification(RelayCommand RemoveLastCommand)
        {
            this.RemoveLastCommand = RemoveLastCommand;
        }

        public RelayCommand RemoveLastCommand { get; set; }

        private int _specId;
        public int SpecId { get { return _specId; } set { _specId = value; OnPropertyChanged(nameof(SpecId)); } }


        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value; OnPropertyChanged(nameof(Name));
            }
        }


        private string _value;
        public string Value { get { return _value; } set { _value = value; OnPropertyChanged(nameof(Value)); } }



    }
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Specification> SpecificationsList { get; set; }
        public RelayCommand AddNewRowCommand { get; set; }
        private RelayCommand RemoveLastCommand { get; set; }



        public MainViewModel()
        {
            AddNewRowCommand = new RelayCommand(AddNewRow);
            RemoveLastCommand = new RelayCommand(RemoveLastRow);
            SpecificationsList = new ObservableCollection<Specification>();
        }

        private void RemoveLastRow(object obj)
        {
            var a = SpecificationsList.FirstOrDefault(x => x.SpecId == (int)obj);
            var index = SpecificationsList.IndexOf(a);
            SpecificationsList.RemoveAt(index);
        }

        private void AddNewRow(object obj)
        {
            SpecificationsList.Add(new Specification(RemoveLastCommand) { SpecId = SpecificationsList.Max(x => x.SpecId) + 1 });
        }
    }
}
