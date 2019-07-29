using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSwap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchColor()
    {
        Color newColor = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
        var colors = GetComponent<Button>().colors;
        colors.normalColor = newColor;
        GetComponent<Button>().colors = colors;

        Debug.Log(this.gameObject.name);

    }
}
