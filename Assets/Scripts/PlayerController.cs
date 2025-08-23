using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
public class PlayerController : MonoBehaviour
{
    private Vector3 baitPos = new Vector3(7.12f, 10.474f, -0.19f); // This will be the position that the bait spawns at

    public bool isCasted;
    public bool isPulling;

    Animator animator;
    public GameObject baitPrefab;
    Transform baitPosition;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }



    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && !isCasted && !isPulling)
        {
            StartCoroutine(CastRod(baitPos));
        }

        if (isCasted && Input.GetKey(KeyCode.Space))
        {
            PullRod();
        }
    }


    IEnumerator CastRod(Vector3 targetPosition)
    {
        isCasted = true;
        animator.SetTrigger("Cast");

        // Create a delay between the animation and when the bait appears in the water
        yield return new WaitForSeconds(1f);

        GameObject instantiatedBait = Instantiate(baitPrefab);
        instantiatedBait.transform.position = targetPosition;
        instantiatedBait.transform.rotation = Quaternion.Euler(0f, 0f, 90f);

        baitPosition = instantiatedBait.transform;

        // ---- > Start Fish Bite Logic
        FishingLogic Instance.StartFishing();
    }

    private void PullRod()
    {
        animator.SetTrigger("Pull");
        isCasted = false;
        isPulling = true;

        // ---- > Start Minigame Logic
    }
}

