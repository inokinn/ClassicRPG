using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;
using UniRx.Triggers;
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
    public enum MainCommand
    {
        Attack,
        Magic,
        Skill,
        Item,
        Guard,
        Escape,
    }

    // 次のフェーズ（魔法選択）
    [Inject] private ICombatPhaseSelectSpellCommand _combatPhaseSelectSpellCommand;
    // 次のフェーズ（コマンド実行）
    [Inject] private ICombatPhaseExecute _combatPhaseExecute;

    /// <summary>
    /// 実行
    /// </summary>
    public IEnumerator Execute(ICombatContext combatContext)
    {
        // メインコマンドウィンドウを表示する
        combatContext.ShowMainCommandWindow(true);
        EventSystem.current.SetSelectedGameObject(combatContext.AttackCommandButton.gameObject);

        // コマンドを選択する
        if (combatContext.SortedBattlers.ToList()[combatContext.Initiative] == combatContext.Players)
        {
            Debug.Log("コマンド？");

            var mainCommandYieldInstruction = Observable.Merge(
                combatContext.AttackCommandButton.OnClickAsObservable().Select(_ => combatContext.AttackCommandButton),
                combatContext.MagicCommandButton.OnClickAsObservable().Select(_ => combatContext.MagicCommandButton),
                combatContext.SkillCommandButton.OnClickAsObservable().Select(_ => combatContext.SkillCommandButton),
                combatContext.ItemCommandButton.OnClickAsObservable().Select(_ => combatContext.ItemCommandButton),
                combatContext.GuardCommandButton.OnClickAsObservable().Select(_ => combatContext.GuardCommandButton),
                combatContext.EscapeCommandButton.OnClickAsObservable().Select(_ => combatContext.EscapeCommandButton)
            )
            .First()
            .ToYieldInstruction();

            yield return mainCommandYieldInstruction;

            // 選択したコマンドで次のフェーズを決める
            if (mainCommandYieldInstruction.Result == combatContext.AttackCommandButton)
            {
                combatContext.ChangePhase(_combatPhaseExecute);
            }
            else if (mainCommandYieldInstruction.Result == combatContext.MagicCommandButton)
            {
                combatContext.ChangePhase(_combatPhaseSelectSpellCommand);
            }


        }
        else
        {
            combatContext.ChangePhase(_combatPhaseExecute);
        }
    }
}
