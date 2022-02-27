using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonAnimation : MonoBehaviour
{
    public Animator menuAnimator;
    public Animator buttonAnimator;
    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI wheelText;
    public TextMeshProUGUI spoilerText;
    private bool isOpened;

    public void OnClick()
    {
        if (isOpened == false)
        {
            Debug.Log("opened");
            menuAnimator.SetBool("open", true);
            buttonAnimator.SetBool("open", true);
            buttonText.text = ">";
            spoilerText.text = "s";
            wheelText.text = "w";
            isOpened = true;
        }
        else
        {
            menuAnimator.SetBool("open", false);
            buttonAnimator.SetBool("open", false);
            buttonText.text = "<";
            spoilerText.text = "";
            wheelText.text = "";
            isOpened = false;
        }
    }
}
