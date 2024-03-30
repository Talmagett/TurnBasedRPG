using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Battle.EventBus.Game.Pipeline.Turn
{
    public sealed class TurnPipelineRunner : MonoBehaviour
    {
        [SerializeField] private bool runOnStart = true;
        [SerializeField] private bool runOnFinish = true;

        private TurnPipeline _turnPipeline;

        private void Start()
        {
            if (runOnStart)
                Run();
        }

        private void OnEnable()
        {
            _turnPipeline.OnFinished += OnTurnPipelineFinished;
        }

        private void OnDisable()
        {
            _turnPipeline.OnFinished -= OnTurnPipelineFinished;
        }

        [Inject]
        private void Construct(TurnPipeline turnPipeline)
        {
            _turnPipeline = turnPipeline;
        }

        [Button]
        public void Run()
        {
            _turnPipeline.Run();
        }

        private void OnTurnPipelineFinished()
        {
            if (runOnFinish)
                Run();
        }
    }
}