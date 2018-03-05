using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUserControlUsage
{
    public class CardsViewModel
    {
        public ObservableCollection<CardViewModel> Cards { get; set; }
    }

    public class CardViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Bitmap Picture { get; set; }
    }

}
