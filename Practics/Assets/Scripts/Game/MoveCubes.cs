using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubes : MonoBehaviour
{

    private bool moved = true;
    private Vector3 target;

    void Start()
    {
        target = new Vector3(-4.87f, 5.55f, -0.26f);
    }

    
    void Update()
    {
        if (CubeJump.nextBlock)
        {
            if (transform.position != target)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 7f);
              
            }
            else if (transform.position == target && !moved)
            {
                target = new Vector3(transform.position.x - 2.5f, transform.position.y + 2f, transform.position.z);
                CubeJump.jump = false;
                moved = true;
            }

            if (CubeJump.jump)
                moved = false;
        }
    }
}
