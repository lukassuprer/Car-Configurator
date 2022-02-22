using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonAnimation : MonoBehaviour
{
    public Animator menuAnimator;
    public Animator buttonAnimator;
    public TextMeshProUGUI buttonText;
    private bool isOpened;
    public void OnClick()
    {
        if (isOpened == false)
        {
            menuAnimator.SetBool("open", true);
            buttonAnimator.SetBool("open", true);
            buttonText.text = ">";
            isOpened = true;
        }
        else
        {
            menuAnimator.SetBool("open", false);
            buttonAnimator.SetBool("open", false);
            buttonText.text = "<";
            isOpened = false;
        }
    }
}
