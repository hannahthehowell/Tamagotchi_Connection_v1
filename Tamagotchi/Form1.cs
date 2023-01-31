using System.Drawing.Imaging;
using System.Text.Json;

namespace Tamagotchi
{
    public partial class Form1 : Form
    {
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
        private void drawSpriteTL(Graphics canvas, int[,] sprite, int[] startingPixel)
        {
            for (int y = 0; y < sprite.GetLength(0); y++)
            {
                for (int x = 0; x < sprite.GetLength(1); x++)
                {
                    if (sprite[y, x] == 1)
                    {
                        // draws one filled pixel
                        canvas.FillRectangle(Brushes.Black, new Rectangle
                        (
                        startingPixel[0] + x * ScreenSettings.cellWidth,
                        startingPixel[1] + y * ScreenSettings.cellHeight,
                        ScreenSettings.cellWidth,
                        ScreenSettings.cellHeight
                        ));
                    }
                }
            }
        }
        private void UpdateScreenGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            if (pet != null)
            {
                int[] startingPixel = { 15, 30 };
                // TODO: how to access sprite 2d arrays?
                Console.WriteLine(pet.speciesInfo.sprites);
                //drawSpriteTL(canvas, pet.speciesInfo.sprites.idle1, startingPixel);
            }
        }

        private void GameTick(object sender, EventArgs e)
        {
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