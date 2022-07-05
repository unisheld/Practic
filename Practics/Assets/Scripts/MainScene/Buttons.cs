using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject shopBG;
    public Sprite mus_on, mus_off;
    public float bigger= 1.15f,lower=1.05f;

    void Start()
    {
        if(gameObject.name == "setting")
        {
            if (PlayerPrefs.GetString("Music") == "off")
            {
                transform.GetChild(0).gameObject.GetComponent<Image>().sprite = mus_off;
                Camera.main.GetComponent<AudioListener>().enabled = false;  // Switch off music
            }
        }
    }
   
    void OnMouseDown()
    {
        transform.localScale = new Vector3 (bigger, bigger, bigger);
    }


    void OnMouseUp()
    {
        transform.localScale = new Vector3 (lower, lower, lower);
    }

    void OnMouseUpAsButton()
    {
        GetComponent<AudioSource>().Play();
        switch (gameObject.name)
        {
            case "restart":
                SceneManager.LoadScene("main");
                break;
            case "vk":
                Application.OpenURL("https://vk.com/unisheld");
                break;
            case "Twitter":
                Application.OpenURL("https://twitter.com/Unisheld");
                break;
            case "Facebook":
                Application.OpenURL("https://www.facebook.com/dima.unisheld");
                break;
            case "Music":
                if (PlayerPrefs.GetString("Music") == "off") //Play music now
                {
                    GetComponent<Image>().sprite = mus_on;
                    PlayerPrefs.SetString("Music", "on");
                    Camera.main.GetComponent<AudioListener>().enabled = true;  // Switch on music
                }
                else
                { //Off music
                    GetComponent<Image>().sprite = mus_off;
                    PlayerPrefs.SetString("Music", "off");
                    Camera.main.GetComponent<AudioListener>().enabled = false;  // Switch off music
                }

                break;
            case "settings":
                for (int i = 0; i < transform.childCount; i++)
                    transform.GetChild(i).gameObject.SetActive(!transform.GetChild(i).gameObject.activeSelf);
                break;
            case "shop":
                shopBG.SetActive(!shopBG.activeSelf);
                break;
            case "close":
                
                shopBG.SetActive(false);

                break;
        }

    }
}
