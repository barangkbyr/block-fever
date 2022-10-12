using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour {
    public static int score;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Start() {
        score = 0;
    }

    private void Update() {
        scoreText.text = score.ToString();
    }
}
