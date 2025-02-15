using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpSpeed;

    //i save the jumping routine for a check in this
    private Coroutine jumpRoutine = null;

    private void Update()
    {
        HorizontalMovement();

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    //handle horizontal movement (left and right)
    private void HorizontalMovement()
    {
        float MovementAxisH = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(MovementAxisH * movementSpeed * Time.deltaTime, 0, 0);
    }

    //jump function to start up the coroutine
    private void Jump()
    {
        //if a jump is already ongoing, return.
        if (jumpRoutine != null) return;

        //start the routine and save it into 'jumpRoutine'
        jumpRoutine = StartCoroutine(JumpCoroutine());
    }

    //the coroutine handling the jump
    private IEnumerator JumpCoroutine()
    {
        //iterate through all the frames (from 20 to -20)
        for (int f = 20; f >= -20; f--)
        {
            //move self in the direction depending on the f variable (for example, 20 will move you up, +t will as well,
            //then you get to the negatives, -t will move you down then at the end -20 will move you down completing the jump)
            transform.position += new Vector3(0, jumpSpeed * f, 0);

            //wait a frame :)
            yield return null;
        }

        //set 'jumpRoutine' to make sure i can jump again later!
        jumpRoutine = null;
    }
}
