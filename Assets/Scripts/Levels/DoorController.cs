using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Collectibles c;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" && c.GemCount == c.GemGoal)
        {
            //Loads the next scene from the Build Profiles-> Scene List
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
