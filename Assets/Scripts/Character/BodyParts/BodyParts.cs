using System;
using Battle.Actors;
using Configs.Enums;
using UnityEngine;

namespace Configs.Character
{
    [RequireComponent(typeof(CharacterEntity))]
    public class BodyParts : MonoBehaviour
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

        private void Awake()
        {
            GetComponent<CharacterEntity>().Add(this);
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