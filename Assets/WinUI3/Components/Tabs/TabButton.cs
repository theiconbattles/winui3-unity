using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
	public Image background;

	private TabGroup tabGroup;
	private GameObject content;

	private void Start()
	{
		background = GetComponent<Image>();
		tabGroup.Subscribe(this, content);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		tabGroup.OnTabSelected(this);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		tabGroup.OnTabEnter(this);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tabGroup.OnTabExit(this);
	}
}
