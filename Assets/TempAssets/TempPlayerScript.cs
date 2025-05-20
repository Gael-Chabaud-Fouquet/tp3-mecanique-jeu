using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class TempPlayerScript : MonoBehaviour
{
    private Rigidbody m_TempPlayer;
    [SerializeField] private string m_MainMenu;

    private NavMeshAgent m_TempAgent;
    //[SerializeField] private GameObject m_TempEnemy;
    //[SerializeField] private int m_TempAttackRadius;
    //[SerializeField] private float m_TempSpeed;
    //[SerializeField] private int m_TempAttackDamage;
    //[SerializeField] private int m_TempHP;

    private Vector3 m_TempOrigin;
    private Vector3 m_TempDestination;
    private float m_TempMovementTime;
    // Start is called before the first frame update
    void Start()
    {
        m_TempPlayer = GetComponent<Rigidbody>();
        m_TempAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        EscapeToMainMenu();

        MoveArround();
        //DestroyObject();
        //AttackEnemy();
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
        if (Input.GetMouseButtonDown(0) /*&& gameObject.tag == "SurfaceToWalkOn"*/)
        {
            Ray RayFromCamera = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(RayFromCamera, out RaycastHit info))
            {
                Debug.Log("touched the ground!");
                m_TempAgent.SetDestination(info.point);
            }
        }
    }

    //private void DestroyObject()
    //{
    //    if (Input.GetMouseButtonDown(0) && gameObject.tag == "Destructible")
    //    {
    //        Ray RayFromCamera = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        if (Physics.Raycast(RayFromCamera, out RaycastHit info))
    //        {
    //            Debug.Log("Touched a destructible!");
    //            //m_Agent.SetDestination(info.point);
    //        }
    //    }
    //}

    //private void AttackEnemy()
    //{
    //    if (Input.GetMouseButtonDown(0) && gameObject.tag == "Enemy")
    //    {
    //        Ray RayFromCamera = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        if (Physics.Raycast(RayFromCamera, out RaycastHit info))
    //        {
    //            Debug.Log("Touched an enemy!");
    //            //m_Agent.SetDestination(info.point);
    //        }
    //    }
    //}
}
