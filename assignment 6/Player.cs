using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;

    [Space]

    [SerializeField] private float jumpForce;

    [Header("Ground check")]
    [SerializeField] private bool isOnGround;
    private int GroundObjects;

    [Header("Animation")]
    [SerializeField] Animator animator;

    private Rigidbody2D rb;
    void Start()
    {
        //get the rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    //manage movement
    private void Movement()
    {
        //get pressed direction from the player
        float movementInput = Input.GetAxisRaw("Horizontal");

        //apply it to the rigidbody, no Time.DeltaTime is needed because i 'set' the velocity and dont 'add' it over time
        rb.linearVelocityX = movementInput * movementSpeed;
    }

    private void Jump()
    {
        //return if im not on the ground
        if (!isOnGround) return;

        //add force upwards (jump) :D
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

        //run the jump animation
        animator.Play("Jump");
    }

    //gets the ground detection from the playerLegs script
    public void GroundCheck(GameObject other, bool enter)
    {
        //return if player was hit
        if (other.tag.Equals("Player")) return;

        //when entering add and when exiting remove from the amout of things that were hit
        if (enter)
            GroundObjects++;
        else
            GroundObjects--;

        //if nothing is currently hit set isOnGround to false and set to true otherwise
        isOnGround = GroundObjects != 0;
    }
}
