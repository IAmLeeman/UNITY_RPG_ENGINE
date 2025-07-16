using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    private GameObject background;
    private GameObject monika;

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

        Debug.Log("Monika texture: " + (monikaTexture != null ? "Loaded" : "Null"));

        if (backgroundTexture == null)
        {
            Debug.LogError("Failed to load background texture.");
            return;
        }
        Sprite sprite = Sprite.Create(backgroundTexture, new Rect(0,0, backgroundTexture.width, backgroundTexture.height), new Vector2(0.5f, 0.5f), 100f);
        Sprite monikaSprite = Sprite.Create(monikaTexture, new Rect(0,0, monikaTexture.width, monikaTexture.height), new Vector2(0.5f, 0.5f), 100f);
        
        background = new GameObject("Background");
        monika = new GameObject("Monika");

        SpriteRenderer sr = background.AddComponent<SpriteRenderer>();
        sr.sprite = sprite;
        sr.sortingOrder = -10; // Background should be behind everything else

        SpriteRenderer msr = monika.AddComponent<SpriteRenderer>();
        msr.sprite = monikaSprite;
        msr.sortingOrder = 10; // Monika should be in front of the background

        background.transform.position = Vector3.zero;
        Debug.Log("Monika GO final state: position " + monika.transform.position + ", sprite: " + msr.sprite + ", enabled: " + msr.enabled);

    }
}
