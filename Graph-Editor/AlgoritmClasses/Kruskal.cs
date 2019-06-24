﻿using Graph_Editor.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Editor.AlgoritmClasses
{
    public static class Kruskal
    {
        public static List<Edge> edgesUsed = new List<Edge>();
        static int[] p = new int[globals.Size];
        static Random rnd = new Random();

        
        
        static int dsu_get(int v)
        {
            return (v == p[v]) ? v : (p[v] = dsu_get(p[v]));
        }

        static void dsu_unite(int a, int b)
        {
            a = dsu_get(a);
            b = dsu_get(b);
            if(rnd.Next() % 2 == 0)
            {
                int c = a;
                a = b;
                b = c;
            }
            if (a != b)
                p[a] = b;
        }

        public static void Start(int v)
        {
            List<Edge> list = new List<Edge>(globals.edgesData);
            list.Sort((e1, e2) => e1.Weight.CompareTo(e2.Weight));
            int a = 0;
        }

        static void kru(int v)
        {

        }
    }
}
