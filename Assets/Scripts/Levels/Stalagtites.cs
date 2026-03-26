using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Stalagtites : MonoBehaviour
{
    [SerializeField] private LayerMask gLayer;
    private Renderer r;
    [SerializeField] private Material[] materials;
    private float height;
    private Vector3 pos;
    private int liftCheck;
    private bool lift;
    private int sec = 2;
    private Vector3 origPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        height = 7f;
        origPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        pos = new Vector3(transform.position.x, transform.position.y - height, transform.position.z);
        StartCoroutine(TilesClock());
    }

    IEnumerator TilesClock()
    {
        while (true)
        {
            liftCheck = Random.Range(0, 2);
            if (liftCheck == 0)
            {
                lift = true;
            }
            else
            {
                lift = false;
            }
            if (lift == true)
            {
                yield return new WaitForSeconds(sec);
                ColorChange();
                yield return new WaitForSeconds(sec);
                transform.position = Vector3.MoveTowards(transform.position, pos, height);
                CleanUp();
                yield return new WaitForSeconds(sec + 1);
                transform.position = Vector3.MoveTowards(transform.position, origPos, height);

            }
            else
            {
                yield return new WaitForSeconds(sec * 3 + 1);
            }
        }
    }

    public void ColorChange()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, gLayer))
        {
            r = hit.collider.gameObject.GetComponent<Renderer>();
            r.material = materials[1];
        }
    }

    public void CleanUp()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, gLayer))
        {
            r = hit.collider.gameObject.GetComponent<Renderer>();
            r.material = materials[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
