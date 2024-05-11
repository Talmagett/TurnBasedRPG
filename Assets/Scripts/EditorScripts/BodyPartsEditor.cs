using Character.BodyParts;
using UnityEditor;
using UnityEngine;

namespace EditorScripts
{
    [CustomEditor(typeof(BodyParts))]
    public class BodyPartsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update(); // Update serialized object

// Button to trigger setup
            if (GUILayout.Button("Setup")) SetupBodyParts(); // Call function to set BodyParts

            serializedObject.ApplyModifiedProperties(); // Apply changes to serialized object
        }

        private void SetupBodyParts()
        {
            serializedObject.Update(); // Update serialized object

            var data = (BodyParts)target; // Get the target ActorData object

            data.Root = FindDeepChild(data.transform, "root");
            data.Head = FindDeepChild(data.transform, "head");
            data.Chest = FindDeepChild(data.transform, "spine_03");
            data.RHand = FindDeepChild(data.transform, "hand_r");
            data.LHand = FindDeepChild(data.transform, "hand_l");
            data.RFeet = FindDeepChild(data.transform, "foot_r");
            data.LFeet = FindDeepChild(data.transform, "foot_l");

            serializedObject.ApplyModifiedProperties(); // Apply changes to serialized object
            EditorUtility.SetDirty(target);
        }

        private Transform FindDeepChild(Transform parent, string name)
        {
            foreach (Transform child in parent)
            {
                if (child.name == name) return child;

                var found = FindDeepChild(child, name);
                if (found != null) return found;
            }

            return null;
        }
    }
}