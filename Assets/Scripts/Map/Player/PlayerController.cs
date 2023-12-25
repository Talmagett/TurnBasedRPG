using System;
using System.Linq;
using Battle;
using Control;
using UnityEngine;
using UnityEngine.AI;

namespace Map.Player
{
    public class PlayerController:MonoBehaviour
    {
        [SerializeField] private float radius;
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(1))
            {
                var target = RaycastResults();
                if (target != null)
                {
                    var path = new NavMeshPath();
                    if (!NavMesh.SamplePosition(target.Point, out NavMeshHit hit, _agent.radius*2, NavMesh.AllAreas))
                        return;
                    _agent.CalculatePath(hit.position, path);
                    switch (path.status)
                    {
                        case NavMeshPathStatus.PathComplete:
                            _agent.isStopped = false;
                            _agent.SetDestination(target.Point);
                            break;
                        case NavMeshPathStatus.PathPartial:
                        case NavMeshPathStatus.PathInvalid:
                            print("no path");
                            _agent.isStopped = true;
                            break;
                    }
                }
            }
        }
        
        private TargetResult RaycastResults()
        {
            var ray = GetMouseRay();
            var hits = Physics.SphereCastAll(ray, radius,99);
            Debug.DrawRay(ray.origin,ray.direction,Color.red,0.1f);
            if (hits.Length == 0||hits.Length>1)
                return null;
            
            hits = hits.OrderBy(t => Vector3.Distance(Camera.main.transform.position, t.point)).ToArray();
            var firstHit = hits[0];
            return new TargetResult(firstHit.point, firstHit.transform);
        }
        

        private Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}