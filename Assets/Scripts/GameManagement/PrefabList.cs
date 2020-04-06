using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrefabList
{
    private List<GameObjectPair> prefabList;

    //name을 key로 리스트내 해당 원소 리턴
    public GameObject GetGameObjectByName(string n)
    {
        for (int i = 0; i < prefabList.Count; i++){
            if (prefabList[i].name.Equals(n))
                return prefabList[i].gameObject;
        }
        return null;
    }

    //name을 key로 리스트 내에 존재여부를 리턴
    public bool IsExist(string n)
    {
        for (int i = 0; i < prefabList.Count; i++){

            if (prefabList[i].name.Equals(n))
                return true;
        }

        return false;
    }
    public string Debug()
    {
        string s = "";

        for (int i = 0; i < prefabList.Count; i++){
            s += prefabList[i].name + " ";
        }

        return s;
    }

    //생성자
    public PrefabList()
    {
        prefabList = new List<GameObjectPair>();
        Object[] all = Resources.LoadAll("Prefabs");

        for (int i = 0; i < all.Length; i++){
            //Debug.Log("OBJECTNAME:"+all[i].name);
            prefabList.Add
            (
                new GameObjectPair
                (all[i].name, (all[i] as GameObject))
            );
        }
    }
}