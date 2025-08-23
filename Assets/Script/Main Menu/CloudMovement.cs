using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float moveSpeed;

    public Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(transform.position.x > 12)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
