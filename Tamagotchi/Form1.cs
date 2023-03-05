using System;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Security.Policy;
using System.Text.Json;
using Tamagotchi.CustomComponents;
using Tamagotchi.SpriteSheetClasses.Species;
using static System.Windows.Forms.AxHost;

namespace Tamagotchi
{
    public partial class Form1 : Form
    {
        private DateTime localDateTime;
        private TimeSpan localTime;

        private int numTicks = 0;
        private const double ticksPerFrame = 4.5;
        private const int millisecondsPerTick = 100;
        
        private bool isMenuOpen;
        private bool toggleMenu;
        private bool isPaused = false;
        private bool toggleBMenu;
        private bool isOpenBMenu = false;

        StateTree defaultStateTree;
        StateNode currentState;

        private int currMenuIndex = -1;
        private bool clearMenu = false;
        private bool menuIndexChanged = false;

        private bool petIsIdle = false;
        private int idleAnimationChoice = 0;

        private AlphaNumSprites alnumSprites;
        private ConnectionSprites connectionSprites;
        private FoodSprites foodSprites;
        private ItemSprites itemSprites;
        private MenuSprites menuSprites;
        private MiscSprites miscSprites;

        private Pet pet;
        private Screen screen;
        
        public Form1()
        {
            InitializeComponent();

            new ScreenSettings();
            populateSpriteSheets();

            // pet = new Pet();
            // For testing
            pet = new TestTama();
            petIsIdle = true;

            PopulateStateTree();
            currentState = defaultStateTree.root;
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
            if (!isPaused)
            {
                updateState('A');
            }
        }

        private void BButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("B Button Clicked");
            // toggleBMenu = true;
            if (!isPaused)
            {
                updateState('B');
            }
        }

        private void CButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("C Button Clicked");
            if (!isPaused)
            {
                updateState('C');
            }
        }

        private void updateState(char button)
        {
            switch (button)
            {
                case 'A':
                    currentState = currentState.AButton;
                    break;
                case 'B':
                    currentState = currentState.BButton;
                    break;
                case 'C':
                    currentState = currentState.CButton;
                    break;
                default:
                    break;
            }

            foreach (Action func in currentState.functionList)
                func();
        }

        private void drawWholeScreen(Graphics canvas)
        {
            for (int y = 0; y < screen.getHeight(); y++)
            {
                for (int x = 0; x < screen.getWidth(); x++)
                {
                    if (screen.getScreenArr()[y][x] == 1)
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

        private void UpdateScreenGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            if (pet != null)
            {
                
                
                if (isOpenBMenu)
                {
                    makeBMenu();
                    drawWholeScreen(canvas);
                    return;
                }

                if (isPaused)
                {
                    makePauseScreen();
                    drawWholeScreen(canvas);
                    return;
                }

                if (petIsIdle)
                {
                    screen = new Screen();
                    GenerateIdleScreen();
                    drawWholeScreen(canvas);
                    return;
                }
                if (screen != null)
                {
                    drawWholeScreen(canvas);
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

            if (clearMenu)
            {
                clearMenu = false;
                currMenuIndex = -1;
            }

            if (menuIndexChanged)
            {
                Console.WriteLine("Menu Index changed");
                menuIndexChanged = false;
                if (currMenuIndex != -1)
                {
                    Console.WriteLine("Currently on Menu item: " + currMenuIndex);
                }
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

        private void GenerateIdleScreen()
        {
            Console.WriteLine("GenerateIdleScreen");
            petIsIdle = true;
            SpriteLocation[] spriteSequence = pet.speciesInfo.idleSequence1;
            int frameNum = (int)(numTicks / ticksPerFrame);
            int currFrameIdx = frameNum % spriteSequence.Length;
            SpriteLocation currFrameInfo = spriteSequence[currFrameIdx];
            string toAddName = currFrameInfo.spriteName.ToString();
            int[][] sprite2add = (int[][])pet.speciesInfo.sprites.GetType().GetProperty(toAddName).GetValue(pet.speciesInfo.sprites, null);
            if (currFrameInfo.isMirrored)
            {
                sprite2add = mirrorSprite(sprite2add);
            }
            screen.addSpriteFromTopLeft(sprite2add, currFrameInfo.y, currFrameInfo.x);
        }

        private void HighlightMenuItem(int index)
        {
            Console.WriteLine("HighlightMenuItem: " + index);
        }

        private void GenerateTimeMenu()
        {
            Console.WriteLine("GenerateTimeMenu");
        }


        private void makePauseScreen()
        {
            screen.addSpriteFromBottomAtMiddle(pet.speciesInfo.sprites.idle1, ScreenSettings.screenHeightNumCells - 9);
            addNameToScreen("pause", 1);
        }
        private void addNameToScreen(string name, int xOffset = 0)
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

                screen.addSpriteAtBottom(sprite, startingX);
                startingX = startingX + ScreenSettings.cellsPerLetterWidth;
            }
        }
        private void makeBMenu()
        {
            int month = localDateTime.Month;
            int day = localDateTime.Day;
            int hour = localDateTime.Hour;
            int minute = localDateTime.Minute;
            int second = localDateTime.Second;

            string digit;
            string propName;

            int[][] sprite2add;

            // construct row 1 - date - 0-6 //
            // add month
            if (month.ToString().Length == 2)
            {
                digit = month.ToString()[0].ToString();
                propName = "small_" + digit;
                sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                screen.addSpriteFromTopLeft(sprite2add, 0, 5);
                digit = month.ToString()[1].ToString();
                propName = "small_" + digit;
                sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                screen.addSpriteFromTopLeft(sprite2add, 0, 9);
            }
            else
            {
                digit = month.ToString();
                propName = "small_" + digit;
                sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                screen.addSpriteFromTopLeft(sprite2add, 0, 9);
            }

            // add day
            if (day.ToString().Length == 2)
            {
                digit = day.ToString()[0].ToString();
                propName = "small_" + digit;
                sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                screen.addSpriteFromTopLeft(sprite2add, 0, 19);
                digit = day.ToString()[1].ToString();
                propName = "small_" + digit;
                sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                screen.addSpriteFromTopLeft(sprite2add, 0, 23);
            }
            else
            {
                digit = day.ToString();
                propName = "small_" + digit;
                sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                screen.addSpriteFromTopLeft(sprite2add, 0, 23);
            }

            // add slash in date
            screen.setSinglePixel(1, 1, 15);
            screen.setSinglePixel(1, 2, 14);
            screen.setSinglePixel(1, 3, 13);


            // construct row 2 - time - 7-22 //
            Screen innerScreen = new Screen(16);

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
            innerScreen.addSpriteFromTopLeft(sprite2add, 1, 1);
            sprite2add = alnumSprites.time_m;
            innerScreen.addSpriteFromTopLeft(sprite2add, 1, 7);


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
                innerScreen.addSpriteFromTopLeft(sprite2add, 8, 1);
                digit = hourAMPM.ToString()[1].ToString();
                propName = "large_" + digit;
                sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                innerScreen.addSpriteFromTopLeft(sprite2add, 8, 6);
            }
            else
            {
                digit = hourAMPM.ToString();
                propName = "large_" + digit;
                sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                innerScreen.addSpriteFromTopLeft(sprite2add, 8, 6);
            }

            // add colon between hour and minute
            innerScreen.setSinglePixel(1, 9, 11);
            innerScreen.setSinglePixel(1, 13, 11);


            // add minute
            digit = (minute.ToString().Length == 2) ? minute.ToString()[0].ToString() : "0";
            propName = "large_" + digit;
            sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
            innerScreen.addSpriteFromTopLeft(sprite2add, 8, 13);

            digit = (minute.ToString().Length == 2) ? minute.ToString()[1].ToString() : minute.ToString();
            propName = "large_" + digit;
            sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
            innerScreen.addSpriteFromTopLeft(sprite2add, 8, 18);

            // add seconds
            digit = (second.ToString().Length == 2) ? second.ToString()[0].ToString() : "0";
            propName = "small_" + digit;
            sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
            innerScreen.addSpriteFromTopLeft(sprite2add, 10, 24);

            digit = (second.ToString().Length == 2) ? second.ToString()[1].ToString() : second.ToString();
            propName = "small_" + digit;
            sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
            innerScreen.addSpriteFromTopLeft(sprite2add, 10, 28);

            int[][] innerScreenArr = invertSprite(innerScreen.getScreenArr());
            screen.addSpriteFromTopLeft(innerScreenArr, 7, 0);


            // construct row 3 - display hearts - 23-29 //

            sprite2add = miscSprites.heartbeat;
            int secondDigit = second % 10;
            if (secondDigit >= 1 && secondDigit <= 5)
            {
                screen.addSpriteFromTopLeft(sprite2add, 25, 1);
            }
            if (secondDigit >= 2 && secondDigit <= 6)
            {
                screen.addSpriteFromTopLeft(sprite2add, 25, 7);
            }
            if (secondDigit >= 3 && secondDigit <= 7)
            {
                screen.addSpriteFromTopLeft(sprite2add, 25, 13);
            }
            if (secondDigit >= 4 && secondDigit <= 8)
            {
                screen.addSpriteFromTopLeft(sprite2add, 25, 19);
            }
            if (secondDigit >= 5 && secondDigit <= 9)
            {
                screen.addSpriteFromTopLeft(sprite2add, 25, 25);
            }

        }

        private void GenerateHungryHappyScreen()
        {
            Console.WriteLine("GenerateHungryHappyScreen");
            screen = new Screen();
            petIsIdle = false;
            screen.addSpriteFromTopLeft(menuSprites.hungry_happy_page);
            fillHearts(pet.hunger, 7);
            fillHearts(pet.happiness, 23);
        }

        private void fillHearts(int metric, int startY)
        {
            int startX = 0;
            int hearts2draw = (metric <= 4) ? metric : 4;
            int[][] sprite2Add = menuSprites.heart_full;
            for (int i = 1; i <= hearts2draw; i++)
            {
                screen.addSpriteFromTopLeft(sprite2Add, startY, startX);
                startX = startX + sprite2Add[0].Length + 1;
            }
        }

        private void GenerateTrainingScreen()
        {
            Console.WriteLine("GenerateTrainingScreen");
            screen = new Screen();
            petIsIdle = false;
            screen.addSpriteFromTopLeft(menuSprites.training_page);
            fillBar(pet.training, 18);
        }

        private void fillBar(int metric, int startY)
        {
            int[][] barSprite = new int[3][];
            barSprite[0] = new int[] { 1, 1 };
            barSprite[1] = new int[] { 1, 1 };
            barSprite[2] = new int[] { 1, 1 };
            int startX = 3;
            for (int i = 1; i <= metric; i++)
            {
                screen.addSpriteFromTopLeft(barSprite, startY, startX);
                startX = startX + barSprite[0].Length + 1;
            }
        }

        private void GenerateInfoScreen()
        {
            Console.WriteLine("GenerateInfoScreen");
            screen = new Screen();
            petIsIdle = false;
            screen.addSpriteFromTopLeft(menuSprites.name_page);
            addLargeNumToScreenFromRight(pet.age, 0, 22);
            addLargeNumToScreenFromRight(pet.weight, 8, 22);
            addNameToScreen(pet.givenName);  
        }

        private void addLargeNumToScreenFromRight(int num2add, int startY, int startXRight)
        {
            int numDigits = num2add.ToString().Length;
            for (int i = 0; i < numDigits; i++)
            {
                string digit = num2add.ToString()[numDigits-i-1].ToString();
                string propName = "large_" + digit;
                int[][] sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                screen.addSpriteFromTopRight(sprite2add, startY, startXRight);
                startXRight = startXRight - ScreenSettings.cellsPerNumberWidth;
            } 
        }

        private void GenerateGenGenScreen()
        {
            Console.WriteLine("GenerateGenGenScreen");
            screen = new Screen();
            petIsIdle = false;
            screen.addSpriteFromTopLeft(menuSprites.gen_page);
            addLargeNumToScreenFromRight(pet.generationNumber, 23, 15);
            if (pet.sex != Pet.Sex.Undetermined) {
                int[][] gender = pet.sex == Pet.Sex.Male ? menuSprites.boy : menuSprites.girl;
                screen.addSpriteFromTopRight(gender, 10, 31);
            }
        }


        private void PopulateStateTree()
        {
            defaultStateTree = new StateTree();
            
            StateNode root = new StateNode();
            root.name = "Idle";
            root.functionList.Add(GenerateIdleScreen);
            root.functionList.Add(() => HighlightMenuItem(-1));

            StateNode timeMenu = new StateNode();
            timeMenu.name = "Time Menu";
            timeMenu.functionList.Add(GenerateTimeMenu);


            ///// Menu 0 Meter Nodes

            StateNode menu0 = new StateNode();
            menu0.name = "Menu 0: Meter";
            menu0.functionList.Add(GenerateIdleScreen);
            menu0.functionList.Add(() => HighlightMenuItem(0));

            StateNode hungryHappy = new StateNode();
            hungryHappy.name = "Hungry/Happy Page";
            hungryHappy.functionList.Add(GenerateHungryHappyScreen);

            StateNode training = new StateNode();
            training.name = "Training Page";
            training.functionList.Add(GenerateTrainingScreen);

            StateNode info = new StateNode();
            info.name = "Info Page";
            info.functionList.Add(GenerateInfoScreen);

            StateNode genGen = new StateNode();
            genGen.name = "Gen/Gen Page";
            genGen.functionList.Add(GenerateGenGenScreen);

            menu0.BButton = hungryHappy;
            menu0.CButton = root;
            hungryHappy.AButton = training;
            hungryHappy.BButton = training;
            hungryHappy.CButton = menu0;
            training.AButton = info;
            training.BButton = info;
            training.CButton = menu0;
            info.AButton = genGen;
            info.BButton = genGen;
            info.CButton = menu0;
            genGen.AButton = hungryHappy;
            genGen.BButton = hungryHappy;
            genGen.CButton = menu0;

            root.AButton = menu0;
            

            ///// Menu 1 Chef Nodes

            StateNode menu1 = new StateNode();
            menu1.name = "Menu 1: Chef";
            menu1.functionList.Add(GenerateIdleScreen);
            menu1.functionList.Add(() => HighlightMenuItem(1));


            ///// Menu 2 Toilet Nodes
           
            StateNode menu2 = new StateNode();
            menu2.name = "Menu 2: Toilet";
            menu2.functionList.Add(GenerateIdleScreen);
            menu2.functionList.Add(() => HighlightMenuItem(2));


            ///// Menu 3 Game Nodes

            StateNode menu3 = new StateNode();
            menu3.name = "Menu 3: Game";
            menu3.functionList.Add(GenerateIdleScreen);
            menu3.functionList.Add(() => HighlightMenuItem(3));


            ///// Menu 4 Connect Nodes

            StateNode menu4 = new StateNode();
            menu4.name = "Menu 4: Connect";
            menu4.functionList.Add(GenerateIdleScreen);
            menu4.functionList.Add(() => HighlightMenuItem(4));


            ///// Menu 5 Talk Nodes

            StateNode menu5 = new StateNode();
            menu5.name = "Menu 5: Talk";
            menu5.functionList.Add(GenerateIdleScreen);
            menu5.functionList.Add(() => HighlightMenuItem(5));


            ///// Menu 6 Medicine Nodes

            StateNode menu6 = new StateNode();
            menu6.name = "Menu 6: Medicine";
            menu6.functionList.Add(GenerateIdleScreen);
            menu6.functionList.Add(() => HighlightMenuItem(6));


            ///// Menu 7 Lamp Nodes

            StateNode menu7 = new StateNode();
            menu7.name = "Menu 7: Lamp";
            menu7.functionList.Add(GenerateIdleScreen);
            menu7.functionList.Add(() => HighlightMenuItem(7));


            ///// Menu 8 Book Nodes

            StateNode menu8 = new StateNode();
            menu8.name = "Menu 8: Book";
            menu8.functionList.Add(GenerateIdleScreen);
            menu8.functionList.Add(() => HighlightMenuItem(8));









            defaultStateTree.root = root;
        }
    }
}