using UnityEngine;
using Zenject;

/// <summary>
/// 戦闘に関するオブジェクトを注入するインストーラ
/// </summary>
public class CombatInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ICombatPhaseStart>().To<CombatPhaseStart>().AsSingle();
        Container.Bind<ICombatPhaseCheckInitiative>().To<CombatPhaseCheckInitiative>().AsSingle();
        Container.Bind<ICombatPhaseSelectCommand>().To<CombatPhaseSelectCommand>().AsSingle();
        Container.Bind<ICombatPhaseExecute>().To<CombatPhaseExecute>().AsSingle();
        Container.Bind<ICombatPhaseJudge>().To<CombatPhaseJudge>().AsSingle();
        Container.Bind<ICombatPhaseResult>().To<CombatPhaseResult>().AsSingle();
        Container.Bind<ICombatPhaseEnd>().To<CombatPhaseEnd>().AsSingle();
    }
}