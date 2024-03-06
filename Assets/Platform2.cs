using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector2 move_dir = Vector2.right;
    public float distance = 2.0f;
    public float move_time = 4.0f;
    public void Start()
    {
        StartCoroutine(moveTime((Vector2)transform.position + move_dir * distance, move_time));
    }

    IEnumerator moveTime(Vector2 targetLocation, float targetTime)
    {
        float passedTime = 0.0f;
        Vector2 defaultLocation = transform.position;
        while (passedTime < targetTime)
        {
            Vector2 new_pos = Vector2.Lerp(defaultLocation, targetLocation, passedTime / targetTime);
            transform.position = new_pos;
            passedTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        arrived();
    }

    public void arrived()
    {
        move_dir *= -1.0f;
        StartCoroutine(moveTime((Vector2)transform.position + move_dir * distance, move_time));
    }
}
