using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{

    public static bool paused = false;

    public GameObject pauseMenueUI;

    private UnityEngine.EventSystems.EventSystem system;

    // Start is called before the first frame update
    void Start()
    {
        system = transform.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>();
        system.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        print("pause key =" + (Input.GetKeyDown("escape") || Input.GetKeyDown("joystick button 6")) );
        if(Input.GetKeyDown("escape") || Input.GetKeyDown("joystick button 6") ){
            if(paused){
                resume();
            }else{
                pause();
            }
        }
    }

    public void pause(){
        system.gameObject.SetActive(true);
        pauseMenueUI.SetActive(true);
        try{
            pauseMenueUI.transform.Find("Resume").gameObject.GetComponent<UnityEngine.UI.Button>().Select();
        }catch{
            print("pasmarché");
        }
        Time.timeScale = 0f;
        paused = true;

    }

public void exitGame(){
    Time.timeScale = 1f;
    Destroy(GameObject.Find("game"));
}
    public void resume(){
        system.gameObject.SetActive(false);
        pauseMenueUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }
}
