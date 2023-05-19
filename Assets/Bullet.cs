using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    public string playerTag = "Player";
    public string zombieTag = "Zombie";


    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(zombieTag))
             Destroy(collision.gameObject);
        //Destroy(gameObject);
    }
}