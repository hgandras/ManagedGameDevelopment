using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : CharacterBase
{
    protected enum State
    {
        IDLE,
        ALERTED,
        COMBAT,
        FLEEING
    }
    protected State npcState= State.IDLE;
}
