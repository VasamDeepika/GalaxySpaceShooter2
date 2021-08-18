using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //if gameOver is true then game over screen disappear
    //press space key to respawn the player
    //else if player is still active then Gameover title will be inactive
    public bool gameOver = true;
    public GameObject player;
    public UIManager uIManager;
    private void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    private void Update()
    {
        if(gameOver == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //gameover screen to be inactive and player needs to respawn
                Instantiate(player, Vector3.zero, Quaternion.identity);
                gameOver = false;
                uIManager.HideGameOverScreen();
            }
        }
    }
}
