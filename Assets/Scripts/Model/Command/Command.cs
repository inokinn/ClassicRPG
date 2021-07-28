using UnityEngine;

public interface ICommand
{
    // 名前
    string Name { get; }
    // 消費MP
    int MpCost { get; }

    // 実行
    void Execute(IBattler user, IBattler target);
}

/// <summary>
/// バトルコマンドの基底クラス
/// </summary>
public abstract class Command : ScriptableObject, ICommand
{
    // 名前
    [SerializeField] private string _name;
    public string Name
    {
        get => _name;
    }

    // 消費MP
    [SerializeField] private int _mpCost;
    public int MpCost
    {
        get => _mpCost;
    }

    /// <summary>
    /// コマンドの実行
    /// </summary>
    /// <param name="user"></param>
    /// <param name="target"></param>
    public abstract void Execute(IBattler user, IBattler target);
}
