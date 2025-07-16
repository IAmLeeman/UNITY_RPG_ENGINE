using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private TextMeshProUGUI textComponent;

    void Start()
    {
        GameObject canvasGO = new GameObject("Canvas");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        GameObject textGO = new GameObject("Text");
        textGO.transform.SetParent(canvasGO.transform);

        textComponent = textGO.AddComponent<TextMeshProUGUI>();
        textComponent.text = "Hello, Doki World!";
        textComponent.fontSize = 24;
        textComponent.color = Color.white;

        RectTransform rect = textComponent.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(600, 200);
        rect.anchoredPosition = Vector2.zero;
    }

    public void UpdateText(string newText)
    {
        textComponent.text = newText;
    }
}
}
