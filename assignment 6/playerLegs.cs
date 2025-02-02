using UnityEngine;

public class playerLegs : MonoBehaviour
{
    //a reference to the player
    [SerializeField] private Player player;

    //here i detect the collisions and send them to the player to process them.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GroundCheck(collision.gameObject, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.GroundCheck(collision.gameObject, false);
    }
}
