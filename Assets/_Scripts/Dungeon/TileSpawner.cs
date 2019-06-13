using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    DungeonManager dunMan;

    void Awake()
    {
        dunMan = FindObjectOfType<DungeonManager>();
        GameObject goFloor = Instantiate(dunMan.floorPrefab, transform.position, Quaternion.identity) as GameObject;
        goFloor.name = dunMan.floorPrefab.name;
        goFloor.transform.SetParent(dunMan.transform);

        if(transform.position.x > dunMan.maxX)
        {
            dunMan.maxX = transform.position.x;
        }
        if(transform.position.x < dunMan.minX)
        {
            dunMan.minX = transform.position.x;
        }
        if (transform.position.y > dunMan.maxY)
        {
            dunMan.maxY = transform.position.y;
        }
        if (transform.position.y < dunMan.minY)
        {
            dunMan.minY = transform.position.y;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        LayerMask envMask = LayerMask.GetMask("Wall", "Floor");
        Vector2 hitSize = Vector2.one * 0.8f;
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                Vector2 targetPos = new Vector2(transform.position.x + x, transform.position.y + y);
                Collider2D hit = Physics2D.OverlapBox(targetPos, hitSize, 0, envMask);
                if (!hit)
                {
                    // add a wall
                    GameObject goWall = Instantiate(dunMan.wallPrefab, targetPos, Quaternion.identity) as GameObject;
                    goWall.name = dunMan.wallPrefab.name;
                    goWall.transform.SetParent(dunMan.transform);

                }
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(transform.position, Vector3.one);
    }
}
