using System.Collections.Generic;
using UnityEngine;

public class GameManagerAnswer
{
    static GameManagerAnswer _instance = new GameManagerAnswer();
    public static GameManagerAnswer Instance => _instance;
    private GameManagerAnswer() { }


    PlayerAnswer _player;
    List<EnemyAnswer> _enemies = new List<EnemyAnswer>();

    public PlayerAnswer Player => _player;
    public List<EnemyAnswer> Enemies => _enemies;

    public void Register(PlayerAnswer p) { _player = p; }
    public void Register(EnemyAnswer e) { _enemies.Add(e); }
    public void Remove(EnemyAnswer e) { _enemies.Remove(e); }
}
