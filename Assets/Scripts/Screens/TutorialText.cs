/*****************************************************************************
// File Name : TutorialText.cs
// Author : Alan Miles
// Creation Date : April 30, 2026
//
// Brief Description : Plays through the text for the tutorial
******************************************************************************/
using System.Collections;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    [SerializeField] Canvas green;
    [SerializeField] Canvas red;
    [SerializeField] Canvas time;
    [SerializeField] Canvas gem;
    [SerializeField] private int greenTime = 1;
    [SerializeField] private int redTime = 1;
    [SerializeField] private int timeTime = 1;
    [SerializeField] private int gemTime = 1;
    /// <summary>
    /// Enable or disable canvases depending on how they need to start, start coroutine
    /// </summary>
    void Start()
    {
        green.enabled = true;
        red.enabled = false;
        time.enabled = false;
        gem.enabled = false;
        StartCoroutine(TextTimer());
    }

    /// <summary>
    /// Plays through the text by enabling/disabling canvases
    /// </summary>
    /// <returns></returns>
    IEnumerator TextTimer()
    {
        yield return new WaitForSeconds(greenTime);
        green.enabled = false;
        red.enabled = true;
        Debug.Log("RedTest");
        yield return new WaitForSeconds(redTime);
        red.enabled = false;
        time.enabled = true;
        Debug.Log("TimeTest");
        yield return new WaitForSeconds(timeTime);
        time.enabled = false;
        gem.enabled = true;
        Debug.Log("GemTest");
        yield return new WaitForSeconds(gemTime);
        gem.enabled = false;
        Debug.Log("Finish");

    }
}
