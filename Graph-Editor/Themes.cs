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
    public static class Themes
    {
        public static Brush ColorEdge = Brushes.Black;
        public static Brush ColorInsideVertex = (Brush)new BrushConverter().ConvertFrom("#80FFFF");
        // Options Window
        public static Brush OptionsMainWindowOptionsColor = (Brush)new BrushConverter().ConvertFrom("#DCF5F5");
        public static Brush OptionsActiveToolBarButton = (Brush)new BrushConverter().ConvertFrom("#C6DCDC");
        public static Brush OptionsPassiveToolBarButton = (Brush)new BrushConverter().ConvertFrom("#B0C4C4");
        public static Brush OptionsWindowExitButtons = (Brush)new BrushConverter().ConvertFrom("#CBDFDF");
        public static Brush OptionsPassiveAnimationSpeedButtons = (Brush)new BrushConverter().ConvertFrom("#C6DCDC");
        public static Brush OptionsActiveAnimationSpeedButtons = (Brush)new BrushConverter().ConvertFrom("#849393");
        public static Brush OptionsVEResetButton = Brushes.Gray;
        public static Brush OptionsVECheckButton = Brushes.DarkSeaGreen;

        // Algoritms Window
        public static Brush AlgoMainWindowColor = Brushes.PaleTurquoise;
        public static Brush AlgoIsAlgoReady = Brushes.CadetBlue;
        public static Brush AlgoIsAlgoFailed = (Brush)new BrushConverter().ConvertFrom("#AFCECF");
        public static Brush AlgoCancelButton = (Brush)new BrushConverter().ConvertFrom("#B9C2C2");

        // Main Window
        public static Brush MainMainWindow = (Brush)new BrushConverter().ConvertFrom("#0A3F4C");
        public static Brush MainTeamName = (Brush)new BrushConverter().ConvertFrom("#B7E1E1");
        public static Brush MainToolsButtons = (Brush)new BrushConverter().ConvertFrom("#345160");
        public static Brush MainToolsButtonsHover = (Brush)new BrushConverter().ConvertFrom("#4c7184");
        public static Brush MainCanvas = (Brush)new BrushConverter().ConvertFrom("#B7E1E1");
        public static Brush MainMenu = Brushes.Black;
        public static Brush MainExitDialog = Brushes.White;
        public static Brush MainMenuItems = Brushes.Black;

        // Documentation Window
        public static Brush DocCreatorsButton = Brushes.Transparent;
        public static Brush DocCreatorsWindow = Brushes.White;
        public static Brush DocExitButton = Brushes.Transparent;
        public static Brush DocExitButtonHover = Brushes.WhiteSmoke;

        // Connect Window
        public static Brush ConnectMainWindow = (Brush)new BrushConverter().ConvertFrom("#98B0B0");
        public static Brush ConnectWindowForVertex = (Brush)new BrushConverter().ConvertFrom("#728484");
        public static Brush ConnectSlider = (Brush)new BrushConverter().ConvertFrom("#98B0B0");
        public static Brush ConnectSliderWindow = (Brush)new BrushConverter().ConvertFrom("#728484");
        public static Brush ConnectResultButtons = (Brush)new BrushConverter().ConvertFrom("#B2B4B4");
        public static Brush ConnectUnactiveOrientation = (Brush)new BrushConverter().ConvertFrom("#98B0B0");
        public static Brush ConnectActiveOrientation = (Brush)new BrushConverter().ConvertFrom("#789778");
        public static Brush ConnectUnactiveOrientationHover = (Brush)new BrushConverter().ConvertFrom("#BCCBBC");
    }
}