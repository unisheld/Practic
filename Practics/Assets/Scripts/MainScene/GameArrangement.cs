using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameArrangement : MonoBehaviour
{
    public GameObject[] cubes;
    public GameObject buttons, m_cube, spawn_blocks,hearts,music;
    public Light dirLight,dirLight_2;
    public Animation cubes_anim,block;
    public Text playTxt, gameName,study, record;

    private bool clicked;

    void Update()
    {
        if (clicked && dirLight.intensity != 0)
            dirLight.intensity -= 0.03f;
        if (clicked && dirLight_2.intensity >= 1.05f)
            dirLight_2.intensity -= 0.025f;
    }

    void OnMouseDown()
    {
        if (!clicked)
        {
            StartCoroutine(delCubes());
            clicked = true; //Works only once 
            playTxt.gameObject.SetActive(false);
            study.gameObject.SetActive(true);
            record.gameObject.SetActive(true);
            hearts.gameObject.SetActive(true);
            //hide settings
            if (music.activeSelf)
            {
                for (int i = 0; i < music.transform.parent.transform.childCount; i++)
                    music.transform.parent.transform.GetChild(i).gameObject.SetActive(!music.transform.parent.transform.GetChild(i).gameObject.activeSelf);
            }

            gameName.text = "0";
            buttons.GetComponent<ScrollObjects>().speed = -2f;
            buttons.GetComponent<ScrollObjects>().checkPos = -220f;
            m_cube.GetComponent<Animation>().Play("StartGameCube");
            StartCoroutine(cubeToblock());
            m_cube.transform.localScale = new Vector3(1f,1f,1f);
            cubes_anim.Play();
        } else if (clicked && study.gameObject.activeSelf)
            study.gameObject.SetActive(false);
    }

    

    IEnumerator delCubes()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
           cubes[i].GetComponent<FallCube>().enabled = true;
        }

        spawn_blocks.GetComponent<SpawnBlocks>().enabled = true;
    }


    IEnumerator cubeToblock()
    {
        yield return new WaitForSeconds(m_cube.GetComponent<Animation>().clip.length + 0.3f);
        block.Play();

        // Add Rigitbody component
        m_cube.AddComponent<Rigidbody>();
    }
}
