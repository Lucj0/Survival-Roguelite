using UnityEngine;
using UnityEngine.UI;

public class GrayHealthBar : MonoBehaviour
{
    [SerializeField] private Image grayFill;
    [SerializeField] private Image targetFill;
    [SerializeField] private float speed = 4f;

    void Update()
    {
        if (Mathf.Abs(grayFill.fillAmount - targetFill.fillAmount) > 0.001f)
        {
            grayFill.fillAmount = Mathf.Lerp(grayFill.fillAmount, targetFill.fillAmount, speed * Time.deltaTime);
        }
        else
        {
            grayFill.fillAmount = targetFill.fillAmount;
        }
    }
}
