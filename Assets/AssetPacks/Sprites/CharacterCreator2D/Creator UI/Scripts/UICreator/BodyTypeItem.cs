﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CharacterCreator2D.UI
{
    public class BodyTypeItem : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        ///     BodyType value loaded by this BodyTypeItem.
        /// </summary>
        public BodyType bodyType;

        /// <summary>
        ///     Part loaded by this PartItem.
        /// </summary>
        [Tooltip("Skin loaded by this BodyTypeItem")] [ReadOnly]
        public Part bodySkin;

        private BodyTypeGroup _group;

        private void Awake()
        {
            _group = transform.GetComponentInParent<BodyTypeGroup>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _group.SelectItem(this);
        }

        /// <summary>
        ///     Initialize BodyTypeItem with a given BodyType and body skin value.
        /// </summary>
        /// <param name="bodyType"></param>
        /// <param name="bodySkin"></param>
        public void Initialize(BodyType bodyType, Part bodySkin)
        {
            this.bodyType = bodyType;
            this.bodySkin = bodySkin;
            transform.name = "" + bodyType;
            transform.name = bodySkin == null
                ? string.Format("NULL {0}", bodyType == BodyType.Female ? "Female" : "Male")
                : string.Format("{0}_{1}", bodySkin.packageName, bodySkin.name);
            transform.Find("Text").GetComponent<Text>().text = bodySkin == null
                ? string.Format("NULL {0}", bodyType == BodyType.Female ? "Female" : "Male")
                : bodySkin.name;
        }
    }
}