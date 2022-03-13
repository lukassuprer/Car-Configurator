using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.UI;
using UnityEngine.UI;
using TMPro;

public class SaveManager : MonoBehaviour
{
    private SaveObject saveObject;
    public SaveDataList saveDataList = new SaveDataList();
    public SpoilersManager spoilersManager;
    public WheelsManager wheelsManager;
    public ApplyColor applyColor;
    
    public GameObject saveButton;
    public Transform saveHolder;
    public TMP_InputField inputDeleteField;
    public GameObject enterButton;
    private string path => $"{Application.dataPath}/SavedPresets.json";
    

//Classa s listem z toho objekt a ten uložit
    private void Start()
    {
        saveObject = new SaveObject();
        SetValues();
        //SaveDataList saveList = GetSaveData();
        saveDataList = GetSaveData();
        SpawnUISave();
        saveDataList.saveList.Add(saveObject);
        //saveList.saveList.Add(saveObject);
        //SaveData(saveList);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            //SaveDataList saveList = GetSaveData();
            //saveDataList = GetSaveData();
            SaveData(saveDataList);
            /*saveObject = new SaveObject();
            string json = JsonUtility.ToJson(saveObject);
            Debug.Log(json);*/
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            //SaveDataList saveList = GetSaveData();
        }

        if (saveDataList.saveList.Count <= 0)
        {
            saveObject = new SaveObject();
            SetValues();
            saveDataList.saveList.Add(saveObject);
        }
    }

    private void SaveData(SaveDataList saveList)
    {
        //saveDataList.saveList.Add(saveObject);
        /*string json = JsonUtility.ToJson(saveList);
        if (!File.Exists(path))
        {
            File.WriteAllText(path, json);
        }
        else
        {
            File.AppendAllText(path, json);
        }*/
        using (StreamWriter stream = new StreamWriter(path))
        {
            string json = JsonUtility.ToJson(saveDataList, true);
            Debug.Log(json);
            stream.Write(json);
        }
        //SpawnUISave();
        /*saveObject = new SaveObject();
        saveDataList.saveList.Add(saveObject);*/
    }

    private SaveDataList GetSaveData()
    {
        /*string json = File.ReadAllText(path);
        Debug.Log(json);
        return JsonUtility.FromJson<SaveList>(json);*/

        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
            return new SaveDataList();
        }
        using(StreamReader stream = new StreamReader(path))
        {
            string json = stream.ReadToEnd();
            return JsonUtility.FromJson<SaveDataList>(json);
        }
    }

    //Buttons send shit to object
    public void SetColorName(string colorName)
    {
        saveObject.colorName = colorName;
        Debug.Log(saveObject.colorName);
    }

    public void SetSpoilerIndex(int spoilerIndex)
    {
        saveObject.spoilerIndex = spoilerIndex;
    }

    public void SetWheelsIndex(int wheelsIndex)
    {
        saveObject.wheelsIndex = wheelsIndex;
    }
    
    //Buttons load shit from list
    public void GetValues(int index)
    {
        //Color
        ColorUtility.TryParseHtmlString(saveDataList.saveList[index].colorName, out ApplyColor.myColour);
        spoilersManager.SetColor();
        applyColor.material.color = ApplyColor.myColour;
        //Spoiler
        int spoilerIndex = saveDataList.saveList[index].spoilerIndex;
        spoilersManager.NextSpoiler(spoilerIndex);
        //Wheels
        int wheelsIndex = saveDataList.saveList[index].wheelsIndex;
        wheelsManager.NextWheel(wheelsIndex);
    }

    public void SaveButton()
    {
        inputDeleteField.gameObject.SetActive(true);
        enterButton.SetActive(true);
    }

    public void EnterButton()
    {
        saveObject.presetName = inputDeleteField.text;
        enterButton.SetActive(false);
        inputDeleteField.gameObject.SetActive(false);
        //saveDataList.saveList.Add(saveObject);
        SaveData(saveDataList);
        saveDataList = GetSaveData();
        SpawnUISave();
        saveObject = new SaveObject();
        SetValues();
        saveDataList.saveList.Add(saveObject);
    }

    public void CancelButton()
    {
        
    }
    public void DeletePreset(int index)
    {
        if (index < saveDataList.saveList.Count)
        {
            saveDataList.saveList.RemoveAt(index);
            saveDataList.saveList.RemoveAt(saveDataList.saveList.Count - 1);
            Debug.Log(saveDataList.saveList.Count);
            SaveData(saveDataList);
            saveDataList = GetSaveData();
            SpawnUISave();
            saveObject = new SaveObject();
            SetValues();
            saveDataList.saveList.Add(saveObject);
        }
    }

    private void SetValues()
    {
        saveObject.colorName = applyColor.myStringColor;
        saveObject.spoilerIndex = spoilersManager.currentSpoiler;
        saveObject.wheelsIndex = wheelsManager.currentWheels;
    }

    private void SpawnUISave()
    {
        foreach (Transform child in saveHolder)
        {
            Destroy(child.gameObject);
        }

        foreach (var save in saveDataList.saveList)
        {
            GameObject button = Instantiate(saveButton, saveHolder.position, saveHolder.rotation, saveHolder);
            Button objectButton = button.GetComponent<Button>();
            objectButton.onClick.AddListener(delegate { GetValues(saveDataList.saveList.IndexOf(save)); });
            objectButton.GetComponentInChildren<TextMeshProUGUI>().text = save.presetName;
            objectButton.GetComponentInChildren<TextMeshProUGUI>().fontSize = 9;
            objectButton.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
            button.GetComponent<Outline>().effectColor = Color.black;
            
            GameObject buttonDelete = Instantiate(saveButton, saveHolder.position, saveHolder.rotation, saveHolder);
            buttonDelete.GetComponentInChildren<TextMeshProUGUI>().text = "DELETE";
            buttonDelete.GetComponentInChildren<TextMeshProUGUI>().fontSize = 9;
            buttonDelete.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
            buttonDelete.GetComponent<Button>().onClick.AddListener(delegate { DeletePreset(saveDataList.saveList.IndexOf(save)); });
        }
    }
}