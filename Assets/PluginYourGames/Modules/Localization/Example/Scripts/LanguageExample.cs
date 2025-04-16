﻿using UnityEngine;
using TMPro;
using YG.Insides;

namespace YG.Example
{
    public class LanguageExample : MonoBehaviour
    {
        public string ru, en;

        private TextMeshProUGUI textComponent;

        private void Awake()
        {
            textComponent = GetComponent<TextMeshProUGUI>();
            SwitchLanguage(YG2.lang);
            PlayerPrefs.SetString("lang", YG2.lang);
        }

        private void OnEnable()
        {
            YG2.onSwitchLang += SwitchLanguage;
        }
        private void OnDisable()
        {
            YG2.onSwitchLang -= SwitchLanguage;
        }

        public void SwitchLanguage(string lang)
        {
            PlayerPrefs.SetString("lang", lang);
            switch (lang)
            {
                case "ru":
                    textComponent.text = ru;
                    break;
                default:
                    textComponent.text = en;
                    break;
            }
        }
    }
}