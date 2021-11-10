using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private int totalPlayers = 2;
    
    private int CurrentPlayer = 0;

    public LayerMask ballsMask;
    
    public GameObject ball;

    private Color[] colours;


    private List<GameObject>[,] balls = new List<GameObject>[6,10];
    
    // Start is called before the first frame update
    void Start()
    {
        colours = new Color[totalPlayers];
        float increment = 360F / colours.Length;
        float currentHue = 0F;
        
        for (int i = 0; i < colours.Length; i++)
        {
            colours[i] = Color.HSVToRGB(currentHue, 1, 1);
            currentHue += increment;
        }
        
        for (int x = 0; x < balls.GetLength(0); x++)
        {
            for (int y = 0; y < balls.GetLength(1); y++)
            {
                balls[x, y] = new List<GameObject>();
            }
        }
        
        Debug.Log("Loaded Main");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hit " + 1/Time.deltaTime);
        
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            Debug.Log("Clicked");
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ballsMask))
                if (hit.transform != null)
                {
                    Vector2 pos = hit.transform.gameObject.GetComponent<Tile>().pos;
                    Debug.Log("Hit " + hit.transform.gameObject.GetComponent<Tile>().pos);
                    GameObject newBall = Instantiate(ball);
                    newBall.transform.position = hit.transform.position + new Vector3(0.2F, 0.4F, 0);
                    newBall.SetActive(true);
                    balls[(int)pos.x, (int)pos.y].Add(newBall);
                }
        }

        for (int x = 0; x < balls.GetLength(0); x++)
        {
            for (int y = 0; y < balls.GetLength(1); y++)
            {
                foreach (GameObject currentBall in balls[x, y])
                {
                    
                    currentBall.transform.RotateAround(new Vector3(x, 1, y), Vector3.up, 80 * Time.deltaTime);
                }
            }
        }
    }

    void addBall(int x, int y)
    {
        
    }
}

class BallBlob
{
    public BallBlob(int size)
    {
        
    }
}