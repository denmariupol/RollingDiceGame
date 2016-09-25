using UnityEngine;
using System.Collections.Generic;

public class Ground : MonoBehaviour
{
    private int groundSize = 5;

    public GameObject groundPrefab;
    public List<GameObject> tiles = new List<GameObject>();
    void Start ()
    {
        CreateGround(groundSize);
	}
	
	public void CreateGround(int groundSize)
    {
        for(int i = 0;i < groundSize;i++)
        {
            for (int j = 0; j < groundSize;j++)
            {
                GameObject g = Instantiate(groundPrefab, new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                tiles.Add(g);
                g.transform.parent = gameObject.transform;
            }
        }
    }
}
