using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Editor.Objects;
using System.Windows;

namespace Graph_Editor.UndoRedo
{
    public static class History
    {
        public static List<Record> records = new List<Record>();

        public static int numberRecords = 0;

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

        public static void Add(object befor, object after, int checker)
        {
            if (numberRecords != records.Count)
            {
                records.RemoveRange(numberRecords, records.Count - numberRecords);
            }

            Record newRecord = new Record(befor, after, checker);
            records.Add(newRecord);
            numberRecords++;
        }

        public static void UndoRedo(int n)
        {
            Record record;

            if (n == 0)
            {
                if (!canUndo)
                {
                    return;
                }

                numberRecords--;
                record = records[numberRecords];
            }
            else
            {
                if (!canRedo)
                {
                    return;
                }

                record = records[numberRecords];
                numberRecords++;
            }

            if ((record.Befor is Vertex) || (record.After is Vertex))
            {
                if ((record.Befor is Vertex) && (record.After is List<Edge>))
                {
                    UndoDeleteVertex(record, n);
                    return;
                }

                if(record.Befor == null)
                {
                    UndoAddVertex(record, n);
                    return;
                }
                
                if((record.Befor is Vertex) && (record.After is Vertex))
                {
                    UndoMoveVertex(record, n);
                    return;
                }
                
            }

            if ((record.Befor is Edge) || (record.After is Edge))
            {
                if (record.Befor == null)
                {
                    UndoAddEgde(record, n);
                    return;
                }
                
                if(record.After == null)
                {
                    UndoDeleteEgde(record, n);
                    return;
                }

                if((record.After is Edge) && (record.Befor is Edge))
                {
                    UndoChangeEdge(record, n);
                }
            }

            if((record.Befor is List <Vertex>) && (record.After is List<Edge>))
            {
                UndoClearAll(record, n);
            }

            if ((record.Befor is List<Edge>) && (record.After is List<Vertex>))
            {
                UndoLoadFile(record, n);
            }

            if ((record.Befor is List<Point>) && (record.After is List<Point>))
            {
                UndoMoveAllVertex(record, n);
            }

            if((record.Checker == 1))
            {
                UndoResize(record, n);
            }
        }

        // TODO Придумать другие названия для функций.

        private static void UndoAddVertex(Record record, int n)
        {
            Vertex rollback = Globals.FindVertex(record.After as Vertex);
            Globals.GlobalIndex--;
            Globals.VertexData.Remove(rollback);


            if (n == 0)
            {
                record.Befor = new Vertex(rollback);
                record.After = new List<Edge>();
            }
            else
            {
                List<Edge> adjacentVertices = new List<Edge>();

                foreach (var edge in Globals.EdgesData.ToArray())
                {
                    if (edge.From == rollback || edge.To == rollback)
                    {
                        adjacentVertices.Add(new Edge(edge));

                        Globals.EdgesData.Remove(edge);
                    }
                }

                foreach (var vertex in Globals.VertexData)
                {
                    if (vertex.Index >= rollback.Index && vertex != rollback)
                    {
                        vertex.Index--;
                    }
                }

                Globals.RestoreMatrix();

                record.Befor = new Vertex(rollback);
                record.After = adjacentVertices;
            }
        }


        private static void UndoDeleteVertex(Record record, int n)
        {
            Vertex vertexBefor = (Vertex)record.Befor;

            foreach (var vertex in Globals.VertexData)
            {
                if (vertex.Index >= vertexBefor.Index && vertex != vertexBefor)
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


            if (n == 0)
            {
                record.Befor = null;
                record.After = new Vertex(vertexBefor);
            }
            else
            {
                record.Befor = null;
                record.After = new Vertex(vertexBefor);
            }
        }

        private static void UndoAddEgde(Record record, int n)
        {
            Edge rollbackDirected = Globals.FindEdge((Edge)record.After);
            Edge rollbackUndirected = Globals.FindReversEdge((Edge)record.After);

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

            record.Befor = new Edge(rollbackDirected);
            record.After = null;
        }

        private static void UndoDeleteEgde(Record record, int n)
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

            record.Befor = null;
            record.After = new Edge(directedEdge);
        }

        private static void UndoClearAll(Record record, int n)
        {
            if (n == 1)
            {
                Globals.VertexData.Clear();
                Globals.EdgesData.Clear();
                Globals.GlobalIndex = 0;
                Globals.RestoreMatrix();
            }
            else
            {
                foreach (var vertex in (record.Befor as List<Vertex>))
                {
                    Globals.VertexData.Add(new Vertex(vertex));
                    Globals.GlobalIndex++;
                }

                foreach (var edge in (record.After as List<Edge>))
                {
                    Globals.EdgesData.Add(new Edge(Globals.FindVertex(edge.From), Globals.FindVertex(edge.To), edge.Weight, edge.Directed, edge.Color, edge.Thickness));
                }

                Globals.RestoreMatrix();
            }
        }

        private static void UndoMoveVertex(Record record, int n)
        {
            Vertex rollback = Globals.FindVertex(record.After as Vertex);

            Globals.VertexData.Add((Vertex)record.Befor);

            foreach (var edge in Globals.EdgesData.ToArray())
            {
                if (edge.From == rollback)
                {
                    edge.From = (Vertex)record.Befor;
                }

                if (edge.To == rollback)
                {
                    edge.To = (Vertex)record.Befor;
                }
            }

            record.After = new Vertex((Vertex)record.Befor);
            record.Befor = new Vertex(rollback);

            Globals.VertexData.Remove(rollback);
        }

        private static void UndoChangeEdge(Record record, int n)
        {
            Edge edgeBefor = (record.Befor as Edge);
            Edge edgeAfter = (record.After as Edge);

            Edge rollbackDirected = Globals.FindEdge(edgeAfter);

            if (rollbackDirected != null)
            {
                Edge directedEdge = new Edge(Globals.FindVertex(rollbackDirected.From), Globals.FindVertex(rollbackDirected.To), edgeBefor.Weight, edgeBefor.Directed, edgeBefor.Color, edgeBefor.Thickness);

                if (!rollbackDirected.Directed)
                {
                    Edge rollbackUnDirected = Globals.FindReversEdge(edgeAfter);
                    Edge unDirectedEdge = new Edge(Globals.FindVertex(rollbackUnDirected.From), Globals.FindVertex(rollbackUnDirected.To), edgeBefor.Weight, edgeBefor.Directed, edgeBefor.Color, edgeBefor.Thickness);
                    Globals.EdgesData.Remove(rollbackUnDirected);
                    Globals.EdgesData.Add(unDirectedEdge);
                }

                Globals.EdgesData.Remove(rollbackDirected);
                Globals.EdgesData.Add(directedEdge);

                Globals.RestoreMatrix();

                record.After = new Edge(edgeBefor);
                record.Befor = new Edge(edgeAfter);
            }
        }

        private static void UndoMoveAllVertex(Record record, int n)
        {
            Point startPoint = (record.Befor as List<Point>)[0];
            Point finishPoint = (record.After as List<Point>)[0];

            Vector vector = Point.Subtract(startPoint, finishPoint);

            foreach(var vertex in Globals.VertexData)
            {
                vertex.Coordinates = Point.Add(vertex.Coordinates, vector);
            }

            List<Point> startPoints = new List<Point>();
            startPoints.Add(finishPoint);

            List<Point> finishPoints = new List<Point>();
            finishPoints.Add(startPoint);

            record.Befor = startPoints;
            record.After = finishPoints;
        }

        private static void UndoLoadFile(Record record, int n)
        {
            if (n == 0)
            {
                Globals.VertexData.Clear();
                Globals.EdgesData.Clear();
                Globals.GlobalIndex = 0;
                Globals.RestoreMatrix();
            }
            else
            {
                foreach (var vertex in (record.After as List<Vertex>))
                {
                    Globals.VertexData.Add(new Vertex(vertex));
                    Globals.GlobalIndex++;
                }

                foreach (var edge in (record.Befor as List<Edge>))
                {
                    Globals.EdgesData.Add(new Edge(Globals.FindVertex(edge.From), Globals.FindVertex(edge.To), edge.Weight, edge.Directed, edge.Color, edge.Thickness));
                }

                Globals.RestoreMatrix();
            }
        }

        private static void UndoResize(Record record, int n)
        {
            Globals.VertexData.Clear();
            Globals.EdgesData.Clear();

            foreach (var vertex in (record.Befor as List<Vertex>))
            {
                Globals.VertexData.Add(vertex);
            }

            foreach(var edge in (record.After as List<Edge>))
            {
                Globals.EdgesData.Add(new Edge(Globals.FindVertex(edge.From), Globals.FindVertex(edge.To), edge.Weight, edge.Directed, edge.Color, edge.Thickness));
            }

            records.Remove(record);
        }
    }
}
