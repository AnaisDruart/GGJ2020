﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    Image bar;
    public float maxTime = 90f;
    float timeLeft;
    public Text timesText;

    // Start is called before the first frame update
    void Start()
    {
        //timesText.SetActive(true);
        bar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            bar.fillAmount = timeLeft / maxTime;
            timesText.text = timeLeft.ToString("0.0") + "s";
        }
        else
        {
            Time.timeScale = 0;
        }

    }
}
