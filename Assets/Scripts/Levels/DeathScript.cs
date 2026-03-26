using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    [SerializeField] private int deathScene = 1;
    private void OnTriggerEnter(Collider collidingObject)
    {
        if (collidingObject.gameObject.name == "Player")
        {
            //Loads the next scene from the Build Profiles-> Scene List
            SceneManager.LoadScene(deathScene);
        }
    }
}
