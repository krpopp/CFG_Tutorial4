using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TMP_Text dialogueText;
    public GameObject dialogueObj;

    float timer;
    public float resetTime;

    void Start()
    {
        timer = resetTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (dialogueObj.activeSelf)
            {
                dialogueObj.SetActive(false);
            }
            //if the dialogue is active, turn it off
        }
    }

    public void SetDialogueText(string newDialogueLine)
    {
        dialogueObj.SetActive(true);
        dialogueText.text = newDialogueLine;
        timer = resetTime;
    }
}
