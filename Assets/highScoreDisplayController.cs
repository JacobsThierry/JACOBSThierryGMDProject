using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highScoreDisplayController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        highScoreData scors = saveSystem.LoadHighScore();
        int[] list;
        if(scors != null && scors.highScore != null){
            list = scors.highScore;
        }else{
            list = new int[0];
        }
        
        string s = "";
        for(int i=0; i<list.Length;i++){
            s += "#" + i + " ---- " + list[i].ToString() + " Points\n";
        }
        GetComponent<UnityEngine.UI.Text>().text = s;
    }


}
