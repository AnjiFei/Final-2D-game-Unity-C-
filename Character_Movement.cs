using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Character_Movement : MonoBehaviour
{
    // Start is called before the first frame update


    public Chamber _hbar;
    Rigidbody2D rb;


    public int Health;

    public string character;

    public float walk_speed;
    public float sprint_speed;
    public float speed = 0;
    public bool grounded;
    public float vert_movement = 0;
    public bool hurt;
    public float hurt_dir;
    public float iframes;

    public GameObject bullet_spawn;
    public GameObject bullet_prefab;
    public float bullet_dir;
    public float hori_movement;
    public Animator isa;
    public bool hammer_time,shooty, walky;
    public GameObject hammer;
    public GameObject  player;
    GameObject sp; Fall fa;
    Transform spaw;
    void Start()
    {
        _hbar = GameObject.Find("Hesalth_Con").GetComponent<Chamber>();

        rb = GetComponent<Rigidbody2D>();
        hammer_time = false;
        shooty = false;
        walky = false;
    }

    // Update is called once per frame
    void Update()
    {
        _hbar.SetHealth(Health);
        if (sp == null)
        { sp =  GameObject.FindWithTag("spawn");
        //fa.respawnPoint = sp.transform;
        }
        hori_movement = CrossPlatformInputManager.GetAxis("Horizontal");
        float hori_mob = CrossPlatformInputManager.GetAxis("Horizontal");


        if (hori_movement > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

            bullet_dir = 1;
        }
        if (hori_movement < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

            bullet_dir = -1;

        }


        jump();



        move();
        melee();
        ranged();

        Vector3 movement = new Vector3(hori_movement * speed, 0, 0);

        transform.Translate(movement * Time.deltaTime);
        //  rb.MovePosition(transform.position + movement * Time.deltaTime * speed);
        //   rb.AddForce(movement * 10*Time.deltaTime,ForceMode2D.Impulse);
        // rb.AddForce(movement * Time.deltaTime, ForceMode2D.Force);

       

        if (hurt)
        {
            hurt = false;
            rb.AddForce(new Vector2(20f * hurt_dir, 10f), ForceMode2D.Impulse);
            iframes = 1;
            Invoke("IframeHandlers", 1f);

        }
         if (!Input.GetKeyDown(KeyCode.Z))
        {
            shooty = false;
            isa.SetBool("shoot", false); 
        }
       
        
       
    }
    public void move()
    {
        if (hori_movement < 0)
        {

            hori_movement *= -1;
        }
        if (hori_movement != 0)
        {
            isa.SetBool("walk", true); walky = true;
            isa.SetBool("idle", false);
            if ((Input.GetKey(KeyCode.LeftShift)) || CrossPlatformInputManager.GetButtonDown("Run"))

            {
                speed = sprint_speed;
                isa.SetBool("run", true);
                isa.SetBool("idle", false);
            }
            else
            {
                speed = walk_speed;
                isa.SetBool("run", false);
                isa.SetBool("idle", false);
            }

        }
        else
        {
            isa.SetBool("idle", true);
            isa.SetBool("walk", false);
        }
    }

    public void jump()
    {
        if ((Input.GetKey(KeyCode.UpArrow) || CrossPlatformInputManager.GetAxis("Vertical") > 0) && grounded)

        {
            isa.SetBool("run", false);
            isa.SetBool("walk", false); isa.SetTrigger("jump");
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, 20f), ForceMode2D.Impulse);

        }

        if (Input.GetKey(KeyCode.DownArrow) && grounded)
        {

        }
    }
    public void melee()
    {
         if ((Input.GetKeyDown(KeyCode.X)) || CrossPlatformInputManager.GetButtonDown("Melee"))
        {
            isa.SetBool("idle", false);
            hammer.SetActive(true);
            isa.SetTrigger("hammer");
            
            //StartCoroutine("OnCompleteAttackAnimation");
        }
        hammer.SetActive(false);
    }
    public void ranged()
    {
        if ((Input.GetKeyDown(KeyCode.Z)) || CrossPlatformInputManager.GetButtonDown("Ranged"))
        {
            isa.SetBool("idle", false);
            shooty = true;
            isa.SetBool("shoot", shooty);
            GameObject bulletshoot = Instantiate(bullet_prefab, bullet_spawn.transform.position, transform.rotation);
            bulletshoot.GetComponent<Rigidbody2D>().AddForce(new Vector2(50f * bullet_dir, 0f), ForceMode2D.Impulse);
            //StartCoroutine("OnCompleteAttackAnimation");
        }
    }
    public IEnumerator OnCompleteAttackAnimation()
    {   
        while (isa.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f ) { 
          
            
            
        }
        
       
        yield return null;

        
    }
    void IframeHandlers()
    {
        if (iframes > 0)
        {
            iframes -= 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("FallRespawn"))
        {
            this.transform.position = sp.transform.position;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

 
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = false;
        }
    }
}
