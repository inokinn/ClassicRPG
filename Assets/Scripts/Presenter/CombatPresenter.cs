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

    // メインコマンドウィンドウ
    [SerializeField] private GameObject _mainCommandWindow;
    // サブコマンドウィンドウ
    [SerializeField] private GameObject _subCommandWindow;

    // 戦闘コマンドに対応したボタン
    [SerializeField] private Button _attackCommandButton;    // 攻撃ボタン
    public Button AttackCommandButton
    {
        get => _attackCommandButton;
    }
    [SerializeField] private Button _magicCommandButton;     // 魔法ボタン
    public Button MagicCommandButton
    {
        get => _magicCommandButton;
    }
    [SerializeField] private Button _skillCommandButton;     // スキルボタン
    public Button SkillCommandButton
    {
        get => _skillCommandButton;
    }
    [SerializeField] private Button _itemCommandButton;      // アイテムボタン
    public Button ItemCommandButton
    {
        get => _itemCommandButton;
    }
    [SerializeField] private Button _guardCommandButton;     // 防御ボタン
    public Button GuardCommandButton
    {
        get => _guardCommandButton;
    }
    [SerializeField] private Button _escapeCommandButton;    // 逃げるボタン
    public Button EscapeCommandButton
    {
        get => _escapeCommandButton;
    }

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

        // コマンドウィンドウを一旦非アクティブに
        ShowMainCommandWindow(false);
        ShowSubCommandWindow(false);

        // イニシアチブとフェーズをリセット
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

    /// <summary>
    /// イニシアチブをチェックし戦闘参加者をソート
    /// </summary>
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
    /// メインコマンドウィンドウの表示/非表示を切り替え
    /// </summary>
    /// <param name="isActive"></param>
    public void ShowMainCommandWindow(bool isActive)
    {
        _mainCommandWindow.SetActive(isActive);
    }

    /// <summary>
    /// サブコマンドウィンドウの表示/非表示を切り替え
    /// </summary>
    /// <param name="isActive"></param>
    public void ShowSubCommandWindow(bool isActive)
    {
        _subCommandWindow.SetActive(isActive);
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
