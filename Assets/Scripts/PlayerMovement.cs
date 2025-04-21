using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb2d; // Private Variable

    float move;
    [ SerializeField] float speed; 

    [ SerializeField] float jumpForce;
    [ SerializeField] bool isJumping;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // Walk left and right
        move = Input.GetAxis("Horizontal"); 
        rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y); 

        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(new Vector2 (rb2d.linearVelocity.x, jumpForce));
            Debug.Log("Jump!!");
        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;

        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }

    }

}
