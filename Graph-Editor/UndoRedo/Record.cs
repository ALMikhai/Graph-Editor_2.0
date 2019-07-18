using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Editor.UndoRedo
{
    public class Record
    {
        public object Befor
        {
            get;
            set;
        }

        public object After
        {
            get;
            set;
        }

        public Record(object befor, object after)
        {
            Befor = befor;
            After = after;
        }
    }
}
