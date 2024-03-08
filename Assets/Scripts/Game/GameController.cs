using Battle;
using Data;
using UnityEngine;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Transform battleParent;
        [SerializeField] private GameObject mainCamera;
        [SerializeField] private GameObject battleCamera;
        
        public bool IsBattle { get; private set; }

        private Environment _currentEnvironment;
        
        public void EnterBattle(EnemyRiftConfig enemyRiftConfig)
        {
            IsBattle = true;
            ChangeCamera();
            _currentEnvironment=Instantiate(enemyRiftConfig.Environment,battleParent);
            foreach (var enemy in enemyRiftConfig.Enemies)
            {
                Instantiate(enemy, battleParent.position+Random.insideUnitSphere*5,Quaternion.identity,battleParent);
            }
        }

        public void ExitBattle()
        {
            IsBattle = false;
            ChangeCamera();
            while (battleParent.childCount > 0)
            {
                DestroyImmediate(battleParent.GetChild(0).gameObject);
            }
        }

        private void ChangeCamera()
        {
            mainCamera.SetActive(!IsBattle);
            battleCamera.SetActive(IsBattle);
        }
    }
}