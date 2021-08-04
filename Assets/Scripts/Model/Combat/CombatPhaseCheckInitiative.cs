using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// 行動順決定フェーズのインスタンス
/// </summary>
public interface ICombatPhaseCheckInitiative : ICombatPhase { }

/// <summary>
/// 行動順決定フェーズ
/// </summary>
public class CombatPhaseCheckInitiative : ICombatPhaseCheckInitiative
{
    // 次のフェーズ（コマンド選択）
    [Inject] private ICombatPhaseSelectCommand _combatPhaseSelectCommand;

    /// <summary>
    /// 実行
    /// </summary>
    public IEnumerator Execute(ICombatContext combatContext)
    {
        // 行動順を決定する
        Debug.Log("行動順にソートします");
        combatContext.Initiative = 0;
        combatContext.SetInitiatibeAndSort();
        combatContext.ChangePhase(_combatPhaseSelectCommand);
        yield return null;
    }
}
