using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class MoveTextOnClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("Assign the TextMeshProUGUI child here")]
    public TextMeshProUGUI textElement;

    [Header("Vertical move amount (positive = down, negative = up)")]
    public float moveDistance = 10f;

    private float initialY;

    public void OnPointerDown(PointerEventData eventData)
    {
        textElement.transform.localPosition = new Vector3 (textElement.transform.localPosition.x, initialY + moveDistance, 0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        textElement.transform.localPosition = new Vector3(textElement.transform.localPosition.x, initialY, 0);
    }

    private void Awake()
    {
        if(textElement == null) textElement = GetComponentInChildren<TextMeshProUGUI>();
        initialY = textElement.transform.localPosition.y;
    }
}
