using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Editor.UndoRedo
{
    public class Record
    {
        private int checker = 0;

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

        public int Checker
        {
            get
            {
                return checker;
            }
            set
            {
                checker = value;
            }
        }

        public Record(object befor, object after)
        {
            Befor = befor;
            After = after;
        }

        public Record(object befor, object after, int checker)
        {
            Befor = befor;
            After = after;
            Checker = checker;
        }
    }
}
