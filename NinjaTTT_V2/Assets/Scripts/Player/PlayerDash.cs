using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField]
    private float _dashSpeed;
    [SerializeField]
    private float _dashTime;
    [SerializeField]
    private float _resetTime;
    [SerializeField]
    private bool _canDash;

    public bool _isDashing;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        if (Input.GetButton("Jump") && _canDash)
        {
            rb.velocity = new Vector2(x, y) * _dashSpeed;
            StartCoroutine(DashResetRoutine());
            StartCoroutine(DashTimeRoutine());
        }
    }

    IEnumerator DashResetRoutine()
    {
        _canDash = false;
        _isDashing = true;

        yield return new WaitForSeconds(_resetTime);

        _canDash = true;
        _isDashing = false;
    }

    IEnumerator DashTimeRoutine()
    {
        yield return new WaitForSeconds(_dashTime);

        rb.velocity = Vector2.zero;
    }
}
