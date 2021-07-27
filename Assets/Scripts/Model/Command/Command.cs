using UnityEngine;

/// <summary>
/// バトルコマンドの基底クラス
/// </summary>
public abstract class Command : ScriptableObject
{
    // 名前
    [SerializeField] private string _name;
    public string Name
    {
        get => _name;
    }

    // 消費MP
    [SerializeField] private string _mpCost;
    public string MpCost
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
