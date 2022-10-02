using System;
using System.Collections;
using System.Collections.Generic;
using SonicBloom.Koreo.Demos;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private RhythmGameController rhythmGameController;
    [SerializeField] private TMP_Text text;

    private int notesHit;
    private int notesMissed;

    private void OnEnable()
    {
        rhythmGameController.noteHit.AddListener(OnNoteHit);
        rhythmGameController.noteMissed.AddListener(OnNoteMissed);
    }
    
    private void OnDisable()
    {
        rhythmGameController.noteHit.RemoveListener(OnNoteHit);
        rhythmGameController.noteMissed.RemoveListener(OnNoteMissed);
    }

    private void OnNoteHit(string payload)
    {
        notesHit++;
        
        UpdateText();
    }

    private void OnNoteMissed(string payload)
    {
        notesMissed++;
        
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = notesHit + "/" + (notesHit + notesMissed);
    }
}
