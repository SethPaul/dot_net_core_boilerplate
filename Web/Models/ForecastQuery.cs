using System.Collections.Generic;

namespace ForecastCore.Models
{
    public class ForecastQuery
    {
        public Dictionary<string, List<string>> Filters;
        public string QueryText;
        public int Take = 10;
        public string Cursor;
        public List<string> Groups;
    }

}
