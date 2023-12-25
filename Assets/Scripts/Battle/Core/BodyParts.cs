using System;
using UnityEngine;

namespace Battle.Core
{
    [Serializable]
    public class BodyParts
    {
        [field: SerializeField] public Transform Head { get; private set; }
        [field: SerializeField] public Transform RightHand { get; private set; }
        [field: SerializeField] public Transform RightWeapon { get; private set; }
        [field: SerializeField] public Transform LeftHand { get; private set; }
        [field: SerializeField] public Transform LeftWeapon { get; private set; }
        [field: SerializeField] public Transform Chest { get; private set; }
        [field: SerializeField] public Transform Neck { get; private set; }

        [field: SerializeField] public Transform RightFeet { get; private set; }
        [field: SerializeField] public Transform LeftFeet { get; private set; }

        [field: SerializeField] public Transform ShootPoint { get; private set; }

        [field: SerializeField] public Transform Alternate1 { get; private set; }
        [field: SerializeField] public Transform Alternate2 { get; private set; }
        [field: SerializeField] public Transform Alternate3 { get; private set; }
        [field: SerializeField] public Transform Alternate4 { get; private set; }
        [field: SerializeField] public Transform Alternate5 { get; private set; }
    }
}