using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Jump : MonoBehaviour
{
    public float JumpPower = 300.0f;

    [SerializeField] private LayerMask platformLayerMask;
    BoxCollider2D boxCollider2D;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsGrouded();
        if ( Input.GetMouseButtonDown(0) == true)
        {
            if (IsGrouded() == true)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpPower));   // new Vector2(X√‡, Y√‡);
            }
        }
    }

    public bool IsGrouded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(    boxCollider2D.bounds.center, 
                                                        Vector2.down, 
                                                        boxCollider2D.bounds.extents.y + extraHeight, 
                                                        platformLayerMask);
/*
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(  boxCollider2D.bounds.center, 
                        Vector2.down * (boxCollider2D.bounds.extents.y + extraHeight), 
                        rayColor);
        Debug.Log(raycastHit.collider);
*/
        if (raycastHit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
