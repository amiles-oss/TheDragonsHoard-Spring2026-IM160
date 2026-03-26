/*****************************************************************************
// File Name : StoneController.cs
// Author : Alan Miles
// Creation Date : March 25, 2026
//
// Brief Description : Changes the color of the stones, lifts them, and 
                       controls the lava
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    [SerializeField] private Renderer r;
    [SerializeField] private GameObject lava;
    private bool lift;
    private float height;
    private float lheight;
    private int safeNum = 1;
    private int origNum = 0;
    private int liftCheck;
    private int sec = 2;
    private Vector3 pos;
    private Vector3 origPos;
    private Vector3 lpos;
    private Vector3 origLPos;
    /// <summary>
    /// Set Variables and call the TilesClock coroutine so tiles will work properly
    /// </summary>
    void Start()
    {
        //Height calculates how high each thing needs to lift
        height = 2f;
        lheight = 0.25f;
        //origPos & origLPos save the original position of tiles so they can return to their spots
        //pos & lpos set the new position for each tile after the waitforseconds
        origPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        pos = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
        origLPos = new Vector3(lava.transform.position.x, lava.transform.position.y, lava.transform.position.z);
        lpos = new Vector3(lava.transform.position.x, lava.transform.position.y + lheight, lava.transform.position.z);
        StartCoroutine(TilesClock());
    }

    /// <summary>
    /// Makes tiles change color and raise up to protect from the lava that this script also raises
    /// </summary>
    /// <returns></returns>
    IEnumerator TilesClock()
    {
        while (true)
        {
            //Checks if that particular stone will lift
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
                //Change color of the tiles
                r.material = materials[safeNum];
                yield return new WaitForSeconds(sec);
                //Change y value of tiles
                transform.position = Vector3.MoveTowards(transform.position, pos, height);
                r.material = materials[origNum];
                yield return new WaitForSeconds(1);
                //Change y value of lava
                lava.transform.position = Vector3.MoveTowards(lava.transform.position, lpos, height);
                yield return new WaitForSeconds(sec);
                //Returns lava and tiles to their original positions
                lava.transform.position = Vector3.MoveTowards(lava.transform.position, origLPos, height);
                transform.position = Vector3.MoveTowards(transform.position, origPos, height);
            }
            else
            {
                //If a tile doesn't raise, keep it on the same timer as the ones that raise
                yield return new WaitForSeconds(sec * 3 + 1);
            }
        }
    }
}
