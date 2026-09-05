using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health targetHealth;
    [SerializeField] private Image fillImage;
    [SerializeField] private TextMeshProUGUI healthText;

    void Awake()
    {
        targetHealth.OnHealthChanged += UpdateBar;
    }

    void Start()
    {
        UpdateBar(targetHealth.CurrentHealth, targetHealth.MaxHealth);
    }

    void OnDestroy()
    {
        targetHealth.OnHealthChanged -= UpdateBar;
    }

    private void UpdateBar(int current, int max)
    {
        fillImage.fillAmount = (float)current / max;
        healthText.text = $"{current}/{max}";
    }
}
