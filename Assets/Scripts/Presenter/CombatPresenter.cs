using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPresenter : MonoBehaviour
{
    private enum CombatPhase
    {
        Start,              // 戦闘開始
        CheckInitiative,    // 行動順決定
        SelectCommand,      // コマンド選択
        Execute,            // 実行
        Judge,              // ジャッジ
        Result,             // 戦闘結果を表示
        End,                // 戦闘終了
    }

    private CombatPhase _phase;

    private Player _player;
    private Enemy _enemy;

    private IOrderedEnumerable<IBattler> _sortedBattlers;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        _player = new Player();
        _player.Temp();
        // 敵の準備
        _enemy = new Enemy();
        _enemy.Temp();

        _phase = CombatPhase.Start;
        StartCoroutine(CombatCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CombatCoroutine()
    {
        int initiative = 0;
        while (_phase != CombatPhase.End)
        {
            yield return null;
            //Debug.Log(_phase);
            switch (_phase)
            {
                case CombatPhase.Start:
                    // 敵が現れたことを知らせる
                    Debug.Log($"{_enemy.Name}があらわれた！");
                    _phase = CombatPhase.CheckInitiative;
                    break;
                case CombatPhase.CheckInitiative:
                    // 行動順決定
                    List<IBattler> battlers = new List<IBattler>(new IBattler[] {
                        _enemy,
                        _player,
                    });
                    _sortedBattlers = battlers.OrderByDescending(battler => battler.Spd);
                    _phase = CombatPhase.SelectCommand;
                    break;
                case CombatPhase.SelectCommand:
                    // TODO: コマンド選択させる or 敵の行動を決定
                    if (_sortedBattlers.ToList()[initiative] == _player)
                    {
                        Debug.Log("コマンド？");
                        yield return new WaitUntil(() => Input.GetButtonDown("Submit"));
                    }
                    _phase = CombatPhase.Execute;
                    break;
                case CombatPhase.Execute:
                    // TODO: 行動の実行
                    IBattler battler = _sortedBattlers.ToList()[initiative];
                    if (battler.Name == "ヨシヒコ")
                    {
                        battler.Commands[0].Execute(battler, _enemy);
                    }
                    else if (battler.Name == "スライム")
                    {
                        battler.Commands[0].Execute(battler, _player);
                    }
                    _phase = CombatPhase.Judge;

                    break;
                case CombatPhase.Judge:
                    if (_player.CurrentHp <= 0 || _enemy.CurrentHp <= 0)
                    {
                        _phase = CombatPhase.Result;
                    }
                    else
                    {
                        if (initiative + 1 == _sortedBattlers.ToList().Count)
                        {
                            initiative = 0;
                            _phase = CombatPhase.CheckInitiative;
                        }
                        else
                        {
                            initiative += 1;
                            _phase = CombatPhase.SelectCommand;
                        }
                    }
                    break;
                case CombatPhase.Result:
                    // TODO: 敵が全滅していたら勝利、味方が全滅していたら敗北
                    Debug.Log($"戦闘に勝利した！");
                    _phase = CombatPhase.End;
                    break;
                default:
                    break;
            }
        }
    }
}
