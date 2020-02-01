using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public int speed;
    int[] sockInventory = new int[20];
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        for (int i =0; i < sockInventory.Length; i++)
        {
            sockInventory[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(speed * Time.deltaTime, speed * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(speed * Time.deltaTime, -speed * Time.deltaTime, 0);
            }
            else
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(-speed * Time.deltaTime, speed * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(-speed * Time.deltaTime, -speed * Time.deltaTime, 0);
            }
            else
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(speed * Time.deltaTime, speed * Time.deltaTime, 0);
                
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-speed * Time.deltaTime, speed * Time.deltaTime, 0);
            }
            else
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(speed * Time.deltaTime, -speed * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-speed * Time.deltaTime, -speed * Time.deltaTime, 0);
            }
            else
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Sock")
        {
            int index = collision.gameObject.GetComponent<SockScript>().pairID;
            sockInventory[index]++;
            Debug.Log(string.Format("Sock added to {0}.", index));
            Destroy(collision.gameObject);
        }     
    }
}
