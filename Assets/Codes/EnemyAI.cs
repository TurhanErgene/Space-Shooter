using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody fizik;
    public float egim;
    public float timeBtwShoots;
    public float startTimeBtwShots;

    public GameObject bullet;
    public Transform bulletExitPoint;

    void Start()
    {
        fizik = GetComponent<Rigidbody>();

    }
    void Update()
    {
        if (timeBtwShoots <= 0)
        {
            Instantiate(bullet, bulletExitPoint.position, Quaternion.identity);
            timeBtwShoots = startTimeBtwShots;
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }        
    }
}
