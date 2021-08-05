using System.Linq;
using UnityEngine.UI;

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
    // 攻撃ボタン
    Button AttackCommandButton { get; }
    // 魔法ボタン
    Button MagicCommandButton { get; }
    // 技ボタン
    Button SkillCommandButton { get; }
    // アイテムボタン
    Button ItemCommandButton { get; }
    // 防御ボタン
    Button GuardCommandButton { get; }
    // 逃げるボタン
    Button EscapeCommandButton { get; }

    /// <summary>
    /// フェーズの切り替え
    /// </summary>
    /// <param name="nextPhase"></param>
    void ChangePhase(ICombatPhase nextPhase);

    /// <summary>
    /// 戦闘参加者をマージしてイニシアチブ順にソート
    /// </summary>
    void SetInitiatibeAndSort();

    /// <summary>
    /// メインコマンドウィンドウの表示/非表示を切り替え
    /// </summary>
    /// <param name="isActive"></param>
    void ShowMainCommandWindow(bool isActive);

    /// <summary>
    /// サブコマンドウィンドウの表示/非表示を切り替え
    /// </summary>
    /// <param name="isActive"></param>
    void ShowSubCommandWindow(bool isActive);
}
