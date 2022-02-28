using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelsManager : MonoBehaviour
{
    [System.Serializable]
    public class Wheels
    {
        public GameObject wheelsObject;
    }

    public List<Wheels> wheelsList = new List<Wheels>();
    private int currentWheels = 0;

    public void NextWheel()
    {
        wheelsList[currentWheels].wheelsObject.SetActive(false);
        currentWheels++;
        if (currentWheels >= wheelsList.Count)
        {
            currentWheels = 0;
        }
        wheelsList[currentWheels].wheelsObject.SetActive(true);
    }
}
