public float playermovementSpeed = 5f;
public float jumpPower = 5f;
public LayerMask layerM;

public Transform gCheckTrans;

SpriteRenderer spriteRd;
Animator animatorContoller;

Rigidbody2D rbbody;
void Start()
{
    rbbody = GetComponent<Rigidbody2D>();
    spriteRd = GetComponent<SpriteRenderer>();
    animatorContoller = GetComponent<Animator>();
}

// Update is called once per frame
void Update()
{
    float movementX = Input.GetAxis("Horizontal");

    rbbody.velocity = new Vector2(movementX * playermovementSpeed, rbbody.velocity.y);


    //jump

    if (Input.GetButton("Jump") && groundcheck())
    {
        //rbbody.AddForce(Vector2.up * jumpPower);
        rbbody.velocity = new Vector2(rbbody.velocity.x, jumpPower);
    }

    if (groundcheck())
    {
        if (Math.Abs(rbbody.velocity.x) > 0)
        {
            animatorContoller.SetInteger("switchAni", 1);
        }
        else
        {
            animatorContoller.SetInteger("switchAni", 0);
        }

    }
    else
    {
        animatorContoller.SetInteger("switchAni", 2);
    }



    if (rbbody.velocity.x < 0)
    {
        spriteRd.flipX = true;
    }
    if (rbbody.velocity.x > 0)
    {
        spriteRd.flipX = false;
    }

}

bool groundcheck()
{
    return Physics2D.OverlapCapsule(new Vector2(gCheckTrans.position.x, gCheckTrans.position.y), new Vector2(0.2f, 0.2f), CapsuleDirection2D.Vertical, 0, layerM);
}