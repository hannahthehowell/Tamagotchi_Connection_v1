using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    internal class ScreenSettings
    {
        public static int cellWidth { get; set; }
        public static int cellHeight { get; set; }
        public static int screenSizeX;
        public static int screenSizeY;
        public ScreenSettings()
        {
            cellWidth = 3;  // num pixels per cell
            cellHeight = 3;

            // size of screen
            screenSizeX = 96;
            screenSizeY = 90;
        }
    }
}
