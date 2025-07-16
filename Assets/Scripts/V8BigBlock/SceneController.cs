using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    private GameObject background;
    private GameObject monika;
    private GameObject textBox;

    //public Rect t44 = new Rect(100, 100, 100, 100); // Not SDL - Rect and RectTransform are different in Unity

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void testScene(string path, string monikaPath)
    {
        if (background != null)
        {
            Destroy(background);
        }
        if (monika != null)
        {
            Destroy(monika);
        }

        // a raw jpg/png needs converting to a texture2D to be used in Resources.Load()
        Texture2D backgroundTexture = Resources.Load<Texture2D>(path);
        Texture2D monikaTexture = Resources.Load<Texture2D>(monikaPath);
        Texture2D textBoxTexture = Resources.Load<Texture2D>("gui/textbox");

        
        if (backgroundTexture == null)
        {
            Debug.LogError("Failed to load background texture.");
            return;
        }
        Sprite backgroundSprite = Sprite.Create(backgroundTexture, new Rect(0,0, backgroundTexture.width, backgroundTexture.height), new Vector2(0.5f, 0.5f), 100f);
        Sprite monikaSprite = Sprite.Create(monikaTexture, new Rect(0,0, monikaTexture.width, monikaTexture.height), new Vector2(0.5f, 0.5f), 100f);
        Sprite textBoxSprite = Sprite.Create(textBoxTexture, new Rect(0,0, textBoxTexture.width, textBoxTexture.height), new Vector2(0.5f, 0.5f), 100f);

        background = new GameObject("Background");
        monika = new GameObject("Monika");
        textBox = new GameObject("TextBox");

        SpriteRenderer sr = background.AddComponent<SpriteRenderer>();
        sr.sprite = backgroundSprite;
        sr.sortingOrder = -10; // Background should be behind everything else

        SpriteRenderer msr = monika.AddComponent<SpriteRenderer>();
        msr.sprite = monikaSprite;
        msr.sortingOrder = 5; // Monika should be in front of the background

        SpriteRenderer tsr = textBox.AddComponent<SpriteRenderer>();
        tsr.sprite = textBoxSprite;
        tsr.sortingOrder = 10; // TextBox should be in front of Monika

        background.transform.position = Vector3.zero;
        textBox.transform.position = new Vector3(0, -4, 0);
    }
}
