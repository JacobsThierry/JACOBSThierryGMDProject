using System.Collections.Generic;
using UnityEngine;

public abstract class itemPool
{
    private static List<GameObject> objectList;


    public static List<GameObject> get_items_from_pool(int count)
    {
        if (objectList == null) refillItems();
        List<GameObject> lis = new List<GameObject>();
        for (int i = 0; i < count; i++)
        {
            if (objectList.Count < 1) refillItems(); //this line need to be placed there in case count > ammount of items
            int rand = (int)Random.Range(0, objectList.Count);
            lis.Add(objectList[rand]);
            objectList.RemoveAt(rand);
        }
        return lis;
    }


    private static void refillItems()
    {
        objectList = new List<GameObject>(Resources.LoadAll<GameObject>("Items/Items"));
    }

}