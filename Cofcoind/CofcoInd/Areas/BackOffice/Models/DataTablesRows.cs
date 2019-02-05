using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CofcoInd.Areas.Models
{
        public class NTr
        {
            public int _DT_RowIndex { get; set; }
        }

        public class DTCellIndex
        {
            public int row { get; set; }
            public int column { get; set; }
        }

        public class AnCell
        {
            public DTCellIndex _DT_CellIndex { get; set; }
        }

        public class DataTablesRows
    {
            public NTr nTr { get; set; }
            public List<AnCell> anCells { get; set; }
            public List<string> _aData { get; set; }
            public List<string> _aSortData { get; set; }
            public object _aFilterData { get; set; }
            public object _sFilterRow { get; set; }
            public string _sRowStripe { get; set; }
            public string src { get; set; }
            public int idx { get; set; }
        }

    
}