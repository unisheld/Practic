using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObjects : MonoBehaviour
{
    public float speed = 2f, checkPos = 0f;
    private RectTransform rec;

    void Start ()
    {
        rec = GetComponent <RectTransform> ();
    }

    void Update ()
    {
        if ((speed > 0f && rec.offsetMin.y < checkPos) || (speed < 0f && rec.offsetMin.y > checkPos))
        {
        
            rec.offsetMin += new Vector2(rec.offsetMin.x, speed);
            rec.offsetMax += new Vector2(rec.offsetMax.x, speed);
        }
    }
}
