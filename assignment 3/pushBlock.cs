using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushBlock : MonoBehaviour
{
    [SerializeField] private float force;
    private void OnTriggerStay(Collider other)
    {
        //try getting rigidbody from the object
        if (other.TryGetComponent(out Rigidbody rb))
        {
            //add force in the direction the cube is facing * the specified force amount
            rb.AddForce(transform.forward * force, ForceMode.Force);
        }
    }
}
