using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int maxMessages = 25;

    public GameObject chatPanel, textObject;
    public TMP_InputField chatBox;

    public Color playerMessage, info;

    [SerializeField]
    List<Message> messageList = new List<Message>();

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(chatBox.text != "")
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                SendMessageToChat(chatBox.text, Message.MessageType.playerMessagge);
                chatBox.text = "";
            }
        }
        else
        {
            if(!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                chatBox.ActivateInputField();
            }
        }

        if (!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SendMessageToChat("You pressed the space key!", Message.MessageType.info);
                Debug.Log("space");
            }               
        }    
              
    }

    public void SendMessageToChat(string text, Message.MessageType messageType)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);

        }
        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<TMP_Text>();

        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);

        messageList.Add(newMessage);





    }

    Color MessageTypeColor(Message.MessageType messageType)
    {
        Color color = info;

        switch (messageType)
        {
            case Message.MessageType.playerMessagge: // similar to if statement
                color = playerMessage;
                break;
        }


        return color;
    }
}
[System.Serializable]
public class Message
{
    public string text;
    public TMP_Text textObject;
    public MessageType messageType;

    public enum MessageType
    {
        playerMessagge,
        info

    }
}
