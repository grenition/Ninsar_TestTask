using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//сущность куба
public class CubeEntity
{
    public Vector2Int Position;
    private ColorChanger colorChanger;

    public CubeEntity(Vector2Int pos, ColorChanger colChanger)
    {
        Position = pos;
        colorChanger = colChanger;
    }
    public bool IsEmpty()
    {
        return colorChanger == null;
    }
    public void ChangeColor(int colorId)
    {
        if (IsEmpty())
            return;
        colorChanger.ChangeColor(colorId);
    }
}

public class GeometryMovementController : MonoBehaviour
{
    [SerializeField] private string fileName = "example";
    [SerializeField] private ColorChanger[] cubes;
    
    private int[][] matrix;
    private List<CubeEntity> currentCubes = new List<CubeEntity>();
    private void Awake()
    {
        matrix = StringHelper.GetMatrixFromText(FileReader.ReadTextFile("example.txt"));
        InitializeCubes();
    }
    private void Update()
    {
        if (!Input.anyKeyDown)
            return;

        Vector2Int direction = Vector2Int.zero;
        if (Input.GetKeyDown(KeyCode.W))
            direction += Vector2Int.up;
        if (Input.GetKeyDown(KeyCode.S))
            direction += Vector2Int.down;
        if (Input.GetKeyDown(KeyCode.D))
            direction += Vector2Int.right;
        if (Input.GetKeyDown(KeyCode.A))
            direction += Vector2Int.left;
        MoveCubes(direction);
    }

    //создает и добавляет в список currentCubes сущности кубов
    private void InitializeCubes()
    {
        currentCubes.Clear();

        if (matrix.Length == 0)
            return;
        foreach(var cube in cubes)
        {
            if (cube == null)
                continue;

            int r1 = Random.Range(0, matrix.Length);
            Vector2Int pos = new Vector2Int(r1, Random.Range(0, matrix[r1].Length));

            var entity = new CubeEntity(pos, cube);
            entity.ChangeColor(matrix[pos.y][pos.x]);
            currentCubes.Add(entity);
        }
    }

    //движение кубов по матрице
    private void MoveCubes(Vector2Int direction)
    {
        foreach (CubeEntity cube in currentCubes)
        {
            Vector2Int newPosition = cube.Position += direction;
            newPosition.y = LoopNumber(newPosition.y, matrix.Length);
            newPosition.x = LoopNumber(newPosition.x, matrix[newPosition.y].Length);
            cube.Position = newPosition;
            cube.ChangeColor(matrix[newPosition.y][newPosition.x]);
        }
    }
    private int LoopNumber(int number, int len)
    {
        number %= len;
        if (number < 0)
            number += len;
        return number;
    }
}
