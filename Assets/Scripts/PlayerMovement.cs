using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody m_Player;
    private NavMeshAgent m_Agent;
    [SerializeField] private string m_MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        m_Player = GetComponent<Rigidbody>();
        m_Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        EscapeToMainMenu();
        MoveArround();
    }

    private void EscapeToMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(m_MainMenu);
        }
    }
    private void MoveArround()
    {
        if (Input.GetMouseButtonDown(0) && gameObject.tag == "SurfaceToWalkOn")
        {
            Ray RayFromCamera = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(RayFromCamera, out RaycastHit info))
            {
                Debug.Log("touched the ground!");
                m_Agent.SetDestination(info.point);
            }
        }
    }

    private void DestroyObject()
    {
        
    }

    private void AttackEnemy()
    {
        
    }
}
