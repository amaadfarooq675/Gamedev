using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using TMPro;
using System; 

public class DatabaseManager : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_Text score_text;
    public TMP_Text db_username_text;
    public TMP_Text db_score_text;
    public float inputScore;
    private string user_id;
    private DatabaseReference dbReference;

    private GameObject gameManagerObject;

 
    void Start()
    {
        user_id = SystemInfo.deviceUniqueIdentifier;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;

    }

    
    public void WriteUser()
    {
        UserClass user = new UserClass(usernameInput.text, inputScore);
        string json = JsonUtility.ToJson(user);
        dbReference.Child("users").Child(user_id).SetRawJsonValueAsync(json);
    }

    public IEnumerator GetUser(Action<UserClass> callback)
    {
        var dbTask = dbReference.Child("users").Child(user_id).GetValueAsync();
        yield return new WaitUntil(predicate: () => dbTask.IsCompleted);

        if (dbTask != null)
        {
            DataSnapshot snapshot = dbTask.Result;
            UserClass dbUser = new UserClass(snapshot.Child("username").Value.ToString(), float.Parse(snapshot.Child("score").Value.ToString()));
            callback.Invoke(dbUser);
        }
    }

    public void ReadUser()
    {
        StartCoroutine(GetUser((UserClass user) =>
        {
            db_username_text.text = user.username;
            db_score_text.text = user.score.ToString();
        }));
    }
}
