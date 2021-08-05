using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// 魔法コマンド選択フェーズのインターフェース
/// </summary>
public interface ICombatPhaseSelectSpellCommand : ICombatPhase { }

public class CombatPhaseSelectSpellCommand : ICombatPhaseSelectSpellCommand
{
    // 次のフェーズ（コマンド選択）
    [Inject] private ICombatPhaseSelectCommand _combatPhaseSelectCommand;
    // 次のフェーズ（コマンド実行）
    [Inject] private ICombatPhaseExecute _combatPhaseExecute;

    /// <summary>
    /// 実行
    /// </summary>
    public IEnumerator Execute(ICombatContext combatContext)
    {
        // サブコマンドウィンドウを表示する
        combatContext.ShowSubCommandWindow(true);
        yield return null;

        // 呪文コマンドを選択する
        yield return new WaitUntil(() => Input.GetButtonDown("Submit"));
        combatContext.ShowSubCommandWindow(false);
        combatContext.ChangePhase(_combatPhaseExecute);
    }
}
