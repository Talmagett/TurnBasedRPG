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

        public Transform Root;
        public Transform Head;
        public Transform Chest;
        public Transform RHand;
        public Transform LHand;
        public Transform RFeet;
        public Transform LFeet;

        public void Setup()
        {
            Root = GameObject.Find("root")?.transform;
            Head = GameObject.Find("head")?.transform;
            Chest = GameObject.Find("spine_02")?.transform;
            RHand = GameObject.Find("hand_r")?.transform;
            LHand = GameObject.Find("hand_l")?.transform;
            RFeet = GameObject.Find("ball_r")?.transform;
            LFeet = GameObject.Find("ball_l")?.transform;
        }

        public Transform GetPoint(Key key)
        {
            return key switch
            {
                Key.Root => Root,
                Key.Head => Head,
                Key.Chest => Chest,
                Key.RHand => RHand,
                Key.LHand => LHand,
                Key.RFeet => RFeet,
                Key.LFeet => LFeet,
                _ => null
            };
        }
    }
}