using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : MonoBehaviour
{
    private float tripleShotPowerUp = 3.0f;
    //Player player;
    // Start is called before the first frame update
    void Start()
    {
        //player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * tripleShotPowerUp);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //accessing the can
        //player.canTripleShoot = true;
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TripleShotPowerUp();
            }
            this.gameObject.SetActive(false);
        }
    }

}
