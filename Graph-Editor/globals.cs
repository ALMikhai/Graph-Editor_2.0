﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using Graph_Editor.Objects;
using System.ComponentModel;
using System.Timers;


namespace Graph_Editor
{
    public static class globals
    {
        public static int globalIndex = 0;
        public static int Size = 100;
        public static int[,] matrix = new int[Size, Size];
        public static List<Vertex> vertexData = new List<Vertex>();
        public static List<Edge> edgesData = new List<Edge>();
        public static Brush color = Brushes.Black;
        public static Pen pen = new Pen(color, 6);
        public static Pen algopen = new Pen(Brushes.Red, 6);
        public static int vertRadius = 20;
        
        public static Brush colorInsideVertex = (Brush)new BrushConverter().ConvertFrom("#80FFFF");
        public static bool IsAlgo = false;


        public static Dictionary<int, Tool> toolList = new Dictionary<int, Tool>
        {
            {0, new  AddVertex()},
            {1, new  MoveVertex()},
        };

        public static Tool toolNow = toolList[0];

        public static bool IsBe(int value)
        {
            if (value > vertexData.Count - 1)
                return false;
            return true;
        }
    }
}
