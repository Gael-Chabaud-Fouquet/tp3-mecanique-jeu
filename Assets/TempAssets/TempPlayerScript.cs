using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempPlayerScript : MonoBehaviour
{
    private Rigidbody m_TempPlayer;
    [SerializeField] private string m_MainMenu;
    [SerializeField] private GameObject m_TempEnemy;
    [SerializeField] private int m_TempAttackRadius;
    [SerializeField] private float m_TempSpeed;
    [SerializeField] private int m_TempAttackDamage;
    [SerializeField] private int m_TempHP;
    // Start is called before the first frame update
    void Start()
    {
        m_TempPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        EscapeToMainMenu();


        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("touched something");
        }
    }
    private void EscapeToMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(m_MainMenu);
        }
    }


}
