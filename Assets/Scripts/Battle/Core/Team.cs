using UnityEngine;

namespace Battle.Core
{
    public class Team:MonoBehaviour
    {
        [field:SerializeField] public bool IsPlayer { get; private set; }
    }
}