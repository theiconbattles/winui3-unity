using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
	[SerializeField] private RectTransform container;
	[SerializeField] private Image leftCorner;
	[SerializeField] private Image rightCorner;
	[SerializeField] private Image progressBarFill;
	[SerializeField] private Gradient fillGradient;
	[SerializeField, Range(0, 100)] private int value = 100;

	private void OnValidate()
	{
		SetValue(value);
	}

	public void SetValue(int newValue)
	{
		value = newValue;

		float containerWidth = container.sizeDelta.x;
		float fillAmount = value / 100f;
		progressBarFill.fillAmount = fillAmount;
		rightCorner.rectTransform.anchoredPosition = new Vector2(
			Mathf.Max(
				(fillAmount * containerWidth) - containerWidth,
				-containerWidth + 3
			),
			0
		);

		Color currentColor = fillGradient.Evaluate(fillAmount);
		progressBarFill.color = currentColor;
		leftCorner.color = currentColor;
		rightCorner.color = currentColor;
	}
}
