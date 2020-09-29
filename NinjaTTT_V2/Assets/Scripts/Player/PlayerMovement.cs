using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _crouchSpeed;
    [SerializeField]
    private bool _isCrouching;

    public bool isfacingRight = true;
    public bool isfacingUp = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (!isfacingRight && x > 0)
        {
            FlipX();
        }
        else if (isfacingRight && x < 0)
        {
            FlipX();
        }

        if (!isfacingUp && y > 0)
        {
            FlipY();
        }
        else if (isfacingUp && y < 0)
        {
            FlipY();
        }


        if (Input.GetKey(KeyCode.LeftControl))
        {
            _isCrouching = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _isCrouching = false;
        }

        Move();

    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        if (_isCrouching)
        {
            transform.Translate(Vector2.right * x * _crouchSpeed * Time.deltaTime);
            transform.Translate(Vector2.up * y * _crouchSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * x * _speed * Time.deltaTime);
            transform.Translate(Vector2.up * y * _speed * Time.deltaTime);
        }

    }

    void FlipX()
    {
        isfacingRight = !isfacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void FlipY()
    {
        isfacingUp = !isfacingUp;
        /*Vector3 Scaler = transform.localScale;
        Scaler.y *= -1;
        transform.localScale = Scaler;*/
    }
}
