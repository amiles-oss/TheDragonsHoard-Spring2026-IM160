/*****************************************************************************
// File Name : Timer.cs
// Author : Alan Miles
// Creation Date : March 25, 2026
//
// Brief Description : Timer counts down and kills the player when it runs out
******************************************************************************/
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text clock;
    [SerializeField] private int rounds = 4;
    private int sec;
    private int timeUp;
    [SerializeField] private int deathScene = 1;
    /// <summary>
    /// Set variables and start the coroutine for the timer
    /// </summary>
    void Start()
    {
        sec = 7 * rounds;
        timeUp = sec;
        StartCoroutine(DeathTimer());
    }

    /// <summary>
    /// Timer counts down and kills the player when it runs out
    /// </summary>
    /// <returns></returns>
    IEnumerator DeathTimer()
    {
        while (timeUp >= 0)
        {
            if (timeUp == 0)
            {
                SceneManager.LoadScene(deathScene);
            }
            clock.text = (timeUp.ToString());
            timeUp--;
            yield return new WaitForSeconds(1);
        }
    }
}
