using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    float time;

    void Start()
    {

        for (float i = 1; i < 100; i++)
        {
            int r = Random.Range(0, 10);
            if (r > 1)
            {
                GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                var cubeRenderer = plane.GetComponent<Renderer>();

                cubeRenderer.material.SetColor("_Color", Color.white);
                plane.transform.position = new Vector3(0f, 0f, i * 20);
                plane.AddComponent<BoxCollider>();

                plane.transform.localScale = new Vector3(2f, 1f, 2f);
                for (float j = 0; j < 5; j++)
                {
                    float randomz = Random.Range(plane.transform.position.z - 10, plane.transform.position.z);
                    float randomx = Random.Range(-9f, 9f);
                    GameObject cube = Instantiate(obj1, new Vector3(randomx, 0.5f, r + randomz), transform.rotation) as GameObject;
                    //cube.rotation
                    cube.name = "Cube";
                }


            }
            if (r < 8)
            {
                GameObject upplane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                var cubeRenderer2 = upplane.GetComponent<Renderer>();
                cubeRenderer2.material.SetColor("_Color", Color.white);
                upplane.AddComponent<BoxCollider>();
                upplane.transform.eulerAngles = new Vector3(180f, 0f, 0f);
                upplane.transform.position = new Vector3(0f, 10f, i * 20);
                upplane.transform.localScale = new Vector3(2f, 1f, 2f);
                for (float j = 0; j < 5; j++)
                {
                    float randomz = Random.Range(upplane.transform.position.z - 10, upplane.transform.position.z);
                    float randomx = Random.Range(-9f, 9f);
                    GameObject cube = Instantiate(obj2, new Vector3(randomx, 9.5f, r + randomz), transform.rotation) as GameObject;
                    cube.name = "TopCube";
                }
            }
        }


    }

    // Update is called once per frame
    void Update()
    {


    }
}
