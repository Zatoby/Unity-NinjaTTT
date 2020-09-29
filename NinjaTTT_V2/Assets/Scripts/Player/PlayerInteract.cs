using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interacted");
        }
    }
}
