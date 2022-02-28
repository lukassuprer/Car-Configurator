using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WheelsManager : MonoBehaviour
{
    [System.Serializable]
    public class Wheels
    {
        public int index;
        public GameObject wheelsObject;
    }

    public List<Wheels> wheelsList = new List<Wheels>();
    public Transform wheelHolder;
    public GameObject wheelButton;
    private int currentWheels = 0;

    private void Start()
    {
        SummonUI();
    }
    
    public void NextWheel(int index)
    {
        /*wheelsList[currentWheels].wheelsObject.SetActive(false);
        currentWheels++;
        if (currentWheels >= wheelsList.Count)
        {
            currentWheels = 0;
        }
        wheelsList[currentWheels].wheelsObject.SetActive(true);*/
        
        currentWheels = index;
        for (int i = 0; i < wheelsList.Count; i++)
        {
            wheelsList[i].wheelsObject.SetActive(false);
        }
        for (int i = 0; i < wheelsList.Count; i++)
        {
            wheelsList[currentWheels].wheelsObject.SetActive(true);
        }
    }
    
    private void SummonUI()
    {
        foreach (var wheel in wheelsList)
        {
            GameObject button = Instantiate(wheelButton, wheelHolder.position, wheelHolder.rotation, wheelHolder);
            button.name = wheel.index.ToString();
            button.GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = wheel.index.ToString();
            button.GetComponent<Button>().onClick.AddListener(delegate { NextWheel(wheel.index); });
        }
    }
}
