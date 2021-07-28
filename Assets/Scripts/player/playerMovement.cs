using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour
{

    public float speedSlowMode = 30*.2f;
    public float speed = 45;
    public float turnSpeed = 2f;
    public float damp = .9f;

    public bool slowMode = false;

    [Header("dash")]
    public bool dashUnlocked = true;
    public float dashSpeed = 80;
    public float dashWait = 2;
    public float dashStopWait = .5f;
    public bool dashing = false;
    private bool canDash = true;

    [Header("misc")]
    public LayerMask whatIsSolid;
    public float angle = 0;

    private SpriteRenderer sprRenderer;
    private Rigidbody2D rdbd;
    private Animator anim;

    void Start()
    {
        sprRenderer= GetComponent<SpriteRenderer>();
        rdbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        angle += (h * -turnSpeed);

        Vector2 direction = Vector2.zero;
        if (Input.GetButtonDown("Dash"))
        {
            if (dashUnlocked && canDash && !slowMode)
            {
                dashing = true;
                canDash = false;
                Invoke(nameof(nowCanDash), dashWait);
                Invoke(nameof(nowStopDash), dashStopWait);

            }
            else
            {
                anim.Play("alert", 1);
            }
        }
        if (!slowMode)
        {
            if (dashing)
            {
                direction = new Vector2(
                    ((Mathf.Cos(angle * Mathf.Deg2Rad) * dashSpeed)),
                    ((Mathf.Sin(angle * Mathf.Deg2Rad) * dashSpeed)));
            }
            else
            {
                direction = new Vector2(
                    ((Mathf.Cos(angle * Mathf.Deg2Rad) * speed) * v),
                    ((Mathf.Sin(angle * Mathf.Deg2Rad) * speed) * v));
            }

        }
        else {
            direction = new Vector2(
                 ((Mathf.Cos(angle * Mathf.Deg2Rad) * speedSlowMode) * v),
                 ((Mathf.Sin(angle * Mathf.Deg2Rad) * speedSlowMode) * v));
        }


        rdbd.velocity += direction * Time.deltaTime;
        //rdbd.velocity *= damp;

        anim.SetFloat("angle", Mathf.Repeat(-angle + 90, 360));
        //anim.SetFloat("velocityY", rdbd.velocity.y);
        //anim.SetBool("ground", onGround);
        //anim.SetBool("crouching", crouching);
    }

    public void nowCanDash() { canDash = true; }
    public void nowStopDash() { dashing = false; }

}