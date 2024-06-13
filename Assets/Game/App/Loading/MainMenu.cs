using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.App.Loading
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private int mapIndex;

        public void StartGame()
        {
            SceneManager.LoadScene(mapIndex);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}