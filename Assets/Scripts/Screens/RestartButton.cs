using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private int sceneNum = 2;
    public void RestartGame()
    {
        SceneManager.LoadScene(sceneNum);
    }
}
