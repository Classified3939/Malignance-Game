using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.5f;
    [SerializeField] Rigidbody2D rb;

    Vector2 moveDirection;
    Vector2 mousePosition;

    bool isMoving;

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        moveDirection = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")).normalized;

        isMoving = Input.GetMouseButton(0);
    }

    private void FixedUpdate()
    {
        Vector2 facingDirection = mousePosition - rb.position;
        float facingAngle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = facingAngle;
        if (isMoving)
        {
            rb.velocity = new Vector2(facingDirection.x * moveSpeed, facingDirection.y * moveSpeed);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }

    }

}
