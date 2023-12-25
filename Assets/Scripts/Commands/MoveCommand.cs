using UnityEngine;
using UnityEngine.AI;

namespace Commands
{
    internal class MoveCommand : Command
    {
        private readonly Vector3 _destination;
        private readonly NavMeshAgent _agent;
        public MoveCommand(Vector3 destination, NavMeshAgent agent)
        {
            _destination = destination;
            _agent = agent;
        }
        public override void Execute()
        {
            _agent.isStopped = false || !_agent.SetDestination(_destination);
        }
        public override bool IsFinished => _agent.remainingDistance <= 0.1f;
    }
}