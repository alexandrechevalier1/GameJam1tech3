using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SRetry : MonoBehaviour
{
   public void RetryGame() {
         SceneManager.LoadScene(0);
   }
}
