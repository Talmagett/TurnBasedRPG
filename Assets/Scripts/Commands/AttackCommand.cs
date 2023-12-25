using Cysharp.Threading.Tasks;
using UnityEngine.AI;

namespace Commands
{
    internal class AttackCommand : Command
    {
       /* private readonly Health _target;
        private readonly float _distance;
        private readonly NavMeshAgent _agent;
        private readonly float _damage;
    */
        private bool _hasFinishedAttack;
       /* public AttackCommand(Health target, NavMeshAgent agent, float distance,float damage)
        {
            _target = target;
            _agent = agent;
            _distance = distance;
            _damage=damage;
        }*/
        public override void Execute()
        {
            //_ = Process();
        }
        /*private async UniTask Process()
        {
            var dist = (_target.transform.position - _agent.transform.position).normalized * _distance;
            _agent.SetDestination(_target.transform.position - dist);
            await UniTask.WaitWhile(() => _agent.remainingDistance > _distance);
            _target.TakeDamage(_damage);
            await UniTask.Delay(500);
            _hasFinishedAttack = true;
        }*/
        public override bool IsFinished => _hasFinishedAttack;
    }
}