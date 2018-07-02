using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.Client.Mobile.Navigation
{

    public class MyPageMenuItem
    {
        public MyPageMenuItem()
        {
            TargetType = typeof(MyPageDetail);
        }
        public string ImageSource { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}