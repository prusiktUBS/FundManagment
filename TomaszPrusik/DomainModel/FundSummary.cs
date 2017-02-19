using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Annotations;

namespace DomainModel
{
    public class FundSummary : INotifyPropertyChanged
    {
        public Type Type { get; set; }
        public double _TotalNumber { get; set; }
        public double _TotalWeight { get; set; }
        public double _TotalMv { get; set; }

        public double TotalNumber
        {
            get { return _TotalNumber; }
            set
            {
                _TotalNumber = value;
                OnPropertyChanged("_TotalNumber");
            }
        }

        public double TotalWeight
        {
            get { return _TotalWeight; }
            set
            {
                _TotalWeight = value;
                OnPropertyChanged("_TotalWeight");
            }
        }

        public double TotalMv
        {
            get { return _TotalMv; }
            set
            {
                _TotalMv = value;
                OnPropertyChanged("_TotalMv");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
