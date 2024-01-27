using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVDLogo : MonoBehaviour
{
    // Speed it moves at
    public float speed = 5;

    // Bounds of the screen
    public float X_Max = 5, Y_Max = 4;

    // Current direction
    private Vector3 direction;

    // Scale factor
    public float scaleSpeed = 0.1f;
    private bool isGrowing = true;
    public float maxScale = 2.0f;
    public float minScale = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Randomly initialize direction
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction.Normalize();
    }

    private void FlipDirectionX()
    {
        direction.x *= -1;
        direction.x += Random.Range(-0.1f, 0.1f);
        direction.y += Random.Range(-0.1f, 0.1f);
        direction.Normalize();
    }

    private void FlipDirectionY()
    {
        direction.y *= -1;
        direction.x += Random.Range(-0.1f, 0.1f);
        direction.y += Random.Range(-0.1f, 0.1f);
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        // Move in direction unless we'd go out of bounds, if so bounce with some randomness
        Vector3 newPosition = transform.position + direction * Time.deltaTime * speed;

        // See if a bounce needs to happen before moving
        if (newPosition.x > X_Max || newPosition.x < -X_Max)
        {
            FlipDirectionX();
        }

        if (newPosition.y > Y_Max || newPosition.y < -Y_Max)
        {
            FlipDirectionY();
        }

        // Update the scale
        UpdateScale();

        // Update the position
        transform.position += direction * Time.deltaTime * speed;
    }

    void UpdateScale()
    {
        float newScale = transform.localScale.x;

        if (isGrowing)
        {
            newScale += scaleSpeed * Time.deltaTime;
            if (newScale >= maxScale)
            {
                newScale = maxScale;
                isGrowing = false;
            }
        }
        else
        {
            newScale -= scaleSpeed * Time.deltaTime;
            if (newScale <= minScale)
            {
                newScale = minScale;
                isGrowing = true;
            }
        }

        transform.localScale = new Vector3(newScale, newScale, 1.0f);
    }
}






