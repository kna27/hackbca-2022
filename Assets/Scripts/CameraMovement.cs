using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    private Transform target;
    private Vector3 startPos;
    private void Start()
    {
        target = GameObject.Find("Duck").transform;
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target.GetComponent<Duck>().launched)
        {
            if (target && target.GetComponent<Rigidbody2D>().velocity.y > -15)
            {
                Vector3 newPosition = target.position;
                newPosition.z = -10;
                transform.position = newPosition;
            }
        }
        if(!target.GetComponent<Duck>().launched)
        {
            transform.position = startPos;
        }
    }
}