using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.CrossCutting.Helper
{
    public class PagedParameters
    {
        public int PageSizeMax { get; private set; } = 50;
        public int NumberPage { get; set; } = 1;
        public int _PageSize { get; private set; } = 10;
        public int PageSize
        {
            get
            {
                return _PageSize;
            }
            set
            {
                _PageSize = value > PageSizeMax ? PageSizeMax : value;
            }
        }
    }
}
