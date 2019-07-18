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
        public static List<Record> records = new List<Record>();

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
                Vertex rollback = Globals.VertexData.Find(match => (match.Index == (record.After as Vertex).Index
                                                         && match.Coordinates == (record.After as Vertex).Coordinates
                                                         && match.Color == (record.After as Vertex).Color));

                if (rollback != null)
                {
                    if(record.Befor == null)
                    {
                        Globals.GlobalIndex--;
                        Globals.VertexData.Remove(rollback);
                    }

                    if(record.After is List<int>)
                    {
                        // TODO Если в до лежит вершина, а в после лежит лист индексов - вставить обратно эту вершину и соеденить с вершинами в листе.
                    }

                    if((record.Befor is Vertex) && (record.After is Vertex))
                    {
                        Globals.VertexData.Add((Vertex)record.Befor);

                        foreach (var edge in Globals.EdgesData.ToArray())
                        {
                            if(edge.From == rollback)
                            {
                                edge.From = (Vertex)record.Befor;
                            }

                            if(edge.To == rollback)
                            {
                                edge.To = (Vertex)record.Befor;
                            }
                        }

                        Globals.VertexData.Remove(rollback);
                    }
                }
            }

            if ((record.Befor is Edge) || (record.After is Edge))
            {
                Edge rollbackDirected = Globals.EdgesData.Find(match => match == record.After);
                Edge rollbackUndirected = Globals.EdgesData.Find(match => (match.From == (record.After as Edge).To) && (match.To == (record.After as Edge).From));

                if(rollbackDirected != null)
                {
                    if (record.Befor == null)
                    {
                        if (!rollbackDirected.Directed)
                        {
                            Globals.Matrix[rollbackUndirected.From.Index, rollbackUndirected.To.Index] = 0;
                            Globals.EdgesData.Remove(rollbackUndirected);
                        }

                        Globals.Matrix[rollbackDirected.From.Index, rollbackDirected.To.Index] = 0;
                        Globals.EdgesData.Remove(rollbackDirected);
                    }
                }
            }
        }

        public static void Redo()
        {

        }
    }
}
