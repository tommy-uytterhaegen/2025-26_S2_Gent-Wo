using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiJokes.ViewModels.Base
{
    public abstract class ViewModel 
        : INotifyPropertyChanged // Dit zorgt ervoor dat de view zich kan 'abonneren' op de veranderingen
    {
        public event PropertyChangedEventHandler? PropertyChanged; // The event die wij zullen oproepen als een property gewijzigd is

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") // CallerMemberName zorgt ervoor dat de 'propertyName' de naam van de oproeper krijgt, deze kunnen we dan gebruiken om de event te lanceren
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
