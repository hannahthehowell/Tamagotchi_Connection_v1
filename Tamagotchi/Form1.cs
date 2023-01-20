using System.Drawing.Imaging;

namespace Tamagotchi
{
    public partial class Form1 : Form
    {
        private bool isMenuOpen;
        private bool toggleMenu;

        private Pet pet;

        int[,] testMametchi = { 
            { 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
            { 0, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0 },
            { 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1 },
            { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
            { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0 },
            { 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0 },
            { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
            { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
        };

        public Form1()
        {
            InitializeComponent();

            new ScreenSettings();
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
        private void UpdateScreenGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            if (pet != null)
            {
                int[] startingPixel = { 15, 30 };
                // looping through test mametchi
                for (int y = 0; y < testMametchi.GetLength(0); y++)
                {
                    for (int x = 0; x < testMametchi.GetLength(1); x++)
                    {
                        if (testMametchi[y, x] == 1)
                        {
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