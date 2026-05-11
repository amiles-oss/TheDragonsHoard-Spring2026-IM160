/*****************************************************************************
// File Name : GemCounter.cs
// Author : Alan Miles
// Creation Date : April 30, 2026
//
// Brief Description : Counts and displays the number of gems collected
******************************************************************************/
using TMPro;
using UnityEngine;

public class GemCounter : MonoBehaviour
{
    [SerializeField] private Collectibles c;
    [SerializeField] private TMP_Text gems;

    /// <summary>
    /// Counts and displays the number of gems collected
    /// </summary>
    void Update()
    {
        gems.text = ("Gems: " + (c.GemCount.ToString()) + " / " + (c.GemGoal.ToString()));
    }
}
