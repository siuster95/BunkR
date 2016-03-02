#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.IO;
//using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace game
{
    /// <summary>
    /// This is the main type for your game
    /// 
    /// 
    /// </summary>
    /// 

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        

        // Animation
        int frame;				// The current animation frame
        double timeCounter;		// The amount of time that has passed
        double fps;				// The speed of the animation
        double timePerFrame;	// The amount of time (in fractional seconds) per frame

        // Constants for "source" rectangle (inside the image)
        const int WALK_FRAME_COUNT = 3;			// The number of frames in the animation
        const int PLAYER_RECT_Y_OFFSET = 116;	// How far down in the image are the frames?
        const int PLAYER_RECT_HEIGHT = 72;		// The height of a single frame
        const int PLAYER_RECT_WIDTH = 49;		// The width of a single frame

        const int ZOMBIE_RECT_Y_OFFSET = 116;	// How far down in the image are the frames?
        const int ZOMBIE_RECT_HEIGHT = 72;		// The height of a single frame
        const int ZOMBIE_RECT_WIDTH = 44;       // The width of a single frame

        enum GameState
        {
            Menu,
            Game,
            Gamepause,
            Gameover,
        }
       

        enum PlayerState
        {
            FaceLeft,
            FaceRight,
            WalkLeft,
            WalkRight
        }

        PlayerState playerState = PlayerState.WalkRight;

        GameState state;

        SpriteFont font;
        MouseState mstate;
        
        float zombieRtime = 0;
        double medigametimer;
        double weapongametimer;
        
        int zombiedead = 0;
        int newzombiecount;
        bool medispawnbool;
        bool weaponspawnbool;
        
        double PMGameTime;
        double PWGameTime;
        
        float Firstsafespottime;
        float totaltimestart;
        bool firstsafebool=false;
        bool SSinbetween = false;
        float durationsafespot;
        float SSstarttime;
        float Startofinbetween;
        float spawnanother;
        bool dropping;
        double radioactivedmg;
        

        // rectangles
        Rectangle bulletRect;
        Rectangle RPGBulletRect;
        Rectangle playerRect;
        Rectangle pistolRect;
        Rectangle enemyrectangle;
        Rectangle ARrect;
        Rectangle rpgRect;
        Rectangle medkitRect;
        Rectangle safeSpotRect;
        Rectangle nukeRect;
        Rectangle startrectangle;
        Rectangle backrectangle;
        Rectangle quitrectangle;

        // textures
        Texture2D PistolPlayerTexture;
        Texture2D ARPlayerTexture;
        Texture2D RPGPlayerTexture;

        Texture2D enemytexture;
        Texture2D bullettexture;
        Texture2D RPGbulletTexture;
        Texture2D RPGbulletLeftTexture;

        Texture2D ARPickUpAble;
        Texture2D PistolPickUpAble;
        Texture2D RPGPickUpAble;

        Texture2D medkitTexture;
        Texture2D safeSpotTexture;

        Texture2D backgroundTexture;

        Texture2D menutexture;
        Texture2D backtexture;
        Texture2D starttexture;
        Texture2D quittexture;
        Texture2D titleTexture;
        Texture2D nuketexture;
        // actual game objects
        Player player;
        PlayerStat playerstat;
        Pistol pistol;
        Assault_Rifle AR;
        RPG rpg;
        Bullet bullet;
        Bomb nuke;

        Enemy enemy;
        List<Enemy> Enemylist;

        HealthPack medkit;
        List<Rectangle> medkitSpawns;
        Rectangle medspawn1;
        Rectangle medspawn2;
        Rectangle medspawn3;
        Rectangle medspawn4;
        Rectangle medspawn5;
        Rectangle medspawn6;
        Rectangle selectedMedSpawn;

        SafeSpot safeSpot;
        List<Rectangle> safeSpotSpawns;
        Rectangle safeSpawn1;
        Rectangle safeSpawn2;
        Rectangle safeSpawn3;
        Rectangle safeSpawn4;
        Rectangle safeSpawn5;
        Rectangle selectedSafeSpawn;

        // Miscellaneous
        List<Bullet> bulletsForPistol;
        List<Bullet> bulletsForAR;
        List<Bullet> bulletsForRPG;
        List<Bullet> bulletsinflight;
        List<Weapon> Weaponlist;
        List<Rectangle> randomWeaponSpawns;
        Rectangle spawn1;
        Rectangle spawn2;
        Rectangle spawn3;
        Rectangle spawn4;
        Rectangle spawn5;
        Rectangle spawn6;
        Rectangle selectedSpawn;
        Weapon selectedWeapon;

        int numZombiesPrevLevel;
        bool checker= false;
        bool landedonplatform = false;
        bool landedstate=false;


        // keyboards
        KeyboardState currentKey;
        KeyboardState previousKey;

        int bulletbuffer;
        Random rando = new Random();
        List<Platforms> ListofPlatforms;
        Platforms platform; 
        Platforms platform2;
        Platforms platform3;
        Platforms platform4;
        Platforms platform5;
        Platforms platform6;
        Texture2D platformtexture;
        Texture2D jwallbruhTexture;
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 540;
            
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            fps = 10.0;
            timePerFrame = 1.0 / fps;
            // TODO: Add your initialization logic here
            state = GameState.Menu;
            startrectangle = new Rectangle(GraphicsDevice.Viewport.Width / 2 - 100, GraphicsDevice.Viewport.Height / 2 + 100, 200, 100);
            
            // initialize list of bullets for AR, pistol and RPG
            bulletbuffer = 0;
            bulletRect = new Rectangle(playerRect.X, playerRect.Y, 10, 10);
            RPGBulletRect = new Rectangle(playerRect.X, playerRect.Y, 25, 25);
            bulletsinflight = new List<Bullet>();
            bulletsForAR = new List<Bullet>();
            for (int x = 0; x < 20; x++)
            {
                bullet = new Bullet(bulletRect, 3);
                bulletsForAR.Add(bullet);
            }

            bulletsForPistol = new List<Bullet>();
            for (int x = 0; x < 20; x++)
            {
                bullet = new Bullet(bulletRect, 3);
                bulletsForPistol.Add(bullet);
            }

            bulletsForRPG = new List<Bullet>();
            for (int x = 0; x < 2; x++)
            {
                bullet = new Bullet(RPGBulletRect, 3);
                bulletsForRPG.Add(bullet);
            }

            // intitalize player related objects
            playerRect = new Rectangle(250, 390, 40, 40);
            player = new Player(playerRect, playerstat);

            playerstat = new PlayerStat(player);
            
            // initialize weapons
            pistolRect = new Rectangle(playerRect.X, playerRect.Y, 30, 30);
            ARrect = new Rectangle(playerRect.X, playerRect.Y, 30, 30);
            rpgRect = new Rectangle(playerRect.X, playerRect.Y, 30, 30);

            pistol = new Pistol(bulletsForPistol, pistolRect, player);
            AR = new Assault_Rifle(bulletsForAR, ARrect, player);
            rpg = new RPG(bulletsForRPG, rpgRect, player);

            player.CurrentlyEquipped = pistol;

            // initialize list of weapons
            Weaponlist = new List<Weapon>();
            Weaponlist.Add(AR);
            Weaponlist.Add(rpg);
            Weaponlist.Add(pistol);

            spawn1 = new Rectangle(230, 142, 30, 30);
            spawn2 = new Rectangle(500, 180, 30, 30);
            spawn3 = new Rectangle(770, 360, 30, 30);
            spawn4 = new Rectangle(340, 390, 30, 30);
            spawn5 = new Rectangle(850, 215, 30, 30);
            spawn6 = new Rectangle(600, 390, 30, 30);
            randomWeaponSpawns = new List<Rectangle>();
            randomWeaponSpawns.Add(spawn1);
            randomWeaponSpawns.Add(spawn2);
            randomWeaponSpawns.Add(spawn3);
            randomWeaponSpawns.Add(spawn4);
            randomWeaponSpawns.Add(spawn5);
            randomWeaponSpawns.Add(spawn6);

            // initialize medkits and spawns
            medkitRect = new Rectangle();
            medkit = new HealthPack(medkitRect);
            medspawn1 = new Rectangle(140, 142, 30, 30);
            medspawn2 = new Rectangle(620, 390, 30, 30);
            medspawn3 = new Rectangle(140, 350, 30, 30);
            medspawn4 = new Rectangle(480, 285, 30, 30);
            medspawn5 = new Rectangle(730, 215, 30, 30);
            medspawn6 = new Rectangle(250, 390, 30, 30);
            medkitSpawns = new List<Rectangle>();
            medkitSpawns.Add(medspawn1);
            medkitSpawns.Add(medspawn2);
            medkitSpawns.Add(medspawn3);
            medkitSpawns.Add(medspawn4);
            medkitSpawns.Add(medspawn5);
            medkitSpawns.Add(medspawn6);

            // initialize safespots and spawns
            safeSpotRect = new Rectangle();
            safeSpot = new SafeSpot(safeSpotRect);
            safeSpawn1 = new Rectangle(170, 110, 45, 67);
            safeSpawn2 = new Rectangle(570, 150, 45, 67);
            safeSpawn3 = new Rectangle(20, 320, 45, 67);
            safeSpawn4 = new Rectangle(935, 390, 45, 67);
            safeSpawn5 = new Rectangle(290, 390, 45, 67);
            safeSpotSpawns = new List<Rectangle>();
            safeSpotSpawns.Add(safeSpawn1);
            safeSpotSpawns.Add(safeSpawn2);
            safeSpotSpawns.Add(safeSpawn3);
            safeSpotSpawns.Add(safeSpawn4);
            safeSpotSpawns.Add(safeSpawn5);

            // initialize enemies
            Enemylist = new List<Enemy>();
            
            for (int x = 0; x < 10; x++)
            {
                int enemySpawnLoc = rando.Next(0, 2);
                if (enemySpawnLoc == 0)
                {
                    enemyrectangle = new Rectangle(rando.Next(-50, 0), 390, 40, 40);
                }
                else if (enemySpawnLoc == 1)
                {
                    enemyrectangle = new Rectangle(rando.Next(GraphicsDevice.Viewport.Width + 1, GraphicsDevice.Viewport.Width + 50), 390, 40, 40);
                }
                enemy = new Enemy(player, enemyrectangle);
                Enemylist.Add(enemy);
                numZombiesPrevLevel = Enemylist.Count;
            }
            newzombiecount = Enemylist.Count;
          
            // initialize pause menu buttons
            backrectangle = new Rectangle(GraphicsDevice.Viewport.Width - GraphicsDevice.Viewport.Width / 4, GraphicsDevice.Viewport.Height - GraphicsDevice.Viewport.Height / 4, 200, 100);
            quitrectangle = new Rectangle(GraphicsDevice.Viewport.Width - 795, GraphicsDevice.Viewport.Height - GraphicsDevice.Viewport.Height / 4, 200, 100);

            //initialize platforms
             ListofPlatforms = new List<Platforms>();
             platform = new Platforms(GraphicsDevice.Viewport.Width/2+150, GraphicsDevice.Viewport.Height/2+110,player,1);
             platform2 = new Platforms(GraphicsDevice.Viewport.Width / 2 - 510, GraphicsDevice.Viewport.Height / 2 + 110, player,2);
             platform3 = new Platforms(GraphicsDevice.Viewport.Width / 2 - 130, GraphicsDevice.Viewport.Height / 2 + 40, player,3);
             platform4 = new Platforms(GraphicsDevice.Viewport.Width / 2 + 200, GraphicsDevice.Viewport.Height / 2-30 , player,4);
             platform5 = new Platforms(GraphicsDevice.Viewport.Width / 2 - 450, GraphicsDevice.Viewport.Height / 2 - 100 , player,5);
             platform6 = new Platforms(GraphicsDevice.Viewport.Width / 2 - 90, GraphicsDevice.Viewport.Height / 2 - 60, player,6);
             ListofPlatforms.Add(platform);
             ListofPlatforms.Add(platform2);
             ListofPlatforms.Add(platform3);
             ListofPlatforms.Add(platform4);
             ListofPlatforms.Add(platform5);
             ListofPlatforms.Add(platform6);
             selectedSpawn = randomWeaponSpawns[5];
             selectedWeapon = Weaponlist[rando.Next(0, 3)];
             selectedWeapon.Spawn(selectedSpawn);

             selectedMedSpawn = medkitSpawns[5];
             medkit.Spawn(selectedMedSpawn);
             medispawnbool = false;
             weaponspawnbool = false;
             totaltimestart = 0;

            // initialize nuke
            nukeRect = new Rectangle(GraphicsDevice.Viewport.Width / 2, 0, 40, 40);
            nuke = new Bomb(nukeRect);
            radioactivedmg = .04;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Arial14");

            backgroundTexture = this.Content.Load<Texture2D>("Background.png");

            // start menu content
            menutexture = Content.Load<Texture2D>("Cityscape.jpg");
            starttexture = Content.Load<Texture2D>("startbutton.jpg");
            titleTexture = Content.Load<Texture2D>("title.png");

            // pause menu content
            quittexture = Content.Load<Texture2D>("quitbutton.jpg");
            backtexture = Content.Load<Texture2D>("backbutton.jpg");

            // in-game content
            System.IO.Stream defaultStream = TitleContainer.OpenStream("Content/DefaultPlayer.png");
            PistolPlayerTexture = Texture2D.FromStream(GraphicsDevice, defaultStream);
            defaultStream.Close();

            System.IO.Stream ARStream = TitleContainer.OpenStream("Content/ARPlayer.png");
            ARPlayerTexture = Texture2D.FromStream(GraphicsDevice, ARStream);
            ARStream.Close();

            System.IO.Stream RPGStream = TitleContainer.OpenStream("Content/RPGPlayer.png");
            RPGPlayerTexture = Texture2D.FromStream(GraphicsDevice, RPGStream);
            RPGStream.Close();

            System.IO.Stream enemyStream = TitleContainer.OpenStream("Content/zombie.png");
            enemytexture = Texture2D.FromStream(GraphicsDevice, enemyStream);
            enemyStream.Close();

            bullettexture = Content.Load<Texture2D>("bullet.png");
            RPGbulletTexture = Content.Load<Texture2D>("RPG.png");
            RPGbulletLeftTexture = Content.Load<Texture2D>("RPGLeft.png");

            ARPickUpAble = Content.Load<Texture2D>("ARPickUpable.png");
            PistolPickUpAble = Content.Load<Texture2D>("PistolPickUpAble.png");
            RPGPickUpAble = Content.Load<Texture2D>("RPGPickUpAble.png");

            medkitTexture = Content.Load<Texture2D>("medkit.png");
            safeSpotTexture = Content.Load<Texture2D>("Bunker.png");

            jwallbruhTexture = Content.Load<Texture2D>("jwallbruh.png");
            //platforms
            platformtexture = Content.Load<Texture2D>("platform.png");
           
            //nuke
            nuketexture = Content.Load<Texture2D>("nuke.png");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            timeCounter += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeCounter >= timePerFrame)
            {
                frame += 1;						// Adjust the frame

                if (frame > WALK_FRAME_COUNT)	// Check the bounds
                    frame = 1;					// Back to 1 (since 0 is the "standing" frame)

                timeCounter -= timePerFrame;	// Remove the time we "used"
            }

            // TODO: Add your update logic here

            currentKey = Keyboard.GetState();
            KeyboardState playerkbstate = Keyboard.GetState();

            if (state == GameState.Menu)
            {
                this.IsMouseVisible = true;
                mstate = Mouse.GetState();
                if (mstate.LeftButton == ButtonState.Pressed && mstate.X > startrectangle.X && mstate.X < startrectangle.X + 200 && mstate.Y > startrectangle.Y && mstate.Y < startrectangle.Y + 100)
                {
                    state = GameState.Game;
                    totaltimestart = gameTime.TotalGameTime.Minutes * 60 + gameTime.TotalGameTime.Seconds;
                    firstsafebool = true;
                }

            }
            else if (state == GameState.Game)
            {

                // implements player jump
                if (currentKey.IsKeyDown(Keys.Space) && previousKey.IsKeyUp(Keys.Space) && player.Jumpbool == false && player.Dropbool == false && platform.PDB == false && platform2.PDB == false && platform3.PDB == false && platform4.PDB == false && platform5.PDB == false && platform6.PDB == false)
                {
                      player.Jumpbool = true;
                }
                // implements player dropping off platforms
                if (currentKey.IsKeyDown(Keys.S) && previousKey.IsKeyUp(Keys.S) && platform.Onbool == true || currentKey.IsKeyDown(Keys.S) && previousKey.IsKeyUp(Keys.S) && platform2.Onbool == true || currentKey.IsKeyDown(Keys.S) && previousKey.IsKeyUp(Keys.S) && platform3.Onbool == true || currentKey.IsKeyDown(Keys.S) && previousKey.IsKeyUp(Keys.S) && platform4.Onbool == true || currentKey.IsKeyDown(Keys.S) && previousKey.IsKeyUp(Keys.S) && platform5.Onbool == true || currentKey.IsKeyDown(Keys.S) && previousKey.IsKeyUp(Keys.S) && platform6.Onbool == true)
                {
                    if (platform.Onbool == true)
                    {
                        platform.PDB = true;
                        platform.Onbool = false;
                    }
                    else if (platform2.Onbool == true)
                    {
                        platform2.PDB = true;
                        platform2.Onbool = false;
                    }
                    else if (platform3.Onbool == true)
                    {
                        platform3.PDB = true;
                        platform3.Onbool = false;
                    }
                    else if (platform4.Onbool == true)
                    {
                        platform4.PDB = true;
                        platform4.Onbool = false;
                    }
                    else if (platform5.Onbool == true)
                    {
                        platform5.PDB = true;
                        platform5.Onbool = false;
                    }
                    else if (platform6.Onbool == true)
                    {
                        platform6.PDB = true;
                        platform6.Onbool = false;
                    }
                }
                player.Jump();
                if (platform.Onbool == false && platform2.Onbool == false && platform3.Onbool == false && platform4.Onbool == false && platform5.Onbool == false && platform6.Onbool == false)
                {
                     
                     dropping = player.Drop();
                }
                else 
                {
                    player.Dropcount = 0;
                    player.Dropbool = false;
                }
                foreach (Platforms P in ListofPlatforms)
                {
                    landedonplatform=platform.IsPlayerOnPlatform(dropping, player.Jumpbool,P.PDB);
                    if(landedonplatform==true)
                    {
                        landedstate = true;
                    }
                    landedonplatform= platform2.IsPlayerOnPlatform(dropping, player.Jumpbool, P.PDB);
                    if (landedonplatform == true)
                    {
                        landedstate = true;
                    }
                    landedonplatform = platform3.IsPlayerOnPlatform(dropping, player.Jumpbool, P.PDB);
                    if (landedonplatform == true)
                    {
                        landedstate = true;
                    }
                    landedonplatform = platform4.IsPlayerOnPlatform(dropping, player.Jumpbool, P.PDB);
                    if (landedonplatform == true)
                    {
                        landedstate = true;
                    }
                    landedonplatform = platform5.IsPlayerOnPlatform(dropping, player.Jumpbool, P.PDB);
                    if (landedonplatform == true)
                    {
                        landedstate = true;
                    }
                    landedonplatform = platform6.IsPlayerOnPlatform(dropping, player.Jumpbool, P.PDB);
                    if (landedonplatform == true)
                    {
                        landedstate = true;
                    }
                    if(P.Onbool ==true&&safeSpot.IsSafe(player)==false)
                    {
                        player.Health = player.Health - radioactivedmg;
                    }
                }
                platform.Drop(1,landedstate);
                platform2.Drop(2, landedstate);
                platform3.Drop(3, landedstate);
                platform4.Drop(4, landedstate);
                platform5.Drop(5, landedstate);
                platform6.Drop(6, landedstate);

                landedstate = false;
                // implements player moving left and right
                switch (playerState)
                {
                    case PlayerState.FaceLeft:
                        player.ValueDirect = 1;
                        if (playerkbstate.IsKeyDown(Keys.A) == true)
                        {
                            playerState = PlayerState.WalkLeft;
                        }
                        else if (playerkbstate.IsKeyDown(Keys.D) == true)
                        {
                            playerState = PlayerState.WalkRight;
                        }
                        break;

                    case PlayerState.FaceRight:
                        player.ValueDirect = 3;
                        if (playerkbstate.IsKeyDown(Keys.A) == true)
                        {
                            playerState = PlayerState.WalkLeft;
                        }
                        else if (playerkbstate.IsKeyDown(Keys.D) == true)
                        {
                            playerState = PlayerState.WalkRight;
                        }
                        break;

                    case PlayerState.WalkLeft:
                        player.ValueDirect = 1;
                        player.X -= 3;
                        if (playerkbstate.IsKeyUp(Keys.A) == true)
                        {
                            playerState = PlayerState.FaceLeft;
                        }
                        else if (playerkbstate.IsKeyDown(Keys.D) == true)
                        {
                            playerState = PlayerState.WalkRight;
                        }
                        break;
                    case PlayerState.WalkRight:
                        player.ValueDirect = 3;
                        player.X += 3;
                        if (playerkbstate.IsKeyUp(Keys.D) == true)
                        {
                            playerState = PlayerState.FaceRight;
                        }
                        else if (playerkbstate.IsKeyDown(Keys.A) == true)
                        {
                            playerState = PlayerState.WalkLeft;
                        }
                        break;

                }

                if(player.X <= 0)
                {
                    player.X = 0;
                }
                if (player.X + player.Width >= 1024)
                    player.X = 1023 - player.Width;
                
                //fire bullets when bullet is push once 
                if (currentKey.IsKeyDown(Keys.F) && previousKey.IsKeyUp(Keys.F))
                {
                    if (player.CurrentlyEquipped == pistol)
                    {
                        bullet = pistol.Fire();
                        if (bullet != null)
                        {
                            bulletbuffer = 0;
                            bulletsinflight.Add(bullet);
                            bulletsForPistol.Remove(bullet);
                        }
                    }
                    else if (player.CurrentlyEquipped == AR)
                    {

                        bullet = AR.Fire();
                        if (bullet != null)
                        {
                            bulletbuffer = 0;
                            bulletsinflight.Add(bullet);
                            bulletsForAR.Remove(bullet);
                        }
                    }
                    else if (player.CurrentlyEquipped == rpg)
                    {
                        bullet = rpg.Fire();
                        if (bullet != null)
                        {
                            bulletbuffer = 0;
                            bulletsinflight.Add(bullet);
                            bulletsForRPG.Remove(bullet);
                        }
                    }
                }

                // player fire's bullets if fire button is held
                if (currentKey.IsKeyDown(Keys.F))
                {
                    if (bulletbuffer == 15)
                    {
                        if (player.CurrentlyEquipped == pistol)
                        {
                            bullet = pistol.Fire();
                            if (bullet != null)
                            {
                                bulletbuffer = 0;
                                bulletsinflight.Add(bullet);
                                bulletsForPistol.Remove(bullet);
                            }
                        }
                    }
                    else if (bulletbuffer == 5)
                    {
                        if (player.CurrentlyEquipped == AR)
                        {

                            bullet = AR.Fire();
                            if (bullet != null)
                            {
                                bulletbuffer = 0;
                                bulletsinflight.Add(bullet);
                                bulletsForAR.Remove(bullet);
                            }
                        }
                    }
                    else if (bulletbuffer == 40)
                    {
                        if (player.CurrentlyEquipped == rpg)
                        {
                            bullet = rpg.Fire();
                            if (bullet != null)
                            {
                                bulletbuffer = 0;
                                bulletsinflight.Add(bullet);
                                bulletsForRPG.Remove(bullet);
                            }
                        }
                    }
                    bulletbuffer++;
                }

                // implements bullet movement
                if (bulletsinflight.Count > 0)
                {
                    if (player.CurrentlyEquipped == pistol)
                    {
                        foreach (Bullet b in bulletsinflight)
                        {
                            if (b.Active == true)
                            {
                                b.Move();
                            }
                        }
                    }
                    else if (player.CurrentlyEquipped == AR)
                    {
                        foreach (Bullet b in bulletsinflight)
                        {
                            if (b.Active == true)
                            {

                                b.Move();
                            }
                        }
                    }
                    else if (player.CurrentlyEquipped == rpg)
                    {
                        foreach (Bullet b in bulletsinflight)
                        {
                            if (b.Active == true)
                            {

                                b.Move();
                            }
                        }
                    }
                }

                
                //Reload 
                if (currentKey.IsKeyDown(Keys.R) && previousKey.IsKeyUp(Keys.R))
                {
                        if (player.CurrentlyEquipped == AR)
                        {
                            if (bulletsForAR.Count <= 0)
                            {
                                for (int x = 0; x < 30; x++)
                                {
                                    bullet = new Bullet(bulletRect, 3);
                                    bulletsForAR.Add(bullet);
                                }
                            }
                        }
                        else if (player.CurrentlyEquipped == pistol)
                        {
                            if (bulletsForPistol.Count <= 0)
                            {
                                for (int x = 0; x < 20; x++)
                                {
                                    bullet = new Bullet(bulletRect, 3);
                                    bulletsForPistol.Add(bullet);
                                }
                            }
                        }
                        else if (player.CurrentlyEquipped == rpg)
                        {
                            if (bulletsForRPG.Count <= 0)
                            {
                                for (int x = 0; x < 2; x++)
                                {
                                    bullet = new Bullet(RPGBulletRect, 3);
                                    bulletsForRPG.Add(bullet);
                                }
                            }
                        }
                }
                 
                // implements random spawn points for health packs
                // Heals player when player collides with medkit
                if (medkit.Active == true && medkit.IsColliding(player)&&medispawnbool==false)
                {
                    medkit.Active = false;
                    player.Health = 100;
                    medispawnbool = true;
                    PMGameTime = gameTime.TotalGameTime.Minutes*60+gameTime.TotalGameTime.Seconds;
                }

                if(medispawnbool==true)
                {
                    medigametimer = gameTime.TotalGameTime.Minutes*60+gameTime.TotalGameTime.Seconds-PMGameTime;
                }

                if(medigametimer>=15)
                {
                    selectedMedSpawn = medkitSpawns[rando.Next(0, 6)];
                    medkit.Spawn(selectedMedSpawn);
                    medigametimer = 0;
                    medispawnbool = false;
                }

                // implements random spawn points for weapon drops
                if (selectedWeapon.Active == true && player.IsColliding(selectedWeapon) == true)
                {
                    selectedWeapon.Active = false;
                    player.PickUpWeapon(selectedWeapon);
                    weaponspawnbool = true;
                    PWGameTime = gameTime.TotalGameTime.Minutes * 60 + gameTime.TotalGameTime.Seconds;
                }

                if (weaponspawnbool == true)
                {
                    weapongametimer = gameTime.TotalGameTime.Minutes * 60 + gameTime.TotalGameTime.Seconds - PWGameTime;
                }

                if (weapongametimer >= 15)
                {
                    selectedSpawn = randomWeaponSpawns[rando.Next(0, 6)];
                    selectedWeapon = Weaponlist[rando.Next(0, 3)];
                    selectedWeapon.Spawn(selectedSpawn);
                    weapongametimer = 0;
                    weaponspawnbool= false;
                }


                // implements safespot spawns and collision detection
                if(firstsafebool==true)
                {
                    Firstsafespottime = gameTime.TotalGameTime.Minutes * 60 + gameTime.TotalGameTime.Seconds - totaltimestart;
                }
                if(Firstsafespottime>15)
                {
                    firstsafebool = false;
                    selectedSafeSpawn = safeSpotSpawns[rando.Next(0,5)];
                    safeSpot.Spawn(selectedSafeSpawn);
                    SSstarttime = gameTime.TotalGameTime.Minutes * 60 + gameTime.TotalGameTime.Seconds;
                    Firstsafespottime = 0;
                    nuke.Active = true;
                }
                if(safeSpot.Active==true)
                {
                    durationsafespot = gameTime.TotalGameTime.Minutes * 60 + gameTime.TotalGameTime.Seconds - SSstarttime;
                }
                if(durationsafespot>20)
                {
                    durationsafespot = 0;
                    safeSpot.Active = false;
                    Startofinbetween = gameTime.TotalGameTime.Minutes * 60 + gameTime.TotalGameTime.Seconds;
                    SSinbetween = true;
                }
                if(SSinbetween==true)
                {
                    spawnanother = gameTime.TotalGameTime.Minutes * 60 + gameTime.TotalGameTime.Seconds - Startofinbetween;
                }
                if(spawnanother>10)
                {
                    spawnanother = 0;
                    SSinbetween = false;
                    selectedSafeSpawn = safeSpotSpawns[rando.Next(0,5)];
                    safeSpot.Spawn(selectedSafeSpawn);
                    SSstarttime = gameTime.TotalGameTime.Minutes * 60 + gameTime.TotalGameTime.Seconds;
                    nuke.Active = true;
                }

                // Nuke logic here!
                if(nuke.Active==true&&durationsafespot>9)
                {
                    int mph =430/50;
                    nuke.Y += mph;
                }
                if(nuke.Active ==false)
                {
                    nuke.Y = 0;
                }

                if (nuke.Y+nuke.height>430 && nuke.Active == true)
                {
                    if (safeSpot.IsSafe(player) == true)
                    {

                        player.Health = player.Health;
                        
                    }
                    else
                    {

                        nuke.Nuke(player);
                        
                    }

                }
                
                // implement enemy game logic
                foreach(Enemy ene in Enemylist)
                {
                    if (ene.IsDead() == false)
                    {
                        ene.Follow();

                        if (nuke.Y + nuke.height > 430 && nuke.Active == true)
                        {
                            nuke.Nuke(ene);
                            zombiedead = Enemylist.Count;
                            nuke.Active = false;
                            radioactivedmg = radioactivedmg + .005;
                        }
                        if (safeSpot.IsSafe(player) == true && safeSpot.Active == true)
                        {
                            player.TakeDamage(0);
                        }
                        // player takes damage
                        else if (player.IsColliding(ene) == true)
                        {
                            player.TakeDamage(ene.Attack);
                        }

                        // zombies take damage according to player's currently equipped weapon
                        if (player.CurrentlyEquipped == AR)
                        {
                            for (int x = 0; x < bulletsinflight.Count; x++)
                            {
                                bullet = bulletsinflight[x];
                                if (bullet.IsColliding(ene) == true && bullet.Active == true)
                                {
                                   ene.TakeDamage(player.CurrentlyEquipped.Dmg);
                                    bulletsinflight.Remove(bullet);

                                    if (ene.IsDead() == true)
                                    {
                                        playerstat.PlayerScore += 1;
                                        zombiedead++;
                                           
                                    }
                                }
                                else if (bullet.Active == true && (bullet.X > GraphicsDevice.Viewport.Width || bullet.X < 0))
                                {
                                    bullet.Active = false;
                                    bulletsinflight.Remove(bullet);

                                }
                            }
                        }
                        else if (player.CurrentlyEquipped == pistol)
                        {
                            for (int x = 0; x < bulletsinflight.Count; x++)
                            {
                                bullet = bulletsinflight[x];
                                if (bullet.IsColliding(ene) == true && bullet.Active == true)
                                {
                                    ene.TakeDamage(player.CurrentlyEquipped.Dmg);
                                    bulletsinflight.Remove(bullet);

                                    if (ene.IsDead() == true)
                                    {
                                        playerstat.PlayerScore += 1;
                                        zombiedead++;
                                        
                                    }
                                }
                                else if (bullet.Active == true && (bullet.X > GraphicsDevice.Viewport.Width || bullet.X < 0))
                                {
                                    bullet.Active = false;
                                    bulletsinflight.Remove(bullet);

                                }
                            }
                        }
                        else if (player.CurrentlyEquipped == rpg)
                        {
                            for (int x = 0; x < bulletsinflight.Count; x++)
                            {
                                bullet = bulletsinflight[x];
                                if (bullet.IsColliding(ene) == true && bullet.Active == true)
                                {

                                    bulletsinflight.Remove(bullet);
                                    ene.TakeDamage(player.CurrentlyEquipped.Dmg);
                                    if (ene.IsDead() == true)
                                    {
                                        playerstat.PlayerScore += 1;
                                        zombiedead++;
                                       
                                    }
                                }
                                else if (bullet.Active == true && (bullet.X > GraphicsDevice.Viewport.Width || bullet.X < 0))
                                {
                                    bullet.Active = false;
                                    bulletsinflight.Remove(bullet);

                                }
                            }
                        }
                    }
                    
                }

                // brings up pause menu (state)
                if (currentKey.IsKeyDown(Keys.P))
                {
                    state = GameState.Gamepause;
                }
                // Game Over here!
                if (player.IsDead() == true)
                {
                    state = GameState.Gameover;
                    checker = true;

                    player.Health = 100;
                }
           if(zombiedead==Enemylist.Count)
           
              zombieRtime += gameTime.TotalGameTime.Seconds;
              if(zombieRtime>10)
              {
                  newzombiecount = newzombiecount + 2;
                  zombiedead = 0;
                  zombieRtime = 0;
                  Enemylist.Clear();
           
                  for (int x = 0; x < newzombiecount; x++)
                  {
                      int enemySpawnLoc = rando.Next(0, 2);
                      if (enemySpawnLoc == 0)
                      {
                          enemyrectangle = new Rectangle(rando.Next(-50, 0), 390, 40, 40);
                      }
                      else if (enemySpawnLoc == 1)
                      {
                          enemyrectangle = new Rectangle(rando.Next(GraphicsDevice.Viewport.Width + 1, GraphicsDevice.Viewport.Width + 50), 390, 40, 40);
                      }
                      enemy = new Enemy(player, enemyrectangle);
                      Enemylist.Add(enemy);
                      numZombiesPrevLevel = Enemylist.Count;
                      
                  }
                  
              }
           
            }
            else if (state == GameState.Gameover)
            {
                currentKey = Keyboard.GetState();
                
                if (currentKey.IsKeyDown(Keys.M) == true&&checker==true)
                {
                    Initialize();
                    checker = false;
                    state = GameState.Menu;
                }
            }

            else if (state == GameState.Gamepause)
            {
                this.IsMouseVisible = true;
                mstate = Mouse.GetState();
                if (mstate.LeftButton == ButtonState.Pressed && mstate.X > quitrectangle.X && mstate.X < quitrectangle.X + 200 && mstate.Y > quitrectangle.Y && mstate.Y < quitrectangle.Y + 200)
                {
                    Initialize();
                    checker = false;
                    state = GameState.Menu;

                }
                else if (mstate.LeftButton == ButtonState.Pressed && mstate.X > backrectangle.X && mstate.X < backrectangle.X + 200 && mstate.Y > backrectangle.Y && mstate.Y < backrectangle.Y + 200)
                {
                    state = GameState.Game;
                }
            }
            previousKey = currentKey;
            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, backgroundTexture.Width, backgroundTexture.Height), Color.White);
            SpriteEffects imageFlip;
            SpriteEffects imageFlipZombie;

            Rectangle sourceRect = new Rectangle(
                0,
                PLAYER_RECT_Y_OFFSET,
                PLAYER_RECT_WIDTH,
                PLAYER_RECT_HEIGHT);

            Rectangle sourceRectZombie = new Rectangle(
               0,
               ZOMBIE_RECT_Y_OFFSET,
               ZOMBIE_RECT_WIDTH,
               ZOMBIE_RECT_HEIGHT);

            imageFlip = SpriteEffects.None;
            if (state == GameState.Menu)
            {
                spriteBatch.Draw(menutexture, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.Draw(titleTexture, new Vector2(250, 50), Color.White);
                spriteBatch.Draw(starttexture, startrectangle, Color.White);
            }
            else if (state == GameState.Game)
            {
                
                spriteBatch.DrawString(font, "Health: " + string.Format("{0:0}", player.Health), new Vector2(20, GraphicsDevice.Viewport.Height - 20), Color.White);
                spriteBatch.DrawString(font, "P-Pause/Options", new Vector2(720, GraphicsDevice.Viewport.Height - 20), Color.White);
                // Draw zombies
                foreach (Enemy ene in Enemylist)
                {
                    if (ene.IsDead() == false)
                    {
                        sourceRectZombie.X = frame * ZOMBIE_RECT_WIDTH;
                        if (ene.X > player.X)
                        {
                            imageFlipZombie = SpriteEffects.FlipHorizontally;
                            spriteBatch.Draw(enemytexture, new Vector2(ene.Rect.X, ene.Rect.Y), sourceRectZombie, Color.White, 0, Vector2.Zero, 1.0f, imageFlipZombie, 0);
                        }
                        else
                        {
                            imageFlipZombie = SpriteEffects.None;
                            spriteBatch.Draw(enemytexture, new Vector2(ene.Rect.X, ene.Rect.Y), sourceRectZombie, Color.White, 0, Vector2.Zero, 1.0f, imageFlipZombie, 0);
                        }
                    }
                }
                
                // Draws weapon pickup-able 
                if (selectedWeapon.Active == true)
                {
                    if (selectedWeapon is Pistol)
                        spriteBatch.Draw(PistolPickUpAble, selectedSpawn, Color.CornflowerBlue);
                    else if (selectedWeapon is Assault_Rifle)
                        spriteBatch.Draw(ARPickUpAble, selectedSpawn, Color.CornflowerBlue);
                    else if (selectedWeapon is RPG)
                        spriteBatch.Draw(RPGPickUpAble, selectedSpawn, Color.CornflowerBlue);

                }
                // Draw health packs
                if (medkit.Active == true)
                    spriteBatch.Draw(medkitTexture, selectedMedSpawn, Color.White);
                //Draw a platform
                foreach (Platforms P in ListofPlatforms)
                {
                    spriteBatch.Draw(platformtexture, P.Rectangle, Color.White);
                }
                // Draw safespot
                if (safeSpot.Active == true)
                {
                    spriteBatch.DrawString(font, "SAFE SPOT ACTIVE!!!!", new Vector2(400, 70), Color.Red);
                    spriteBatch.Draw(safeSpotTexture, selectedSafeSpawn, Color.White);
                }

                // Decides which frame of player to draw (DON'T CHANGE)
                switch (playerState)
                {
                    case PlayerState.FaceLeft:
                        sourceRect.X = 0;
                        imageFlip = SpriteEffects.FlipHorizontally;
                        break;
                    case PlayerState.FaceRight:
                        sourceRect.X = 0;
                        break;
                    case PlayerState.WalkLeft:
                        if (player.CurrentlyEquipped == pistol)
                            sourceRect.Width = 44;
                        sourceRect.X = frame * PLAYER_RECT_WIDTH;
                        imageFlip = SpriteEffects.FlipHorizontally;
                        break;
                    case PlayerState.WalkRight:
                        if (player.CurrentlyEquipped == pistol)
                            sourceRect.Width = 44;
                        sourceRect.X = frame * PLAYER_RECT_WIDTH;
                        break;
                }

                    // Draw player with pistol
                    if (player.CurrentlyEquipped == pistol)
                    {
                        spriteBatch.DrawString(font, "Ammo: " + bulletsForPistol.Count, new Vector2(150, GraphicsDevice.Viewport.Height - 20), Color.White);
                        spriteBatch.Draw(PistolPlayerTexture, new Vector2(player.Rect.X, player.Rect.Y), sourceRect, Color.White, 0, Vector2.Zero, 1.0f, imageFlip, 0);
                        foreach (Bullet B in bulletsinflight)
                        {
                            if (B.Active == true)
                            {
                                spriteBatch.Draw(bullettexture, B.Rect, Color.White);
                            }
                        }
                        if (bulletsForPistol.Count <= 0)
                        {
                            //spriteBatch.Draw(jwallbruhTexture, new Vector2(5,20), Color.White);
                            spriteBatch.DrawString(font, "R to Reload", new Vector2(player.Rect.X - 11, player.Rect.Y - 20), Color.Red);
                        }
                            
                    }
                    // Draw player with AR
                    else if (player.CurrentlyEquipped == AR)
                    {
                        spriteBatch.DrawString(font, "Ammo: " + bulletsForAR.Count, new Vector2(150, GraphicsDevice.Viewport.Height - 20), Color.White);
                        spriteBatch.Draw(ARPlayerTexture, new Vector2(player.Rect.X, player.Rect.Y), sourceRect, Color.White, 0, Vector2.Zero, 1.0f, imageFlip, 0);
                        foreach (Bullet B in bulletsinflight)
                        {
                            if (B.Active == true)
                            {
                                spriteBatch.Draw(bullettexture, B.Rect, Color.White);
                            }
                        }
                        if (bulletsForAR.Count <= 0)
                        {
                            //spriteBatch.Draw(jwallbruhTexture, new Vector2(5, 20), Color.White);
                            spriteBatch.DrawString(font, "R to Reload", new Vector2(player.Rect.X - 11, player.Rect.Y - 20), Color.Red);
                        }
                            
                    }
                    // Draw player if RPG
                    else if (player.CurrentlyEquipped == rpg)
                    {
                        spriteBatch.DrawString(font, "Ammo: " + bulletsForRPG.Count, new Vector2(150, GraphicsDevice.Viewport.Height - 20), Color.White);
                        spriteBatch.Draw(RPGPlayerTexture, new Vector2(player.Rect.X, player.Rect.Y), sourceRect, Color.White, 0, Vector2.Zero, 1.0f, imageFlip, 0);
                        foreach (Bullet B in bulletsinflight)
                        {
                            if (B.Active == true)
                            {
                                if (B.ValueDirect == 1)
                                    spriteBatch.Draw(RPGbulletLeftTexture, B.Rect, Color.White);
                                else if (B.ValueDirect == 3)
                                    spriteBatch.Draw(RPGbulletTexture, B.Rect, Color.White);
                                
                            }
                        }
                        if (bulletsForRPG.Count <= 0)
                            spriteBatch.DrawString(font, "R to Reload", new Vector2(player.Rect.X - 11, player.Rect.Y - 20), Color.Red);
                    }
                //draw nuke
                    if (nuke.Active == true&&durationsafespot > 9)
                    {
                        nukeRect.Y = nuke.Y;
                        spriteBatch.Draw(nuketexture, nukeRect, Color.White);
                    }
                
            }  
                else if (state == GameState.Gamepause)
                {
                    spriteBatch.Draw(backtexture, backrectangle, Color.White);
                    spriteBatch.Draw(quittexture, quitrectangle, Color.White);
                    spriteBatch.DrawString(font, "Objective: survive in zombieland while trying to avoid nukes from the US Army, ", new Vector2(GraphicsDevice.Viewport.Width / 2 - 300, GraphicsDevice.Viewport.Height / 2 - 120), Color.White);
                    spriteBatch.DrawString(font, "MAJOR HINT: the platforms are radioactive, stand on it and you take damage", new Vector2(GraphicsDevice.Viewport.Width / 2 - 300, GraphicsDevice.Viewport.Height / 2 - 100), Color.White);
                    spriteBatch.DrawString(font, "Controls", new Vector2(GraphicsDevice.Viewport.Width / 2 - 50, GraphicsDevice.Viewport.Height / 2 - 80), Color.White);
                    spriteBatch.DrawString(font, "Spacebar-Jump", new Vector2(GraphicsDevice.Viewport.Width / 2 - 50, GraphicsDevice.Viewport.Height / 2 - 60), Color.White);
                    spriteBatch.DrawString(font, "A-Left", new Vector2(GraphicsDevice.Viewport.Width / 2 - 50, GraphicsDevice.Viewport.Height / 2 - 40), Color.White);
                    spriteBatch.DrawString(font, "D-Right", new Vector2(GraphicsDevice.Viewport.Width / 2 - 50, GraphicsDevice.Viewport.Height / 2 - 20), Color.White);
                    spriteBatch.DrawString(font, "F-Fire", new Vector2(GraphicsDevice.Viewport.Width / 2 - 50, GraphicsDevice.Viewport.Height / 2), Color.White);
                    spriteBatch.DrawString(font, "R-Reload", new Vector2(GraphicsDevice.Viewport.Width / 2 - 50, GraphicsDevice.Viewport.Height / 2 +20), Color.White);
                    
                }
                else if (state == GameState.Gameover)
                {
                    spriteBatch.DrawString(font, "Press M - Go Back to Menu", new Vector2((GraphicsDevice.Viewport.Width / 2) - 100, GraphicsDevice.Viewport.Height / 2), Color.White);
                    spriteBatch.DrawString(font, "GAME OVER!!!", new Vector2((GraphicsDevice.Viewport.Width / 2) - 100, GraphicsDevice.Viewport.Height / 2 - 80), Color.White);
                    spriteBatch.DrawString(font, "Score: " + playerstat.PlayerScore, new Vector2((GraphicsDevice.Viewport.Width / 2) - 100, GraphicsDevice.Viewport.Height / 2 - 60), Color.White);

                }
                spriteBatch.End();
                base.Draw(gameTime);
            }
        }
    
    }

    

