using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveTime = 0.1f;           //Time it will take object to move, in seconds.
    public float speed;
    float x;
    float y;
    Vector3 move;
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horisontal"), Input.GetAxis("Vertical"));
        move = moveInput.normalized * speed;
        x = transform.position.x;
        y = transform.position.y;
        if (Input.GetKeyDown (KeyCode.W) )
        {
            
            transform.position = new Vector2(x,y+1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {

            transform.position = new Vector2(x, y - 1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            
            transform.position = new Vector2(x+1, y);
            
        }
        if (Input.GetKeyDown(KeyCode.A))
        {

            transform.position = new Vector2(x- 1, y );

        }
    }
    void FixedUpdate()
    {
        // Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // transform.Translate(Vector3.forward * Time.deltaTime * 0.1);
        GetComponent<Rigidbody2D>().MovePosition(transform.position + move * Time.fixedDeltaTime);
    }
}
