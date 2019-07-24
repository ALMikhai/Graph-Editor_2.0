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
        public static int ChooseTheme = 1;

        public static string logoPath;

        public static Brush ColorInsideVertex;
        public static Brush ColorOfTheTextOfVertex;

        public static Brush OptionsMainWindowOptionsColor;
        public static Brush OptionsActiveToolBarButton;
        public static Brush OptionsPassiveToolBarButton;
        public static Brush OptionsWindowExitButtons;
        public static Brush OptionsPassiveAnimationSpeedButtons;
        public static Brush OptionsActiveAnimationSpeedButtons;
        public static Brush OptionsVEResetButton;
        public static Brush OptionsVECheckButton;

        public static Brush AlgoMainWindowColor;
        public static Brush AlgoIsAlgoReady;
        public static Brush AlgoIsAlgoFailed;
        public static Brush AlgoIsAlgoReadyHover;

        public static Brush MainMainWindow;
        public static Brush MainTeamName;
        public static Brush MainToolsButtons;
        public static Brush MainToolsButtonsHover;
        public static Brush MainChooseToolButton;
        public static Brush MainCanvas;
        public static Brush MainMenu;
        public static Brush MainExitDialog;
        public static Brush MainMenuItems;
        public static Brush MainMenuItemsBorder;

        public static Brush DocMainWindow;
        public static Brush DocCreatorsButton;
        public static Brush DocCreatorsWindow;
        public static double DocCreatorsWindowOpacity;
        public static Brush DocExitButton;
        public static Brush DocExitButtonHover;

        public static Brush ConnectMainWindow;
        public static Brush ConnectWindowForVertex;
        public static Brush ConnectSlider;
        public static Brush ConnectSliderWindow;
        public static Brush ConnectResultButtons;
        public static Brush ConnectUnactiveOrientation;
        public static Brush ConnectActiveOrientation;
        public static Brush ConnectUnactiveOrientationHover;

        // Ice Theme
        public static void IceTheme()
        {
            ChooseTheme = 1;

            logoPath = "../../images/Icelogo.png";

            ColorInsideVertex = (Brush)new BrushConverter().ConvertFrom("#80FFFF");
            ColorOfTheTextOfVertex = (Brush)new BrushConverter().ConvertFrom("#305F5F");

            // Options Window
            OptionsMainWindowOptionsColor = (Brush)new BrushConverter().ConvertFrom("#DCF5F5");
            OptionsActiveToolBarButton = (Brush)new BrushConverter().ConvertFrom("#C6DCDC");
            OptionsPassiveToolBarButton = (Brush)new BrushConverter().ConvertFrom("#B0C4C4");
            OptionsWindowExitButtons = (Brush)new BrushConverter().ConvertFrom("#CBDFDF");
            OptionsPassiveAnimationSpeedButtons = (Brush)new BrushConverter().ConvertFrom("#C6DCDC");
            OptionsActiveAnimationSpeedButtons = (Brush)new BrushConverter().ConvertFrom("#849393");
            OptionsVEResetButton = Brushes.Gray;
            OptionsVECheckButton = Brushes.DarkSeaGreen;

            // Algoritms Window
            AlgoMainWindowColor = Brushes.PaleTurquoise;
            AlgoIsAlgoReady = Brushes.CadetBlue;
            AlgoIsAlgoFailed = (Brush)new BrushConverter().ConvertFrom("#7EB1B3");
            AlgoIsAlgoReadyHover = (Brush)new BrushConverter().ConvertFrom("#7EB1B3");

            // Main Window
            MainMainWindow = (Brush)new BrushConverter().ConvertFrom("#0A3F4C");
            MainTeamName = (Brush)new BrushConverter().ConvertFrom("#B7E1E1");
            MainToolsButtons = (Brush)new BrushConverter().ConvertFrom("#345160");
            MainToolsButtonsHover = (Brush)new BrushConverter().ConvertFrom("#4c7184");
            MainChooseToolButton = Brushes.CadetBlue;
            MainCanvas = (Brush)new BrushConverter().ConvertFrom("#B7E1E1");
            MainMenu = Brushes.Black;
            MainExitDialog = Brushes.White;
            MainMenuItems = Brushes.Black;
            MainMenuItemsBorder = Brushes.Black;

            // Documentation Window
            DocMainWindow = Brushes.White;
            DocCreatorsButton = Brushes.Transparent;
            DocCreatorsWindow = Brushes.White;
            DocCreatorsWindowOpacity = 0.9;
            DocExitButton = Brushes.Transparent;
            DocExitButtonHover = Brushes.WhiteSmoke;

            // Connect Window
            ConnectMainWindow = (Brush)new BrushConverter().ConvertFrom("#98B0B0");
            ConnectWindowForVertex = (Brush)new BrushConverter().ConvertFrom("#728484");
            ConnectSlider = Brushes.Transparent;
            ConnectSliderWindow = (Brush)new BrushConverter().ConvertFrom("#728484");
            ConnectResultButtons = (Brush)new BrushConverter().ConvertFrom("#B2B4B4");
            ConnectUnactiveOrientation = Brushes.Transparent;
            ConnectActiveOrientation = (Brush)new BrushConverter().ConvertFrom("#789778");
            ConnectUnactiveOrientationHover = (Brush)new BrushConverter().ConvertFrom("#BCCBBC");
        }

        // Vulcan Theme
        public static void VolcanoTheme()
        {
            ChooseTheme = 2;

            logoPath = "../../images/Vulcanlogo.png";

            ColorInsideVertex = (Brush)new BrushConverter().ConvertFrom("#F0854D");
            ColorOfTheTextOfVertex = (Brush)new BrushConverter().ConvertFrom("#BF1111");

            // Main Window
            MainMainWindow = (Brush)new BrushConverter().ConvertFrom("#763C4B");
            MainTeamName = (Brush)new BrushConverter().ConvertFrom("#F8A376");
            MainToolsButtons = (Brush)new BrushConverter().ConvertFrom("#5E303C");
            MainToolsButtonsHover = (Brush)new BrushConverter().ConvertFrom("#522A34");
            MainChooseToolButton = (Brush)new BrushConverter().ConvertFrom("#3F2030");
            MainCanvas = (Brush)new BrushConverter().ConvertFrom("#F8A376");
            MainMenu = (Brush)new BrushConverter().ConvertFrom("#3F2030");
            MainExitDialog = (Brush)new BrushConverter().ConvertFrom("#3F2030");
            MainMenuItems = (Brush)new BrushConverter().ConvertFrom("#3F2030");
            MainMenuItemsBorder = (Brush)new BrushConverter().ConvertFrom("#3F2030");

            // Documentation Window
            DocMainWindow = (Brush)new BrushConverter().ConvertFrom("#FABE9F");
            DocCreatorsButton = Brushes.Transparent;
            DocCreatorsWindow = (Brush)new BrushConverter().ConvertFrom("#FABE9F");
            DocCreatorsWindowOpacity = 0.9;
            DocExitButton = Brushes.Transparent;
            DocExitButtonHover = (Brush)new BrushConverter().ConvertFrom("#FBD1BA");

            // Algoritms Window
            AlgoMainWindowColor = (Brush)new BrushConverter().ConvertFrom("#DF926A");
            AlgoIsAlgoReady = (Brush)new BrushConverter().ConvertFrom("#91626E");
            AlgoIsAlgoFailed = (Brush)new BrushConverter().ConvertFrom("#F8A376");
            AlgoIsAlgoReadyHover = (Brush)new BrushConverter().ConvertFrom("#B29199");

            // Options Window
            OptionsMainWindowOptionsColor = (Brush)new BrushConverter().ConvertFrom("#F8AC83");
            OptionsActiveToolBarButton = (Brush)new BrushConverter().ConvertFrom("#FD926A");
            OptionsPassiveToolBarButton = (Brush)new BrushConverter().ConvertFrom("#B29199");
            OptionsWindowExitButtons = (Brush)new BrushConverter().ConvertFrom("#F8A376");
            OptionsPassiveAnimationSpeedButtons = (Brush)new BrushConverter().ConvertFrom("#F8A376");
            OptionsActiveAnimationSpeedButtons = (Brush)new BrushConverter().ConvertFrom("#C6825E");
            OptionsVEResetButton = Brushes.Gray;
            OptionsVECheckButton = (Brush)new BrushConverter().ConvertFrom("#763C4B");

            // Connect Window
            ConnectMainWindow = (Brush)new BrushConverter().ConvertFrom("#834F5D");
            ConnectWindowForVertex = (Brush)new BrushConverter().ConvertFrom("#6A3643");
            ConnectSlider = Brushes.Transparent;
            ConnectSliderWindow = (Brush)new BrushConverter().ConvertFrom("#6A3643");
            ConnectResultButtons = (Brush)new BrushConverter().ConvertFrom("#cdb8be");
            ConnectUnactiveOrientation = Brushes.Transparent;
            ConnectActiveOrientation = (Brush)new BrushConverter().ConvertFrom("#FD926A");
            ConnectUnactiveOrientationHover = (Brush)new BrushConverter().ConvertFrom("#a8838d");
        }
    }
}