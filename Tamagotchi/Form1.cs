using System;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Security.Policy;
using System.Text.Json;
using Tamagotchi.CustomComponents;
using Tamagotchi.SpriteSheetClasses.Species;

namespace Tamagotchi
{
    public partial class Form1 : Form
    {
        private DateTime localDateTime;
        private TimeSpan localTime;

        private int numTicks = 0;
        private const int ticksPerFrame = 4;
        private const int millisecondsPerTick = 100;
        private bool isMenuOpen;
        private bool toggleMenu;
        private bool isPaused = false;
        private bool toggleBMenu;
        private bool isOpenBMenu = false;

        private bool petIsIdle = false;

        private AlphaNumSprites alnumSprites;
        private ConnectionSprites connectionSprites;
        private FoodSprites foodSprites;
        private ItemSprites itemSprites;
        private MenuSprites menuSprites;
        private MiscSprites miscSprites;

        private Pet pet;

        public Form1()
        {
            InitializeComponent();

            new ScreenSettings();
            populateSpriteSheets();

            pet = new Pet();
        }

        private void populateSpriteSheets()
        {
            string jsonString = File.ReadAllText("../../../SpriteSheets/Other/AlphaNumSpriteSheet.json");
            alnumSprites = JsonSerializer.Deserialize<AlphaNumSprites>(jsonString);
            
            jsonString = File.ReadAllText("../../../SpriteSheets/Other/ConnectionSpriteSheet.json");
            connectionSprites = JsonSerializer.Deserialize<ConnectionSprites>(jsonString);
            
            jsonString = File.ReadAllText("../../../SpriteSheets/Other/FoodSpriteSheet.json");
            foodSprites = JsonSerializer.Deserialize<FoodSprites>(jsonString);

            jsonString = File.ReadAllText("../../../SpriteSheets/Other/ItemsSpriteSheet.json");
            itemSprites = JsonSerializer.Deserialize<ItemSprites>(jsonString);

            jsonString = File.ReadAllText("../../../SpriteSheets/Other/MenuingSpriteSheet.json");
            menuSprites = JsonSerializer.Deserialize<MenuSprites>(jsonString);

            jsonString = File.ReadAllText("../../../SpriteSheets/Other/MiscSpriteSheet.json");
            miscSprites = JsonSerializer.Deserialize<MiscSprites>(jsonString);
        }

        private void PauseButtonClicked(object sender, EventArgs e)
        {
            toggleMenu = true;
            isPaused = !isPaused;

            pet.isAging = !isPaused;

            Console.WriteLine("Pause Toggled " + isPaused);
        }
        private void SoundButtonClicked(object sender, EventArgs e)
        {
            toggleMenu = true;
        }
        private void ResetButtonClicked(object sender, EventArgs e)
        {
            // check to make sure they're sure
            isPaused = false;
            toggleMenu = true;
            Console.WriteLine("Reset Button Clicked");
            pet = new Pet();
            petIsIdle = true;
        }

        private void AButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("A Button Clicked");
        }

        private void BButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("B Button Clicked");
            toggleBMenu = true;
        }

        private void CButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("C Button Clicked");

        }

        private void drawWholeScreen(Graphics canvas, int[][] sprite)
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
                        x * ScreenSettings.cellWidth,
                        y * ScreenSettings.cellHeight,
                        ScreenSettings.cellWidth,
                        ScreenSettings.cellHeight
                        ));
                    }
                }
            }
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
        private void drawSpriteFromMiddle(Graphics canvas, int[][] sprite, int centerCellX, int centerCellY)
        {
            int startingCellX = centerCellX - sprite[0].Length / 2;
            int startingCellY = centerCellY - sprite.Length / 2;
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

        private int[][] mirrorSprite(int[][] sprite)
        {
            int[][] mirroredSprite = sprite.Select(a => a.ToArray()).ToArray();
            for (int y = 0; y < sprite.Length; y++)
            {
                for (int x = 0; x < sprite[y].Length; x++)
                {
                    mirroredSprite[y][x] = sprite[y][sprite[y].Length-1-x];
                }
            }
            return mirroredSprite;
        }

        private int[][] invertSprite(int[][] sprite)
        {
            int[][] invertedSprite = sprite.Select(a => a.ToArray()).ToArray();
            for (int y = 0; y < invertedSprite.Length; y++)
            {
                for (int x = 0; x < invertedSprite[y].Length; x++)
                {
                    if (invertedSprite[y][x] == 1)
                    {
                        invertedSprite[y][x] = 0;
                    }
                    else
                    {
                        invertedSprite[y][x] = 1;
                    }
                }
            }
            return invertedSprite;
        }

        private void writeName(Graphics canvas, string name, int xOffset = 0)
        {
            int startingX = 1 + xOffset;
            char[] chars = name.ToLower().ToCharArray();
            foreach (char c in chars)
            {
                string ch = c.ToString();
                int[][] sprite;

                if (ch == "?")
                {
                    sprite = alnumSprites.question;
                }
                else if (ch == "!")
                {
                    sprite = alnumSprites.exclamation;
                }
                else if (alnumSprites.GetType().GetProperty(ch) == null)
                {
                    startingX = startingX + ScreenSettings.cellsPerLetterWidth;
                    continue;
                }
                else
                {
                    sprite = (int[][])alnumSprites.GetType().GetProperty(ch).GetValue(alnumSprites, null);
                }
                
                drawSpriteAtBottom(canvas, sprite, startingX);
                startingX = startingX + ScreenSettings.cellsPerLetterWidth;
            }
        }


        private int[] getLine(int num)
        {
            int[] line = new int[ScreenSettings.screenWidthNumCells];
            for (int i = 0; i < line.Length; i++)
            {
                line[i] = num;
            }
            return line;
        }

        private int[][] getBlankSpriteScreen(int height = 0, int width = 0)
        {
            if (height == 0)
            {
                height = ScreenSettings.screenHeightNumCells;
            }
            if (width == 0)
            {
                width = ScreenSettings.screenWidthNumCells;
            }

            int[][] screen = new int[height][];
            for (int i = 0; i < screen.Length; i++)
            {
                int[] line = new int[width];
                for (int j = 0; j < line.Length; j++)
                {
                    line[j] = 0;
                }
                screen[i] = line;   
            }
            return screen;
        }

        private int[][] addToSprite(int[][] sprite, int[][] toAdd, int topY, int leftX)
        {
            for (int row = 0; row < toAdd.Length; row++)
            {
                for (int col = 0; col < toAdd[row].Length; col++)
                {
                    sprite[row+topY][col+leftX] = toAdd[row][col];
                }
            }
            return sprite;
        }
        private void drawPauseScreen(Graphics canvas)
        {
            drawSpriteFromBottomAtMiddle(canvas, pet.speciesInfo.sprites.idle1, ScreenSettings.screenHeightNumCells-9);
            writeName(canvas, "pause", 1);
        }

        private void drawBMenu(Graphics canvas)
        {
            int month = localDateTime.Month;
            int day = localDateTime.Day;
            int hour = localDateTime.Hour;
            int minute = localDateTime.Minute;
            int second = localDateTime.Second;

            string digit;
            string propName;

            int[][] sprite2add;


            int[][] menuScreen = getBlankSpriteScreen();
            // construct row 1 - date - 0-6 //
            // add month
            if (month.ToString().Length == 2)
            {
                digit = month.ToString()[0].ToString();
                propName = "small_" + digit;
                sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                menuScreen = addToSprite(menuScreen, sprite2add, 0, 5);
                digit = month.ToString()[1].ToString();
                propName = "small_" + digit;
                sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                menuScreen = addToSprite(menuScreen, sprite2add, 0, 9);
            }
            else
            {
                digit = month.ToString();
                propName = "small_" + digit;
                sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                menuScreen = addToSprite(menuScreen, sprite2add, 0, 9);
            }

            // add day
            if (day.ToString().Length == 2)
            {
                digit = day.ToString()[0].ToString();
                propName = "small_" + digit;
                sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                menuScreen = addToSprite(menuScreen, sprite2add, 0, 19);
                digit = month.ToString()[1].ToString();
                propName = "small_" + digit;
                sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                menuScreen = addToSprite(menuScreen, sprite2add, 0, 23);
            }
            else
            {
                digit = day.ToString();
                propName = "small_" + digit;
                sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                menuScreen = addToSprite(menuScreen, sprite2add, 0, 23);
            }

            // add slash in date
            menuScreen[1][15] = 1;
            menuScreen[2][14] = 1;
            menuScreen[3][13] = 1;


            // construct row 2 - time - 7-22 //
            int[][] innerSprite = getBlankSpriteScreen(16);

            // lines 8-12 am/pm
            bool isAM = (hour < 12) ? true : false;
            if (isAM)
            {
                sprite2add = alnumSprites.time_a;
            }
            else
            {
                sprite2add = alnumSprites.time_p;
            }
            innerSprite = addToSprite(innerSprite, sprite2add, 1, 1);
            sprite2add = alnumSprites.time_m;
            innerSprite = addToSprite(innerSprite, sprite2add, 1, 7);


            // lines 15-21 time
            int hourAMPM = hour switch
            {
                int i when i == 0 => 12,
                int i when i > 12 => hour - 12,
                _ => hour
            };

            // add hour
            if (hourAMPM.ToString().Length == 2)
            {
                digit = hourAMPM.ToString()[0].ToString();
                propName = "large_" + digit;
                sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                innerSprite = addToSprite(innerSprite, sprite2add, 8, 1);
                digit = hourAMPM.ToString()[1].ToString();
                propName = "large_" + digit;
                sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                innerSprite = addToSprite(innerSprite, sprite2add, 8, 6);
            }
            else
            {
                digit = hourAMPM.ToString();
                propName = "large_" + digit;
                sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                innerSprite = addToSprite(innerSprite, sprite2add, 8, 6);
            }

            // add colon between hour and minute
            innerSprite[9][11] = 1;
            innerSprite[13][11] = 1;


            // add minute
            digit = (minute.ToString().Length == 2) ? minute.ToString()[0].ToString() : "0";
            propName = "large_" + digit;
            sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
            innerSprite = addToSprite(innerSprite, sprite2add, 8, 13);
            
            digit = (minute.ToString().Length == 2) ? minute.ToString()[1].ToString() : minute.ToString();
            propName = "large_" + digit;
            sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
            innerSprite = addToSprite(innerSprite, sprite2add, 8, 18);

            // add seconds
            digit = (second.ToString().Length == 2) ? second.ToString()[0].ToString() : "0";
            propName = "small_" + digit;
            sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
            innerSprite = addToSprite(innerSprite, sprite2add, 10, 24);

            digit = (second.ToString().Length == 2) ? second.ToString()[1].ToString() : second.ToString();
            propName = "small_" + digit;
            sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
            innerSprite = addToSprite(innerSprite, sprite2add, 10, 28);

            innerSprite = invertSprite(innerSprite);
            menuScreen = addToSprite(menuScreen, innerSprite, 7, 0);


            // construct row 3 - display hearts - 23-29 //

            sprite2add = miscSprites.heartbeat;
            int secondDigit = second % 10;
            if (secondDigit >= 1 && secondDigit <= 5)
            {
                menuScreen = addToSprite(menuScreen, sprite2add, 25, 1);
            }
            if (secondDigit >= 2 && secondDigit <= 6)
            {
                menuScreen = addToSprite(menuScreen, sprite2add, 25, 7);
            }
            if (secondDigit >= 3 && secondDigit <= 7)
            {
                menuScreen = addToSprite(menuScreen, sprite2add, 25, 13);
            }
            if (secondDigit >= 4 && secondDigit <= 8)
            {
                menuScreen = addToSprite(menuScreen, sprite2add, 25, 19);
            }
            if (secondDigit >= 5 && secondDigit <= 9)
            {
                menuScreen = addToSprite(menuScreen, sprite2add, 25, 25);
            }

            drawWholeScreen(canvas, menuScreen);
        }

        private void UpdateScreenGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            if (pet != null)
            {
                if (isPaused)
                {
                    drawPauseScreen(canvas);
                    return;
                }

                if (isOpenBMenu)
                {
                    drawBMenu(canvas);
                    return;
                }

                if (petIsIdle)
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
        }

        private void GameTick(object sender, EventArgs e)
        {
            numTicks++;

            localDateTime = DateTime.Now;
            localTime = localDateTime.TimeOfDay;

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

            if (toggleBMenu)
            {
                toggleBMenu = false;
                isOpenBMenu = !isOpenBMenu;
            }

            petIsIdle = true;
            
            


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