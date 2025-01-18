using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    private Vector3 boardOrigin;
    public GameObject chessboard;
    public float gridSize = 1.49f;
    public int gridCount = 8;
    public Material borderMaterial;

    private void Start()
    {
        // Calculate the board origin
        Vector3 boardPosition = chessboard.transform.position;
        Vector3 boardScale = chessboard.transform.localScale;

        boardOrigin = new Vector3(
            boardPosition.x - (boardScale.x / 2) * gridSize,
            boardPosition.y,
            boardPosition.z - (boardScale.z / 2) * gridSize
        );

        DrawGridBorders();
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 snappedPosition = new Vector3(
            Mathf.Round((worldPosition.x - boardOrigin.x) / gridSize) * gridSize + boardOrigin.x,
            transform.position.y,
            Mathf.Round((worldPosition.z - boardOrigin.z) / gridSize) * gridSize + boardOrigin.z
        );

        transform.position = ClampToChessboard(snappedPosition);
    }

    private Vector3 ClampToChessboard(Vector3 position)
    {
        float minX = boardOrigin.x;
        float maxX = boardOrigin.x + (gridSize * (gridCount - 1));
        float minZ = boardOrigin.z;
        float maxZ = boardOrigin.z + (gridSize * (gridCount - 1));

        float clampedX = Mathf.Clamp(position.x, minX, maxX);
        float clampedZ = Mathf.Clamp(position.z, minZ, maxZ);

        return new Vector3(clampedX, position.y, clampedZ);
    }

    private void DrawGridBorders()
    {
        // Can see the lines 

        GameObject gridBorders = new GameObject("GridBorders");

        for (int i = 0; i <= gridCount; i++)
        {
            CreateLine(new Vector3(boardOrigin.x, boardOrigin.y, boardOrigin.z + i * gridSize), 
                       new Vector3(boardOrigin.x + (gridCount - 1) * gridSize, boardOrigin.y, boardOrigin.z + i * gridSize));

            CreateLine(new Vector3(boardOrigin.x + i * gridSize, boardOrigin.y, boardOrigin.z),
                       new Vector3(boardOrigin.x + i * gridSize, boardOrigin.y, boardOrigin.z + (gridCount - 1) * gridSize));
        }
    }

    private void CreateLine(Vector3 start, Vector3 end)
    {
        GameObject lineObj = new GameObject("GridLine");
        LineRenderer lineRenderer = lineObj.AddComponent<LineRenderer>();

        lineRenderer.material = borderMaterial;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);

        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
    }
}
