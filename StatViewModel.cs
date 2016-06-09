using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderCharacterSheet
{
    class StatViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int statBonus = -5, statValue;

        public int StatValue
        {
            set
            {
                if (statValue != value)
                {
                    statValue = value;
                    OnPropertyChanged("StatValue");
                    StatBonus = calculateStatBonus();
                }
            }
            get
            {
                return statValue;
            }
        }

        public int StatBonus
        {
            set
            {
                if (statBonus != value)
                {
                    statBonus = value;
                    OnPropertyChanged("StatBonus");
                }
            }
            get
            {
                return statBonus;
            }
        }

        /* Calculate the Pathfinder Stat Bonus */
        public int calculateStatBonus()
        {
            return (int)Math.Floor(((double)statValue - 10) / 2);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
