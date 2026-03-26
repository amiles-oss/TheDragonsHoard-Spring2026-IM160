using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int offset;

    private void LateUpdate()
    {
        transform.position = 
            new Vector3(player.transform.position.x + offset, transform.position.y, transform.position.z);
    }
}
