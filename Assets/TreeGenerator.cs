using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TreeGenerator : MonoBehaviour
{
    public Texture2D heightmap;

    Vector3[] matrix;

    public float distanceBetweenTrees;
    public int forestSize;
    [Range(0, 1)]
    public float min;
    [Range(0, 1)]
    public float max;


    public Element[] elements;
    public Transform forest;

#if (UNITY_EDITOR)
    [ContextMenu("GenerateAssets")]
    public void GenerateAssets()
    {

        LoadSurface();
        foreach (Vector3 value in matrix)
        {


            for (int i = 0; i < elements.Length; i++)
            {

                if (min < value.z && value.z < max)
                {
                    Vector3 offset = new Vector3(Random.Range(-0.75f, 0.75f), 0, Random.Range(-0.75f, 0.75f));
                    Vector3 position = new Vector3(value.x * distanceBetweenTrees, 0f, value.y * distanceBetweenTrees) + offset;
                    Vector3 rotation = new Vector3(Random.Range(0, 5f), Random.Range(0, 360), Random.Range(0, 5f));
                    Vector3 scale = Vector3.one * Random.Range(0.75f, 1.25f);

                    GameObject tree = Instantiate(elements[i].GetRandom(), position, Quaternion.identity, forest);
                    //tree.transform.parent = forest;
                    tree.transform.eulerAngles = rotation;
                    tree.transform.localScale = scale;

                    break;
                }
            }

        }

        /*for (float x = 17; x < forestSize + 17; x += distanceBetweenTrees)
        {
            for (float z = 0; z < forestSize; z += distanceBetweenTrees)
            {
                for (int i = 0; i < elements.Length; i++)
                {

                    if (elements[i].CanPlace())
                    {
                        Vector3 offset = new Vector3(Random.Range(-0.75f, 0.75f), 0, Random.Range(-0.75f, 0.75f));
                        Vector3 position = new Vector3(x, 0f, z) + offset;
                        Vector3 rotation = new Vector3(Random.Range(0, 5f), Random.Range(0, 360), Random.Range(0, 5f));
                        Vector3 scale = Vector3.one * Random.Range(0.75f, 1.25f);

                        GameObject tree = Instantiate(elements[i].GetRandom(), position, Quaternion.identity, forest);
                        //tree.transform.parent = forest;
                        tree.transform.eulerAngles = rotation;
                        tree.transform.localScale = scale;
                        break;
                    }
                }

            }

        }*/
    }

    [ContextMenu("DeleteAssets")]
    public void DeleteAssets()
    {
        int nbchildren = forest.transform.childCount;
        for (int i = nbchildren - 1; i >= 0; i--)
        {
            DestroyImmediate(forest.GetChild(i).gameObject);
        }
    }


    public void LoadSurface()
    {
        matrix = new Vector3[heightmap.height * heightmap.width];
        int index = 0;
        for (int y = 0; y < heightmap.height; y++)
        {
            for (int x = 0; x < heightmap.width; x++)
            {

                matrix[index] = new Vector3(x, y, heightmap.GetPixel(x, y).grayscale);
                // Debug.Log(heightmap.GetPixel(x, y).grayscale);
                index++;
            }
        }

    }

#endif


}

[System.SerializableAttribute]
public class Element
{
    public string name;
    [Range(1, 10)]
    public int density;
    public GameObject[] prefabs;

    public bool CanPlace()
    {
        if (Random.Range(1, 10) < density)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public GameObject GetRandom()
    {
        return prefabs[Random.Range(0, prefabs.Length)];
    }
}