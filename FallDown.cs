using UnityEngine;

public class FallDown : MonoBehaviour
{
   
   public float fallSpeed = 3f;
   
   private TargetColorManager targetColorManager;

    void Start()
    {
        targetColorManager = Object.FindFirstObjectByType<TargetColorManager>();
    }

    void Update()
    {
        transform.Translate(Vector3.down*fallSpeed*Time.deltaTime);
        if (transform.position.y < Camera.main.ViewportToWorldPoint(new Vector3(0 ,0, 0)).y - 1f)
        {
            Destroy(gameObject);
        }
        if(Input.GetMouseButtonDown(0))
        {
            //This converts the screen space touch/click position into word space cordinates
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //This checks if any 2D collider if under the touch point, if yes return that collider2D           
            Collider2D hit = Physics2D.OverlapPoint(touchPos);

            if(hit && hit.gameObject == gameObject)
            {
                Color spriteColor = GetComponent<SpriteRenderer>().color;
                string targetColor = targetColorManager.currentTarget.ToLower();
                Debug.Log("Cole");
                Debug.Log(spriteColor);
                Debug.Log(targetColor);
                Debug.Log("Cole");
                if(MatchesColor(targetColor))
                {
                    Debug.Log("Correct Tap!");
                    GameManager.Instance.AddScore();
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("Wrong Tap!");
                    GameManager.Instance.LoseLife();
                    Destroy(gameObject);
                }
                
            }
        
        }   

    }

    bool MatchesColor(string target)
{
    Color spriteColor = GetComponent<SpriteRenderer>().color;
    Color targetColor = Color.white;


    if (target == "red") targetColor = Color.red;
    else if (target == "blue") targetColor = Color.blue;
    else if (target == "green") targetColor = Color.green;


    return ColorsMatch(spriteColor, targetColor);
}


bool ColorsMatch(Color a, Color b)
{
    float tolerance = 0.01f;
    return Mathf.Abs(a.r - b.r) < tolerance &&
           Mathf.Abs(a.g - b.g) < tolerance &&
           Mathf.Abs(a.b - b.b) < tolerance;
}

}
