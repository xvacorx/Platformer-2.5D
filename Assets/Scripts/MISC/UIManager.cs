using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PowerUpManager ppmanager;

    public TextMeshProUGUI jump;
    public TextMeshProUGUI dash;
    public TextMeshProUGUI stomp;

    public TextMeshProUGUI time;

    public PlayerMovement player;

    float actualTime;
    private void Start()
    {
        actualTime = 0f;
    }
    private void Update()
    {
        if (player.enabled) { actualTime += Time.deltaTime; }

        time.text = actualTime.ToString();
        jump.text = "Jumps: " + ppmanager.jumps;
        dash.text = "Dashes: " + ppmanager.dashes;
        stomp.text = "Stomps: " + ppmanager.stomps;
    }
}
