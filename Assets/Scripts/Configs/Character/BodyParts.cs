using System;
using UnityEngine;

namespace Configs.Character
{
    [Serializable]
    public class BodyParts
    {
        public enum Key
        {
            Root,
            Head,
            Chest,
            RHand,
            LHand,
            RFeet,
            LFeet
        }

        [SerializeField] private Transform root;
        [SerializeField] private Transform head;
        [SerializeField] private Transform chest;
        [SerializeField] private Transform rHand;
        [SerializeField] private Transform lHand;
        [SerializeField] private Transform rFeet;
        [SerializeField] private Transform lFeet;

        public void Setup()
        {
            root = GameObject.Find("root")?.transform;
            head = GameObject.Find("head")?.transform;
            chest = GameObject.Find("spine_02")?.transform;
            rHand = GameObject.Find("hand_r")?.transform;
            lHand = GameObject.Find("hand_l")?.transform;
            rFeet = GameObject.Find("ball_r")?.transform;
            lFeet = GameObject.Find("ball_l")?.transform;
        }

        public Transform GetPoint(Key key)
        {
            return key switch
            {
                Key.Root => root,
                Key.Head => head,
                Key.Chest => chest,
                Key.RHand => rHand,
                Key.LHand => lHand,
                Key.RFeet => rFeet,
                Key.LFeet => lFeet,
                _ => null
            };
        }
    }
}