using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Block blockPrefab;
    [SerializeField] private GridLayoutGroup gridLayout;

    public List<Block> SpawnBlocks(int blockCount)
    {
        List<Block> blockList = new List<Block>(blockCount * blockCount);

        // 샐 크기
        int cellSize = 300 - 50 * (blockCount - 2);
        gridLayout.cellSize = new Vector2(cellSize, cellSize);

        // 가로에 배치되는 샐 개수
        gridLayout.constraintCount = blockCount;

        // blockCount * blockBount 만큰 블록 생성
        for (int y = 0; y < blockCount; y++)
        {
            for (int x = 0; x < blockCount; x++)
            {
                Block block = Instantiate(blockPrefab, gridLayout.transform);
                blockList.Add(block);
            }
        }

        return blockList;
    }
}
