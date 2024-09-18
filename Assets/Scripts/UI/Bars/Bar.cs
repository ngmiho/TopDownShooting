using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Image fillBar;
    public TextMeshProUGUI valueText;

    public void UpdateBar(int currentValue, int maxValue)
    {
        valueText.text = currentValue.ToString() + " / " + maxValue.ToString();
        if (fillBar != null)
            fillBar.fillAmount = (float)currentValue / (float)maxValue;
    }
}
