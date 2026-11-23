using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArchiveListItem : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private Button button;

    [Header("Warna Background")]
    [SerializeField] private Color unreadColor = new Color(1f, 1f, 1f, 0f);
    [SerializeField] private Color readColor = new Color(1f, 1f, 1f, 0f);
    [SerializeField] private Color selectedColor = new Color(1f, 0.72f, 0.12f, 0.9f);

    public ArchiveEntry Entry { get; private set; }
    private bool isSelected;

    public void Setup(ArchiveEntry entry, Action<ArchiveListItem> onClick)
    {
        Entry = entry;
        titleText.text = entry.title;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => onClick(this));

        Refresh();
    }

    public void SetSelected(bool value)
    {
        isSelected = value;
        Refresh();
    }

    private void Refresh()
    {
        if (isSelected) background.color = selectedColor;
        else background.color = Entry.isRead ? readColor : unreadColor;
    }
}