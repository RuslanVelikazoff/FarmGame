using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
    [SerializeField] public float offsetDistance = 1f;
    [SerializeField] public float sizeOfInteractableArea = 1.2f;
    
    private CharacterController2D character;
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        character = GetComponent<CharacterController2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseTools();
        }
    }

    private void UseTools()
    {
        Vector2 position = rigidbody2D.position + character.lastMotionVector * offsetDistance;

        Collider2D[] coliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in coliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }

}
