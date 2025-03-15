using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private Button lunchButton;
    [SerializeField] private Button allyButton;
    [SerializeField] private Button enemyButton;
    
    private void Awake() {
        lunchButton.onClick.AddListener(() => {
            SceneManager.LoadScene(2);
        });
        allyButton.onClick.AddListener(() => {
            SceneManager.LoadScene(3);
        });
        enemyButton.onClick.AddListener(() => {
            SceneManager.LoadScene(4);
        });
    }
}
