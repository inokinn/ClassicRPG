using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// 開始フェーズのインターフェース
/// </summary>
public interface ICombatPhaseStart : ICombatPhase { }

/// <summary>
/// 開始フェーズ
/// </summary>
public class CombatPhaseStart : ICombatPhaseStart
{
    // 次のフェーズ（行動順決定）
    [Inject] private ICombatPhaseCheckInitiative _combatPhaseCheckInitiative;

    /// <summary>
    /// 実行
    /// </summary>
    public IEnumerator Execute(ICombatContext combatContext)
    {
        // 敵が現れたことを知らせる
        Debug.Log($"{combatContext.Enemies.Name}があらわれた！");
        combatContext.ChangePhase(_combatPhaseCheckInitiative);
        yield return null;
    }
}
