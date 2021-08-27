using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    bool CanMove = true;
    Vector3 destiny;
    public float Velocity = 3;
    
    Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        destiny = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        // If player press "AWSD", will make player move 

        if(Input.GetKey(KeyCode.D))
        {
            if(CanMove)
            {
                destiny = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);

                transform.position = Vector3.Lerp(transform.position, destiny, Velocity * Time.deltaTime);
            }
        }
        if(Input.GetKey(KeyCode.A))
        {
            if(CanMove)
            {
                destiny = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);

                transform.position = Vector3.Lerp(transform.position, destiny, Velocity * Time.deltaTime);
            }
        }
        if(Input.GetKey(KeyCode.W))
        {
            if(CanMove)
            {
                destiny = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f);

                transform.position = Vector3.Lerp(transform.position, destiny, Velocity * Time.deltaTime);
            }
        }
        if(Input.GetKey(KeyCode.S))
        {
            if(CanMove)
            {
                destiny = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.5f);

                transform.position = Vector3.Lerp(transform.position, destiny, Velocity * Time.deltaTime);
            }
        }
    }
}
