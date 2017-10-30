using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D rb;

    private float moveVelocity;
    public float jumpHeight = 20;

    public Transform[] groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask whatIsGround;
    private bool grounded;
    private float timeWhenGrounded = 0f;
    private float timeSinceGrounded;
    private bool kyoteTime = false;

    public bool Hidden = false;

    public float doubleJumpHeight = 25f;
    private bool doubleJumped;

    public Transform[] wallCheck;
    public float wallCheckRadius = 0.1f;
    public LayerMask whatIsWall;
    private bool onWall;
    float timeOnWall = 0;

    private float particalGrav = 7;
    private float waveGrav = 4;

    public LayerMask whatIsHideObj;

    private bool WallJumped;

    private Animator anim;

    public Transform firePoint;
    public GameObject projectile;

    public float fireRate = 0.15f;
    private float fireTime;

    //Knockback Variables
    public float knockback = 5;
    public float knockbackLength = 0.2f;
    public float knockbackCount;
    public bool knockFromRight;

    private float moveSpeed = 8;

    public int ammoToAdd = -1;
    int currentWeapon;
    public GameObject thisEnemyVision;
    public GameObject thisEnemy;
    public AudioClip JumpSound;

    private float JumpTimer = 1f;
    private float JumpTime = 2f;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update() {

		if (GameMaster.particleWorld) {
			anim.SetBool ("Particle", true);
		} else {
			anim.SetBool ("Particle", false);
		}

        //Check to see if you have already double jumped
        if (grounded) {
            WallJumped = false;
            doubleJumped = false;
            onWall = false;
            timeSinceGrounded = 0;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, 0.2f);

        anim.SetBool("Grounded", grounded);

        if (onWall == true) {
            //reduce velocity

            timeOnWall = timeOnWall + Time.deltaTime;
            moveSpeed = moveSpeed / 1 * timeOnWall;
        }
        else
        {
            timeOnWall = 0;
            moveSpeed = 12;
        }

        //jump
        if ((Input.GetAxisRaw("Vertical") > 0  || Input.GetKeyDown(KeyCode.Space)) && kyoteTime && JumpTimer <= JumpTime && grounded) {
            //Play sound
            AudioSource.PlayClipAtPoint(JumpSound, transform.position);
            Jump();
            JumpTimer = JumpTime + 0.7f;
            JumpTimer = JumpTime + 0.5f;
        }

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    dash();
        //}

        //Wall jump
        //if (Input.GetAxisRaw("Vertical") > 0 && !WallJumped && !grounded && onWall)
        //{
        //    wallJump();
        //    WallJumped = true;
        //}
        JumpTime = Time.time;

        //double jump
        if ((Input.GetKeyDown("up") || Input.GetKeyDown("w")) && !doubleJumped && !grounded && !GameMaster.particleWorld) {
            AudioSource.PlayClipAtPoint(JumpSound, transform.position);
            doubleJump();
            doubleJumped = true;
        }

        moveVelocity = 0f;

        //walking
        if (Input.GetAxis("Horizontal") != 0) {
            moveVelocity = (Input.GetAxis("Horizontal")) * moveSpeed;
        }

        ////walk left
        //if (Input.GetKey(KeyCode.A)) {
        //    moveVelocity = -moveSpeed;
        //}

        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);

        if(knockbackCount <= 0) {
            rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
        } else {
            if (knockFromRight) {
                rb.velocity = new Vector2(-knockback, knockback);
            }
            if (!knockFromRight) {
                rb.velocity = new Vector2(knockback, knockback);
            }

            knockbackCount -= Time.deltaTime;
        }
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        if (rb.velocity.x > 0) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if (rb.velocity.x < 0) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        //Hide behind box
        if ((Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.Comma)) && Physics2D.OverlapCircle(wallCheck[1].position, wallCheckRadius, whatIsHideObj) && GameMaster.particleWorld)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Hidden = true;
        } else
        {
            GetComponent<SpriteRenderer>().enabled = true;
            Hidden = false;
        }
        //Use weapons
        if (Input.GetKey(KeyCode.Z)||Input.GetKey(KeyCode.M)) {
            //if gun equipped
            if (currentWeapon == 0) {
                if (Time.time > fireTime && GameMaster.particleWorld && AmmoManager.ammo > 0) {
                    AmmoManager.AddAmmo(ammoToAdd);
                    Instantiate(projectile, firePoint.position, firePoint.rotation);
                    fireTime = Time.time + fireRate;
                    anim.SetBool("Shooting", true);
                }
            
        }
            
        }


        
        //gravity depending on each world
        if (GameMaster.particleWorld) {
            rb.gravityScale = particalGrav;
        } else {
            rb.gravityScale = waveGrav;
        }


    }

    void FixedUpdate() {
        grounded = Physics2D.OverlapArea(groundCheck[0].position, groundCheck[1].position, whatIsGround);

        //kyoteTime Check
        if (!grounded && timeWhenGrounded == 0f) {
            timeWhenGrounded = Time.deltaTime;
        }
        else if (grounded)
        {
            timeWhenGrounded = 0f;
        }

        timeSinceGrounded = Time.deltaTime - timeWhenGrounded;

        if (Physics2D.OverlapArea(groundCheck[2].position, groundCheck[1].position, whatIsGround) && timeSinceGrounded < 1.0f) {
            kyoteTime = true;
        }
        else
            kyoteTime = false;



        //wall Check
        if (Physics2D.OverlapCircle(wallCheck[0].position, wallCheckRadius, whatIsWall) || Physics2D.OverlapCircle(wallCheck[1].position, wallCheckRadius, whatIsWall)&&!grounded) {
            onWall = true;
        }
        //on wall spirte transition
        else{
            onWall = false;
        }
}

    public void Jump() {
        if (!GameMaster.particleWorld)
            rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical")*jumpHeight);
        else
        rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical")*jumpHeight);
    }

    public void doubleJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, doubleJumpHeight);
    }

    //public void wallJump()
    //{
    //    transform.localScale = transform.localScale.x == 1 ? new Vector2(-1, 1) : Vector2.one;

    //    rb.velocity = new Vector2(jumpHeight * 5, (jumpHeight * 0.8f));

    //    moveVelocity = 20f;
    //}

    public bool isHidden()
    {
        return Hidden;
    }

    /// <summary>
    /// Do this later
    /// </summary>
    //public void dash()
    //{
    //    waveGrav = 0;
    //    particalGrav = 0;
    //    rb.velocity = new Vector2(rb.velocity.x* 3000f,rb.velocity.y);
    //    waveGrav = 4;
    //    particalGrav = 7;
    //}

}
