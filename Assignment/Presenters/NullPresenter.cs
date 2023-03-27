using System.Collections.Generic;

namespace Assignment.Presenters
{
    public class NullPresenter : IPresenter
    {

        public NullPresenter()
        {
        }

        public List<string> GetViewData()
        {
            List<string> lines = new List<string> { };

            return lines;
        }
    }
}
