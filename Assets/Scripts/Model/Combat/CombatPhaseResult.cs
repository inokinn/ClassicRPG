using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// リザルトフェーズのインターフェース
/// </summary>
public interface ICombatPhaseResult : ICombatPhase { }

/// <summary>
/// リザルトフェーズ
/// </summary>
public class CombatPhaseResult : ICombatPhaseResult
{
    // 次のフェーズ（終了）
    [Inject] private ICombatPhaseEnd _combatPhaseEnd;

    /// <summary>
    /// 実行
    /// </summary>
    public IEnumerator Execute(ICombatContext combatContext)
    {
        // TODO: 敵が全滅していたら勝利、味方が全滅していたら敗北
        Debug.Log($"戦闘に勝利した！");
        combatContext.ChangePhase(_combatPhaseEnd);
        yield return null;
    }
}
