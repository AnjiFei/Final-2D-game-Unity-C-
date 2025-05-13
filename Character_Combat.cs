using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Combat : MonoBehaviour
{

    public GameObject bullet_spawn;
    public GameObject bullet_prefab;
    public float bullet_dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Z))
        {

            if (transform.rotation.eulerAngles.y == 0)
            {
                bullet_dir = 1;
            }
            if (transform.rotation.eulerAngles.y == -180)
            {
                bullet_dir = -1;
            }
            GameObject bulletshoot = Instantiate(bullet_prefab, bullet_spawn.transform.position, transform.rotation);
            bulletshoot.GetComponent<Rigidbody2D>().AddForce(new Vector2(50f *bullet_dir, 0f), ForceMode2D.Impulse);
        }
    }
}
