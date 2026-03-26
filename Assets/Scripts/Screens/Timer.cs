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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sec = 7 * rounds;
        timeUp = sec;
        StartCoroutine(DeathTimer());
    }

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
