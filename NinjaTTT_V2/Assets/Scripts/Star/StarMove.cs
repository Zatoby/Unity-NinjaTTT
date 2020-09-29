using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMove : MonoBehaviour
{
    public Vector3 rotationDirection;

    private Rigidbody2D rb;
    [SerializeField]
    private float _starSpeed;
    [SerializeField]
    private float _speedMultiplier;
    [SerializeField]
    private float _starLife;

    private PlayerMovement _playerMovement;

    void Start()
    {
        bool up = Input.GetKey(KeyCode.W);
        bool left = Input.GetKey(KeyCode.A);
        bool down = Input.GetKey(KeyCode.S);
        bool right = Input.GetKey(KeyCode.D);

        rb = GetComponent<Rigidbody2D>();
        _playerMovement = GameObject.Find("Killer").GetComponent<PlayerMovement>();

        if (_playerMovement.isfacingRight && !up && !left && !right && !down)
        {
            rb.AddForce(Vector2.right * _starSpeed * _speedMultiplier);
        }
        else if(!_playerMovement.isfacingRight && !up && !left && !right && !down)
        {
            rb.AddForce(Vector2.left * _starSpeed * _speedMultiplier);
        }

        if (up)
        {
            rb.AddForce(Vector2.up * _starSpeed * _speedMultiplier);
        }
        if (left)
        {
            rb.AddForce(Vector2.left * _starSpeed * _speedMultiplier);
        }
        if (down)
        {
            rb.AddForce(Vector2.down * _starSpeed * _speedMultiplier);
        }
        if (right)
        {
            rb.AddForce(Vector2.right * _starSpeed * _speedMultiplier);
        }

        StartCoroutine(StarLifeRoutine());
    }

    private void FixedUpdate()
    {
        if (_playerMovement.isfacingRight)
        {
            transform.Rotate(rotationDirection * Time.deltaTime);
        }
        else
        {
            transform.Rotate(-rotationDirection * Time.deltaTime);
        }
    }

    IEnumerator StarLifeRoutine()
    {
        yield return new WaitForSeconds(_starLife);
        Destroy(this.gameObject);
    }
}
