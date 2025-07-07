using UnityEngine;

public class GoalZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GoalZone Trigger Enter: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Goal reached! Changing state.");
            GameManager.Instance.ChangeState(new ClearState());
        }
        else
        {
            Debug.Log("Not Player tag");
        }
    }
}