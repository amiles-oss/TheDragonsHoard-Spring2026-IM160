/*****************************************************************************
// File Name : Collectibles.cs
// Author : Alan Miles
// Creation Date : March 25, 2026
//
// Brief Description : Allows the player to collect gemstones
******************************************************************************/
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private int gemCount;
    [SerializeField] private int gemGoal;

    public int GemCount { get => gemCount; set => gemCount = value; }
    public int GemGoal { get => gemGoal; set => gemGoal = value; }

    /// <summary>
    /// Makes gems collectible
    /// </summary>
    /// <param name="triggerObject"></param>
    private void OnTriggerEnter(Collider triggerObject)
    {
        if (triggerObject.gameObject.CompareTag("Gem"))
        {
            gemCount++;
            Destroy(triggerObject.gameObject);
        }
    }
}
