using System.Collections;
using System.Collections.Generic;

public class Player : IBattler
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

    public void SelectCommand()
    {
        // TODO: コマンド選択
    }

    public void Temp()
    {
        _name = "ヨシヒコ";
        _title = "勇者";
        _faceId = 1;
        _raceType = BattlerRaceType.Human;
        _level = 1;
        _maxHp = 20;
        _currentHp = 20;
        _maxMp = 10;
        _currentMp = 10;
        _str = 5;
        _def = 2;
        _spd = 8;
        _mgc = 4;
        _luc = 3;
    }
}
