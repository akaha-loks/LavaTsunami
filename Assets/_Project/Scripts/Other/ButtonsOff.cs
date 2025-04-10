using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsOff : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image levelImage;
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        if (button.interactable)
        {
            levelImage.color = new Color(0, 0, 0, 200);
            text.color = new Color(255, 255, 255, 50);
        }
    }
}