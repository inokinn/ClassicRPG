using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// コマンド実行フェーズのインターフェース
/// </summary>
public interface ICombatPhaseExecute : ICombatPhase { }

/// <summary>
/// コマンド実行フェーズ
/// </summary>
public class CombatPhaseExecute : ICombatPhaseExecute
{
    // 次のフェーズ（ジャッジ）
    [Inject] private ICombatPhaseJudge _combatPhaseJudge;

    /// <summary>
    /// 実行
    /// </summary>
    public IEnumerator Execute(ICombatContext combatContext)
    {
        IBattler battler = combatContext.SortedBattlers.ToList()[combatContext.Initiative];
        if (battler.Name == "ヨシヒコ")
        {
            battler.Commands[0].Execute(battler, combatContext.Enemies);
        }
        else if (battler.Name == "スライム")
        {
            battler.Commands[0].Execute(battler, combatContext.Players);
        }
        combatContext.ChangePhase(_combatPhaseJudge);
        yield return null;
    }
}
