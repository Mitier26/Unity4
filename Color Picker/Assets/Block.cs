using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Block : MonoBehaviour, IPointerDownHandler
{
    // IPointerDownHandler : UI 에 있는 것을 클릭했을 때 이벤트를 처리하기 위한 것
    private Image image;
    private GameController gameController;

    public Color Color
    {
        set => image.color = value;
        get => image.color;
    }

    public void Setup(GameController gameController)
    {
        image = GetComponent<Image>();
        this.gameController = gameController;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameController.CheckBlock(Color);
    }
}
