using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCube : MonoBehaviour
{
 
    public GameObject whichCube, selectBtn,mainCube;

    void OnMouseDown()
    {
        if(PlayerPrefs.GetInt("Hearts") >= 2)
        {//Buy
            PlayerPrefs.SetString(whichCube.GetComponent<SelectCube>().nowCube,"Open");
            PlayerPrefs.SetString("Now Cube", whichCube.GetComponent<SelectCube>().nowCube);
            PlayerPrefs.SetInt("Hearts", PlayerPrefs.GetInt("Hearts") - 2);
            mainCube.GetComponent<MeshRenderer>().material = GameObject.Find(whichCube.GetComponent<SelectCube>().nowCube).GetComponent<MeshRenderer>().material;
            selectBtn.SetActive(true);
            gameObject.SetActive(false);
            GetComponentInParent<AudioSource>().Play();
        }
    }
}
