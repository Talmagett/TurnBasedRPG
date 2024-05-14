using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private int mapIndex;

    public void Start()
    {
        SceneManager.LoadScene(mapIndex);
    }
}