using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarKill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Killed " + collision.tag);
            collision.GetComponent<PlayerLife>()._isAlive = false;
            collision.GetComponent<CapsuleCollider2D>().enabled = false;

            Destroy(this.gameObject);
        }
    }
}
