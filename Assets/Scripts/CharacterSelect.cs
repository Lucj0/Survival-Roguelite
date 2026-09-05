using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SelectCharacter(CharacterSelection character)
    {
        PlayerData.Instance.currentCharacter = character;
    }
}
