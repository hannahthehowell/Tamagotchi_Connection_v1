namespace Tamagotchi
{
    public partial class Form1 : Form
    {
        private bool isMenuOpen;
        private bool toggleMenu;

        public Form1()
        {
            InitializeComponent();
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

        }

        private void GameTick(object sender, EventArgs e)
        {
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