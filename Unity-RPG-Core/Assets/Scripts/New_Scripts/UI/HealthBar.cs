using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetMax(int max) => slider.maxValue = max;
    public void Set(int value) => slider.value = value;
}