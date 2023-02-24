using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
	[SerializeField] private Dictionary<TabButton, GameObject> tabs;
	[SerializeField] private Sprite tabInactive;
	[SerializeField] private Sprite tabHover;
	[SerializeField] private Sprite tabActive;
	[SerializeField] private TabButton selectedTab;

	public void Subscribe(TabButton button, GameObject content)
	{
		if (tabs == null) tabs = new Dictionary<TabButton, GameObject>();
		tabs.Add(button, content);
		if (selectedTab == null) selectedTab = button;
		ResetTabs();
	}

	public void OnTabEnter(TabButton button)
	{
		ResetTabs();

		if (selectedTab == button) return;
		button.background.sprite = tabHover;
	}

	public void OnTabExit(TabButton button)
	{
		ResetTabs();
	}

	public void OnTabSelected(TabButton button)
	{
		selectedTab = button;
		tabs[button].SetActive(true);

		ResetTabs();
		button.background.sprite = tabActive;
	}

	public void ResetTabs()
	{
		foreach (var tab in tabs)
		{
			if (selectedTab == tab.Key) continue;
			tab.Key.background.sprite = tabInactive;
			tab.Value.SetActive(false);
		}
	}
}
