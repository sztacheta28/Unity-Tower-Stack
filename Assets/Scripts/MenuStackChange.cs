using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStackChange : MonoBehaviour
{
    private Color currentStartColor;
    private Color targetStartColor;

    public float colorChangeRate = 3;
    private float nextChangeColor = 0;

    private GameObject[] cubesFromStack;

    void Start()
    {
        cubesFromStack = GameObject.FindGameObjectsWithTag("CubeStack");
        currentStartColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        targetStartColor = new Color(Random.value, Random.value, Random.value, 1.0f);
    }

    void Update () {
        if (nextChangeColor < Time.time)
        {
            targetStartColor = new Color(Random.value, Random.value, Random.value, 1.0f);

            nextChangeColor = Time.time + colorChangeRate;
        }

        currentStartColor = Color.Lerp(currentStartColor, targetStartColor, Time.deltaTime / colorChangeRate);

        foreach(GameObject cube in cubesFromStack)
        {
            Mesh mesh = cube.GetComponent<MeshFilter>().mesh;
            Vector3[] vertices = mesh.vertices;
            Color32[] colors = new Color32[vertices.Length];

            for (int i = 0; i < vertices.Length; i++)
            {
                colors[i] = currentStartColor;
            }

            mesh.colors32 = colors;
        }
    }
}
