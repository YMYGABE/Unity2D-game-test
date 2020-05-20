using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fox_Health : MonoBehaviour
{
    public Text HealthText;
    public static int HealthCurrent;
    public static int HealthMax;
    public int jjj;
    private Image healthbar;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Image>();
        //HealthCurrent = HealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = (float)HealthCurrent / (float)HealthMax;
        HealthText.text = HealthCurrent.ToString() + "/" + HealthMax.ToString();
    }
}
