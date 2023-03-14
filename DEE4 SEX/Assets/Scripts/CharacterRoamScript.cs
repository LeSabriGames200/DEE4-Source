using UnityEngine;
using UnityEngine.AI;

public class CharacterRoamScript : MonoBehaviour
{
    // The radius of the area the character can roam in
    public float roamRadius = 10f;

    // The distance the character must be from a destination before it stops moving
    public float stoppingDistance = 0.1f;

    // An array of waypoints the character can roam to (not used if we're roaming without waypoints)
    public Transform[] waypoints;

    // The index of the current waypoint (not used if we're roaming without waypoints)
    private int currentWaypointIndex = 0;

    // A reference to the NavMeshAgent component
    private NavMeshAgent navMeshAgent;

    // The starting position of the character (used as the center of the roaming area)
    private Vector3 startingPosition;

    void Start()
    {
        // Get the NavMeshAgent component
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Get the starting position of the character
        startingPosition = transform.position;

        // If we're using waypoints, make sure there's at least one defined
        if (waypoints.Length > 0)
        {
            // Set the NavMeshAgent's destination to the first waypoint
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
        else
        {
            // If we're not using waypoints, generate a random destination
            SetRandomDestination();
        }
    }

    void Update()
    {
        // If we're using waypoints and we've reached the current waypoint, set the NavMeshAgent's destination to the next waypoint
        if (waypoints.Length > 0 && navMeshAgent.remainingDistance <= stoppingDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
        // If we're not using waypoints and we've reached the destination, generate a new random destination
        else if (waypoints.Length == 0 && navMeshAgent.remainingDistance <= stoppingDistance)
        {
            SetRandomDestination();
        }
    }

    // Generate a random destination within the roaming area and set it as the NavMeshAgent's destination
    private void SetRandomDestination()
    {
        // Generate a random direction within a sphere of radius roamRadius
        Vector3 randomDirection = Random.insideUnitSphere * roamRadius;

        // Add the random direction to the starting position to get a random destination point
        randomDirection += startingPosition;

        // Find the nearest point on the NavMesh to the destination point
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, roamRadius, NavMesh.AllAreas);

        // Set the NavMeshAgent's destination to the nearest point on the NavMesh
        navMeshAgent.SetDestination(hit.position);
    }
}
