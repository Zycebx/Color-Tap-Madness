using UnityEngine;
using TMPro;
//using UnityEngine.UI;
public class TargetColorManager : MonoBehaviour
{   

    public TextMeshProUGUI targetText;

    public string[] colorNames = {"RED", "BLUE", "YELLOW"};

    public Color[] colors={Color.red, Color.blue, Color.yellow};

    public string currentTarget;

    private float timer = 0f;

    public float changeInterval = 1f;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetText.text = "Cole";
        ChangeColor();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            ChangeColor();
            timer = 0f;
        }
    }

    void ChangeColor()
    {
        int rand = Random.Range(0, colorNames.Length);
        currentTarget = colorNames[rand];
        targetText.text = "Target: "+ currentTarget.ToUpper();
        Color ChosenColor = colors[rand];
        ChosenColor.a = 1f;
        targetText.color = ChosenColor;
        Debug.Log("Color Changed"+ targetText.text);
        Debug.Log("Color Now"+ targetText.color);

    }
}
