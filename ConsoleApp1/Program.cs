using System;
using System.Threading;

// cd /Users/aleksolenichev/CSharpPlayersGuide/ConsoleApp1/          

public class Game
{
    private int turnNumber;
    private Manticore player1;
    private Consolas player2;
    private int manticoreHealth;
    private int cityHealth;

    public Game(Manticore p1, Consolas p2)
    {
        turnNumber = 1;
        player1 = p1;
        player2 = p2;
        manticoreHealth = 10; 
        cityHealth = 15; 

    }

    public int ManticoreHealth
    {
        get { return manticoreHealth; }
        set { if (value > 0) manticoreHealth = value; }
    
    }

    public int CityHealth 
    {
        get { return cityHealth; }
        set { if (value > 0) cityHealth = value; }
    }
    public int NextTurn()
    {
        Console.WriteLine($"The current turn number is {turnNumber}.");
        turnNumber++; 
        return turnNumber;
    }

    public void GameRunning()
    {
        

            while(manticoreHealth > 0 && cityHealth > 0)
            {       
            NextTurn();
            DisplayHealthStatus(); 
            player1.SetManticorePosition();
            
            bool wasHit = player2.CannonShot(player1.ManticorePosition); 

            player1.ManticoreHealthLevel(this, wasHit);
            player2.ConsolasHealthReduction(this, wasHit);

            }           
    }
// the game does not end when Manticore health is 0 (stops at 1)
    public void DisplayHealthStatus() 
    {
        Console.WriteLine($"Manticore health level is {manticoreHealth}."); 
        Console.WriteLine($"Consolas health level is {cityHealth}.");  
    }

    public void GameOver()
    {
        if (manticoreHealth == 0)
        {
            Console.WriteLine("Congratulations, Consolas! You have successfully defended the city!");
        }
        else if (cityHealth == 0)
        {
            Console.WriteLine("The Manticore has destroyed Consolas. The city is lost.");
        }
    }

}

public class Manticore
{
   private int ManticoreUnits;

  public Manticore ()
  {
    //left blank
  }

  public int ManticorePosition 
    {
        get { return ManticoreUnits; }
        set { ManticoreUnits = value; }
    }

   public void SetManticorePosition()
   {
       Console.WriteLine(
        "It is up to you now, the commanding officer of the Manticore, to make your turn.\n" +
        "Please choose how far you would like to place your ship from the city's gates.\n" +
        "The distance should be between 0 and 100 units.");

        while(true)
        {
            try
            {
            ManticoreUnits = Convert.ToInt32(Console.ReadLine());

            if (ManticoreUnits < 0 || ManticoreUnits > 100)
            {
                Console.WriteLine("Please select the distance which is between our limits.");
                continue;
            }
            
            break;

            }
        
            catch (FormatException)
            {
            Console.WriteLine("Please enter a valid number.");
            }
       
        }
        Console.WriteLine($"Very well, the chosen distance is {ManticoreUnits}.");
        
    
        //Thread.Sleep(2000); commenting out for the testing purposes 
        //Console.Clear();
   } 


   public int ManticoreHealthLevel(Game game, bool isAsimpleHit)
   {
        if(isAsimpleHit)
        {
            game.ManticoreHealth--;
        }
       
        return game.ManticoreHealth;
        
   }
}

public class Consolas
{
    private int playerDistance;
    
    public Consolas()
    {
       //left blank
    }

    public bool CannonShot(int ManticorePosition)
    
    {
        Console.WriteLine("It is your turn now, defenders of Consolas!");

        playerDistance = AskDistance();

        bool isAsimpleHit = ShotResult(ManticorePosition);

        return isAsimpleHit; 
    }

    public int AskDistance()
    {
        while(true)
        {
            try
            {
                Console.WriteLine("Please select the cannon's shot distance between 0 and 100.");
                playerDistance = Convert.ToInt32(Console.ReadLine());

                if (playerDistance < 0 || playerDistance > 100)
                {
                    Console.WriteLine("Please select the distance which is between our limits.");
                    continue;
                }

                Console.WriteLine($"Confirming the distance of {playerDistance}.");
                return playerDistance;
    
            }   
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid number.");
        }
        
        }
    }
    
    public bool ShotResult(int ManticorePosition)
    {

        bool isAsimpleHit; 

        if (playerDistance < ManticorePosition)
        {
            Console.WriteLine("That round fell short, reload quick!");
            isAsimpleHit = false;
        }
        else if (playerDistance > ManticorePosition)
        {
            Console.WriteLine("We have an overshot, try again!"); 
            isAsimpleHit = false;
        }
        else 
        {
            Console.WriteLine("We have a direct hit here!. The health of the Manticore is reduced by 1 point!");
            isAsimpleHit = true;
        
        }
        return isAsimpleHit;
        
    }
        // so, what happens after all of that? the turn is ending, right? we either had a hit or not. 
        // every turn takes out -1 health from Consolas health as Manticore is kind of attacking as well. 


    public int ConsolasHealthReduction (Game game, bool isAsimpleHit) 

    {
    if (isAsimpleHit == true)
     {
        return game.CityHealth;
     }

    else if (game.ManticoreHealth > 0)                                                           
        {
            game.CityHealth --;                                                              
            Console.WriteLine("The health level of Consolas is reduced by 1 point!");
            return game.CityHealth;
        }

    return game.CityHealth;

    }

}

public class Program 
{
    public static void Main()
    {
        
        Manticore player1 = new Manticore();
        Consolas player2 = new Consolas();

        Game game = new Game(player1, player2);
       
        game.GameRunning();
        game.GameOver();

    }
} 



