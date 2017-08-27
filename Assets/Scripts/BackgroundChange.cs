using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    public Color currentStartColor = Color.green;
    public Color currentEndColor = Color.yellow;
    private Color targetStartColor = Color.blue;
    private Color targetEndColor = Color.red;

    private Mesh mesh;

    public float colorChangeRate = 5;
    private float nextChangeColor = 0;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        Color[] colors = new Color[mesh.vertices.Length];
        colors[0] = currentStartColor;
        colors[1] = currentEndColor;
        colors[2] = currentStartColor;
        colors[3] = currentEndColor;
        mesh.colors = colors;
    }

    void Update()
    {
        if(nextChangeColor < Time.time)
        {
            targetStartColor = new Color(Random.value, Random.value, Random.value, 1.0f);
            targetEndColor = new Color(Random.value, Random.value, Random.value, 1.0f);

            nextChangeColor = Time.time + colorChangeRate;
        }

        currentStartColor = Color.Lerp(currentStartColor, targetStartColor, Time.deltaTime / colorChangeRate);
        currentEndColor = Color.Lerp(currentEndColor, targetEndColor, Time.deltaTime / colorChangeRate);

        Color[] colors = new Color[mesh.vertices.Length];
        colors[0] = currentStartColor;
        colors[1] = currentEndColor;
        colors[2] = currentStartColor;
        colors[3] = currentEndColor;
        mesh.colors = colors;
    }
}
