using UnityEngine;

namespace Configs.Character
{
    [System.Serializable]
    public class BodyParts
    {
        [field: SerializeField] public Transform Head { get; private set; }
        [field: SerializeField] public Transform Chest { get; private set; }
        [field: SerializeField] public Transform RightHand { get; private set; }
        [field: SerializeField] public Transform LeftHand { get; private set; }
        [field: SerializeField] public Transform RightFeet { get; private set; }
        [field: SerializeField] public Transform LeftFeet { get; private set; }
    }
}