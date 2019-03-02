using UnityEngine;
using UnityEngine.Tilemaps;

public class LandPlot
{
    public byte sand { get; set; }
    public byte silt { get; set; }
    public byte clay { get; set; }
    //May turn the texture darker in the future
    public byte orgScore { get; set; }

    //Limiters
    public byte tolerance { get; set; }
    public byte stone { get; set; }

    public Tile tile { get; set; }

    public string Name { get; set; }

    public Tilemap Tilemap { get; set; }

    public Vector3Int LocalPlace { get; set; }

    public Vector3 WorldLocation { get; set; }

    void Start()
    {
        tolerance = 25;
        stone = 25;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTile();
    }

    //Updates the tiles according to land attributes
    private void UpdateTile()
    {
        float average = (sand + silt + clay) / 3;

        float sandDiff = Mathf.Abs(average - sand);
        float siltDiff = Mathf.Abs(average - silt);
        float clayDiff = Mathf.Abs(average - clay);

        float max = Mathf.Max(sand, silt, clay);

        if (average < stone)
        {
            Debug.Log("Stone");
        }
        else if (average > 200 && Mathf.Abs(average - sand) < tolerance && Mathf.Abs(average - silt) < tolerance && Mathf.Abs(average - clay) < tolerance)
        {
            Debug.Log("Balanced");
        }
        else if ((max == sand || max == silt) && Mathf.Abs(sand - silt) < tolerance)
        {
            Debug.Log("Sand_Silt");
        }
        else if ((max == sand || max == clay) && Mathf.Abs(sand - clay) < tolerance)
        {
            Debug.Log("Sand_Clay");
        }
        else if ((max == silt || max == clay) && Mathf.Abs(silt - clay) < tolerance)
        {
            Debug.Log("Silt_Clay");
        }
        else if (max == sand)
        {
            Debug.Log("Sand");
        }
        else if (max == silt)
        {
            Debug.Log("Silt");
        }
        else
        {
            Debug.Log("Clay");
        }
    }
}
