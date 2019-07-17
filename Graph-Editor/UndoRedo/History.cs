using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Editor.Objects;

namespace Graph_Editor.UndoRedo
{
    public static class History
    {
        private static List<Record> records = new List<Record>();

        private static int numberRecords = 0;

        private static bool canUndo
        {
            get
            {
                int count = records.Count;
                return ((count > 0 && numberRecords > 0) ? true : false);
            }
        }

        private static bool canRedo
        {
            get
            {
                return ((numberRecords < records.Count) ? true : false);
            }
        } 

        public static void Add(object befor, object after)
        {
            if(numberRecords != records.Count)
            {
                records.RemoveRange(numberRecords, records.Count - numberRecords);
            }

            Record newRecord = new Record(befor, after);
            records.Add(newRecord);
            numberRecords++;
        }

        public static void Undo()
        {
            if (!canUndo)
            {
                return;
            }

            Record record = records[numberRecords - 1];
            numberRecords--;

            if ((record.Befor is Vertex) || (record.After is Vertex))
            {
                Vertex rollback = Globals.VertexData.Find(match => match == record.After);

                if (record.Befor == null)
                {
                    if(rollback != null)
                    {
                        Globals.VertexData.Remove(rollback);
                    }
                }
                else
                {
                    rollback = (Vertex)record.Befor;
                }
                // Есть сомнения что это так работает.

            }
        }

        public static void Redo()
        {

        }
    }
}
