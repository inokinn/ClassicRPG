using System.Collections.Generic;

public enum BattlerRaceType
{
    Human,          // 人間
    Elf,            // エルフ
    Dwarf,          // ドワーフ
    Ogre,           // オーガ
    Beastman,       // 獣人
    Dragonute,      // ドラゴニュート
    Enemy,           // エネミー
}

public interface IBattler
{
    // 名前
    string Name { get; }
    // 種族
    BattlerRaceType RaceType { get; }
    // 最大HP
    int MaxHp { get; }
    // 現在のHP
    int CurrentHp { get; set; }
    // 最大MP
    int MaxMp { get; }
    // 現在のMP
    int CurrentMp { get; }
    // 力
    int Str { get; }
    // 守り
    int Def { get; }
    // 素早さ
    int Spd { get; }
    // 魔力
    int Mgc { get; }
    // 運
    int Luc { get; }

    // コマンドリスト
    List<Command> Commands { get; }
    // ターゲット
    List<IBattler> Targets { get; set; }

    // 行動選択
    void SelectCommand();
}
