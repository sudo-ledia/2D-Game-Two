using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerActivation : MonoBehaviour
{

    public GameManager manager;
    public Tower towerScript;
    public int activationFee = 20;

    private SpriteRenderer sr;
    private Color originalColor;
    public int defaultHealth;

    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        towerScript = GetComponent<Tower>();

        originalColor = sr.color;
        
        sr.color = originalColor * 0.5f;
    }
    
    void Start()
    {
        towerScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        manager = FindObjectOfType<GameManager>();

        if (!towerScript.enabled)
        {
            sr.color = originalColor * 0.5f;
        }
    }

    void OnMouseDown()
    {
        if (!towerScript.enabled && manager.money >= activationFee)
        {
            towerScript.enabled = true;
            manager.money -= activationFee;

            sr.color = originalColor;
            towerScript.health = defaultHealth;
        }
    }
}
