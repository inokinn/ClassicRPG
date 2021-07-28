using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public interface IEnemy : IBattler
{

}

public class Enemy : IEnemy
{
    // 名前
    private string _name;
    public string Name
    {
        get => _name;
    }

    // 肩書き
    private string _title;
    public string Title
    {
        get => _title;
    }

    // 顔ID
    private int _faceId;
    public int FaceId
    {
        get => _faceId;
    }

    // 種族
    private BattlerRaceType _raceType;
    public BattlerRaceType RaceType
    {
        get => _raceType;
    }

    // レベル
    private int _level;
    public int Level
    {
        get => _level;
    }

    // 最大HP
    private int _maxHp;
    public int MaxHp
    {
        get => _maxHp;
    }

    // 現在のHP
    private int _currentHp;
    public int CurrentHp
    {
        get => _currentHp;
        set { _currentHp = value; }
    }

    // 最大MP
    private int _maxMp;
    public int MaxMp
    {
        get => _maxMp;
    }
    // 現在のMP
    private int _currentMp;
    public int CurrentMp
    {
        get => _currentMp;
    }
    // 力
    private int _str;
    public int Str
    {
        get => _str;
    }
    // 守り
    private int _def;
    public int Def
    {
        get => _def;
    }
    // 素早さ
    private int _spd;
    public int Spd
    {
        get => _spd;
    }
    // 魔力
    private int _mgc;
    public int Mgc
    {
        get => _mgc;
    }
    // 運
    private int _luc;
    public int Luc
    {
        get => _luc;
    }
    // コマンドリスト
    private List<Command> _commands;
    public List<Command> Commands
    {
        get => _commands;
    }

    public void SelectCommand()
    {
        // TODO: コマンド選択
    }

    public void Temp()
    {
        _name = "スライム";
        _raceType = BattlerRaceType.Enemy;
        _maxHp = 12;
        _currentHp = 12;
        _maxMp = 1;
        _currentMp = 1;
        _str = 3;
        _def = 1;
        _spd = 3;
        _mgc = 0;
        _luc = 1;

        this.GenerateCommands();
    }

    /// <summary>
    /// コマンドの生成
    /// </summary>
    private void GenerateCommands()
    {
        Command attack = Resources.Load<Attack>("ScriptableObjects/Commands/Attack");
        _commands = new List<Command>(new Command[] {
                                        attack,
                                    });
    }
}
