using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlatformMove : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public Transform desPos;
    public float speed;

    private void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, desPos.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, desPos.position) <= 0.05f)
        {
            if (desPos == endPos) desPos = startPos;
            else desPos = endPos;
        }
    }
}
