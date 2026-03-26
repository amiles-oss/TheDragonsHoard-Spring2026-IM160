/*****************************************************************************
// File Name : Stalagtites.cs
// Author : Alan Miles
// Creation Date : March 25, 2026
//
// Brief Description : Changes the color of the stones, and controls 
                       stalactites (I spelled it wrong but don't want to 
                       change it everywhere)
******************************************************************************/
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
    /// <summary>
    /// Set Variables and start the coroutine for stalactites to fall
    /// </summary>
    void Start()
    {
        height = 7f;
        origPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        pos = new Vector3(transform.position.x, transform.position.y - height, transform.position.z);
        StartCoroutine(TilesClock());
    }

    /// <summary>
    /// Calls the colorchange and cleanup functions to manage tile colors and changes position of the stalactites
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Changes color of tiles to danger color
    /// </summary>
    public void ColorChange()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, gLayer))
        {
            r = hit.collider.gameObject.GetComponent<Renderer>();
            r.material = materials[1];
        }
    }

    /// <summary>
    /// Changes color of tiles to original color
    /// </summary>
    public void CleanUp()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, gLayer))
        {
            r = hit.collider.gameObject.GetComponent<Renderer>();
            r.material = materials[0];
        }
    }
}
