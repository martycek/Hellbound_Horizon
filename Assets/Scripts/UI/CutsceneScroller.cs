// CutsceneScroller.cs
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CutsceneScroller : MonoBehaviour
{
    public Image[] panels;
    public float transitionTime = 1f;
    public float scrollSpeed = 50f;

    private int currentPanelIndex = 0;

    void Start()
    {
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        RectTransform[] panelRectTransforms = new RectTransform[panels.Length];

        // Get RectTransform components for all panels
        for (int i = 0; i < panels.Length; i++)
        {
            panelRectTransforms[i] = panels[i].rectTransform;
        }

        // Scroll panels upwards one after another
        foreach (RectTransform panelRectTransform in panelRectTransforms)
        {
            float startTime = Time.time;
            float endTime = startTime + transitionTime;

            // Scroll the panel upwards over time
            while (Time.time < endTime)
            {
                float normalizedTime = (Time.time - startTime) / transitionTime;
                float yOffset = Mathf.Lerp(0f, scrollSpeed, normalizedTime);

                panelRectTransform.anchoredPosition = new Vector2(panelRectTransform.anchoredPosition.x, panelRectTransform.anchoredPosition.y + yOffset);

                yield return null;
            }

            // Reset the panel's position for the next iteration
            panelRectTransform.anchoredPosition = new Vector2(panelRectTransform.anchoredPosition.x, 0f);

            // Wait for a short time before transitioning to the next panel
            yield return new WaitForSeconds(0.5f);
        }

        // Add code to transition to the next scene or perform other actions after the intro.
    }
}
