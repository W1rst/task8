using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEffects : MonoBehaviour
{
    [SerializeField] private float tapScaleDuration = 0.1f;
    [SerializeField] private Vector3 tappedScale = new Vector3(0.9f, 0.9f, 0.9f);

    private Button _button;
    private Vector3 _originalScale;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _originalScale = transform.localScale;
        _button.onClick.AddListener(OnButtonTapped);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnButtonTapped);
    }

    private void OnButtonTapped()
    {
        StartCoroutine(TapEffect());
    }

    private IEnumerator TapEffect()
    {
        float elapsedTime = 0f;

        while (elapsedTime < tapScaleDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / tapScaleDuration;
            transform.localScale = Vector3.Lerp(_originalScale, tappedScale, progress);
            yield return null;
        }

        elapsedTime = 0f;

        while (elapsedTime < tapScaleDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / tapScaleDuration;
            transform.localScale = Vector3.Lerp(tappedScale, _originalScale, progress);
            yield return null;
        }

        transform.localScale = _originalScale;
    }
}
