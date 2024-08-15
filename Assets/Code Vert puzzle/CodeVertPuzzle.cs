using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CodeVertPuzzle : MonoBehaviour
{
    public TMP_InputField digit1Field;
    public TMP_InputField digit2Field;
    public TMP_InputField digit3Field;
    public TMP_InputField digit4Field;
    public TMP_Text hintText;
    public TMP_Text feedbackText;
    public Button submitButton;
    public Button hintButton;
    public GameObject hintborder;
    private int attempts = 0;
    private string correctAnswer = "3018";
    public GameObject endmessage;

    void Start()
    {
        hintText.gameObject.SetActive(false);
        feedbackText.text = "";
        submitButton.onClick.AddListener(CheckAnswer);
        hintButton.onClick.AddListener(ShowHint);

        digit1Field.characterLimit = 1;
        digit2Field.characterLimit = 1;
        digit3Field.characterLimit = 1;
        digit4Field.characterLimit = 1;

        digit1Field.onValueChanged.AddListener(delegate { ValidateDigit(digit1Field); });
        digit2Field.onValueChanged.AddListener(delegate { ValidateDigit(digit2Field); });
        digit3Field.onValueChanged.AddListener(delegate { ValidateDigit(digit3Field); });
        digit4Field.onValueChanged.AddListener(delegate { ValidateDigit(digit4Field); });
    }

    void ValidateDigit(TMP_InputField input)
    {
        if (input.text.Length > 0 && !char.IsDigit(input.text, 0))
        {
            input.text = "";
        }
    }

    void CheckAnswer()
    {
        string playerAnswer = digit1Field.text + digit2Field.text + digit3Field.text + digit4Field.text;
        if (playerAnswer == correctAnswer)
        {
            feedbackText.text = "Bien joué ! Tu as déchiffré l’énigme";
            StartCoroutine(ShowEndMessageAfterDelay());
        }
        else
        {
            attempts++;
            feedbackText.text = "Incorrect. Essaye encore.";
            if (attempts >= 3)
            {
                feedbackText.text = "La réponse est 3018.";
                StartCoroutine(ShowEndMessageAfterDelay());
            }
        }
    }

    IEnumerator ShowEndMessageAfterDelay()
    {
        yield return new WaitForSeconds(5);
        endmessage.SetActive(true);
       
    }


    void ShowHint()
    {
        hintborder.SetActive(true);
        hintText.gameObject.SetActive(true);
        //hintText.text = "Indice: Le 2ème chiffre est le 0.";

    }
}