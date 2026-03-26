/*****************************************************************************
// File Name : Timer.cs
// Author : Alan Miles
// Creation Date : March 25, 2026
//
// Brief Description : Makes the camera follow the forward/backward 
                       movement of the player
******************************************************************************/
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int offset;

    /// <summary>
    /// Makes the camera follow the forward/backward movement of the player
    /// </summary>
    private void LateUpdate()
    {
        transform.position = 
            new Vector3(player.transform.position.x + offset, transform.position.y, transform.position.z);
    }
}
