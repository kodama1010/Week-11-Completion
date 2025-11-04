using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // player movement speed
    private float playerSpeed = 6f;

    // movement input values
    private float horizontalInput;
    private float verticalInput;

    // horizontal and vertical screen limits
    private float horizontalScreenLimit = 9.5f;
    private float minY;
    private float maxY;

    // bullet prefab
    public GameObject bulletPrefab;

    void Start()
    {
        // vertical movement range
        minY = -4f; 
        maxY = 0f;  
    }

    void Update()
    {
        Movement();
        Shooting();
    }

    void Shooting()
    {
        // bullet creation when SPACE is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    void Movement()
    {
        // player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // movement application
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);

        Vector3 pos = transform.position;

        // warp horizonatally
        if (pos.x > horizontalScreenLimit)
            pos.x = -horizontalScreenLimit;
        else if (pos.x < -horizontalScreenLimit)
            pos.x = horizontalScreenLimit;

        // restrict vertical movement to bottom half
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
