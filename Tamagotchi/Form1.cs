using System.Drawing.Imaging;
using System.Text.Json;

namespace Tamagotchi
{
    public partial class Form1 : Form
    {
        private int numTicks = 0;
        private const int ticksPerFrame = 4;
        private bool isMenuOpen;
        private bool toggleMenu;

        private Pet pet;

        public Form1()
        {
            InitializeComponent();

            new ScreenSettings();
            populateSpriteSheets();
        }

        private void populateSpriteSheets()
        {
            // TODO read in and populate other sprite sheets
            //string fileName = "masterSpriteSheet.json";
            //string jsonString = File.ReadAllText(fileName);
        }

        private void PauseButtonClicked(object sender, EventArgs e)
        {
            toggleMenu = true;
        }
        private void SoundButtonClicked(object sender, EventArgs e)
        {
            toggleMenu = true;
        }
        private void ResetButtonClicked(object sender, EventArgs e)
        {
            // check to make sure they're sure if pet exists
            toggleMenu = true;
            Console.WriteLine("Reset Button Clicked");
            pet = new Pet();
        }

        private void AButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("A Button Clicked");

        }

        private void BButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("B Button Clicked");

        }

        private void CButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("C Button Clicked");

        }
        private void drawSprite(Graphics canvas, int[][] sprite, int startingCellX, int startingCellY)
        {
            for (int y = 0; y < sprite.Length; y++)
            {
                for (int x = 0; x < sprite[y].Length; x++)
                {
                    if (sprite[y][x] == 1)
                    {
                        // draws one filled pixel
                        canvas.FillRectangle(Brushes.Black, new Rectangle
                        (
                        (startingCellX + x) * ScreenSettings.cellWidth,
                        (startingCellY + y) * ScreenSettings.cellHeight,
                        ScreenSettings.cellWidth,
                        ScreenSettings.cellHeight
                        ));
                    }
                }
            }
        }
        private void drawSpriteFromTopLeft(Graphics canvas, int[][] sprite, int startingCellX, int startingCellY)
        {
            drawSprite(canvas, sprite, startingCellX, startingCellY);
        }
        private void drawSpriteFromBottomLeft(Graphics canvas, int[][] sprite, int startingCellX, int startingCellY)
        {
            startingCellY = startingCellY - sprite.Length;
            drawSprite(canvas, sprite, startingCellX, startingCellY);
        }
        private void drawSpriteFromTopAtMiddle(Graphics canvas, int[][] sprite, int startingCellY)
        {
            int startingCellX = (ScreenSettings.screenWidthNumCells / 2) - (sprite[0].Length / 2);
            drawSprite(canvas, sprite, startingCellX, startingCellY);
        }
        private void drawSpriteFromBottomAtMiddle(Graphics canvas, int[][] sprite, int startingCellY)
        {
            int startingCellX = (ScreenSettings.screenWidthNumCells / 2) - (sprite[0].Length / 2);
            startingCellY = startingCellY - sprite.Length;
            drawSprite(canvas, sprite, startingCellX, startingCellY);
        }
        private void drawSpriteAtBottom(Graphics canvas, int[][] sprite, int startingCellX)
        {
            int startingCellY = ScreenSettings.screenHeightNumCells - sprite.Length;
            drawSprite(canvas, sprite, startingCellX, startingCellY);
        }
        private void drawSpriteAtBottomCenter(Graphics canvas, int[][] sprite)
        {
            int startingCellX = (ScreenSettings.screenWidthNumCells / 2) - (sprite[0].Length / 2);
            int startingCellY = ScreenSettings.screenHeightNumCells - sprite.Length;
            drawSprite(canvas, sprite, startingCellX, startingCellY);
        }
        private void drawSpriteAtCenterCenter(Graphics canvas, int[][] sprite)
        {
            int startingCellX = (ScreenSettings.screenWidthNumCells - sprite[0].Length) / 2;
            int startingCellY = (ScreenSettings.screenHeightNumCells - sprite.Length) / 2;
            drawSprite(canvas, sprite, startingCellX, startingCellY);
        }

        private void UpdateScreenGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            if (pet != null)
            {
                if (numTicks >= 4 * ticksPerFrame)
                {
                    numTicks = 0;
                }

                if (numTicks < 2 * ticksPerFrame)
                {
                    drawSpriteAtBottomCenter(canvas, pet.speciesInfo.sprites.idle1);
                }
                else if (numTicks < 4 * ticksPerFrame)
                {
                    drawSpriteAtBottomCenter(canvas, pet.speciesInfo.sprites.idle2);
                }

            }
        }

        private void GameTick(object sender, EventArgs e)
        {
            numTicks++;
            // Open the Menu
            if (toggleMenu)
            {
                if (isMenuOpen)
                {
                    MenuPanel.Size = MenuPanel.MinimumSize;
                    isMenuOpen = false;
                    Console.WriteLine("Menu Closed"); 
                }
                else
                {
                    MenuPanel.Size = MenuPanel.MaximumSize;
                    isMenuOpen = true;
                    Console.WriteLine("Menu Opened");
                }
                toggleMenu = false;
            }


            // redraws the canvas each tick
            Screen.Invalidate();
        }

        private void ToggleMenuOpen(object sender, EventArgs e)
        {
            toggleMenu = true;
            Console.WriteLine("Menu Toggled");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameTimer.Start();
        }
    }
}