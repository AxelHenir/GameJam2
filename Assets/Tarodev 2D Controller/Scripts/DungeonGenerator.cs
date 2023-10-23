using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class DungeonGenerator : MonoBehaviour
{
    public int width = 50;
    public int height = 50;
    public int numRooms = 10;
    public int minRoomSize = 3;
    public int maxRoomSize = 8;
    public TileBase wallTile;
    public TileBase floorTile;
    public Tilemap wallTilemap;
    public Tilemap floorTilemap;

    private List<Rect> rooms = new List<Rect>();
    private int[,] dungeonMap;

    void Start()
    {
        GenerateDungeon();
        CreateDungeonTiles();
    }

    void GenerateDungeon()
    {
        dungeonMap = new int[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                dungeonMap[x, y] = 1; // Initialize with walls
            }
        }

        rooms.Clear();
        for (int i = 0; i < numRooms; i++)
        {
            int roomWidth = Random.Range(minRoomSize, maxRoomSize);
            int roomHeight = Random.Range(minRoomSize, maxRoomSize);
            int x = Random.Range(1, width - roomWidth - 1);
            int y = Random.Range(1, height - roomHeight - 1);

            Rect newRoom = new Rect(x, y, roomWidth, roomHeight);

            bool failed = false;
            foreach (Rect room in rooms)
            {
                if (newRoom.Overlaps(room))
                {
                    failed = true;
                    break;
                }
            }

            if (!failed)
            {
                CreateRoom(newRoom);
                rooms.Add(newRoom);
            }
        }

        ConnectRooms();
    }

    void CreateRoom(Rect room)
    {
        for (int x = (int)room.x; x < room.x + room.width; x++)
        {
            for (int y = (int)room.y; y < room.y + room.height; y++)
            {
                dungeonMap[x, y] = 0; // Fill with floor
            }
        }
    }

    void ConnectRooms()
    {
        for (int i = 1; i < rooms.Count; i++)
        {
            Vector2 center1 = new Vector2(rooms[i].x + rooms[i].width / 2, rooms[i].y + rooms[i].height / 2);
            Vector2 center2 = new Vector2(rooms[i - 1].x + rooms[i - 1].width / 2, rooms[i - 1].y + rooms[i - 1].height / 2);

            if (Random.Range(0, 2) == 0)
            {
                CreateHorizontalTunnel((int)center2.x, (int)center1.x, (int)center2.y);
                CreateVerticalTunnel((int)center2.y, (int)center1.y, (int)center1.x);
            }
            else
            {
                CreateVerticalTunnel((int)center2.y, (int)center1.y, (int)center2.x);
                CreateHorizontalTunnel((int)center2.x, (int)center1.x, (int)center1.y);
            }
        }
    }

    void CreateHorizontalTunnel(int x1, int x2, int y)
    {
        for (int x = Mathf.Min(x1, x2); x <= Mathf.Max(x1, x2); x++)
        {
            dungeonMap[x, y] = 0; // Fill with floor
        }
    }

    void CreateVerticalTunnel(int y1, int y2, int x)
    {
        for (int y = Mathf.Min(y1, y2); y <= Mathf.Max(y1, y2); y++)
        {
            dungeonMap[x, y] = 0; // Fill with floor
        }
    }

    void CreateDungeonTiles()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (dungeonMap[x, y] == 1)
                {
                    wallTilemap.SetTile(new Vector3Int(x, y, 0), wallTile);
                }
                else
                {
                    floorTilemap.SetTile(new Vector3Int(x, y, 0), floorTile);
                }
            }
        }
    }
}
