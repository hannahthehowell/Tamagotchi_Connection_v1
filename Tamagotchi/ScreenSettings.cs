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

        public static int cellsPerLetterHeight;
        public static int cellsPerLetterWidth;
        public static int cellsPerNumberHeight;
        public static int cellsPerNumberWidth;
        public static int cellsPerNumberSmallHeight;
        public static int cellsPerNumberSmallWidth;
        public ScreenSettings()
        {
            cellWidth = 3;  // num pixels per cell
            cellHeight = 3;

            // size of screen
            screenSizeX = 96;
            screenSizeY = 90;

            cellsPerLetterHeight = 7;
            cellsPerLetterWidth = 6;
            cellsPerNumberHeight = 7;
            cellsPerNumberWidth = 5;
            cellsPerNumberSmallHeight = 5;
            cellsPerNumberSmallWidth = 4;
        }
    }
}
