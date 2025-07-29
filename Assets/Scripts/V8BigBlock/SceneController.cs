using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    private GameObject background;
    private GameObject monika;
    private GameObject textBox;

    Texture2D textBoxTexture;

    AudioSource audioSource;

    private CharacterManager characterManager; 

    //public Rect t44 = new Rect(100, 100, 100, 100); // Not SDL - Rect and RectTransform are different in Unity

    private void Awake()
    {
        characterManager = FindObjectOfType<CharacterManager>();
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
       
        if (monika != null)
        {
            Destroy(monika);
        }
        audioSource = GetComponent<AudioSource>();
        AudioClip bgm = Resources.Load<AudioClip>("audio/COMEUPOUTDAWAHTA");
        audioSource.clip = bgm;
        audioSource.loop = true;
        audioSource.Play();

        

        // a raw jpg/png needs converting to a texture2D to be used in Resources.Load()
        Texture2D backgroundTexture = Resources.Load<Texture2D>(path);
        Texture2D monikaTexture = Resources.Load<Texture2D>(monikaPath);
        textBoxTexture = Resources.Load<Texture2D>("gui/textbox");

        createTextBox();

        if (backgroundTexture == null)
        {
            Debug.LogError("Failed to load background texture.");
            return;
        }
        Sprite backgroundSprite = Sprite.Create(backgroundTexture, new Rect(0,0, backgroundTexture.width, backgroundTexture.height), new Vector2(0.5f, 0.5f), 100f);
        Sprite monikaSprite = Sprite.Create(monikaTexture, new Rect(0,0, monikaTexture.width, monikaTexture.height), new Vector2(0.5f, 0.5f), 100f);
       

        background = new GameObject("Background");
        monika = new GameObject("Monika");
        
        SpriteRenderer sr = background.AddComponent<SpriteRenderer>();
        sr.sprite = backgroundSprite;
        sr.sortingOrder = -10; // Background should be behind everything else

        SpriteRenderer msr = monika.AddComponent<SpriteRenderer>();
        msr.sprite = monikaSprite;
        msr.sortingOrder = 5; // Monika should be in front of the background

        background.transform.position = Vector3.zero;
        textBox.transform.position = new Vector3(0, -4, 0);
    }

    void createTextBox()
    {
        GameObject canvasGO = new GameObject("Canvas");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        canvasGO.transform.localPosition = Vector3.zero;
        canvasGO.transform.localRotation = Quaternion.identity;
        canvasGO.transform.localScale = Vector3.one;


        textBox = new GameObject("TextBox", typeof(RectTransform));
        textBox.tag = "TextBox";
        textBox.transform.SetParent(canvasGO.transform, false);

        Image img = textBox.AddComponent<Image>();
        Sprite textBoxSprite = Sprite.Create(textBoxTexture, new Rect(0, 0, textBoxTexture.width, textBoxTexture.height), new Vector2(0.5f, 0.5f), 100f);

        img.sprite = textBoxSprite;


        RectTransform textBoxRect = textBox.GetComponent<RectTransform>();
        textBoxRect.anchorMin = new Vector2(0.5f, 0.5f);
        textBoxRect.anchorMax = new Vector2(0.5f, 0.5f);
        textBoxRect.pivot = new Vector2(0.5f, 0.5f);
        textBoxRect.anchoredPosition = Vector2.zero;
        textBoxRect.sizeDelta = new Vector2(600, 150); // width, height

    }

    public void BattleTestScene(string audioFile)
    {
        if (background != null)
        {
            Destroy(background);
        }
        if (monika != null)
        {
            Destroy(monika);
        }
        audioSource = GetComponent<AudioSource>();
        AudioClip bgm = Resources.Load<AudioClip>(audioFile);
        audioSource.clip = bgm;
        audioSource.loop = true;
        audioSource.Play();
        characterManager.LoadCharacters();


    }
}
