using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SockScript : MonoBehaviour
{
    public AudioClip pickUp;
    public int pairID;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = pickUp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter()  //Plays Sound Whenever collision detected
    {
        GetComponent<AudioSource>().Play();
    }
}
