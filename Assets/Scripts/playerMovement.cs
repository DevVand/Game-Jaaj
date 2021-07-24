using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour
{

    public float speed = 300;
    public float turnSpeed = 2f;

    public float angle = 0;

    public LayerMask whatIsSolid;

    private SpriteRenderer sprRenderer;
    private Rigidbody2D rdbd;
    private Animator anim;

    void Start()
    {
        sprRenderer= GetComponent<SpriteRenderer>();
        rdbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        angle += (h * -turnSpeed);

        Vector2 direction = new Vector2(
            ((Mathf.Cos(angle * Mathf.Deg2Rad) * speed) * v),
            ((Mathf.Sin(angle * Mathf.Deg2Rad) * speed) * v));
        rdbd.velocity += direction*Time.deltaTime;
        rdbd.velocity *= .8f;

        anim.SetFloat("angle",Mathf.Repeat(-angle+90,360));
        //anim.SetFloat("velocityY", rdbd.velocity.y);
        //anim.SetBool("ground", onGround);
        //anim.SetBool("crouching", crouching);

    }

}