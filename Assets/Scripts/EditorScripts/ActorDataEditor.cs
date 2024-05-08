using Battle.Actors;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace EditorScripts
{
    [CustomEditor(typeof(ActorData))]
    public class ActorDataEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update(); // Update serialized object

// Button to trigger setup
            if (GUILayout.Button("Setup"))
            {
                SetupBodyParts(); // Call function to set BodyParts
            }
            
            serializedObject.ApplyModifiedProperties(); // Apply changes to serialized object
        }

        private void SetupBodyParts()
        {
            serializedObject.Update(); // Update serialized object

            ActorData data = (ActorData)target; // Get the target ActorData object
            
            data.BodyParts.Root =  FindDeepChild(data.transform, "root");
            data.BodyParts.Head = FindDeepChild(data.transform, "head");
            data.BodyParts.Chest = FindDeepChild(data.transform, "spine_03");
            data.BodyParts.RHand = FindDeepChild(data.transform, "hand_r");
            data.BodyParts.LHand = FindDeepChild(data.transform, "hand_l");
            data.BodyParts.RFeet = FindDeepChild(data.transform, "foot_r");
            data.BodyParts.LFeet = FindDeepChild(data.transform, "foot_l");
            
            serializedObject.ApplyModifiedProperties(); // Apply changes to serialized object
            EditorUtility.SetDirty(target);
        }
        Transform FindDeepChild(Transform parent, string name)
        {
            foreach (Transform child in parent)
            {
                if (child.name == name)
                {
                    return child;
                }

                Transform found = FindDeepChild(child, name);
                if (found != null)
                {
                    return found;
                }
            }
            return null;
        }
    }
}
