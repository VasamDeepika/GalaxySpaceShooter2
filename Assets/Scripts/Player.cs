using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private float horiInput, vertiInput;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    { 
        horiInput = Input.GetAxis("Horizontal");
        vertiInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horiInput);
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * vertiInput);

        //player bounds in y direction
        if(transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if(transform.position.y < -4.0f)
        {
            transform.position = new Vector3(transform.position.x, -4.0f, 0);
        }
        //player bounds in x direction
        /*if(transform.position.x>8.2f)
        {
            transform.position = new Vector3(8.2f, transform.position.y, 0);
        }
        else if (transform.position.x < 8.2f)
        {
            transform.position = new Vector3(-8.2f, transform.position.y, 0);
        }*/
        if (transform.position.x > -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
    }
}
