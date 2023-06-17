using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField] private GameObject pickUpDrop;
    [SerializeField] private int dropCount = 5;
    [SerializeField] private float spread = .7f;
    
    public override void Hit()
    {
        while (dropCount > 0)
        {
            Vector3 position = transform.position;

            position.x += spread * Random.value - spread / 2;
            position.y += spread * Random.value - spread / 2;

            Instantiate(pickUpDrop, position, Quaternion.identity);
            
            dropCount--;
        }

        Destroy(gameObject);
    }
}
