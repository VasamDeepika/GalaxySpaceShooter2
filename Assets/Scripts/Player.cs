using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool canTripleShoot = false;
    public bool isSpeedPowerUpActive = false;//variable to know whether you collected the speed power up
    public bool isShieldActice = false;

    [SerializeField] float moveSpeed;
    [SerializeField] GameObject laserPrefab, tripleLaserPrefab;
    [SerializeField] float canfire;
    [SerializeField] float fireRate = 0.25f;

    public GameObject playerExplosion;
    public GameObject sheildGameObject;

    public int playerLives = 3;

    private UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        //UIManager = GameObject.FindObjectOfType<Canvas>();
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(uIManager!=null)
        {
            uIManager.UpdateLives(playerLives);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //if speed power up enabled move 2x faster
        //else normal speed

        if (isSpeedPowerUpActive == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * 2.0f * horizontal);
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * 2.0f * vertical);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontal);
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * vertical);
        }


        //Player Y Boundarys
        PlayerMovements();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void PlayerMovements()
    {
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.1f)
        {
            transform.position = new Vector3(transform.position.x, -4.1f, 0);
        }
        //Player X Boundarys
        if (transform.position.x >= 10f)
        {
            transform.position = new Vector3(-10f, transform.position.y, 0);
        }
        else if (transform.position.x <= -10f)
        {
            transform.position = new Vector3(10f, transform.position.y, 0);
        }
    }

    private void Shoot()
    {
        if (Time.time > canfire)
        {
            //if tripleshoot is true shoot three lasers, if not one laser
            if(canTripleShoot == true)
            {
                Instantiate(tripleLaserPrefab, transform.position+ new Vector3(-1f, 1f, 0), Quaternion.identity); // tripleLaser Powerup
            }
            else
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
            }
            
            canfire = Time.time + fireRate;
        }
    }
    public void Damage()
    {
        //subtract 1 live from player lives
        //if live less than 1 destroy player
        //if player has shields do no damage
        if(isShieldActice == true)
        {
            isShieldActice = false;
            sheildGameObject.SetActive(false);
        }
        else
        {
            playerLives--;
            uIManager.UpdateLives(playerLives);
            if (playerLives < 1)
            {

                gameObject.SetActive(false);
                Instantiate(playerExplosion, transform.position, Quaternion.identity);
            }
        }
    }
    public void TripleShotPowerUp()
    {
        canTripleShoot = true;
        StartCoroutine(TripleShotPowerdown());
    }
    
    //method to enable SPEED power up  and power down
    public void SpeedPowerUpON()
    {
        isSpeedPowerUpActive = true;
        StartCoroutine(SpeedPowerDown());
    }
    public void EnableSheild()
    {
        isShieldActice = true;
        sheildGameObject.SetActive(true);
    }

    public IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedPowerUpActive = false;
    }
    public IEnumerator TripleShotPowerdown()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShoot = false;
    }
}