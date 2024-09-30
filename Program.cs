﻿// See https://aka.ms/new-console-template for more information

using System;
using System.IO;

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



public static void Main(string[] args)
{
        //grab word from the txt file
    int attempts = 0;
    string word = GetWord();
    string hidden = UnderScore(word);
    HashSet<char> guessedLetters = new HashSet<char>();
 
    Console.WriteLine(hidden);
    Console.WriteLine(word);
    while (attempts != 7 && hidden.Contains('_') ){
        Console.WriteLine("enter a letter");
            string input = Console.ReadLine();
            char letter = input[0];
            string NewHidden = Check(letter,word,hidden);
        char check = char.ToLower(input[0]);
    if (ProcessGuess(check,guessedLetters)){      
        if (NewHidden != hidden)
        {
            hidden = NewHidden;
        }
        else 
        {
            attempts += 1;
            Console.WriteLine("number of guesses left: " + (7 - attempts) );
            Console.WriteLine(DisplayHangman(attempts));
        }
    
    Console.WriteLine(hidden);
    }
    }

    if (attempts < 0   ){
            Console.WriteLine("Oops you went over the limit buddyo");
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




















