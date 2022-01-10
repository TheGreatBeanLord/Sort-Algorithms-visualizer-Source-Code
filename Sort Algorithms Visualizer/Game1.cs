using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Text;

namespace Sort_Algorithms_Visualizer
{
    public class Game1 : Game
    {

        //Declare graphics variables
        private Texture2D pixelTexture;

        private GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;
        
        SpriteFont CourrierFont;

        public int width;


        //Declare functionality variables

        //Create instance of random object
        public Random rand;

        //Variables for selecting length of list, must be a factor of 800px
        int chosenFactor;

        List<int> FactorsList;

        int length;

        //Bool for heapsort to check if we have created the binary tree yet

        bool isheaped = false;

        //Stores the last key pressed to see if a new key has been pressed

        string lastKeyDown;

        string lastLastKeyDown;

        //Array of values

        public List<int> dataList;

        //Variables for drawing

        public Point drawPosition;

        public int spacing;



        public int frameCounter;

        //Int to select an element from the modesList array, chooses which algorithm to use

        int mode;


        //Stores which iteration of the algorithms we are curretnly at
        int index;

        //controls the speed at which iteration of the algorithms are run
        int speed;



        List<string> modesList;

      


        //Properties


        private int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                if (value >= 0 && value <= 10)
                {
                    speed = value;
                }
            }
        }

        private int Length
        {
            get
            {
                return length;

            }

            set
            {
                if (value > 0)
                {
                    length = value;
                }
            }
        }

        public int ChosenFactor
        {
            get
            {
                return chosenFactor;
            }
            set
            {
                if (value >= 0 && value <= 6)
                {
                    chosenFactor = value;
                }
            }
        }

    
        //Makes sure we don't try to ask for an algorithm that doesn't exist
        private int Mode
        {
            get
            {
                return mode;

            }
            
            set
            {
                if (value >= 0 && value <= 6)
                {
                    mode = value;
                }
            }
        }

        public Game1()
        {
            //List of all the names of sorting algorithsm
            modesList = new List<string>() { "Bubble Sort", "Insertion Sort", "Selection Sort", "Quickish Sort", "Heap Sort", "Cocktail Sort", "Gnome Sort"};

            //default settings
            width = 10;

            index = 0;

            speed = 5;

            mode = 0;

            drawPosition = new Point(0 , 300);

            rand = new Random();

            //all the possible lengths for the dataset that would fit on the canvas properly

            FactorsList = new List<int>()
            {
                4, 9, 49, 79, 99, 399, 799
            };

            chosenFactor = 3;

            //sets teh length of the array to the chosen factor
            length = FactorsList[chosenFactor];

            //Graphics setup
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        //Runs once upon start
        protected override void Initialize()
        {
            dataList = MakeRandomList(length, 0, 480);

            spacing = ((800 / dataList.Count));

            base.Initialize();
        }

        //Load in graphics content, runs once upon start
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            pixelTexture = Content.Load<Texture2D>("1x1_#ffffffff");

            CourrierFont = Content.Load<SpriteFont>("Courrier");

        }

        //Update loop; runs once every frame (60 frames per second)
        protected override void Update(GameTime gameTime)
        {

            //Keyboard input

            KeyboardState keyboard = new KeyboardState();
            keyboard = Keyboard.GetState();

            frameCounter += 1;


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboard.IsKeyDown(Keys.Escape))
                Exit();


            //Changes the chosen algorithm
            if (keyboard.IsKeyDown(Keys.Left))
            {
                if (lastKeyDown != "left")
                {
                index = 0;
                    Mode -= 1;
                }
                lastKeyDown = "left";
            }

            else if (keyboard.IsKeyDown(Keys.Right))
            {
                if (lastKeyDown != "right")
                {
                    Mode += 1;
                    index = 0;

                }
                lastKeyDown = "right";
            }

            //Changes the speed
            else if (keyboard.IsKeyDown(Keys.Down))
            {
                if (lastKeyDown != "down")
                {
                    Speed += 1;
                    index = 0;

                }
                lastKeyDown = "down";
            }
            else if (keyboard.IsKeyDown(Keys.Up))
            {
                if (lastKeyDown != "up")
                {
                    Speed -= 1;
                }
              
                lastKeyDown = "up";
            }


            //Gives a new dataset
            else if (keyboard.IsKeyDown(Keys.R))
            {
                if (lastKeyDown != "R")
                {
                    isheaped = false;
                  //  Speed -= 1;
                }
                lastKeyDown = "R";
                dataList = MakeRandomList(FactorsList[ChosenFactor], 0, 480);
                index = 0;
                spacing = ((800 / dataList.Count));

            }

            //Changes the length of dataset
            else if (keyboard.IsKeyDown(Keys.W))
            {
                if (lastKeyDown != "W")
                {
                    ChosenFactor += 1;
                }
                lastKeyDown = "W";
            }

            else if (keyboard.IsKeyDown(Keys.S))
            {
                if (lastKeyDown != "S")
                {
                    ChosenFactor -= 1;
                }
                lastKeyDown = "S";
            }

             else
            {
                lastKeyDown = "none";
            }



      
               
            //Call the chosen sorting algorithm
                   if (index < dataList.Count) {



                        if (keyboard.IsKeyDown(Keys.Space) && frameCounter > (Speed * 100) / dataList.Count)
                        {

                            if (lastLastKeyDown != lastKeyDown)
                    {
                        index = 0;
                    }

                     //run bubblesort
                            if (modesList[Mode] == "Bubble Sort")
                            {
                                dataList = SortAlgos.bubbleSortInt(dataList, index, "forward");
                          
                            }
                    //Run insertionSort
                            else if (modesList[Mode] == "Insertion Sort" && index > 0)
                                  {
                                 
                                      dataList = SortAlgos.InsertionSortInt(dataList, index);

                                  }
                    //Run SelectionSort
                            else if (modesList[Mode] == "Selection Sort")
                                    {
                                      dataList = SortAlgos.SelectionSortInt(dataList, index);

                                     }
                    //Run Quickish sort
                            else if (modesList[Mode] == "Quickish Sort")
                            {
                            dataList = SortAlgos.Quickishsort(dataList, 0, dataList.Count - 1);
                      
                                
                            }
                    //Run heapsort
                            else if (modesList[Mode] == "Heap Sort")
                    {
                        //Build an unordered binary tree (heap) out of the array if it hasnt been done already
                        if (!isheaped)
                        {
                            for (int index = dataList.Count / 2 - 1; index >= 0; index--)
                            {
                                SortAlgos.heapify(dataList, dataList.Count, index);
                            }
                            isheaped = true;
                        }


                        //Check if the child is larger than the parent for each node on the binary tree, swap if applicable
                        int i = dataList.Count - (index + 1);

                        int temp = dataList[0];
                        dataList[0] = dataList[i];
                        dataList[i] = temp;

                        SortAlgos.heapify(dataList, i, 0);

                        }
                    //Run cocktail sort
                            else if (modesList[Mode] == "Cocktail Sort")
                    {
                            dataList = SortAlgos.bubbleSortInt(dataList, index, "forward");
                        dataList = SortAlgos.bubbleSortInt(dataList, index, "backward");

                    }
                    //Run Gnome sort
                        else if (modesList[mode] == "Gnome Sort")
                    {
                        Debug.WriteLine(index);
                        if (index < dataList.Count && index != 0)
                        {
                            index = SortAlgos.GnomeSort(dataList, index);

                        }

                    }


                    frameCounter = 0;

                    index++;

                    lastLastKeyDown = lastKeyDown;
                        }

               
                    }

                 
            

           

            base.Update(gameTime);
        }

        //Draw function, called once every frame after update
        protected override void Draw(GameTime gameTime)
        {

            //clear the canvas
            GraphicsDevice.Clear(Color.FloralWhite);

            _spriteBatch.Begin();


            //Draw the dataset as lines on the canvas
            if (dataList != null)
            {
                for (int i = 0; i < dataList.Count; i++)
                {
                    Rectangle drawRectangle = new Rectangle();

                    drawPosition += new Point(spacing, 480 - dataList[i]);

                    _spriteBatch.Draw(pixelTexture, destinationRectangle: new Rectangle(drawPosition.X, drawPosition.Y, 1, dataList[i]), colorGen(dataList[i]));
                    Console.WriteLine(drawPosition.Y);

                    drawPosition.Y = 0;

                }
            }

            //Draw text 
            drawPosition = new Point(0, 0);
            _spriteBatch.DrawString(CourrierFont, "Left/Right arrow to chenge sort mode. R for new dataset. Up/down arrow to change speed. W / S to change dataset size", new Vector2(15, 0), Color.Black);
            _spriteBatch.DrawString(CourrierFont, "Hold space to run", new Vector2(15, 12), Color.Black);

            _spriteBatch.DrawString(CourrierFont, "Sort Mode: " + modesList[mode], new Vector2(15, 24), Color.Black);
            _spriteBatch.DrawString(CourrierFont, "Speed: " + (10 - Speed), new Vector2(15, 36), Color.Black);
            _spriteBatch.DrawString(CourrierFont, "Data Set Size " + (FactorsList[ChosenFactor] + 1).ToString(), new Vector2(15, 48), Color.Black);


            _spriteBatch.End();

            base.Draw(gameTime);
        }

        //Picks a color for the data based on it's value
        public Color colorGen(int length)
        {
            int R = 255;
            int G = 255;
            int B = 255;
            
            for (int i = 0; i < Math.Abs(480 - length * 2); i++)
            {
                R++;
                G--;
                B--;
            }

            for (int i = 0; i > Math.Abs(480 - length * 2); i++)
            {
                G++;
                R--;
                B--;
            }

            for (int i = 0; i < (480 - length) + (480 / 4); i++)
            {
                B++;
                G--;
                R--;

            }
            
            return new Color(R, G, B);
            
            
        }

        //Generate a new randomized dataset

        public List<int> MakeRandomList(int size, int min, int max)
        {
            List<int> returnList = new List<int>();
            for (int i = 0; i <= size; i++)
            {
                returnList.Add(rand.Next(min, max));
            }

            return returnList;
        }
    }
}
