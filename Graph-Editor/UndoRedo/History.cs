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
                // DelVertex.
                if ((record.Befor is Vertex) && (record.After is List<Edge>))
                {
                    Vertex vertexBefor = (Vertex)record.Befor;

                    foreach(var vertex in Globals.VertexData)
                    {
                        if(vertex.Index >= vertexBefor.Index && vertex != vertexBefor)
                        {
                            vertex.Index++;
                        }
                    }

                    Globals.VertexData.Add(vertexBefor);

                    foreach (var edge in (List<Edge>)record.After)
                    {
                        if (edge.From.Index == vertexBefor.Index 
                            && edge.From.Coordinates == vertexBefor.Coordinates 
                            && edge.From.Color == vertexBefor.Color)
                        {
                            Vertex to = Globals.FindVertex(edge.To);
                            Globals.EdgesData.Add(new Edge(vertexBefor, to, edge.Weight, edge.Directed, edge.Color, edge.Thickness));
                        }
                        else
                        {
                            Vertex from = Globals.FindVertex(edge.From);
                            Globals.EdgesData.Add(new Edge(from, vertexBefor, edge.Weight, edge.Directed, edge.Color, edge.Thickness));
                        }
                    }

                    Globals.RestoreMatrix();

                    Globals.GlobalIndex++;

                    return;
                }

                Vertex rollback = Globals.FindVertex(record.After as Vertex);
                
                // AddVertex.
                if(record.Befor == null)
                {
                    Globals.GlobalIndex--;
                    Globals.VertexData.Remove(rollback);
                    return;
                }

                // MoveVertex.
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
                Edge rollbackDirected;
                Edge rollbackUndirected;

                // AddEdge.
                if (record.Befor == null)
                {
                    rollbackDirected = Globals.FindEdge((Edge)record.After);
                    rollbackUndirected = Globals.FindReversEdge((Edge)record.After);

                    if (rollbackDirected != null)
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

                // DelVertex.
                if(record.After == null)
                {
                    Edge edge = (Edge)record.Befor;

                    Vertex from = Globals.FindVertex(edge.From);
                    Vertex to = Globals.FindVertex(edge.To);

                    Edge directedEdge = new Edge(from, to, edge.Weight, edge.Directed, edge.Color, edge.Thickness);
                    Globals.EdgesData.Add(directedEdge);

                    if (!edge.Directed)
                    {
                        Edge unDirectedEdge = new Edge(to, from, edge.Weight, edge.Directed, edge.Color, edge.Thickness);
                        Globals.EdgesData.Add(unDirectedEdge);
                    }

                    Globals.RestoreMatrix();
                }
            }
        }

        public static void Redo()
        {

        }
    }
}
