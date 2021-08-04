using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// コマンド選択フェーズのインターフェース
/// </summary>
public interface ICombatPhaseSelectCommand : ICombatPhase { }

/// <summary>
/// コマンド選択フェーズ
/// </summary>
public class CombatPhaseSelectCommand : ICombatPhaseSelectCommand
{
    // 次のフェーズ（コマンド実行）
    [Inject] private ICombatPhaseExecute _combatPhaseExecute;

    /// <summary>
    /// 実行
    /// </summary>
    public IEnumerator Execute(ICombatContext combatContext)
    {
        // コマンドを選択する
        if (combatContext.SortedBattlers.ToList()[combatContext.Initiative] == combatContext.Players)
        {
            Debug.Log("コマンド？");
            yield return new WaitUntil(() => Input.GetButtonDown("Submit"));
        }
        combatContext.ChangePhase(_combatPhaseExecute);
    }
}
