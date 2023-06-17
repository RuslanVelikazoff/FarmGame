using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] public float speed = 5f; //Скорость движения предмета к игроку
    [SerializeField] public float pickUpDistance = 1.5f;
    [SerializeField] public float ttl = 10f; //Время жизни предмета
    
    private Transform player;

    private void Awake()
    {
        player = GameManager.instance.player.transform;
    }

    private void Update()
    {
        ttl -= Time.deltaTime;
        if (ttl <= 0)
        {
            Destroy(gameObject);
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > pickUpDistance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position, 
            player.position, 
            speed * Time.deltaTime
            );

        if (distance < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
