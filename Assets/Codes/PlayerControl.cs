using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody fizik;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vec;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float egim;
    public float playerSpeed;
    float shotTiming = 0;
    public float shotReload=0;

    public GameObject bullet;
    public Transform bulletExitPoint;

    void Start()
    {
        fizik = GetComponent<Rigidbody>();
    }
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > shotTiming)
        {
            shotTiming = Time.time + shotReload;
            //Instantiate: object, pozisyon, rotasyon 
            Instantiate(bullet, bulletExitPoint.position,Quaternion.identity);
        }
    }
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        vec = new Vector3(horizontal,0,vertical);

        fizik.velocity = vec* playerSpeed;
        //Movement border
        fizik.position = new Vector3(
            Mathf.Clamp(fizik.position.x,minX,maxX),
            0.0f,
            Mathf.Clamp(fizik.position.z,minZ,maxZ)
            );
        //rotating on moving
        fizik.rotation = Quaternion.Euler(0,0,fizik.velocity.x*-egim);

    }
}
