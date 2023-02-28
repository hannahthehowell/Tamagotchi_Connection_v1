using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    internal class Screen
    {
        private int[][] screenArr;
        private int height;
        private int width;
        public Screen(int height=0, int width=0)
        {
            this.height = (height == 0) ? ScreenSettings.screenHeightNumCells : height;
            this.width = (width == 0) ? ScreenSettings.screenWidthNumCells : width;

            screenArr = new int[this.height][];
            for (int i = 0; i < screenArr.Length; i++)
            {
                int[] line = new int[this.width];
                for (int j = 0; j < line.Length; j++)
                {
                    line[j] = 0;
                }
                screenArr[i] = line;
            }
        }

        public int[][] getScreenArr() { return screenArr; }
        public int getHeight() { return height; }
        public int getWidth() { return width; }

        public void setSinglePixel(int val, int y, int x) { screenArr[y][x] = val; }

        private void addSpriteToScreen(int[][] toAdd, int topY, int leftX)
        {
            for (int row = 0; row < toAdd.Length; row++)
            {
                for (int col = 0; col < toAdd[row].Length; col++)
                {
                    screenArr[row + topY][col + leftX] = toAdd[row][col];
                }
            }
        }

        public void addSpriteFromTopLeft(int[][] sprite, int startingCellY=0, int startingCellX=0)
        {
            addSpriteToScreen(sprite, startingCellY, startingCellX);
        }
        public void addSpriteFromBottomLeft(int[][] sprite, int startingCellY, int startingCellX)
        {
            startingCellY = startingCellY - sprite.Length;
            addSpriteToScreen(sprite, startingCellY, startingCellX);
        }
        public void addSpriteFromMiddle(int[][] sprite, int centerCellY, int centerCellX)
        {
            int startingCellX = centerCellX - sprite[0].Length / 2;
            int startingCellY = centerCellY - sprite.Length / 2;
            addSpriteToScreen(sprite, startingCellY, startingCellX);
        }
        public void addSpriteFromTopAtMiddle(int[][] sprite, int startingCellY)
        {
            int startingCellX = (ScreenSettings.screenWidthNumCells / 2) - (sprite[0].Length / 2);
            addSpriteToScreen(sprite, startingCellY, startingCellX);
        }
        public void addSpriteFromBottomAtMiddle(int[][] sprite, int startingCellY)
        {
            int startingCellX = (ScreenSettings.screenWidthNumCells / 2) - (sprite[0].Length / 2);
            startingCellY = startingCellY - sprite.Length;
            addSpriteToScreen(sprite, startingCellY, startingCellX);
        }
        public void addSpriteAtBottom(int[][] sprite, int startingCellX)
        {
            int startingCellY = ScreenSettings.screenHeightNumCells - sprite.Length;
            addSpriteToScreen(sprite, startingCellY, startingCellX);
        }
        public void addSpriteAtBottomCenter(int[][] sprite)
        {
            int startingCellX = (ScreenSettings.screenWidthNumCells / 2) - (sprite[0].Length / 2);
            int startingCellY = ScreenSettings.screenHeightNumCells - sprite.Length;
            addSpriteToScreen(sprite, startingCellY, startingCellX);
        }
        public void addSpriteAtCenterCenter(int[][] sprite)
        {
            int startingCellX = (ScreenSettings.screenWidthNumCells - sprite[0].Length) / 2;
            int startingCellY = (ScreenSettings.screenHeightNumCells - sprite.Length) / 2;
            addSpriteToScreen(sprite, startingCellY, startingCellX);
        } 
    }
}
