using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    public GameObject patlama;
    public GameObject playerPatlama;
    GameObject GameControl;
    GameControl kontrol;

    void Start()
    {
        GameControl = GameObject.FindGameObjectWithTag("oyunkontrol");
        kontrol = GameControl.GetComponent<GameControl>();
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag!="Boundary")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(patlama,transform.position,transform.rotation);
            kontrol.Score(10);
        }
        if (other.tag == "Player")
        {
            Instantiate(playerPatlama, other.transform.position, other.transform.rotation);
            kontrol.GameOver();
        }
    }
}
