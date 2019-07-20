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

                if ((record.Befor is Vertex) && (record.After is List<Edge>))
                {
                    for(var i = (record.Befor as Vertex).Index; i < Globals.VertexData.Count; ++i)
                    {
                        Globals.VertexData[i].Index++;
                    }

                    Globals.VertexData.Add((Vertex)record.Befor);

                    foreach (var edge in (List<Edge>)record.After)
                    {
                        if (edge.From.Index == (record.Befor as Vertex).Index && edge.From.Coordinates == (record.Befor as Vertex).Coordinates && edge.From.Color == (record.Befor as Vertex).Color)
                        {
                            Vertex to = findVertex(edge.To);
                            Globals.EdgesData.Add(new Edge((Vertex)record.Befor, to, edge.Weight, edge.Directed, edge.Color, edge.Thickness));
                        }
                        else
                        {
                            Vertex from = findVertex(edge.From);
                            Globals.EdgesData.Add(new Edge(from, (Vertex)record.Befor, edge.Weight, edge.Directed, edge.Color, edge.Thickness));
                        }
                    }

                    Globals.RestoreMatrix();

                    return;
                }

                Vertex rollback = findVertex(record.After as Vertex);
                
                if(record.Befor == null)
                {
                    Globals.GlobalIndex--;
                    Globals.VertexData.Remove(rollback);
                    return;
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
                    return;
                }
                
            }

            if ((record.Befor is Edge) || (record.After is Edge))
            {
                Edge rollbackDirected = findEdge((Edge)record.After);
                Edge rollbackUndirected = findReversEdge((Edge)record.After);

                if (rollbackDirected != null)
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

        private static Vertex findVertex(Vertex vertex)
        {
            return Globals.VertexData.Find(match => (match.Index == vertex.Index
                                                  && match.Coordinates == vertex.Coordinates
                                                  && match.Color == vertex.Color));
        }

        private static Edge findEdge(Edge edge)
        {
            return Globals.EdgesData.Find(match => (match.From == findVertex(edge.From) && match.To == findVertex(edge.To)));
        }

        private static Edge findReversEdge(Edge edge)
        {
            return Globals.EdgesData.Find(match => (match.From == findVertex(edge.To) && match.To == findVertex(edge.From)));
        }
    }
}
