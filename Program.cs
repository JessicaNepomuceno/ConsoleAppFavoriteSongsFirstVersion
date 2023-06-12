//*****************************************************************************************************
//
//  Program Name: Favorite Songs 
//  Description: App for register favorite songs 
//  Author: Jéssica Nepomuceno
//  Created date: 11/06/2023
//
//*****************************************************************************************************

using FavoriteSongs;

/// <summary>
/// Global variables
/// </summary>
string logoFavoriteSongs = @"
███████╗░█████╗░██╗░░░██╗░█████╗░██████╗░██╗████████╗███████╗  ░██████╗░█████╗░███╗░░██╗░██████╗░░██████╗
██╔════╝██╔══██╗██║░░░██║██╔══██╗██╔══██╗██║╚══██╔══╝██╔════╝  ██╔════╝██╔══██╗████╗░██║██╔════╝░██╔════╝
█████╗░░███████║╚██╗░██╔╝██║░░██║██████╔╝██║░░░██║░░░█████╗░░  ╚█████╗░██║░░██║██╔██╗██║██║░░██╗░╚█████╗░
██╔══╝░░██╔══██║░╚████╔╝░██║░░██║██╔══██╗██║░░░██║░░░██╔══╝░░  ░╚═══██╗██║░░██║██║╚████║██║░░╚██╗░╚═══██╗
██║░░░░░██║░░██║░░╚██╔╝░░╚█████╔╝██║░░██║██║░░░██║░░░███████╗  ██████╔╝╚█████╔╝██║░╚███║╚██████╔╝██████╔╝
╚═╝░░░░░╚═╝░░╚═╝░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝╚═╝░░░╚═╝░░░╚══════╝  ╚═════╝░░╚════╝░╚═╝░░╚══╝░╚═════╝░╚═════╝░";
string messagesWelcome = "Welcome to your app the favorite songs!";
bool showMenu = true;
var artist = new List<Artist>();

/// <summary>
/// Head - Show the logo
/// </summary>
void ShowLogo()
{
    Console.WriteLine(logoFavoriteSongs);
    Console.WriteLine("");
}

/// <summary>
/// Head - Show the welcome message
/// </summary>
void ShowMessagesWelcome()
{
    
    Console.WriteLine("");
    Console.WriteLine(messagesWelcome);
}

/// <summary>
/// Function - Show the menu options
/// </summary>
string ShowMenuOptions()
{
    string numberOptionsMenu;

    Console.WriteLine("");
    Console.WriteLine("OPTIONS MENU");
    Console.WriteLine("");
    //CRUD (Create, Read, Update, Delete)
    Console.WriteLine("Type 1 - Register a favorite song.");
    Console.WriteLine("Type 2 - List your favorite songs.");
    Console.WriteLine("Type 3 - Update a favorite song.");
    Console.WriteLine("Type 4 - Delete a favorite song.");
    Console.WriteLine("Type 0 - Exit.");
    Console.WriteLine("");
    Console.Write("Type the number to select the option: ");     
    numberOptionsMenu = Console.ReadLine()!;
    Console.WriteLine("");

    return numberOptionsMenu;
}

/// <summary>
/// Function - Register a favorite song
/// </summary>
bool CreateFavoriteSong()
{
    bool concluded = false;

    Console.Clear();
    ShowLogo();

    Console.WriteLine("To register a favorite song, enter the information requested below.");
    Console.WriteLine("");

    Console.Write("Type the name of the artist: ");
    var Name = Console.ReadLine()!;
    Console.WriteLine("");

    Console.Write("Type the name of the song: ");
    var NameSong = Console.ReadLine()!;
    Console.WriteLine("");

    Console.Write("Type the note (From 0 to 10) of how much you like this song: ");
    var Note = (decimal.TryParse(Console.ReadLine()!, out decimal number) ? number : 0);
    Console.WriteLine("");

    Console.WriteLine("This is the information you entered:");
    Console.WriteLine("");

    Console.WriteLine($"The name of the artist: {Name}");
    Console.WriteLine($"The name of the song: {NameSong}");
    Console.WriteLine($"The note (From 0 to 10): {Note}");
    Console.WriteLine("");

    bool repeatAgree = true;
    while (repeatAgree)
    {
        Console.Write("Do you agree? Type Y for yes or N for no: ");
        var agree = Console.ReadLine()!.ToUpper();

        switch (agree)
        {
            case "Y":
                Console.WriteLine("The artist information has been saved! Returning to the menu...");
                artist.Add(new Artist { Name = Name, NameSong = NameSong, Note = Note });                            
                concluded = true;
                repeatAgree = false;
                break;
            case "N":
                Console.WriteLine("The artist information has not been saved! Returning to the menu...");                
                concluded = true;
                repeatAgree = false; 
                break;
            default:
                Console.WriteLine("WARNING! --> YOU TYPE A INVALID OPTION, PLEASE TRY IT AGAIN.");
                // Delay that permit the user to read the warning message
                Thread.Sleep(3000);
                repeatAgree = true;
                Console.WriteLine("");
                break;
        }
    } 

    return concluded;
}

/// <summary>
/// Function - List a favorite song
/// </summary>
void ListFavoriteSong()
{   
    if (artist != null && artist.Any())
    {
        foreach (Artist item in artist)
        {
            Console.WriteLine($"The name of the artist: {item.Name} - The name of the song: {item.NameSong} - The note (From 0 to 10): {item.Note}");
            Console.WriteLine("");
        }
    }        
    else
    {
        Console.WriteLine("You have no favorite songs registered.");
        Console.WriteLine("");
    }
    
    Console.WriteLine("Press Enter to Return to menu.");
    while (Console.ReadKey().Key != ConsoleKey.Enter) { }
}

/// <summary>
/// The main program
/// </summary>
while (showMenu)
{
    ShowLogo();
    ShowMessagesWelcome();
    string selectedOptionsMenu = ShowMenuOptions();
    switch (selectedOptionsMenu)
    {
        case "1":
            Console.WriteLine($"You selected the option {selectedOptionsMenu}!");
            Thread.Sleep(3000);
            showMenu = CreateFavoriteSong();
            Thread.Sleep(4000);
            Console.Clear();
            break;
        case "2":
            Console.WriteLine($"You selected the option {selectedOptionsMenu}!");
            Thread.Sleep(3000);
            Console.Clear();
            ShowLogo();
            ListFavoriteSong();            
            Console.Clear();
            showMenu = true;
            break;
        case "3":
            Console.WriteLine($"You selected the option {selectedOptionsMenu}!");
            showMenu = false;
            break;
        case "4":
            Console.WriteLine($"You selected the option {selectedOptionsMenu}!");
            showMenu = false;
            break;
        case "0":
            Console.WriteLine("THE PROGRAM WILL BE EXIT, WAIT...");
            // Delay that permit the user to read the exit message
            Thread.Sleep(3000);
            showMenu = false;            
            break;
        default: 
            Console.WriteLine("WARNING! --> YOU TYPE A INVALID OPTION, PLEASE TRY IT AGAIN.");
            // Delay that permit the user to read the warning message
            Thread.Sleep(3000); 
            Console.Clear();
            showMenu = true;
            break;
    }
}


