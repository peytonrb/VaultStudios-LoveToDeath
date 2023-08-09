using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class AnothaPlayerController : MonoBehaviour
{
    public float speed = 40f;
    public UnityEvent generator;
    private float xInput;
    private float yInput;
    public Rigidbody2D rb;
    public Vector2 movement;
    public GameObject item;
    public ItemValue itemValue;
    public int points;
    public List<string> itemsCollected;
    public bool winLose;
    public Timer timer;
    public bool coroutineFinished;

    [Header("Item Count")]
    public int sodium = 0;
    public int chlorine = 0;
    public int lithium = 0;
    public int potassium = 0;
    public int helium = 0;
    public int nitrogen = 0;
    public int argon = 0;
    public int lead = 0;
    public int oxygen = 0;
    // public RoomFirstGenerator generator;

    [Header("UI")]
    public GameObject finisherScreen;
    public TextMeshProUGUI sodiumText;
    public TextMeshProUGUI chlorineText;
    public TextMeshProUGUI argonText;
    public TextMeshProUGUI lithiumText;
    public TextMeshProUGUI potassiumText;
    public TextMeshProUGUI oxygenText;
    public TextMeshProUGUI nitrogenText;
    public TextMeshProUGUI heliumText;
    public TextMeshProUGUI leadText;
    public GameObject winScreen;
    public GameObject loseScreen;

    void Start()
    {
        finisherScreen.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        coroutineFinished = false;
        itemsCollected = new List<string>();
        generator.Invoke();
        rb.GetComponent<Rigidbody2D>();
        timer = GameObject.Find("EventSystem").GetComponent<Timer>();
    }

    void Update()
    {
        if (timer.levelFinished) // AND timer is finished 
        {
            finisherScreen.SetActive(true);
            sodiumText.text = "" + sodium;
            chlorineText.text = "" + chlorine;
            argonText.text = "" + argon;
            lithiumText.text = "" + lithium;
            potassiumText.text = "" + potassium;
            oxygenText.text = "" + oxygen;
            nitrogenText.text = "" + nitrogen;
            heliumText.text = "" + helium;
            leadText.text = "" + lead;

            if (points >= 100)
                winLose = true;
            else
                winLose = false;

            StartCoroutine(observe());
        }

        if (timer.levelFinished && coroutineFinished)
        {
            if (winLose)
            {
                winScreen.SetActive(true);
            }
            else
            {
                loseScreen.SetActive(true);
            }
        }
    }

    void FixedUpdate()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = movement * speed * Time.fixedDeltaTime;
        // transform.Translate(xInput * speed, yInput * speed, 0f);
    }

    IEnumerator observe()
    {
        yield return new WaitForSeconds(5);
        coroutineFinished = true;
    }

    public void addPoints(int value, string name)
    {
        points += value;
        itemsCollected.Add(name);

        if (name == "Sodium")
        {
            sodium++;
        }
        else if (name == "Chlorine")
        {
            chlorine++;
        }
        else if (name == "Argon")
        {
            argon++;
        }
        else if (name == "Lithium")
        {
            lithium++;
        }
        else if (name == "Potassium")
        {
            potassium++;
        }
        else if (name == "Oxygen")
        {
            oxygen++;
        }
        else if (name == "Nitrogen")
        {
            nitrogen++;
        }
        else if (name == "Helium")
        {
            helium++;
        }
        else if (name == "Lead")
        {
            lead++;
        }
    }
}

