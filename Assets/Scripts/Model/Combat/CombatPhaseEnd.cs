using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// 戦闘終了フェーズのインターフェース
/// </summary>
public interface ICombatPhaseEnd : ICombatPhase { }

/// <summary>
/// 戦闘終了フェーズ
/// </summary>
public class CombatPhaseEnd : ICombatPhaseEnd
{
    /// <summary>
    /// 実行
    /// </summary>
    public IEnumerator Execute(ICombatContext combatContext)
    {
        yield return null;
    }
}
