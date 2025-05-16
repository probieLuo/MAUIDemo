using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocQuery.ViewModels
{
    internal class CocFormationViewModel : INotifyPropertyChanged
    {
        public CocFormationViewModel()
        {
            FormationImages = new ObservableCollection<FormationImage>()
            {
                new FormationImage(){ImageUrl="town_hall1a.webp",Name="一级大本营"},
                new FormationImage(){ImageUrl="town_hall2a.webp",Name="二级大本营"},
                new FormationImage(){ImageUrl="town_hall3a.webp",Name="三级大本营"},
                new FormationImage(){ImageUrl="town_hall4a.webp",Name="四级大本营"},
                new FormationImage(){ImageUrl="town_hall5a.webp",Name="五级大本营"},
                new FormationImage(){ImageUrl="town_hall6a.webp",Name="六级大本营"},
                new FormationImage(){ImageUrl="town_hall7a.webp",Name="七级大本营"},
                new FormationImage(){ImageUrl="town_hall8a.webp",Name="八级大本营"},
                new FormationImage(){ImageUrl="town_hall9a.webp",Name="九级大本营"},
                new FormationImage(){ImageUrl="town_hall10a.webp",Name="十级大本营"},
                new FormationImage(){ImageUrl="town_hall11a.webp",Name="十一级大本营"},
                new FormationImage(){ImageUrl="town_hall12_5a.webp",Name="十二级大本营"},
                new FormationImage(){ImageUrl="town_hall13_5a.webp",Name="十三级大本营"},
                new FormationImage(){ImageUrl="town_hall14_5a.webp",Name="十四级大本营"},
                new FormationImage(){ImageUrl="town_hall15_5a.webp",Name="十五级大本营"},
                new FormationImage(){ImageUrl="town_hall16a.webp",Name="十六级大本营"},
                new FormationImage(){ImageUrl="town_hall17_5a.webp",Name="十七级大本营"},
            };
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion
        private ObservableCollection<FormationImage> _formationImages;
        public ObservableCollection<FormationImage> FormationImages
        {
            get { return _formationImages; }
            set
            {
                _formationImages = value;
                OnPropertyChanged(nameof(FormationImages));
            }
        }

    }

    internal class FormationImage
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }
}
