﻿using System;
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
    }
}
