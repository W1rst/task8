using UnityEngine;
using TMPro;
using System.Collections;

public class TextElementAnimator : MonoBehaviour
{
    [SerializeField] private Color _basicColorText;

    public IEnumerator FadeInAndMove(TextMeshProUGUI textElement, float duration, float moveDistance, float delay)
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = textElement.transform.localPosition - new Vector3(0, moveDistance, 0);
        Vector3 defaultPosition = textElement.transform.localPosition;
        yield return new WaitForSeconds(delay);

        while (elapsedTime < duration)
        {

            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / duration;
            
            // Fade in
            Color newColor = _basicColorText;
            _basicColorText.a = 1;
            newColor.a = Mathf.Lerp(0f, _basicColorText.a, progress);
            textElement.color = newColor;
            
            // Move up
            Vector3 newPosition = initialPosition;
            newPosition.y += moveDistance * progress;
            textElement.transform.localPosition = newPosition;

            yield return null;
        }

        // textElement.color = _basicColorText;
        textElement.transform.localPosition = defaultPosition;
    }
}
