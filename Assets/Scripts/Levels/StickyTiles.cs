/*****************************************************************************
// File Name : StickyTiles.cs
// Author : Alan Miles
// Creation Date : March 25, 2026
//
// Brief Description : Keeps the player on the tiles rather than clipping 
                       through them when they raise up
******************************************************************************/
using UnityEngine;

public class StickyTiles : MonoBehaviour
{
    /// <summary>
    /// Keeps the player on the tiles rather than clipping through them when they raise up
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    /// <summary>
    /// Keeps the player from raising when they aren't touching the tile that raised up.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
            collision.gameObject.transform.SetParent(null);
        }
    }
}
