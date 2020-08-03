using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hexTextValue : MonoBehaviour
{
    public Text Score_UIText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject hitObject = hitInfo.collider.transform.gameObject;
            if (hitObject.name == "Hexagon")
            {
                int resources = hitObject.transform.parent.gameObject.GetComponent<HexScript>().resources;
                string hexValue = "Hex resources: " + resources.ToString();
                Score_UIText.text = hexValue;
            }
            else
            {
                Score_UIText.text = "";
            }

        }
    }
}
