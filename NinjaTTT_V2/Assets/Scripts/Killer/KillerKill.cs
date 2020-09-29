using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerKill : MonoBehaviour
{
    private PlayerDash _playerDash;

    // Start is called before the first frame update
    void Start()
    {
        _playerDash = GetComponent<PlayerDash>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _playerDash._isDashing)
        {
            Debug.Log("Killed " + collision.tag);
            collision.GetComponent<PlayerLife>()._isAlive = false;
            collision.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}
