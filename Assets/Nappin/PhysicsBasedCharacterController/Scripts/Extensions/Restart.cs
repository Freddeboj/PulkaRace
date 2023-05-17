using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField]
    private float resetButtonShowDelay = 10f;
    [SerializeField]
    private Button resetButton;

    private IEnumerator Start()
    {
        resetButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(resetButtonShowDelay);
        resetButton.gameObject.SetActive(true);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}