using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private int gemCount;
    [SerializeField] private int gemGoal;

    public int GemCount { get => gemCount; set => gemCount = value; }
    public int GemGoal { get => gemGoal; set => gemGoal = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider triggerObject)
    {
        if (triggerObject.gameObject.CompareTag("Gem"))
        {
            gemCount++;
            Destroy(triggerObject.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
