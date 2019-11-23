using UnityEngine;
using UnityEngine.UI;


public class Material_Control : MonoBehaviour
{
    public Texture mask1, mask2;
    public Text debug;
    public Color cold, hot;

    Color targetColor = Color.blue;
    Color currentColor;
    float val = .0f;

    Transform parentt;
    Renderer rend;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        mat = rend.material;
        targetColor = cold;
    }

    private void Update()
    {
        //currentColor = mat.GetColor("_Color");
        currentColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * 8);
        //currentColor = Color.Lerp(cold, hot, val/215);
        mat.SetColor("_Color", currentColor);
    }

    public void SetAngle(float a)
    {
        Vector3 rot = transform.parent.transform.eulerAngles;
        rot.z = 215-a;
        transform.parent.transform.eulerAngles = rot;
        debug.text = a.ToString();

        float angle = transform.parent.transform.eulerAngles.z;

        mat.SetTexture("_Mask", angle < 115 ? mask1 : mask2);
        targetColor = (angle < 215 - 190) ? hot : cold;
        val = a;
    }

}
