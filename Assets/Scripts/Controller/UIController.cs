using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Text resultText;
    [SerializeField]
    private CanvasGroup japaneseSunCanvasGroup;

    private List<int> numbers;
    private int min;
    private int max;

    void Start()
    {
        NumberModel numberModel = Utility.LoadNumberModel();
        min = numberModel.Min;
        max = numberModel.Max;

        SetNumbers();
    }

    public void OnSelectButtonClicked()
    {
        DisplaySelectedNumber();
    }

    private void SetNumbers()
    {
        numbers = new List<int>();
        for (int i = min; i <= max; i++)
        {
            numbers.Add(i);
        }
    }

    private void DisplaySelectedNumber()
    {
        if (numbers.Count == 0)
        {
            return;
        }

        HideJapaneseSun();
        HideBounceResultText();

        float duration = Random.Range(3f, 5f);
        float timePassed = 0f;
        int resultIndex = 0;
        int result = 0;

        LeanTween.value(gameObject, (float value) =>
        {
            if (timePassed > value)
            {
                resultIndex = Random.Range(0, numbers.Count);
                result = numbers[resultIndex];
                resultText.text = result.ToString();
                timePassed = 0f;
            }

            timePassed += Time.deltaTime;
        }, 0f, 1f, duration).setEase(LeanTweenType.easeInCubic).setOnComplete(() =>
        {
            ShowJapaneseSun();
            ShowBounceResultText();
            numbers.RemoveAt(resultIndex);
        });
    }

    private void ShowJapaneseSun()
    {
        LeanTween.alphaCanvas(japaneseSunCanvasGroup, 1f, 1f);
    }

    private void HideJapaneseSun()
    {
        LeanTween.alphaCanvas(japaneseSunCanvasGroup, 0f, 0.5f);
    }

    private void ShowBounceResultText()
    {
        LeanTween.scale(resultText.GetComponent<RectTransform>(), new Vector2(1.2f, 1.2f), 0.4f).setEase(LeanTweenType.pingPong);
    }

    private void HideBounceResultText()
    {
        LeanTween.scale(resultText.GetComponent<RectTransform>(), new Vector2(1f, 1f), 0.4f).setEase(LeanTweenType.easeOutCubic);
    }
}