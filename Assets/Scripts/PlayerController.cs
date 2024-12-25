using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public int count = 0;
    public Text countText;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        // Handle RigidBody2D
        rb = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.AddForce(new Vector2 (horizontalInput, verticalInput) * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Collided !");

        if(collision.gameObject.CompareTag("PickUp"))
        {
            Destroy(collision.gameObject);
            Count();
        }
    }

    void Count()
    {
        count++;
        countText.text = "Count: " + count.ToString();

        if (count >= 8)
        {
            winText.text = "You Win !!";
        }
    }
}
