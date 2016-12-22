using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovayaRabota.Models
{
    public class CanModifyWrapper<ICompanySegment>
    {
        public CanModifyWrapper()
        {
            
        }
        public CanModifyWrapper(ICompanySegment value)
        {
            this.Value = value;
        }

        public ICompanySegment Value { get; set; }

        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }

    public static class CanModifyWraperManager
    {
        public static T UnPackCanModifyWrapper<T>(CanModifyWrapper<T> segment)
        {
            if (segment != null)
                return segment.Value;
            else
                return default(T);
        }
        public static List<T> UnPackCanModifyWrapper<T>(IEnumerable<CanModifyWrapper<T>> segmentList)
        {
            List<T> resultingList = new List<T>();
            segmentList.ToList().ForEach(item => resultingList.Add(UnPackCanModifyWrapper(item)));
            return resultingList;
        }
    }

}
