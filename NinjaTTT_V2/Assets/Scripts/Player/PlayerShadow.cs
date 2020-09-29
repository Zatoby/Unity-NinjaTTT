using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadow : MonoBehaviour
{
    [SerializeField]
    private bool _inShadow;
    [SerializeField]
    private bool _isInvisible;
    [SerializeField]
    private float timeTilVis;

    private void Update()
    {
        if (!_inShadow)
        {
            StopCoroutine(BecomeShadowRoutine());
        }

        if (_isInvisible && !_inShadow)
        {
            StartCoroutine(ExitShadow());
        }

        if (_inShadow && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(BecomeShadowRoutine());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            _inShadow = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            _inShadow = true;
        }
    }


    private void BecomeNormal()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        _isInvisible = false;
    }

    IEnumerator BecomeShadowRoutine()
    {
        //player becomes one with the shadow
        //becomes invisible
        //plays fade animation
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        _isInvisible = true;

        yield return new WaitForSeconds(5f);

        BecomeNormal();
    }

    IEnumerator ExitShadow()
    {
        //message: you have exited the shade, maybe
        yield return new WaitForSeconds(timeTilVis);
        BecomeNormal();
    }
}
