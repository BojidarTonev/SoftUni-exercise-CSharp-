using System;
using System.Collections.Generic;
using System.Threading;

namespace Game_project
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 105;
            Console.WindowHeight = 30;
            Player playerOne = new Player();
            A(playerOne);
        }
        public static void A(Player playerOne)
        {
            Arena.GenerateLevel();
            Arena.DefineAtena();
            Ball ball = new Ball();
            while (true)
            {
                Arena.UpdateArena(playerOne, ball);
                Draw(playerOne);
                TakeKey(playerOne);
            }
        }
        public static void Draw(Player playerOne)
        {
            Random rnd = new Random();
            Console.WriteLine($"\tscore:{playerOne.score:D4} \t \t lives: {playerOne.lives}");
            Console.Write(Arena.ArenaToString());
            Console.WriteLine("\t\t\t\t\t\t Bojidar & Rafi (C) 2017  \tall rights reserved");
            for (int i = 1; i < Arena.width - 1; i++)
            {
                for (int j = 1; j < Arena.height - 1; j++)
                {
                    Arena.arena[i, j] = ' ';
                }
            }
            Thread.Sleep(11);
            Console.SetCursorPosition(0, 0);
        }
        public static void TakeKey(Player player)
        {
            if (Console.KeyAvailable)
            {
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.A:
                        player.MoveLeft();
                        Console.Clear();
                        break;
                    case ConsoleKey.LeftArrow:
                        player.MoveLeft();
                        Console.Clear();
                        break;
                    case ConsoleKey.D:
                        player.MoveRight();
                        Console.Clear();
                        break;
                    case ConsoleKey.RightArrow:
                        player.MoveRight();
                        Console.Clear();
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
    public class Player
    {
        public int width;
        public double position;
        public int positionY;
        public char appearance;
        public int lives;
        public int score;
        public double speed;
        public Player()
        {
            width = 10;
            position = 8;
            appearance = '=';
            lives = 1;
            score = 0;
            speed = 5;
            positionY = 1;
        }
        public void Die()
        {
            Console.Clear();
            lives--;
            if (lives == 0)
            {
                Console.WriteLine($"\n\n\tYOU ARE DEAD!  \n\n \tScore: {score:D4}");
                Console.ReadKey();
                Environment.Exit(0);//END GAME METHOD
            }
            else
            {
                Brick.bricks.Clear();
                Program.A(this);
            }
        }
        public void MoveLeft()
        {
            if (position - speed > 0)
            {
                position -= speed;
            }
        }
        public void MoveRight()
        {
            if (position + speed < 100 - width)
            {
                position += speed;
            }
        }
    }
    public class Brick
    {
        public char brickBorder;
        public char brickFill;
        public int length;
        public int positionX;
        public int positionY;
        public int durability;
        public static int Count = 0;
        public int ID;
        public bool notDestroyed;
        public int endX;
        public static List<Brick> bricks = new List<Brick>();
        public Brick(int postX, int postY, int len, int dur)
        {
            brickBorder = '|';
            positionX = postX;
            positionY = postY;
            durability = dur;
            brickFill = '#';
            length = len;
            ID = Count;
            Count++;
            notDestroyed = true;
            bricks.Add(this);
            endX = positionX + length + 1;
        }
    }
    public class Position
    {
        public double X = 0;
        public double Y = 0;
        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }
        public bool EqualsY(Position p)
        {
            if (Y + 0.3 >= p.Y && Y - 0.3 <= p.Y)
            {
                return true;
            }
            return false;
        }
        public bool LessThanX(Position p)
        {
            if (X <= p.X)
            {
                return true;
            }
            return false;
        }
        public bool GreaterThanX(Position p)
        {
            if (X >= p.X)
            {
                return true;
            }
            return false;
        }
        public bool EqualsX(Position p)
        {
            if (X + 0.3 >= p.X && X - 0.3 <= p.X)
            {
                return true;
            }
            return false;
        }
    }
    public class Ball
    {
        public double positionX;
        public double positionY;
        public double speed;
        public static int strength = 1;
        public double angle_d;
        public bool colisionWall;
        public bool colision;
        public Ball()
        {
            positionX = 3;
            positionY = 8;
            speed = 0.1;
            angle_d = 315;
            colisionWall = false;
            colision = false;
        }
        public void Colision()
        {
            if (colision)
            {
                if (Sin(angle_d) * Cos(angle_d) > 0)
                {
                    angle_d -= 90;
                    angle_d = angle_d % 360;
                    colision = false;
                }
                else
                {
                    angle_d += 90;
                    angle_d = angle_d % 360;
                    colision = false;
                }
            }
            if (colisionWall)
            {
                if (Sin(angle_d) * Cos(angle_d) > 0)
                {
                    angle_d += 90;
                    angle_d = angle_d % 360;
                    colisionWall = false;
                }
                else
                {
                    angle_d -= 90;
                    angle_d = angle_d % 360;
                    colisionWall = false;
                }
            }
        }
        public void Move()
        {
            positionX += speed * Cos(angle_d);
            positionY += speed * Sin(angle_d);
        }
        public Position MoveNext()
        {
            positionX += speed * Cos(angle_d);
            positionY += speed * Sin(angle_d);
            return new Position(positionX, positionY);
        }
        public static double Cos(double _angle_d)
        {
            return Math.Cos((_angle_d / 180) * Math.PI);
        }
        public static double Sin(double _angle_d)
        {
            return Math.Sin((_angle_d / 180) * Math.PI);
        }
    }
    public static class Arena
    {
        public static int width = 100;
        public static int height = 25;
        public static int blockLowerX = 3;
        public static int blockLowerY = 11;
        public static int blockUpperX = width - 3;
        public static int blockUpperY = height - 3;
        public static char[,] arena = new char[width, height];
        public static void DefineAtena()
        {
            for (int i = 0; i < width; i++) //draw bottom+top
            {
                arena[i, 0] = '-';
                arena[i, height - 1] = '-';
            }
            for (int i = 0; i < height; i++)
            {
                arena[0, i] = '|';
                arena[width - 1, i] = '|';
            }
            arena[0, 0] = '+';
            arena[0, height - 1] = '+';
            arena[width - 1, height - 1] = '+';
            arena[width - 1, 0] = '+';
        }
        public static void UpdateArena(Player player, Ball ball)
        {
            //draw player
            for (int i = 0; i < player.width; i++)
            {
                arena[(int)Math.Ceiling(player.position) + i, player.positionY] = player.appearance;
            }
            //draw ball
            arena[(int)Math.Ceiling(ball.positionX), (int)Math.Ceiling(ball.positionY)] = 'O';
            //draw bricks
            foreach (var brick in Brick.bricks)
            {
                if (brick.notDestroyed)
                {
                    arena[brick.positionX, brick.positionY] = brick.brickBorder;
                    for (int i = 1; i <= brick.length; i++)
                    {
                        arena[brick.positionX + i, brick.positionY] = brick.brickFill;
                    }
                    arena[brick.endX, brick.positionY] = brick.brickBorder;
                }
            }
            //moveing the ball
            Position next = ball.MoveNext();
            Position max = new Position(97.5, 22.6);
            Position min = new Position(1.5, 0.2);
            Position playerStart = new Position(player.position + .2, 1.5);
            Position playerEnd = new Position(player.position + .2 + player.width, player.positionY + .2);
            if (next.EqualsY(max))
            {
                ball.colision = true;
                ball.Colision();
            }
            if (next.EqualsY(min))
            {
                player.Die();
            }
            if (next.EqualsX(min))
            {
                ball.colisionWall = true;
                ball.Colision();
            }
            if (next.EqualsX(max))
            {
                ball.colisionWall = true;
                ball.Colision();
            }
            if (next.EqualsY(playerStart) && next.GreaterThanX(playerStart) && next.LessThanX(playerEnd))
            {
                ball.colision = true;
                ball.Colision();
                player.score++;
            }
            bool remainingBricks = false;
            foreach (var brick in Brick.bricks)
            {
                if (brick.notDestroyed)
                {
                    remainingBricks = true;
                }
                Position brickStart = new Position(brick.positionX, brick.positionY);
                Position brickEnd = new Position(brick.endX, brick.positionY);
                if (next.EqualsY(brickStart) && next.GreaterThanX(brickStart) && next.LessThanX(brickEnd) && brick.notDestroyed)
                {
                    Brick.bricks[brick.ID].notDestroyed = false;

                    ball.colision = true;
                    ball.Colision();
                    player.score += 10;
                }
            }
            if (remainingBricks == false)
            {
                Console.Clear();
                Console.WriteLine($"\n\t YOU WON! \n\tScore:{player.score:D4}");
                Console.WriteLine("Press [C] to continue...\t or[AnyKey] Not to continue.");
                var value = Console.ReadKey();
                if (value.Key == ConsoleKey.C)
                {
                    Brick.bricks.Clear();
                    Program.A(player);
                }
                else
                    Environment.Exit(0);
            }
            ball.Move();
        }
        public static string ArenaToString()
        {
            string a = "";
            for (int i = height - 1; i >= 0; i--)
            {
                for (int j = 0; j < width; j++)
                {
                    a += arena[j, i];
                }
                a += "\n";
            }
            return a;
        }
        public static void GenerateLevel()
        {
            Random rnd = new Random();
            int i = 0;
            do
            {
                if (Brick.bricks.Count == 0)
                {
                    int leng = (int)rnd.Next(3, 10);
                    int positionX = (int)rnd.Next(blockLowerX, blockUpperX - leng - 1);
                    int positionY = (int)rnd.Next(blockLowerY, blockUpperY);
                    new Brick(positionX, positionY, leng, 1);
                    i++;
                }
                else
                {
                    int leng = (int)rnd.Next(3, 10);
                    int positionX = (int)rnd.Next(blockLowerX, blockUpperX - leng - 1);
                    int positionY = (int)rnd.Next(blockLowerY, blockUpperY);
                    bool allowed = true;
                    foreach (var brick in Brick.bricks)
                    {
                        if (positionY == brick.positionY)
                        {
                            if (positionX <= brick.positionX + brick.length + 1)
                            {
                                if (positionX + leng + 1 >= brick.positionX)
                                {
                                    allowed = false;
                                }

                            }
                        }
                    }
                    if (allowed)
                    {
                        new Brick(positionX, positionY, leng, 1);
                        i++;
                    }
                }
            } while (i < 40);
        }
    }
}
