// using Battle.EventBus.Entities.Common.Components;
// using Entities;
// using UnityEngine;
//
// namespace Battle.EventBus.Entities.Common.UI
// {
//     public sealed class TextWidgetHitPointsAdapter : MonoBehaviour
//     {
//         [SerializeField] private TextWidget textWidget;
//
//         [SerializeField] private MonoEntity entity;
//
//         private DeathComponent _death;
//         private HitPointsComponent _hitPoints;
//
//         private void Awake()
//         {
//             _hitPoints = entity.Get<HitPointsComponent>();
//             _death = entity.Get<DeathComponent>();
//         }
//
//         private void Start()
//         {
//             SetHitPoints();
//         }
//
//         private void OnEnable()
//         {
//             _hitPoints.OnValueChanged += OnHitPointsChanged;
//             _death.OnIsDeadChanged += OnIsDeadChanged;
//         }
//
//         private void OnDisable()
//         {
//             _hitPoints.OnValueChanged -= OnHitPointsChanged;
//             _death.OnIsDeadChanged -= OnIsDeadChanged;
//         }
//
//         private void SetHitPoints()
//         {
//             textWidget.SetText($"{_hitPoints.Value} / {_hitPoints.MaxHitPoints}");
//         }
//
//         private void OnHitPointsChanged(int _)
//         {
//             SetHitPoints();
//         }
//
//         private void OnIsDeadChanged(bool value)
//         {
//             gameObject.SetActive(!value);
//         }
//     }
// }