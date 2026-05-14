# Arena Clash — Interactive Character Experience System

## Project Description
Arena Clash is an interactive Unity fighting showcase where users can switch between 3 animated fighters, trigger combat animations through keyboard and UI buttons, control audio, and navigate animated UI screens. The project demonstrates animation logic, interaction systems, audio feedback, UI transitions, and clean centralized architecture.

---

## Controls

| Key | Action           |
|-----|------------------|
| 1   | Select Fighter 1 |
| 2   | Select Fighter 2 |
| 3   | Select Fighter 3 |
| Q   | Punch            |
| W   | Kick             |
| E   | Hit              |
| R   | KO               |
| T   | Reset KO         |

---

## Architecture

### FightManager
Central controller script that:
- Tracks the active fighter
- Triggers animations on the correct fighter
- Coordinates audio and UI updates
- Ensures only one fighter is active at a time

### UIManager
Handles all UI screen transitions using CanvasGroup fading:
- Main Menu Screen
- Fighter Select Screen
- Battle Screen (health bars, active fighter text, winner text)

### AudioManager
Manages all audio:
- Background music with loop
- Combat sound effects (Punch, Kick, Hit, KO)
- Volume slider and mute toggle

---

## Animator Setup

Each fighter uses an Animator Controller with:

| Parameter | Type    | Purpose         |
|-----------|---------|-----------------|
| Punch     | Trigger | Punch animation |
| Kick      | Trigger | Kick animation  |
| Hit       | Trigger | Hit reaction    |
| KO        | Bool    | Defeat state    |

Transitions:
- Idle → Punch / Kick / Hit: Has Exit Time OFF
- Punch / Kick / Hit → Idle: Has Exit Time ON
- Idle → KO: condition KO = true, no return transition

---

## Screens

1. Main Menu — Start and Exit buttons
2. Fighter Select — Choose Fighter 1, 2, or 3
3. Battle — Action buttons, health bars, volume controls, active fighter display

---

## Built With
- Unity 2022 LTS
- Mixamo Animations
- TextMeshPro
- UMA (Universal Morph & Avatar)
