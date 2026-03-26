/*****************************************************************************
// File Name : DeathScript.cs
// Author : Alan Miles
// Creation Date : March 25, 2026
//
// Brief Description : Kills the player when they touch the item this script 
                       is on
******************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    [SerializeField] private int deathScene = 1;

    /// <summary>
    /// When the player touches the object this script is attached to they die
    /// </summary>
    /// <param name="collidingObject"></param>
    private void OnTriggerEnter(Collider collidingObject)
    {
        if (collidingObject.gameObject.name == "Player")
        {
            //Loads the next scene from the Build Profiles-> Scene List
            SceneManager.LoadScene(deathScene);
        }
    }
}
