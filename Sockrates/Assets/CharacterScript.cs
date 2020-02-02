using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip wallHit, anger, sockGet, walk;
    
    public int madPercent;
    public int speed;
    public bool walking = false;
    int[] sockInventory = new int[20];
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
        for (int i =0; i < sockInventory.Length; i++)
        {
            sockInventory[i] = 0;
        }
        StartCoroutine(SoundOut());
    }

    // Update is called once per frame
    void Update()
    {
        MoveRobby();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if(collision.gameObject.tag == "exit")
        {
            bool allPaired = true;
            for (int i =0; i < sockInventory.Length; i++)
            {
                allPaired &= sockInventory[i]%2 == 0;
            }
            //We wanna play victory and leave the room. 
            if(allPaired) {
                SceneManager.LoadScene("Victory");
            } else {
                //we need some feedback here on how to sock
            }
            
        }

        if(collision.gameObject.tag == "Sock")
        {
            int index = collision.gameObject.GetComponent<SockScript>().pairID;
            sockInventory[index]++;
            Debug.Log(string.Format("Sock added to {0}.", index));
            Destroy(collision.gameObject);
            audio.PlayOneShot(sockGet);  
            // audio.clip = sockGet;
            // audio.Play();
            return;
        }
        PlayBumpMusic();
    }

    private void PlayBumpMusic() {
        float mad = Random.Range(1f,100f);
        if(mad < madPercent) {
            audio.clip = anger;
            audio.Play();
            return;
        }

        audio.clip = wallHit;
        audio.Play();     
    }

    private void MoveRobby() {
        bool movedThisFrame = false;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(speed * Time.deltaTime, speed * Time.deltaTime, 0);
                movedThisFrame = true;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(speed * Time.deltaTime, -speed * Time.deltaTime, 0);
                movedThisFrame = true;
            }
            else
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
                movedThisFrame = true;
            }
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(-speed * Time.deltaTime, speed * Time.deltaTime, 0);
                movedThisFrame = true;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(-speed * Time.deltaTime, -speed * Time.deltaTime, 0);
                movedThisFrame = true;
            }
            else
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
                movedThisFrame = true;
            }
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(speed * Time.deltaTime, speed * Time.deltaTime, 0);
                movedThisFrame = true;
                
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-speed * Time.deltaTime, speed * Time.deltaTime, 0);
                movedThisFrame = true;
            }
            else
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
                movedThisFrame = true;
            }
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(speed * Time.deltaTime, -speed * Time.deltaTime, 0);
                movedThisFrame = true;
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-speed * Time.deltaTime, -speed * Time.deltaTime, 0);
                movedThisFrame = true;
            }
            else
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
                movedThisFrame = true;
            }
        }
        walking = movedThisFrame;
    }

    IEnumerator SoundOut()
    {
        while (true){
            if(walking) {
                audio.PlayOneShot(walk);  
                Debug.Log("Playing footsteps");
            }
            yield return new WaitForSeconds(0.25f);
        }
    }
}
