using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyExplosion;
    
    public float enemySpeed; //enemy speed
    Animator anim;

    private UIManager uIManager;

    AudioSource audioSource;
    public AudioClip explosionAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //move down 
        transform.Translate(Vector3.down * Time.deltaTime * enemySpeed);

        //when the enemy off the screen on the bottom he needs to respawn with new random x position
        if (transform.position.y<-6.0f)
        {
            transform.position = new Vector3(Random.Range(-8.0f, 8.0f), 6.0f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Laser")
        {
            if (collision.transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            
            this.gameObject.SetActive(false);
            Instantiate(enemyExplosion, transform.position, Quaternion.identity);
            audioSource.clip = explosionAudioClip;
            audioSource.Play();
            uIManager.UpdateScore();
            collision.gameObject.SetActive(false);
        }
        else if(collision.tag == "Player")
        {
            //need to damage player
            Player player = collision.GetComponent<Player>();
            if(player!=null)
            {
                player.Damage();
            }
        }
    }
   
}
