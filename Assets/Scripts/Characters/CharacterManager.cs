using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Character/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public Sprite characterSprite; // Add more sprites as needed.
    
}

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance { get; private set; }

    [SerializeField]
    private List<CharacterData> characterList;
    private Dictionary<string, CharacterData> characterMap = new Dictionary<string, CharacterData>();

    private GameObject monika;

    private void Awake()
    {
        
        if (Instance == null) {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
       
    }
    public void LoadCharacters()
    {
        string[] characterNames = {"monika"};
        foreach (string name in characterNames)
        {
            CharacterData assets = new CharacterData();
            

            assets.characterSprite = Resources.Load<Sprite>("monika/3a");
            monika = new GameObject("Monika");

            SpriteRenderer msr = monika.AddComponent<SpriteRenderer>();
            msr.sprite = assets.characterSprite;
            msr.sortingOrder = 5; // Monika should be in front of the background

        }

    }
    
}
