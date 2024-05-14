using System;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Gameplay.Game.Control
{
    [Serializable]
    public class CursorController
    {
        [SerializeField] private CursorMapping[] cursorMappings;
        [SerializeField] private float maxNavMeshProjectionDistance = 1f;
        [SerializeField] private float raycastRadius = 1f;

        public RaycastHit[] RaycastAllSorted()
        {
            var hits = Physics.SphereCastAll(GetMouseRay(), raycastRadius);
            var distances = new float[hits.Length];
            for (var i = 0; i < hits.Length; i++) distances[i] = hits[i].distance;
            Array.Sort(distances, hits);
            return hits;
        }

        private bool RaycastNavmesh(out Vector3 target)
        {
            target = new Vector3();
            RaycastHit hit;
            var hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (!hasHit) return false;
            NavMeshHit navMeshHit;
            var hasCastToNavMesh = NavMesh.SamplePosition(
                hit.point, out navMeshHit, maxNavMeshProjectionDistance, NavMesh.AllAreas);
            if (!hasCastToNavMesh) return false;

            target = navMeshHit.position;
/*
            NavMeshPath path = new NavMeshPath();
            bool hasPath = NavMesh.CalculatePath(transform.position, target, NavMesh.AllAreas, path);
            if (!hasPath) return false;
            if (path.status != NavMeshPathStatus.PathComplete) return false;
            if (GetPathLenght(path) > maxPathLength) return false;*/

            return true;
        }


        public void SetCursor(CursorType type)
        {
            var mapping = GetCursorMapping(type);
            Cursor.SetCursor(mapping.texture, mapping.hotspot, CursorMode.Auto);
        }

        private CursorMapping GetCursorMapping(CursorType type)
        {
            foreach (var item in cursorMappings)
                if (item.type == type)
                    return item;
            return cursorMappings[0];
        }

        private Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        [Serializable]
        private struct CursorMapping
        {
            public CursorType type;
            public Texture2D texture;
            public Vector2 hotspot;
        }
    }
}