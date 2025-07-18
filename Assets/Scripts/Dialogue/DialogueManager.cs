using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    private GameObject textBox;

    IEnumerator Start()
    {   
        yield return new WaitForSeconds(0.1f); // Wait for scene to load
        textBox = GameObject.FindGameObjectWithTag("TextBox");
        if (textBox == null)
        {
            Debug.Log("TextBox not found");
            yield break;
        }
          
        GameObject textGO = new GameObject("DialogueText");
        textGO.transform.SetParent(textBox.transform, false);

        textComponent = textGO.AddComponent<TextMeshProUGUI>();

            // Set anchors to stretch inside textbox
        RectTransform rect = textComponent.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0, 0);
        rect.anchorMax = new Vector2(1, 1);
        rect.offsetMin = new Vector2(10, 10);
        rect.offsetMax = new Vector2(-10, -10);

        textComponent.fontSize = 24;
        textComponent.color = Color.white;
        textComponent.alignment = TextAlignmentOptions.TopLeft;
        
        textComponent.text = "Hello, Doki World!";
 
    }

    public void UpdateText(string newText)
    {
        textComponent.text = newText;
    }
}

