using System.Linq;

/// <summary>
/// 戦闘に関するコンテキストインターフェース
/// </summary>
public interface ICombatContext
{
    // プレイヤー
    Player Players { get; }
    // 敵
    Enemy Enemies { get; }
    // イニシアチブ順にソートした戦闘参加者リスト
    IOrderedEnumerable<IBattler> SortedBattlers { get; }
    // 現在のイニシアチブ順
    int Initiative { get; set; }

    /// <summary>
    /// フェーズの切り替え
    /// </summary>
    /// <param name="nextPhase"></param>
    void ChangePhase(ICombatPhase nextPhase);

    /// <summary>
    /// 戦闘参加者をマージしてイニシアチブ順にソート
    /// </summary>
    void SetInitiatibeAndSort();
}
