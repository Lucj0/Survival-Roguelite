using UnityEngine;
using System.Collections;

public class EndScreenManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup endScreenGroup;

    private IEnumerator PreWarmEndScreen()
    {
        endScreenGroup.gameObject.SetActive(true);
        yield return null;

        endScreenGroup.gameObject.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(PreWarmEndScreen());
    }


    void OnEnable()
    {
        PlayerDeath.OnPlayerDeath += ShowEndScreen;
    }

    void OnDisable()
    {
        PlayerDeath.OnPlayerDeath -= ShowEndScreen;
    }

    void ShowEndScreen()
    {
        endScreenGroup.alpha = 1f;
        endScreenGroup.interactable = true;
        endScreenGroup.blocksRaycasts = true;
        endScreenGroup.gameObject.SetActive(true);
    }
}
