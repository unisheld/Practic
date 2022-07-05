using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectHearts : MonoBehaviour
{
    public AudioClip collectHeart;
    public Text hearts;

    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Heart")
        {
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("Hearts", PlayerPrefs.GetInt("Hearts") + 1);
            hearts.text = PlayerPrefs.GetInt("Hearts").ToString();
            GetComponent<AudioSource>().clip = collectHeart;
            GetComponent<AudioSource>().Play();
        }
    }
}
