using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text countText;
    public float speed;
    public Text winText;
    public Text loseText;

    private Rigidbody rb;
    private int count;
    private bool isJumping = false;
    private float posY;
    private float gravity;
    private float jumpPower;
    private float jumpTime;


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You win!";
        }   
    }

    void Jump()
    {
        float height = (jumpTime * jumpTime * (-gravity) / 2) + (jumpTime * jumpPower);
        transform.position = new Vector3(transform.position.x, posY + height, transform.position.z);
        jumpTime += Time.deltaTime;

        if (height < 0.0f)
        {
            isJumping = false;
            jumpTime = 0.0f;
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        }

    }



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";

        posY = transform.position.y;
        gravity = 9.8f;
        jumpPower = 15.0f;
        jumpTime = 0.0f;


    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            posY = transform.position.y;
        }
        if (isJumping)
        {
            Jump();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
       
    }
}
//Destroy(other.gameObject);
//if (other.gameObject.CompareTag("Player"))
//gameObject.SetActive(false);