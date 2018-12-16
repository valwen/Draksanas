using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusEnemies : Interactable
{

    private Color startColor;

    public Camera cam;
    public GameObject focus;
    public GameObject player;

    float angleView = 180f;
    public float range = 10f;
    public int focusIndex = 0;

    public List<GameObject> listEnemies = new List<GameObject>();


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        // We create a ray

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))

        {
            bool isViewed = false;
            Vector3 direction = (enemy.transform.position - player.transform.position).normalized;

            Ray ray = new Ray(player.transform.position, direction);
            RaycastHit hit;

            // If the ray hits
            if (Vector3.Distance(player.transform.position, enemy.transform.position) <= range)
            {
                if (Physics.Raycast(ray, out hit))
                {

                    float angle = Vector3.Angle(ray.direction, player.transform.forward);
                    if (angle <= angleView / 2)

                    {
                        isViewed = true;
                    }
                }
            }

            Color color = Color.red;
            if (isViewed)
            {
                color = Color.blue;
                if (!listEnemies.Contains(enemy))
                {
                    listEnemies.Add(enemy);

                }
            }
            else if (listEnemies.Contains(enemy))
            {
                listEnemies.Remove(enemy);
            }
            Debug.DrawRay(ray.origin, ray.direction * range, color, 0.1f);


        }

        // If the list isn't empty

        if (listEnemies.Count > 0)
        {

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                focusIndex++;
                if (focusIndex >= listEnemies.Count)
                {
                    focusIndex = 0;
                }
            }

            // Manage the cursor (focus.transform.GetChild(0).gameObject.SetActive) : enable on focus and disable on defocus

            if (focus != null)
            {
                focus.transform.GetChild(0).gameObject.SetActive(false);
            }
            focus = listEnemies[focusIndex];
            focus.transform.GetChild(0).gameObject.SetActive(true);

        }
        else
        {
            if (focus != null)
            {
                focus.transform.GetChild(0).gameObject.SetActive(false);
            }
            focus = null;
        }
    }
}



