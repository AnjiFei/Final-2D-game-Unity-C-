using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 8f;
    public float yOffset = -0.5f;
    Transform target;
    public GameObject t;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (t == null)
        {
            t = GameObject.FindWithTag("Player");
        }
        target = t.transform;
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
