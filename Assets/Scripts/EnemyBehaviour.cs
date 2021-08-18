using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float enemySpeed; //enemy speed
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down 
        transform.Translate(Vector3.down * Time.deltaTime * enemySpeed);
        //when the enemy off the screen on the bottom he needs to respawn with new random x position
        if (transform.position.y<-6.0f)
        {
            transform.position = new Vector3(Random.Range(-8.0f, 8.0f),6.0f,0);
        }
    }
}
