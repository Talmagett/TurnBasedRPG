using System;
using System.Linq;
using Control;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Battle.Player
{
    public class PlayerController : MonoBehaviour, IAbilityCaster
    {
        [Serializable]
        private struct CursorMapping
        {
            public CursorType type;
            public Texture2D texture;
            public Vector2 hotspot;
        }

        [SerializeField] private CursorMapping[] cursorMappings;

        private bool _isChoosing;
        private UniTaskCompletionSource<TargetResult> _onClickResult;
        
        private void Start()
        {
            SetCursor(CursorType.Normal);
        }

        public async UniTask<TargetResult> GetTarget()
        {
            _onClickResult = new UniTaskCompletionSource<TargetResult>();
            _isChoosing = true;
            return await _onClickResult.Task;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (_isChoosing)
                    _onClickResult.TrySetResult(null);
                _isChoosing = false;
                SetCursor(CursorType.Normal);
                return;
            }

            if (!_isChoosing) return;
            
            if (IsHoverUI())
            {
                SetCursor(CursorType.UI);
                if (Input.GetMouseButtonDown(0))
                {
                    _onClickResult.TrySetResult(null);
                    _isChoosing = false;
                }

                return;
            }
            var target = RaycastResults();
            if (target != null)
            {
                SetCursor(CursorType.Target);
                if (Input.GetMouseButtonDown(0))
                {
                    _onClickResult.TrySetResult(target);
                    _isChoosing = false;
                    SetCursor(CursorType.Normal);
                }
                return;
            }
            SetCursor(CursorType.None);
        }

        private bool IsHoverUI()
        {
            return EventSystem.current.IsPointerOverGameObject();
        }

        public void Lock()
        {
            
        }

        public void Unlock()
        {

        }

        private TargetResult RaycastResults()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hits = Physics.RaycastAll(ray, 99);
            if (hits.Length == 0)
                return null;
            
            hits = hits.OrderBy(t => Vector3.Distance(Camera.main.transform.position, t.point)).ToArray();
            var firstHit = hits[0];
            return new TargetResult(firstHit.point, firstHit.transform);
        }


        private void SetCursor(CursorType type)
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

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}