using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public TextMeshProUGUI valueText;

    public void UpdateCoin(int maxValue)
    {
        int currentValue = int.Parse(valueText.text);
        int newValue = ++currentValue;
        if (newValue < maxValue)
            valueText.text = newValue.ToString();
    }
}
