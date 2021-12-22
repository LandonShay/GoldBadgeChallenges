using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings.Repository
{
    public class OutingsRepository
    {
        private readonly List<Outings> _outingsContext = new List<Outings>();

        public List<Outings> ViewAllOutings()
        {
            return _outingsContext;
        }

        public bool AddNewOuting(Outings outing)
        {
            if (outing == null)
            {
                return false;
            }
            else
            {
                _outingsContext.Add(outing);
                return true;
            }
        }
    }
}
