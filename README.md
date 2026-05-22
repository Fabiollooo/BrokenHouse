# Last Ante
> *The house always wins. But your family can't afford for you to lose.*

---

## Overview

**Last Ante** is a text-based CLI survival game built in C# where every decision carries weight. You play as a provider — someone whose family depends entirely on you to keep the lights on, the medicine stocked, and the table full. Your only means of income? The gambling table.

Win big and your family lives comfortably. Lose it all and watch them slowly fall apart.

---

## Gameplay

The game is split into two phases that repeat each in-game day:

### 🃏 The Table — Gambling Phase
Head to the gambling table to earn money for the day. You choose how much to wager and which games to play. Luck and risk management are everything here. Walk away with enough and your family survives another night. Walk away with nothing and the consequences start stacking up.

- Manage your wager carefully — going all-in is tempting but dangerous
- Different games carry different odds and risk levels
- The more desperate your situation, the more pressure there is to gamble bigger

### 🏠 The Home — Family Management Phase
At the end of each day, you must tend to your family's needs. Basic survival costs money, and neglect compounds fast.

Resources you must manage:
- **Food** — your family needs to eat every day. Miss enough meals and they begin to starve.
- **Medicine** — family members can fall ill at random. Without medicine, sickness worsens and can turn fatal.
- **Heat** — especially in colder seasons, heating the home is non-negotiable for health.
- **Other expenses** — unexpected costs can surface and demand your attention.

Skip payments to save money for gambling and you risk your family's health. Spend too freely and you won't have enough left to wager the next day.

---

## The Loop

```
Start of Day
    └── Check family status (health, hunger, warmth)
    └── Decide how much to bring to the table

Gambling Phase
    └── Choose your game
    └── Place your bets
    └── Win or lose your stake

End of Day
    └── Purchase food, medicine, heat as needed
    └── Neglected needs worsen over time
    └── Repeat — until your family is gone, or you finally get ahead
```

---

## Losing

There is no dramatic single failure moment. Your family degrades gradually:

- Missed meals lead to hunger, then starvation
- Untreated illness gets worse before it gets fatal
- Cold homes wear people down over time

The game ends when your family is gone — or if you somehow manage to secure enough stability to survive long-term.

---

## Built With

- **Language:** C#
- **Platform:** Visual Studio / .NET Console Application
- **Interface:** CLI (Command Line Interface)

---

## Inspiration

The family management mechanic is inspired by the end-of-day resource loop in *Papers, Please* by Lucas Pope — specifically the pressure of providing for dependents with limited and unpredictable income. The gambling system replaces the document-checking gameplay with a risk/reward mechanic that puts the financial tension front and center.

---

## Status

> 🚧 In development
