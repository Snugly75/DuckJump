using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    float moved_distance = 0.0f;
    Vector2 move_dir = Vector2.right;
    public float speed = 0.5f;

    void Update()
    {
        Vector2 new_pos = (Vector2)transform.position + (move_dir * speed);
        transform.position = new_pos;
        moved_distance += 0.5f;

        if (moved_distance >= 5.0f)
        {
            moved_distance = 0.0f;
            if (move_dir == Vector2.right)
            {
                move_dir = Vector2.left;
            }
            else if (move_dir == Vector2.left)
            {
                move_dir = Vector2.right;
            }
        }
    }
}
