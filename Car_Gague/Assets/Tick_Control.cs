using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tick_Control : MonoBehaviour
{
    Renderer rend;
    Material mat;

    public Color lit, unlit;
    Color currentCol, targetColor;
    public float angle = 0.0f;
    public GameObject center;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        mat = rend.material;
        angle = (transform.parent.eulerAngles.z + 108 + 360)%360 ;
    }

    // Update is called once per frame
    void Update()
    {
        currentCol = Color.Lerp(currentCol, targetColor, Time.deltaTime * 8);
        mat.SetColor("_Color", currentCol);
        targetColor = center.transform.eulerAngles.z > angle ? lit : unlit;
    }
}
