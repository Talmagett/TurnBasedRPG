using EventBus.Game.Handlers.Turn;
using EventBus.Game.Handlers.Visual;
using EventBus.Game.Pipeline.Turn;
using EventBus.Game.Pipeline.Visual;
using Zenject;

namespace EventBus.Utils
{
    public sealed class BattleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            ConfigureTurn(Container);
            ConfigureVisual(Container);
        }
        
        private void ConfigureTurn(DiContainer builder)
        {
            builder.Bind<Game.EventBus>().AsSingle().NonLazy();
            
            builder.BindInterfacesAndSelfTo<DealDamageHandler>().AsSingle().NonLazy();
            /*builder.BindInterfacesAndSelfTo<ApplyDirectionHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<AttackHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<CollideHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<DestroyHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<MoveHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<ForceDirectionHandler>().AsSingle().NonLazy();
            
            builder.BindInterfacesAndSelfTo<DealDamageEffectHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<PushEffectHandler>().AsSingle().NonLazy();*/

            builder.Bind<TurnPipeline>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<TurnPipelineInstaller>().AsSingle().NonLazy();
        }
        
        private void ConfigureVisual(DiContainer  builder)
        {
            builder.Bind<VisualPipeline>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<VisualParticleHandler>().AsSingle().NonLazy();
/*
            builder.BindInterfacesAndSelfTo<MoveVisualHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<DealDamageVisualHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<DestroyVisualHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<AttackVisualHandler>().AsSingle().NonLazy();
            builder.BindInterfacesAndSelfTo<CollideVisualHandler>().AsSingle().NonLazy();*/
        }
    }
}