using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canTripleShoot = false;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject laserPrefab, tripleLaserPrefab;
    [SerializeField] float canfire;
    [SerializeField] float fireRate = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontal);
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * vertical);


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
    public void TripleShotPowerUp()
    {
        canTripleShoot = true;
        StartCoroutine(TripleShotPowerdown());
    }
    public IEnumerator TripleShotPowerdown()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShoot = false;
    }
}