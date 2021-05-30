﻿using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
/// This script is responsible for the host dialogues in the opening scenes before MiniGame1 and 2.
public class DialogueManager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private TextMeshProUGUI hostDialogueText;

    [SerializeField] private string[] hostDialogueSentences;

    [SerializeField] private GameObject hostContinueButton;

    private int hostIndex;
    private Scene currentScene;
    private string sceneName;

    private void Start()
    {
        StartCoroutine(hostDialogue());
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }
    private IEnumerator hostDialogue()
    {
        foreach (char letter in hostDialogueSentences[hostIndex].ToCharArray())
        {
            hostDialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        hostContinueButton.SetActive(true);
    }

    /// This function is responsible for transitioning scenes.
    public void ContinueHostDialogue()
    {
        if (hostIndex < hostDialogueSentences.Length - 1){
            hostContinueButton.SetActive(false);
            hostIndex++;
            hostDialogueText.text = string.Empty;
            StartCoroutine(hostDialogue());
        }
        else{
            if (sceneName == "Lvl4_MG1_Scene1")
                SceneManager.LoadScene("Lvl4_MG1_Scene2");
            else if (sceneName == "Lvl4_MG2_Scene1")
                SceneManager.LoadScene("Lvl4_MG2_Scene2");
            else if (sceneName == "LastScene")
                SceneManager.LoadScene("Menu");
        }
    }
}
