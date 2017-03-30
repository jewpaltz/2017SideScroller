using UnityEngine;

public class GM : MonoBehaviour {
    public int lives;
    public int points;

    public void SetLives(int newValue) {
        lives = newValue;
        Debug.Log("Lives now equals: " + lives);
    }
}
