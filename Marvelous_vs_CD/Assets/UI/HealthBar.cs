using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    
    public Gradient gradient;
    public Image fill;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

	public void SetMaxHealth(int health)
	{
        slider.maxValue = health;
        slider.value = health;
        
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
		slider.value = health;
	
		fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
