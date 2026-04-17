/*****************************************************************************
// File Name : Stalagtites.cs
// Author : Alan Miles
// Creation Date : March 25, 2026
//
// Brief Description : Changes the color of the stones, and controls 
                       stalactites (I spelled it wrong in the class name 
                       but don't want to change it everywhere)
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Stalagtites : MonoBehaviour
{
    private StoneController sc;
    [SerializeField] private LayerMask gLayer;
    private Renderer r;
    [SerializeField] private Material[] materials;
    private float height;
    [SerializeField] private bool combined = false;
    [SerializeField] private int smoothness = 6;
    [SerializeField] private float offset = 0.125f;
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
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, gLayer))
        {
            sc = hit.collider.gameObject.GetComponent<StoneController>();
        }
        if (combined == false)
        {
            StartCoroutine(TilesClock());
        }
        else
        {
            sc.readyEvent += SCReadyEvent;
        }
    }
    private void SCReadyEvent()
    {
        StartCoroutine(StalactiteFall());
    }

    /// <summary>
    /// Puts StalactiteFall in a loop
    /// </summary>
    /// <returns></returns>
    IEnumerator TilesClock()
    {
        while (true)
        {
            yield return StartCoroutine(StalactiteFall());
        }
    }

    /// <summary>
    /// Calls the colorchange and cleanup functions to manage tile colors and changes position of the stalactites
    /// </summary>
    /// <returns></returns>
    IEnumerator StalactiteFall()
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
            for (int i = 0; i < smoothness; i++)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos, height * 1f / smoothness);
                yield return new WaitForEndOfFrame();
            }
            CleanUp();
            yield return new WaitForSeconds(sec + 1);
            for (int i = 0; i < smoothness; i++)
            {
                transform.position = Vector3.MoveTowards(transform.position, origPos, height * 1f / smoothness);
                yield return new WaitForEndOfFrame();
            }
            sc.Ready = false;

        }
        else
        {
            yield return new WaitForSeconds(sec);
            yield return new WaitForSeconds(sec);
            for (int i = 0; i < smoothness; i++)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, transform.position, height * 1f / smoothness);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(sec + 1);
            for (int i = 0; i < smoothness; i++)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, transform.position, height * 1f / smoothness);
                yield return new WaitForEndOfFrame();
            }
            sc.Ready = false;

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
            height = hit.distance - offset;
            r.material = materials[1];
        }
    }

    /// <summary>
    /// Changes color of tiles to original color
    /// </summary>
    public void CleanUp()
    {
        r.material = materials[0];
    }

    private void OnDestroy()
    {
        sc.readyEvent += SCReadyEvent;
    }
}
