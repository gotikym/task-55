using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        LeaderBoard leaderBoard = new LeaderBoard();
        leaderBoard.ShowTop3();
    }
}

class LeaderBoard
{
    private List<Player> _players = new List<Player>();

    public LeaderBoard()
    {
        CreatePlayers();
    }

    public void ShowTop3()
    {
        var orderedPlayersByLvl = _players.OrderByDescending(player => player.Level).Take(3).ToList();
        var orderedPlayersByStrength = _players.OrderByDescending(player => player.Strength).Take(3).ToList();

        Console.WriteLine("Top 3 players by lvl");
        ShowPlayers(orderedPlayersByLvl);
        Console.WriteLine("\nTop 3 players by Strength");
        ShowPlayers(orderedPlayersByStrength);
    }

    private void ShowPlayers(List<Player> players)
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