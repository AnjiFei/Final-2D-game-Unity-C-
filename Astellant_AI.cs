using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astellant_AI : MonoBehaviour
{
    public string Astellant_Type;
    public float patrol;
    public bool chase;
    public bool Attacking_Hammer;
    public bool Attacking_Gun;
    public float speed;
    GameObject Player;
    Transform pplauer;
    public Animator astl_anim;
    public float smash_cd;
    public float shoot_cd;
    public GameObject Astellant_Hammer;
    public GameObject Astellant_Bullet;
    public GameObject Hammer_Range;
    public GameObject Gun_Range;
    public GameObject astellant_bullet;
    public int bullet_dir = 1;
    public GameObject bulletspawn;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PatrolAndCD", Random.Range(0, 1f), 1f);

        
        //pplauer.transform = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
        }
        if (Vector3.Distance(transform.position,Player.transform.position)<= 8)
        {
            chase = true;
        }

        if (chase == false)
        {
            if (patrol <= 2 && !Attacking_Gun && !Attacking_Hammer)
            {
                astl_anim.SetBool("IsIdle", true);
                astl_anim.SetBool("IsMoving", false);
                bullet_dir = 1;
            }
            else if (patrol <= 4 && !Attacking_Gun && !Attacking_Hammer)
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                transform.rotation = Quaternion.Euler(0, 0, 0);
                bullet_dir = 1;
                astl_anim.SetBool("IsMoving", true);
                astl_anim.SetBool("IsIdle", false);


            }
            else if (patrol <= 6 && !Attacking_Gun && !Attacking_Hammer)
            {
                astl_anim.SetBool("IsIdle", true);
                astl_anim.SetBool("IsMoving", false);
                bullet_dir = -1;

            }
            else if (patrol <= 8 && !Attacking_Gun && !Attacking_Hammer)
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                transform.rotation = Quaternion.Euler(0, 180, 0);
                bullet_dir = -1;

                astl_anim.SetBool("IsMoving", true);
                astl_anim.SetBool("IsIdle", false);


            }
            if (patrol == 9 && !Attacking_Gun && !Attacking_Hammer)
            {
                patrol = 1;
            }
        }

        if (chase && !Attacking_Gun && !Attacking_Hammer)
        {
            astl_anim.SetBool("IsMoving", true);
            astl_anim.SetBool("IsIdle", false);
            if (transform.position.x > Player.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                bullet_dir = -1;


            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                bullet_dir = 1;

            }
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));

        }


        if (Astellant_Type == "Gunnar")
        {


            astl_anim.SetInteger("Stance", 1);
            {
                if (Gun_Range.GetComponent<Astellant_Range_Check>().InRange && shoot_cd == 0)
                {
                    astl_anim.SetTrigger("Atk");

              

                    // chase = false;
                    Attacking_Gun = true;
                    shoot_cd = 5;
                   
                }
            }
        }

        if (astl_anim.GetCurrentAnimatorStateInfo(0).IsName("Astellant_Shoot"))
        {
            Attacking_Gun = true;
           // chase = false;
        }
        else
        {
            Attacking_Gun = false;
            

        }



        if (Astellant_Type == "Hammer")
        {
            astl_anim.SetInteger("Stance", 0);
            if (Hammer_Range.GetComponent<Astellant_Range_Check>().InRange == true && smash_cd == 0)
            {
                //    chase = false;
               

                Attacking_Hammer = true;
                smash_cd= 5;
                astl_anim.SetTrigger("Atk");

            }
        }

        if (astl_anim.GetCurrentAnimatorStateInfo(0).IsName("Astellant_Hammer_Attack"))
        {
            Attacking_Hammer = true;
          //  chase = false;

        }
        else
        {
            Attacking_Hammer = false;

        }


    }

    public void Shoot()
    {
        GameObject bulletshoot = Instantiate(astellant_bullet, bulletspawn.transform.position, transform.rotation);
        bulletshoot.GetComponent<Rigidbody2D>().AddForce(new Vector2(50f * bullet_dir, 0f), ForceMode2D.Impulse);
    }

    public void Hammer_On()
    {
        Astellant_Hammer.GetComponent<Astellant_Hammer_Hitbox>().enabled = true;
        Astellant_Hammer.GetComponent<Collider2D>().enabled = true;

    }
    public void Hammer_Off()
    {
        Astellant_Hammer.GetComponent<Astellant_Hammer_Hitbox>().enabled = false;
        Astellant_Hammer.GetComponent<Collider2D>().enabled = false;

    }


    void PatrolAndCD()
    {

        if (!Attacking_Gun && !Attacking_Hammer)
        {
            patrol += 1;
        }
        if (smash_cd > 0)
        {
            smash_cd -= 1;
        }
        if (shoot_cd > 0)
        {
            shoot_cd -= 1;
        }
    }
}
