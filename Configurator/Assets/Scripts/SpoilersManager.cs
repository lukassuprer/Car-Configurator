using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoilersManager : MonoBehaviour
{
    [System.Serializable]
    public class Spoilers
    {
        public GameObject[] spoilerObject;
    }
    
    public List<Spoilers> spoilerList = new List<Spoilers>();
    private int currentSpoiler = 0;

    public void NextSpoiler()
    {
        //spoilerList[currentSpoiler].spoilerObject.GetComponent<Material>().color = ApplyColor.myColour;
        for (int i = 0; i < spoilerList[currentSpoiler].spoilerObject.Length; i++)
        {
            spoilerList[currentSpoiler].spoilerObject[i].SetActive(false);
        }
        currentSpoiler++;
        if (currentSpoiler >= spoilerList.Count)
        {
            currentSpoiler = 0;
        }
        for (int i = 0; i < spoilerList[currentSpoiler].spoilerObject.Length; i++)
        {
            spoilerList[currentSpoiler].spoilerObject[i].SetActive(true);
            spoilerList[currentSpoiler].spoilerObject[i].GetComponent<Renderer>().material.color = ApplyColor.myColour;
        }
        
    }
}
