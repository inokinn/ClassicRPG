using UnityEngine;

/// <summary>
/// 通常攻撃クラス
/// </summary>
[CreateAssetMenu]
public class Attack : Command
{
    /// <summary>
    /// コマンドの実行
    /// </summary>
    /// <param name="user"></param>
    /// <param name="target"></param>
    override public void Execute(IBattler user, IBattler target)
    {
        target.CurrentHp -= user.Str;
        Debug.Log($"{user.Name}の攻撃！{target.Name}に{user.Str}のダメージ。残りHPは{target.CurrentHp}");
    }
}
