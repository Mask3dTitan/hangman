using System;
using System.IO;
using System.Linq.Expressions;

public class Program{
    //set up phase
    static string GetWord(){
        Random sigma = new Random();
        int gigachad = sigma.Next(1,151);
        string[] lines = File.ReadAllLines("words.txt");
        return lines[gigachad];
    }
    static string UnderScore(string input){
        //underscore setup bit
        string output = "";
        for(int i = 0; i < input.Length ; i++){
            output += "_";
        }
        return output;
    }



//GamePhase
//
public static string Check(char guess, string word, string hidden ){
    bool found = false;
    char[] maskedArray = hidden.ToCharArray();    
    for(int i = 0; i < word.Length ; i++){
        
        if (word[i] == guess){
            maskedArray[i] = guess;
            found = true;
        }
    }
    if (found){
        Console.WriteLine("The letter "+ guess +" is present in the word");
    }
    else{
        Console.WriteLine("The letter "+ guess +" is not present in the chosen word");
    }
    return new string(maskedArray);
}

static string DisplayHangman(int wrongGuesses)
    {//hangman art
        string[] hangmanStages = {
            @"
               -----
               |   |
                   |
                   |
                   |
                   |
            =========",
            @"
               -----
               |   |
               O   |
                   |
                   |
                   |
            =========",
            @"
               -----
               |   |
               O   |
               |   |
                   |
                   |
            =========",
            @"
               -----
               |   |
               O   |
              /|   |
                   |
                   |
            =========",
            @"
               -----
               |   |
               O   |
              /|\  |
                   |
                   |
            =========",
            @"
               -----
               |   |
               O   |
              /|\  |
              /    |
                   |
            =========",
            @"
               -----
               |   |
               O   |
              /|\  |
              / \  |
                   |
            ========="
        };

        return(hangmanStages[wrongGuesses]);
    }

public static bool ProcessGuess(char guess, HashSet<char> guessedLetters)
{

 if (guessedLetters.Contains(guess))
        {
            Console.WriteLine($"You've already guessed '{guess}'. Try again.");
            return false; // Guess was already made
        }
        else
        {
            guessedLetters.Add(guess); // Add new guess to HashSet
            Console.WriteLine($"Guessed letters: {string.Join(", ", guessedLetters)}"); // Display guessed letters
            return true; // Guess is valid
        }
}

public static char GetValidatedInput()
{
    char letter;

    while (true)
    {
        Console.WriteLine("Enter a letter: ");
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input) || input.Length != 1 || !char.IsLetter(input[0]))
        {
        Console.WriteLine("Invalid input. Please enter a single letter.");
        }
        else
        {
            letter = char.ToLower(input[0]); 
            break; 
            }
        }

        return letter; 
    }


public static void Main(string[] args)
{

    int attempts = 0;
    string word = GetWord();
    string hidden = UnderScore(word);
    HashSet<char> guessedLetters = new HashSet<char>();
 
    Console.WriteLine(hidden);
    while (attempts != 7 && hidden.Contains('_') ){
        char letter = GetValidatedInput();
        string NewHidden = Check(letter,word,hidden);
    if (ProcessGuess(letter,guessedLetters)){      
        if (NewHidden != hidden)
        {
            hidden = NewHidden;
        }
        else 
        {
            attempts += 1;
            Console.WriteLine("number of guesses left: " + (6 - attempts) );
            Console.WriteLine(DisplayHangman(attempts));
        }
    
    Console.WriteLine(hidden);
    }
    }

    if (attempts <= 0   ){
            Console.WriteLine("Oops you went over the limit buddyo");
            Console.WriteLine("it was actually" + word);
    }
    else {
            Console.WriteLine("YIPEE");
    }
    Console.WriteLine("Do you want to play again? (y/n)");
    string playAgain = Console.ReadLine().ToLower();
    if (playAgain == "y")
    {
            Main(args);  // Restart the game
    }
    else
    {
            Console.WriteLine("Thanks for playing!");
    }
      
}
}

