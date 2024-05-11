using EventBus.Handlers.Effects;
using EventBus.Handlers.Turn;
using EventBus.Handlers.Turn.Abilities;
using EventBus.Handlers.Visual;
using Zenject;

namespace EventBus
{
    public sealed class EventHandlersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            ConfigureTurn(Container);
            ConfigureVisual(Container);
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void ConfigureTurn(DiContainer builder)
        {
            builder.BindInterfacesAndSelfTo<StartTurnEventHandler>().AsSingle().NonLazy();
            
            //Abilities
            builder.BindInterfacesAndSelfTo<CastAbilityHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<ShootProjectileAbilityHandler>().AsSingle().NonLazy();
            
            builder.BindInterfacesAndSelfTo<ConsumeActionHandler>().AsSingle().NonLazy();
            
            builder.BindInterfacesAndSelfTo<NextTurnHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<NextTimeHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<DelayedHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<DealDamageHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<DestroyCharacterEntityHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<FinishTurnEventHandler>().AsSingle().NonLazy();
            //builder.BindInterfacesAndSelfTo<DestroyHandler>().AsSingle().NonLazy();
            /*builder.BindInterfacesAndSelfTo<ApplyDirectionHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<AttackHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<CollideHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<MoveHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<ForceDirectionHandler>().AsSingle().NonLazy();
*/
            builder.BindInterfacesAndSelfTo<DealDamageEffectHandler>().AsSingle().NonLazy();
  //          builder.BindInterfacesAndSelfTo<PushEffectHandler>().AsSingle().NonLazy();*/
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void ConfigureVisual(DiContainer builder)
        {
            builder.BindInterfacesAndSelfTo<TurnSelectionHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<VisualParticleHandler>().AsSingle().NonLazy();
            
/*
            builder.BindInterfacesAndSelfTo<MoveVisualHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<DealDamageVisualHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<AttackVisualHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<CollideVisualHandler>().AsSingle().NonLazy();*/
        }
    }
}