using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimation : MonoBehaviour
{
    private SpriteRenderer star;
    private float _movementSpeed = 0.5f;

    void Start()
    {
        star = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 3f);

    }

    void Update()
    {
        star.color = new Color(star.color.r, star.color.g, star.color.b, Mathf.PingPong(Time.time / 1.5f, 1.0f));


        //Move star
        transform.position += transform.up * Time.deltaTime * _movementSpeed;
    }
}
