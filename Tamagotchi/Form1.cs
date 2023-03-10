using System;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Security.Policy;
using System.Text.Json;
using System.Xml.Linq;
using Tamagotchi.CustomComponents;
using Tamagotchi.SpriteSheetClasses.Species;
using Newtonsoft.Json;
using static System.Windows.Forms.AxHost;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

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
        private bool isOpenTimeScreen = false;
        private bool is24hrTime = false;

        StateTree defaultStateTree;
        StateNode currentState;

        private bool petIsIdle = false;
        private int idleAnimationChoice = 0;

        private int cursorIndex = 0;

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
            PopulateSpriteSheets();

            // pet = new Pet();
            // For testing
            pet = getPetFromInternalFile("Masktchi_Joel_3-5-2023 8-18-08 PM.json");
            petIsIdle = true;

            PopulateDefaultStateTree();
            currentState = defaultStateTree.root;
    }

        private void PopulateSpriteSheets()
        {
            string jsonString = File.ReadAllText("../../../SpriteSheets/Other/AlphaNumSpriteSheet.json");
            alnumSprites = System.Text.Json.JsonSerializer.Deserialize<AlphaNumSprites>(jsonString);
            
            jsonString = File.ReadAllText("../../../SpriteSheets/Other/ConnectionSpriteSheet.json");
            connectionSprites = System.Text.Json.JsonSerializer.Deserialize<ConnectionSprites>(jsonString);
            
            jsonString = File.ReadAllText("../../../SpriteSheets/Other/FoodSpriteSheet.json");
            foodSprites = System.Text.Json.JsonSerializer.Deserialize<FoodSprites>(jsonString);

            jsonString = File.ReadAllText("../../../SpriteSheets/Other/ItemsSpriteSheet.json");
            itemSprites = System.Text.Json.JsonSerializer.Deserialize<ItemSprites>(jsonString);

            jsonString = File.ReadAllText("../../../SpriteSheets/Other/MenuingSpriteSheet.json");
            menuSprites = System.Text.Json.JsonSerializer.Deserialize<MenuSprites>(jsonString);

            jsonString = File.ReadAllText("../../../SpriteSheets/Other/MiscSpriteSheet.json");
            miscSprites = System.Text.Json.JsonSerializer.Deserialize<MiscSprites>(jsonString);
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
            Console.WriteLine("Sound Button Clicked");
            toggleMenu = true;
        }
        private void ExportButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Export Button Clicked");
            string petAsJSON = JsonConvert.SerializeObject(pet);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json files (*.json)|*.json";
            string defaultFileName = pet.speciesInfo.species + "_" + pet.givenName + "_" + localDateTime;
            foreach (var c in Path.GetInvalidFileNameChars())
            {
                defaultFileName = defaultFileName.Replace(c, '-');
            }
            saveFileDialog.FileName = defaultFileName;
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, petAsJSON);
            }

            toggleMenu = true;
        }
        private void ImportButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Import Button Clicked");

            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                FileName = "Select a json file",
                Filter = "Json files (*.json)|*.json",
                Title = "Open save file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string petAsJSON = File.ReadAllText(openFileDialog.FileName);
                pet = JsonConvert.DeserializeObject<Pet>(petAsJSON);
            } 

            if (pet == null)
            {
                Console.WriteLine("Bad File");
                pet = new Pet();
            }
            // TODO add more checks for importing good files

            toggleMenu = true;
        }

        private Pet getPetFromInternalFile(string fileName)
        {
            string petAsJSON = File.ReadAllText("../../../TestTamaJSONs/" + fileName);
            Pet newPet = JsonConvert.DeserializeObject<Pet>(petAsJSON);
            return newPet;
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
                CallButtonFunction('A');
                UpdateState('A');
            }
        }

        private void BButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("B Button Clicked");
            if (!isPaused)
            {
                CallButtonFunction('B');
                UpdateState('B');  
            }
        }

        private void CButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("C Button Clicked");
            if (!isPaused)
            {
                CallButtonFunction('C');
                UpdateState('C');
            }
        }

        private void CallButtonFunction(char button)
        {
            List<Action> buttonFunctions;

            switch (button)
            {
                case 'A':
                    buttonFunctions = currentState.AButtonFunctionList;
                    break;
                case 'B':
                    buttonFunctions = currentState.BButtonFunctionList;
                    break;
                case 'C':
                    buttonFunctions = currentState.CButtonFunctionList;
                    break;
                default:
                    return;
            }

            if (buttonFunctions != null)
            {
                foreach (Action func in buttonFunctions)
                {
                    func();
                }
            }
        }
        private void UpdateState(char button)
        {
            StateNode nextState;

            switch (button)
            {
                case 'A':
                    nextState = currentState.AButton;
                    break;
                case 'B':
                    nextState = currentState.BButton;
                    break;
                case 'C':
                    nextState = currentState.CButton;
                    break;
                default:
                    return;
            }

            if (nextState != null)
            {
                currentState = nextState;
                foreach (Action func in currentState.initialFunctionList)
                {
                    func();
                }
            }
        }

        private void DrawWholeScreen(Graphics canvas)
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

        private int[][] MirrorSprite(int[][] sprite)
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

        private int[][] InvertSprite(int[][] sprite)
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


                if (isOpenTimeScreen)
                {
                    GenerateTimeScreen();
                    DrawWholeScreen(canvas);
                    return;
                }

                if (isPaused)
                {
                    GeneratePauseScreen();
                    DrawWholeScreen(canvas);
                    return;
                }

                if (petIsIdle)
                {
                    screen = new Screen();
                    GenerateIdleScreen();
                    DrawWholeScreen(canvas);
                    return;
                }
                if (screen != null)
                {
                    DrawWholeScreen(canvas);
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



        ///// Screen Generation & State Changing /////
        private void GenerateIdleScreen()
        {
            //Console.WriteLine("GenerateIdleScreen");
            petIsIdle = true;
            SpriteLocation[] spriteSequence = pet.speciesInfo.idleSequence1;
            int frameNum = (int)(numTicks / ticksPerFrame);
            int currFrameIdx = frameNum % spriteSequence.Length;
            SpriteLocation currFrameInfo = spriteSequence[currFrameIdx];
            string toAddName = currFrameInfo.spriteName.ToString();
            int[][] sprite2add = (int[][])pet.speciesInfo.sprites.GetType().GetProperty(toAddName).GetValue(pet.speciesInfo.sprites, null);
            if (currFrameInfo.isMirrored)
            {
                sprite2add = MirrorSprite(sprite2add);
            }
            screen.addSpriteFromTopLeft(sprite2add, currFrameInfo.y, currFrameInfo.x);
        }

        private void HighlightMenuItem(int index)
        {
            Console.WriteLine("HighlightMenuItem: " + index);
        }


        private void GeneratePauseScreen()
        {
            Console.WriteLine("GeneratePauseScreen");
            screen = new Screen();
            screen.addSpriteFromBottomAtMiddle(pet.speciesInfo.sprites.idle1, ScreenSettings.screenHeightNumCells - 9);
            AddNameToScreen("pause", 1);
        }
        private void AddNameToScreen(string name, int xOffset = 0)
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
        private void GenerateTimeScreen()
        {
            Console.WriteLine("GenerateTimeScreen");
            screen = new Screen();
            petIsIdle = false;
            isOpenTimeScreen = true;

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
            AddSmallNumToScreenFromRight(screen, month, 0, 11);

            // add day
            AddSmallNumToScreenFromRight(screen, day, 0, 24);

            // add slash in date
            screen.setSinglePixel(1, 1, 15);
            screen.setSinglePixel(1, 2, 14);
            screen.setSinglePixel(1, 3, 13);


            // construct row 2 - time - 7-22 //
            Screen innerScreen = new Screen(16);

            if (is24hrTime)
            {
                AddLargeNumToScreenFromRight(innerScreen, hour, 8, 9);
            }
            else
            {
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
                AddLargeNumToScreenFromRight(innerScreen, hourAMPM, 8, 9);
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

            int[][] innerScreenArr = InvertSprite(innerScreen.getScreenArr());
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

        private void ToggleTimeSystem()
        {
            is24hrTime = !is24hrTime;
        }

        private void CloseTimeScreen()
        {
            isOpenTimeScreen = false;
        }

        private void GenerateHungryHappyScreen()
        {
            Console.WriteLine("GenerateHungryHappyScreen");
            screen = new Screen();
            petIsIdle = false;
            screen.addSpriteFromTopLeft(menuSprites.hungry_happy_page);
            FillHearts(pet.hunger, 7);
            FillHearts(pet.happiness, 23);
        }

        private void FillHearts(int metric, int startY)
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
            FillBar(pet.training, 18);
        }

        private void FillBar(int metric, int startY)
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
            AddLargeNumToScreenFromRight(screen, pet.age, 0, 22);
            AddLargeNumToScreenFromRight(screen, pet.weight, 8, 22);
            AddNameToScreen(pet.givenName);  
        }

        private void AddLargeNumToScreenFromRight(Screen scrn, int num2add, int startY, int startXRight)
        {
            int numDigits = num2add.ToString().Length;
            for (int i = 0; i < numDigits; i++)
            {
                string digit = num2add.ToString()[numDigits-i-1].ToString();
                string propName = "large_" + digit;
                int[][] sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                scrn.addSpriteFromTopRight(sprite2add, startY, startXRight);
                startXRight = startXRight - ScreenSettings.cellsPerNumberWidth;
            } 
        }

        private void AddSmallNumToScreenFromRight(Screen scrn, int num2add, int startY, int startXRight)
        {
            int numDigits = num2add.ToString().Length;
            for (int i = 0; i < numDigits; i++)
            {
                string digit = num2add.ToString()[numDigits - i - 1].ToString();
                string propName = "small_" + digit;
                int[][] sprite2add = (int[][])alnumSprites.GetType().GetProperty(propName).GetValue(alnumSprites, null);
                scrn.addSpriteFromTopRight(sprite2add, startY, startXRight);
                startXRight = startXRight - ScreenSettings.cellsPerNumberSmallWidth;
            }
        }

        private void GenerateGenGenScreen()
        {
            Console.WriteLine("GenerateGenGenScreen");
            screen = new Screen();
            petIsIdle = false;
            screen.addSpriteFromTopLeft(menuSprites.gen_page);
            AddLargeNumToScreenFromRight(screen, pet.generationNumber, 23, 15);
            if (pet.sex != Pet.Sex.Undetermined) {
                int[][] gender = pet.sex == Pet.Sex.Male ? menuSprites.boy : menuSprites.girl;
                screen.addSpriteFromTopRight(gender, 10, 31);
            }
        }

        private void GenerateFoodChoiceScreen()
        {
            Console.WriteLine("GenerateFoodChoiceScreen");
            screen = new Screen();
            petIsIdle = false;
            screen.addSpriteFromTopLeft(menuSprites.food_menu);
            screen.addSpriteFromTopLeft(menuSprites.cursor, 2 + 10 * cursorIndex, 0);
        }

        private void ResetMenuCursor()
        {
            cursorIndex = 0;
        }

        private void ToggleMenuCursor()
        {
            cursorIndex = cursorIndex == 0 ? 1 : 0;
        }

        private void GenerateEatingFoodAnimation()
        {
            Console.WriteLine("GenerateEatingFoodAnimation");
            screen = new Screen();
            petIsIdle = false;
        }


        ///// State Tree Population

        private void PopulateDefaultStateTree()
        {
            defaultStateTree = new StateTree();
            
            StateNode root = new StateNode();
            root.name = "Idle";
            root.initialFunctionList.Add(GenerateIdleScreen);
            root.initialFunctionList.Add(() => HighlightMenuItem(0));


            ///// Time Screen Nodes

            StateNode timeScreen = new StateNode();
            timeScreen.name = "Time Screen";
            timeScreen.initialFunctionList.Add(GenerateTimeScreen);
            timeScreen.AButtonFunctionList.Add(ToggleTimeSystem);
            timeScreen.BButtonFunctionList.Add(CloseTimeScreen);
            timeScreen.BButton = root;

            root.BButton = timeScreen;


            ///// Menu 1 Meter Nodes
            #region
            StateNode menu1 = new StateNode();
            menu1.name = "Menu 1: Meter";
            menu1.initialFunctionList.Add(GenerateIdleScreen);
            menu1.initialFunctionList.Add(() => HighlightMenuItem(1));

            StateNode hungryHappy = new StateNode();
            hungryHappy.name = "Hungry/Happy Page";
            hungryHappy.initialFunctionList.Add(GenerateHungryHappyScreen);

            StateNode training = new StateNode();
            training.name = "Training Page";
            training.initialFunctionList.Add(GenerateTrainingScreen);

            StateNode info = new StateNode();
            info.name = "Info Page";
            info.initialFunctionList.Add(GenerateInfoScreen);

            StateNode genGen = new StateNode();
            genGen.name = "Gen/Gen Page";
            genGen.initialFunctionList.Add(GenerateGenGenScreen);

            menu1.BButton = hungryHappy;
            menu1.CButton = root;
            hungryHappy.AButton = training;
            hungryHappy.BButton = training;
            hungryHappy.CButton = menu1;
            training.AButton = info;
            training.BButton = info;
            training.CButton = menu1;
            info.AButton = genGen;
            info.BButton = genGen;
            info.CButton = menu1;
            genGen.AButton = hungryHappy;
            genGen.BButton = hungryHappy;
            genGen.CButton = menu1;

            root.AButton = menu1;
            #endregion


            ///// Menu 2 Chef Nodes
            #region
            StateNode menu2 = new StateNode();
            menu2.name = "Menu 2: Chef";
            menu2.initialFunctionList.Add(GenerateIdleScreen);
            menu2.initialFunctionList.Add(() => HighlightMenuItem(2));
            menu2.BButtonFunctionList.Add(ResetMenuCursor);

            StateNode foodChoice = new StateNode();
            foodChoice.name = "Food Choice Page";
            foodChoice.initialFunctionList.Add(GenerateFoodChoiceScreen);
            foodChoice.AButtonFunctionList.Add(ToggleMenuCursor);
            foodChoice.AButtonFunctionList.Add(GenerateFoodChoiceScreen);

            StateNode eatFood = new StateNode();
            eatFood.name = "Eat Food Animation";
            eatFood.initialFunctionList.Add(GenerateEatingFoodAnimation);
            eatFood.initialFunctionList.Add(() => pet.EatFood(cursorIndex));

            menu2.BButton = foodChoice;
            menu2.CButton = root;
            foodChoice.BButton = eatFood;
            foodChoice.CButton = menu2;
            eatFood.AButton = foodChoice;
            eatFood.BButton = foodChoice;
            eatFood.CButton = foodChoice;

            menu1.AButton = menu2;
            #endregion

            ///// Menu 3 Toilet Nodes
            #region           
            StateNode menu3 = new StateNode();
            menu3.name = "Menu 3: Toilet";
            menu3.initialFunctionList.Add(GenerateIdleScreen);
            menu3.initialFunctionList.Add(() => HighlightMenuItem(3));
            #endregion

            ///// Menu 4 Game Nodes
            #region
            StateNode menu4 = new StateNode();
            menu4.name = "Menu 4: Game";
            menu4.initialFunctionList.Add(GenerateIdleScreen);
            menu4.initialFunctionList.Add(() => HighlightMenuItem(4));
            #endregion

            ///// Menu 5 Connect Nodes
            #region
            StateNode menu5 = new StateNode();
            menu5.name = "Menu 5: Connect";
            menu5.initialFunctionList.Add(GenerateIdleScreen);
            menu5.initialFunctionList.Add(() => HighlightMenuItem(5));
            #endregion

            ///// Menu 6 Talk Nodes
            #region
            StateNode menu6 = new StateNode();
            menu6.name = "Menu 6: Talk";
            menu6.initialFunctionList.Add(GenerateIdleScreen);
            menu6.initialFunctionList.Add(() => HighlightMenuItem(6));
            #endregion

            ///// Menu 7 Medicine Nodes
            #region
            StateNode menu7 = new StateNode();
            menu7.name = "Menu 7: Medicine";
            menu7.initialFunctionList.Add(GenerateIdleScreen);
            menu7.initialFunctionList.Add(() => HighlightMenuItem(7));
            #endregion

            ///// Menu 8 Lamp Nodes
            #region
            StateNode menu8 = new StateNode();
            menu8.name = "Menu 8: Lamp";
            menu8.initialFunctionList.Add(GenerateIdleScreen);
            menu8.initialFunctionList.Add(() => HighlightMenuItem(8));
            #endregion

            ///// Menu 9 Book Nodes
            #region
            StateNode menu9 = new StateNode();
            menu9.name = "Menu 9: Book";
            menu9.initialFunctionList.Add(GenerateIdleScreen);
            menu9.initialFunctionList.Add(() => HighlightMenuItem(9));
            #endregion








            defaultStateTree.root = root;
        }
    }
}