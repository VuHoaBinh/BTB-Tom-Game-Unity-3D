using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class Health : MonoBehaviour
{
    public int health;
    public bool IsLocalPlayer;
    public TextMeshProUGUI healthText;
    [PunRPC]
    public void TakeDamage(int _damage)
    {
        health -= _damage;

        healthText.text = health.ToString();
        if (health <= 0)
        {
            if (IsLocalPlayer)
            {

                RoomManager.instance.RespawnPlayer();
                RoomManager.instance.deaths++;
                RoomManager.instance.SetHashes();
            }
            Destroy(gameObject);
        }
    }
}
