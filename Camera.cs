using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    


    void Start()
    {
        //*10 * Time.deltaTime

    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 5.0f, player.transform.position.z-10.0f);

        transform.LookAt(player.transform);
       
    }
    

}
