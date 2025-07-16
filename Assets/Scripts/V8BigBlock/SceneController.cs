using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    private GameObject background;

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
    public void testScene()
    {
        if (background != null)
        {
            Destroy(background);
        }
        
        // a raw jpg/png needs converting to a texture2D to be used in Resources.Load()
        Texture2D texture = Resources.Load<Texture2D>("bg/warning");

        if (texture == null)
        {
            Debug.LogError("Failed to load background texture.");
            return;
        }
        Sprite sprite = Sprite.Create(texture, new Rect(0,0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f);
        background = new GameObject("Background");

        SpriteRenderer sr = background.AddComponent<SpriteRenderer>();
        sr.sprite = sprite;

        background.transform.position = Vector3.zero;

    }
}
