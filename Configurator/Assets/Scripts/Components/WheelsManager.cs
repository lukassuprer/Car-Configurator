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
        public Sprite imageIcon;
        public GameObject wheelsObject;
    }

    public List<Wheels> wheelsList = new List<Wheels>();
    private List<GameObject> buttonsList = new List<GameObject>();
    public Transform wheelHolder;
    public GameObject wheelButton;
    private int currentWheels = 0;
    public Animator animator;
    public static bool isOpened;
    public ChangePosition changePosition;

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
            //button.GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = wheel.index.ToString();
            button.GetComponent<Button>().onClick.AddListener(delegate { NextWheel(wheel.index); });
            button.GetComponent<Button>().onClick.AddListener(delegate { changePosition.OnClickWheelsButton(0); });
            button.GetComponent<Button>().image.sprite = wheel.imageIcon;
            buttonsList.Add(button);
        }
    }
    
    public void OpenUI()
    {
        if (!isOpened)
        {
            Open();
        }else if (isOpened)
        {
            Close();
        }
    }

    public void Open()
    {
        animator.SetBool("open", true);
        isOpened = true;
    }

    public void Close()
    {
        animator.SetBool("open", false);
        isOpened = false;
    }
}
