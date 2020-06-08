using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stars{ // Class used to store the stars on the background and their speed
    public List<GameObject> stars;
    public float speed=5;
    public List<Color> starsColor;
}

public class Background_Controller : MonoBehaviour
{
    public Stars smallStars;
    public Stars bigStars;
    public float speedMultiplier = 1;
    public float maxOffset;
    public List<Sprite> patterns;

    public List<Sprite> Backgrounds;

    

    // Start is called before the first frame update
    void Start()
    {
        addStarss();
        randomBackground();
    }

    private void addStarss(){
        addRandomBigStars();
        addRandomsmallStars();
        int j = UnityEngine.Random.Range(0,7);
        for(int i=0 ; i<j ;i++) addRandomStars();
        
    }


    public void changeBackground(Sprite bg){
        GameObject lebg = transform.Find("back1").gameObject;
        SpriteRenderer sr = lebg.GetComponent<SpriteRenderer>();
        sr.sprite = bg;
    }

    public void randomBackground(){
        Sprite bg = Backgrounds[UnityEngine.Random.Range(0, Backgrounds.Capacity)];
        changeBackground(bg);
    }

    public GameObject addStars(GameObject star, Color colour, Sprite pattern, float speed, float offset){
        GameObject st = Instantiate(star);
        
        Transform parent;

        parent = transform.Find("Stars");
        if(parent == null) parent = transform;

        st.transform.parent = parent;

        st.transform.localRotation = parent.localRotation;
        Vector3 v = parent.transform.localPosition;
        
        v.y += offset;
        st.transform.localPosition = v;
        scrollController sc = st.GetComponent<scrollController>();
        sc.scrollSpeed = speed * speedMultiplier;
        SpriteRenderer sr = st.GetComponent<SpriteRenderer>();
        sr.sprite = pattern;
        sr.color = colour;
        
        return st;
    }

    public GameObject addRandomStars(){
        if(UnityEngine.Random.Range(-1,1) >= 0 )
            return addRandomBigStars();
        else
            return addRandomsmallStars();
    }

private Color getRandomBigColor(){
    return bigStars.starsColor[UnityEngine.Random.Range(0, bigStars.starsColor.Count)];
}

    private Color getRandomSmallColor()
    {
        return smallStars.starsColor[UnityEngine.Random.Range(0, smallStars.starsColor.Count)];
    }

private Sprite getRandomPattern(){
    return patterns[UnityEngine.Random.Range(0, patterns.Count)];
}

    

    private float getRandomOffset(){
        return UnityEngine.Random.Range(-maxOffset, maxOffset);
    }


    private GameObject addRandomBigStars()
    {
        
        return addStars(bigStars.stars[UnityEngine.Random.Range(0, bigStars.stars.Count)], getRandomBigColor(), getRandomPattern(), bigStars.speed, getRandomOffset());
    }

    private GameObject addRandomsmallStars()
    {
        return addStars(smallStars.stars[UnityEngine.Random.Range(0, smallStars.stars.Count)], getRandomSmallColor(), getRandomPattern(), smallStars.speed, getRandomOffset());
    }

    // Update is called once per frame
    void Update()
    {
        Transform parent = transform.Find("Stars");
        if (parent != null){
            foreach(Transform child in parent){
                scrollController sc = child.GetComponent<scrollController>();
                if(sc != null){
                    sc.setSpeed(sc.scrollSpeed * speedMultiplier);
                }
            }
        }
    }




}
