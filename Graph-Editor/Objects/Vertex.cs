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

namespace Graph_Editor.Objects
{
    public class Vertex
    {
        private readonly int index;
        private Point coordinates;
        private Brush color = globals.color;

        public Brush Color
        { get { return color; } set { color = value; } }

        public int Index
        { get { return index; } }

        public Point Coordinates
        { get{return coordinates; } set { coordinates = value; } }
        
        public Vertex(int number, Point place) { index = number; coordinates = place; }

        public Vertex(int number) { index = number; }
        public Vertex() { }
    }
}
