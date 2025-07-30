using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CardSymbol : MonoBehaviour
{
    [SerializeField] public CardVisual cardVisual;
    [SerializeField] private Image image;
    [SerializeField] private List<int> listNumbers = new List<int>();
    private void Awake()
    {
        image = GetComponent<Image>();
        image.enabled = false;
        if(listNumbers==null) listNumbers = new List<int>();
        if (listNumbers.Count==0)
        {
            listNumbers.Add(2);
        }
        cardVisual.onInitialize.AddListener(UpdateVisual);
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        int number = cardVisual.cardNumber;
        image.enabled = listNumbers.Contains(number);
        image.sprite = cardVisual.cardSprites[(int)cardVisual.cardType];
        image.color = ( (int)cardVisual.cardType > 1 ) ? Color.white : Color.red;
    }
}