using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour
{
    private Vector2 startingPosition, maxPosition;
    private bool direction = true;
    public float max;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        maxPosition = startingPosition + new Vector2(0f, max);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = transform.position;
        if(currentPosition.y >= maxPosition.y) {
            direction = false;
        } else if (currentPosition.y < startingPosition.y) {
            direction = true;
        }
        int scalar = direction ? 1 : -1;
        Vector2 V = new Vector2 (0.0f, scalar * 0.0125f);
        transform.position = currentPosition + V;
    }
}
