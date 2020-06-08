using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuController : MonoBehaviour
{

    public GameObject player;

    public GameObject game;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame(){
        gameController pgc = game.GetComponent<gameController>();
        pgc.player = player;
        Instantiate(game, Vector3.zero, Quaternion.Euler(0f,0f,0f) );
        Destroy(gameObject);
    }
}
