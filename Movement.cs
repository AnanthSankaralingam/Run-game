using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigidbody;
    Vector3 initial;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        initial = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) //left right movement
            transform.Translate(Vector3.left * Time.deltaTime * 10);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * Time.deltaTime * 10);

        Vector3 gravity = Physics.gravity;
        if (Input.GetKeyDown(KeyCode.Space)) //moves sphere to opposite plane
        {

            if (!(transform.position.y < 9.49 && transform.position.y > 0.51))
                Physics.gravity = Physics.gravity * -1;
        }


        transform.Translate(Vector3.forward * Time.deltaTime * 12); //moving forward

        if (Input.GetKeyDown(KeyCode.UpArrow)) //jumps but gravity not changed
        {
            if (!(transform.position.y < 9.49 && transform.position.y > 0.51))
            {
                if (Physics.gravity.y < 0)
                    rigidbody.AddForce(Vector3.up * 11, ForceMode.Impulse);
                if (Physics.gravity.y > 0)
                    rigidbody.AddForce(Vector3.down * 11, ForceMode.Impulse);
            }
        }
        if (transform.position.y > 10 || transform.position.y < 0) //if out of bounds, restart game
        {

            if (transform.position.y > 10)
            {
                Physics.gravity = Physics.gravity * -1;
                rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            }
            transform.position = initial;
            if (transform.position == initial)
            {
                rigidbody.constraints = RigidbodyConstraints.None;

            }
        }





    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "TopCube")
        {
            if (transform.position.y == 9.5)
                Physics.gravity = Physics.gravity * -1;
            transform.position = initial;
        }
        if (collision.gameObject.name == "Cube")
        {
            transform.position = initial;
        }

    }






}
