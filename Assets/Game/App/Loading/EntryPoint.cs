using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.App.Loading
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private int mapIndex;

        public void Start()
        {
            SceneManager.LoadScene(mapIndex);
        }
    }
}