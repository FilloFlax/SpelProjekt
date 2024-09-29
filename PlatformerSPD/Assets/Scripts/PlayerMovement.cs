using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 250f;
    [SerializeField] private float minSpeed = 250f;
    [SerializeField] private float maxSpeed = 500f;
    [SerializeField] private float accSpeed = 500f;
    [SerializeField] private float jumpForce = 750f;
    [SerializeField] private Transform leftFoot, rightFoot;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private LayerMask whatIsGround;

    [SerializeField] private int startingHealth = 5;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image fillColor;
    [SerializeField] private TMP_Text bananaText;


    private float horizontalValue;
    private bool isGrounded;
    private bool canMove;
    private float rayDistance = 0.25f;
    private int currentHealth = 0;
    public int bananasCollected = 0;

    private Rigidbody2D rigidbd;
    private SpriteRenderer rend;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        bananaText.text = "" + bananasCollected;
        currentHealth = startingHealth;
        rigidbd = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        if (horizontalValue < 0)
        {
            FlipSprite(true);
        }

        if (horizontalValue > 0)
        {
            FlipSprite(false);
        }

        if (Input.GetButtonDown("Jump") && CheckIfGrounded() == true)
        {
            Jump();
        }



        if (Input.GetKey(KeyCode.LeftShift) && CheckIfGrounded() == true && moveSpeed < maxSpeed && (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0))
        {
            moveSpeed = moveSpeed + accSpeed * Time.deltaTime;
        }

        else 
        {
            if (moveSpeed > minSpeed && CheckIfGrounded())
            {
                moveSpeed = moveSpeed - accSpeed * Time.deltaTime;
            }
            
        }


        anim.SetFloat("MoveSpeed", Mathf.Abs(rigidbd.velocity.x));
        anim.SetFloat("VerticalSpeed", rigidbd.velocity.y);
        anim.SetBool("IsGrounded", CheckIfGrounded());

    }

    private void FixedUpdate()
    {
        if(!canMove)
        {
            return;
        }     
        
        rigidbd.velocity = new Vector2(horizontalValue * moveSpeed * Time.deltaTime, rigidbd.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Banana")) 
        {
            Destroy(other.gameObject);
            bananasCollected++;
            bananaText.text = "" + bananasCollected;
        }

        if (other.CompareTag("Health"))
        {
            RestoreHealth(other.gameObject);
        }
    }

    private void FlipSprite(bool direction)
    {
        rend.flipX = direction;
    }

    private void Jump()
    {
        rigidbd.AddForce(new Vector2(0, jumpForce));
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Respawn();
        }
    }

    public void TakeKnockback(float knockbackAmount, float upwardsKnockback)
    {
        canMove = false;
        rigidbd.AddForce(new Vector2(knockbackAmount, upwardsKnockback));
        Invoke("CanMoveAgain", 0.25f);
    }

    private void CanMoveAgain()
    {
        canMove = true;
    }

    private void Respawn()
    {
        currentHealth = startingHealth;
        UpdateHealthBar();
        transform.position = spawnPosition.position;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void RestoreHealth(GameObject healthPickup)
    {
        if(currentHealth >= startingHealth)
        {
            return;
        }
        else
        {
            int healthToRestore = healthPickup.GetComponent<HealthPickup>().healthAmount;
            currentHealth += healthToRestore;
            UpdateHealthBar();
            Destroy(healthPickup);

            if(currentHealth >= startingHealth)
            {
                currentHealth = startingHealth;
            }
        }
    }

    private void UpdateHealthBar()
    {
        healthSlider.value = currentHealth;

        if (currentHealth >= 2) 
        {
            fillColor.color = Color.red;
        }
        else
        {
            fillColor.color = Color.yellow;
        }
    }

    private bool CheckIfGrounded()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(leftFoot.position, Vector2.down, rayDistance, whatIsGround);
        RaycastHit2D rightHit = Physics2D.Raycast(rightFoot.position, Vector2.down, rayDistance, whatIsGround);

        //Debug.DrawRay(leftFoot.position, Vector2.down * rayDistance, Color.blue, 0.25f);
        //Debug.DrawRay(rightFoot.position, Vector2.down * rayDistance, Color.red, 0.25f);

        if (leftHit.collider != null && leftHit.collider.CompareTag("Ground") || rightHit.collider != null && rightHit.collider.CompareTag("Ground"))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
