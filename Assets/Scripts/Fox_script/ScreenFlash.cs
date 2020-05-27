using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    public Image image;
    public float flashtime;
    public Color oldColor;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        oldColor = image.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlashScreen() {
        image.color = new Color(255, 255, 255, 0.5f);
       StartCoroutine(finishFlashScreen());
}
    IEnumerator finishFlashScreen()
    {
        yield return new WaitForSeconds(flashtime);
        image.color = oldColor;
    }
}
