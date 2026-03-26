/*****************************************************************************
// File Name : RestartButton.cs
// Author : Alan Miles
// Creation Date : March 25, 2026
//
// Brief Description : Restarts the game on click
******************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private int sceneNum = 2;

    /// <summary>
    /// Restarts the game
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(sceneNum);
    }
}
