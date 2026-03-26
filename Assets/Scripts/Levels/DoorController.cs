/*****************************************************************************
// File Name : DoorController.cs
// Author : Alan Miles
// Creation Date : March 25, 2026
//
// Brief Description : Makes the door load the next scene when the player has 
                       all the gems and touches the door
******************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Collectibles c;

    /// <summary>
    /// Makes the door load the next scene when the player has all the gems and touches the door
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" && c.GemCount == c.GemGoal)
        {
            //Loads the next scene from the Build Profiles-> Scene List
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
