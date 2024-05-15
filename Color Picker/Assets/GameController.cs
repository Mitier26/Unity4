using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //TODO:
    //FIXME:
    // 색상을 배열로 등록하고 사용
    // Random.ColorHSV()를 사용
    [SerializeField] private Color[] colorPalette;
    [SerializeField][Range(2, 5)] private int blockCount = 2;
    [SerializeField] private BlockSpawner blockSpawner;

    [SerializeField] private float difficultyModifier;

    private List<Block> blockList = new List<Block>();

    private Color currentColor;
    private Color otherOneColor;

    private int otherBlockIndex;

    private void Awake()
    {
        blockList = blockSpawner.SpawnBlocks(blockCount);
        
        for(int i = 0;  i < blockList.Count; i++)
        {
            blockList[i].Setup(this);
        }

        SetColors();
    }

    private void Start()
    {
        SetColors();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetColors();
        }
    }

private void SetHSVColor()
    {
        Color color = Random.ColorHSV();
        for(int i = 0; i < blockCount; i++)
        {
            blockList[i].Color = color;
        }
    }

    private void SetColors()
    {
        difficultyModifier *= 0.92f;
            
        Color currentColor = colorPalette[Random.Range(0, colorPalette.Length)];

        float diff = (1.0f / 255.0f) * difficultyModifier;
        otherOneColor = new Color(currentColor.r - diff, currentColor.g - diff, currentColor.b - diff);

        otherBlockIndex = Random.Range(0, blockList.Count);
        Debug.Log(otherBlockIndex);

        for (int i = 0; i < blockList.Count; i++)
        {
            if(i == otherBlockIndex)
            {
                blockList[i].Color = otherOneColor;
            }
            else
            {
                blockList[i].Color = currentColor;
            }
        }
    }

    public void CheckBlock(Color color)
    {
        if (blockList[otherBlockIndex].Color == color)
        {
            SetColors();
            Debug.Log("색상 일치");
        }
        else
        {
            Debug.Log("실패...");
            UnityEditor.EditorApplication.ExitPlaymode();
        }
    }
}
