using UnityEngine;
using UnityEngine.UI;

public class UIBackgroundGradient : MonoBehaviour
{
    public GradientData gradientData;
    public float changeSpeed = 0.001f;

    private Image image;
    private float t;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        t += Time.deltaTime * changeSpeed / 2;
        image.color = gradientData.gradient.Evaluate(Mathf.PingPong(t, 1));
    }
}
