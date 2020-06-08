using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class saveSystem
{




    public static void addHighScore(int score){
        highScoreData Data = LoadHighScore();
        List<int> list;
        if(Data == null || Data.highScore == null){
            list = new List<int>();
            Data = new highScoreData();
        }else{
            list = new List<int>(Data.highScore);
        }
        list.Add(score);
        list.Sort((a, b) => b.CompareTo(a)); //sort the list asc
        List<int> l2 = new List<int>();
        int max = list.Count>10?10:list.Count;
        for(int i = 0; i<max;i++){
            l2.Add(list[i]);
        }
        Data.highScore = l2.ToArray();
        for(int i=0; i<Data.highScore.Length;i++){
        Debug.Log("al " + Data.highScore[i]);
        }
        SaveHighScore(Data);
    }

    private static void SaveHighScore(highScoreData d)
    {

        if(d == null || d.highScore == null || d.highScore.Length < 1){
            return;
        }else{
            string path = Application.persistentDataPath + "/highScore.woo";
            FileStream stream = new FileStream(path, FileMode.Create);
            try{
            BinaryFormatter formatter = new BinaryFormatter();
            
            stream.Seek(0, SeekOrigin.Begin);

            formatter.Serialize(stream, d);
            }finally{
            stream.Close();
            }
        }
    }

    public static highScoreData LoadHighScore(){
        string path = Application.persistentDataPath + "/highScore.woo";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            highScoreData data = new highScoreData();
            try{
            stream.Seek(0, SeekOrigin.Begin);
            data = (highScoreData)formatter.Deserialize(stream);
            }finally{
            stream.Close();
            }
            return data;

        }else{
            return null;
        }
    }

}
