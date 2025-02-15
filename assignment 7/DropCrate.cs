using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCrate : MonoBehaviour
{
    [SerializeField] private float pursuitDistance;
    [SerializeField] private float pursuitDrag;
    [SerializeField] private LayerMask pursuitDetectionMask;
    [SerializeField] private Animator pursuitAnimator;

    private bool isPursuitOpen;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PursuitHandler();
    }

    //handle all cone related to the pursuit
    void PursuitHandler()
    {
        //if the pursuit isn't open yet, check if im 4 meters above what i considered 'ground'
        if (!isPursuitOpen && Physics.Raycast(transform.position, Vector3.down, pursuitDistance, pursuitDetectionMask))
            OpenPursuit();
    }

    //opens the pursuit :D
    void OpenPursuit()
    {
        isPursuitOpen = true;

        //sets drag
        rb.drag = pursuitDrag;

        //starts up animation
        pursuitAnimator.SetBool("isOpen", true);
    }
}
