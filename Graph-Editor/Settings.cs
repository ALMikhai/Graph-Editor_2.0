using System;
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
using System.Drawing.Drawing2D;
using System.Windows.Media.Animation;
using System.Threading;
using System.Diagnostics;
using Graph_Editor.Algoritms;

namespace Graph_Editor
{
    public static class Settings
    {
        public static string BaseVertex = "vBlack";
        public static string BaseEdge = "eLightBlue";
        public static string BaseAnimationColor = "orbBlue";
        public static string BaseAnimationSpeed = "Medium";

        public static double AnimationTime = 1.5;
        public static Brush AnimationEllipseColor = Brushes.Blue;

    }
}
