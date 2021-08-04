using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 戦闘フェーズの基底インターフェース
/// </summary>
public interface ICombatPhase
{
    /// <summary>
    /// 実行
    /// </summary>
    /// <param name="combatContext"></param>
    IEnumerator Execute(ICombatContext combatContext);
}
