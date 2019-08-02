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
using System.Runtime.Serialization;


namespace Graph_Editor
{

    [Serializable]
    public class Settings : ISerializable
    {
        public Brush BaseVertex = (Brush)new BrushConverter().ConvertFrom("#80FFFF");
        public Brush BaseEdge = Brushes.Black;
        public string BaseAnimationColor = "orbBlue";
        public string BaseAnimationSpeed = "Medium";

        public int ChooseTheme = 1;
        public double AnimationTime = 1.5;
        public Brush AnimationEllipseColor = Brushes.Blue;
        public Brush ColorEdge = Brushes.Black;
        public Brush ColorInsideVertex = (Brush)new BrushConverter().ConvertFrom("#80FFFF");

        public string currentTheme = "VulcanTheme";

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("BaseVertex", BaseVertex.ToString());
            info.AddValue("BaseEdge", BaseEdge.ToString());
            info.AddValue("BaseAnimationColor", BaseAnimationColor);
            info.AddValue("BaseAnimationSpeed", BaseAnimationSpeed);
            info.AddValue("ChooseTheme", ChooseTheme);
            info.AddValue("AnimationTime", AnimationTime);
            info.AddValue("AnimationEllipseColor", AnimationEllipseColor.ToString());
            info.AddValue("currentTheme", currentTheme);
            info.AddValue("ColorEdge", ColorEdge.ToString());
            info.AddValue("ColorInsideVertex", ColorInsideVertex.ToString());
        }

        public Settings(SerializationInfo info, StreamingContext context)
        {
            BaseVertex              = (Brush)new BrushConverter().ConvertFrom((string)info.GetValue("BaseVertex", typeof(string)));
            BaseEdge                = (Brush)new BrushConverter().ConvertFrom((string)info.GetValue("BaseEdge", typeof(string)));
            BaseAnimationColor      = (string)info.GetValue("BaseAnimationColor", typeof(string));
            BaseAnimationSpeed      = (string)info.GetValue("BaseAnimationSpeed", typeof(string));
            ChooseTheme             = (int)info.GetValue("ChooseTheme", typeof(int));
            AnimationTime           = (double)info.GetValue("AnimationTime", typeof(double));
            AnimationEllipseColor   = (Brush)new BrushConverter().ConvertFromString((string)info.GetValue("AnimationEllipseColor", typeof(string)));
            currentTheme            = (string)info.GetValue("currentTheme", typeof(string));
            ColorEdge               = (Brush)new BrushConverter().ConvertFromString((string)info.GetValue("ColorEdge", typeof(string)));
            ColorInsideVertex       = (Brush)new BrushConverter().ConvertFromString((string)info.GetValue("ColorInsideVertex", typeof(string)));
        }

        public Settings()
        {

        }
    }
}
