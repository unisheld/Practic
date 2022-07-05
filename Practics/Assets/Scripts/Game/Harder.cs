using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harder : MonoBehaviour
{
    public GameObject detectClicks;
    private bool hard;

    void Update()
    {
        if (CubeJump.count_blocks > 0)
        {
            if (CubeJump.count_blocks % 7 == 0 && !hard)
            {
                print("Harder");
                Camera.main.GetComponent<Animation>().Play("Harder");
                detectClicks.transform.position = new Vector3(8.23f,5.45f,-7.1f);
                detectClicks.transform.eulerAngles = new Vector3(24.45f,-54f,0f);
                hard = true;
            }
            else if ((CubeJump.count_blocks % 7)- 1 == 0 && hard)
            {
                hard = false;
                print("Easier");
                detectClicks.transform.position = new Vector3(0f, 0f, -8.13f);
                detectClicks.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                Camera.main.GetComponent<Animation>().Play("Easier");
                
            }
        }
    }
}
