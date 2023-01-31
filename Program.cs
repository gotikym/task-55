using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        LeaderBoard leaderBoard = new LeaderBoard();
        leaderBoard.Choose();
    }
}

class LeaderBoard
{
    private List<Player> _players = new List<Player>();
    private int _topLadder = 3;

    public LeaderBoard()
    {
        CreatePlayers();
    }

    public void Choose()
    {
        const string CommandShowTopLvl = "1";
        const string CommandShowTopStrength = "2";
        const string CommandExit = "3";
        bool isExit = false;

        while (isExit == false)
        {
            Console.WriteLine("Посмотреть таблицу лидеров по уровню - " + CommandShowTopLvl + ", по силе - " + CommandShowTopStrength + " выйти - " + CommandExit);
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case CommandShowTopLvl:
                    ShowTopLvl();
                    break;
                case CommandShowTopStrength:
                    ShowTopStrength();
                    break;
                case CommandExit:
                    isExit = true;
                    break;
            }
        }
    }

    private void ShowTopLvl()
    {
        var orderedPlayersByLvl = _players.OrderByDescending(player => player.Level).Take(_topLadder).ToList();

        Console.WriteLine("Top " + _topLadder + " players by lvl");
        Show(orderedPlayersByLvl);
    }

    private void ShowTopStrength()
    {
        var orderedPlayersByStrength = _players.OrderByDescending(player => player.Strength).Take(_topLadder).ToList();

        Console.WriteLine("\nTop " + _topLadder + " players by Strength");
        Show(orderedPlayersByStrength);
    }

    private void Show(List<Player> players)
    {
        int numberPlayer = 1;

        foreach (Player player in players)
        {
            Console.WriteLine(numberPlayer + ": " + player.Name + " " + player.Level + " " + player.Strength);
            numberPlayer++;
        }
    }

    private void CreatePlayers()
    {
        _players.Add(new Player("061095", 13, 12347));
        _players.Add(new Player("BC Reductor", 11, 10667));
        _players.Add(new Player("Dokkaebi", 17, 15836));
        _players.Add(new Player("EresoBoy ", 15, 14998));
        _players.Add(new Player("EV", 7, 5613));
        _players.Add(new Player("fin de todo", 16, 16401));
        _players.Add(new Player("I'm about to get my .44 up", 14, 11123));
        _players.Add(new Player("Legosi", 27, 22300));
        _players.Add(new Player("qi", 6, 7640));
        _players.Add(new Player("SayronBlock", 19, 17348));
    }
}

class Player
{
    public Player(string name, int level, int strength)
    {
        Name = name;
        Level = level;
        Strength = strength;
    }

    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Strength { get; private set; }
}
