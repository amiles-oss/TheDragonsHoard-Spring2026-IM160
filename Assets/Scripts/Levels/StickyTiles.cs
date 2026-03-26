using UnityEngine;

public class StickyTiles : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
            collision.gameObject.transform.SetParent(null);
        }
    }
}
