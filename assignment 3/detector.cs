using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector : MonoBehaviour
{
    //a list of the objects inside of the trigger currently in order to keep track of when to turn it back to red
    List<GameObject> objectsInside = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        //add the collided object to the list of objects in the collider
        objectsInside.Add(other.gameObject);
        //change the color of the marerial to green by getting the 'Mesh Renderer' and accessing its material
        GetComponent<Renderer>().material.color = Color.green;
    }

    private void OnTriggerExit(Collider other)
    {
        //remove the object from the list of objects in the collider
        objectsInside.Remove(other.gameObject);

        //check if the list of objects in the collider is empty, if there's nothing inside
        if (objectsInside.Count == 0)
            //change the color of the marerial to red by getting the 'Mesh Renderer' and accessing its material
            GetComponent<Renderer>().material.color = Color.red;
    }
}
