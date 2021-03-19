using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelosity;
    public int yams;
    public int bag;
    public GameObject gameObject1;
    void Start()
    {
        yams = 0;
        bag = 0;
        rb = GetComponent<Rigidbody2D>();
        Instantiate(gameObject1, new Vector2(Random.Range(0, 5), Random.Range(0, 5)), Quaternion.identity);

    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelosity = moveInput.normalized * speed;
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelosity * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.transform.name);
        if (collision.transform.name.Contains("test_yam"))
        {
            yams++;
            Instantiate(gameObject1, new Vector2(Random.Range(0, 7), Random.Range(-4, 0)), Quaternion.identity);

        }
        if (collision.transform.name.Contains("test_bag"))
        {
            bag += yams;
            yams = 0;

        }
    }
}
