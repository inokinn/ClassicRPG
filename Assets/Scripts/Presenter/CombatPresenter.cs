using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CombatPresenter : MonoBehaviour, ICombatContext
{
    // 戦闘開始フェーズ
    [Inject] private ICombatPhaseStart _combatPhaseStart;

    // 戦闘コマンドに対応したボタン
    [SerializeField] private Button AttackCommandButton;    // 攻撃ボタン
    [SerializeField] private Button MagicCommandButton;     // 魔法ボタン
    [SerializeField] private Button SkillCommandButton;     // スキルボタン
    [SerializeField] private Button ItemCommandButton;      // アイテムボタン
    [SerializeField] private Button GuardCommandButton;   // 防御ボタン
    [SerializeField] private Button EscapeCommandButton;    // 逃げるボタン

    // 現在のフェーズ
    private ICombatPhase _currentPhase;

    // プレイヤー
    private Player _player;
    public Player Players
    {
        get => _player;
    }

    // 敵
    private Enemy _enemy;
    public Enemy Enemies
    {
        get => _enemy;
    }

    // イニシアチブ順にソートされた戦闘参加者
    private IOrderedEnumerable<IBattler> _sortedBattlers;
    public IOrderedEnumerable<IBattler> SortedBattlers
    {
        get => _sortedBattlers;
    }

    // 現在のイニシアチブ順
    private int _initiative;
    public int Initiative
    {
        get => _initiative;
        set
        {
            _initiative = value;
        }
    }

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

        //_phase = CombatPhase.Start;
        _initiative = 0;
        _currentPhase = _combatPhaseStart;
        StartCoroutine(CombatCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// フェーズの変更
    /// </summary>
    /// <param name="nextPhase"></param>
    public void ChangePhase(ICombatPhase nextPhase)
    {
        _currentPhase = nextPhase;
    }

    public void SetInitiatibeAndSort()
    {
        // TODO: イニシアチブ順ソート
        List<IBattler> battlers = new List<IBattler>(new IBattler[] {
            _enemy,
            _player,
        });
        _sortedBattlers = battlers.OrderByDescending(battler => battler.Spd);
    }

    /// <summary>
    /// 戦闘コルーチン
    /// </summary>
    /// <returns></returns>
    IEnumerator CombatCoroutine()
    {
        while (!(_currentPhase is ICombatPhaseEnd))
        {
            yield return _currentPhase.Execute(this);
        }
    }
}
