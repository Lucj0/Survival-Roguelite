using UnityEngine;

public enum CharacterSelection
{
    Knight,
    Archer,
    Mage
}


public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance { get; private set; }

    public CharacterSelection currentCharacter;


    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
