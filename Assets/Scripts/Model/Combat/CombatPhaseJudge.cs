using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// 戦闘ジャッジフェーズのインターフェース
/// </summary>
public interface ICombatPhaseJudge : ICombatPhase { }

/// <summary>
/// 戦闘ジャッジフェーズ
/// </summary>
public class CombatPhaseJudge : ICombatPhaseJudge
{
    // 次のフェーズ（行動順決定）
    [Inject] private ICombatPhaseCheckInitiative _combatPhaseCheckInitiative;
    // 次のフェーズ（コマンド選択）
    [Inject] private ICombatPhaseSelectCommand _combatPhaseSelectCommand;
    // 次のフェーズ（結果）
    [Inject] private ICombatPhaseResult _combatPhaseResult;

    /// <summary>
    /// 実行
    /// </summary>
    public IEnumerator Execute(ICombatContext combatContext)
    {
        if (combatContext.Players.CurrentHp <= 0 || combatContext.Enemies.CurrentHp <= 0)
        {
            combatContext.ChangePhase(_combatPhaseResult);
        }
        else
        {
            if (combatContext.Initiative + 1 == combatContext.SortedBattlers.ToList().Count)
            {
                combatContext.ChangePhase(_combatPhaseCheckInitiative);
            }
            else
            {
                combatContext.Initiative += 1;
                combatContext.ChangePhase(_combatPhaseSelectCommand);
            }
        }
        yield return null;
    }
}
