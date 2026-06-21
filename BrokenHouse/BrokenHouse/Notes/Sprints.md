✅ Sprint 0 — Project Setup (DONE)

Get the basics in place before writing any game logic. (DONE)
 -Create a new C# Console App project in Visual Studio (DONE)
 -Name the solution BrokenHouse (DONE)
 -Set up GitHub repo with a Visual Studio .gitignore (DONE)
 -Push your empty project to GitHub (DONE)
 -Add README.md to the repo (DONE)
 


✅ Sprint 1 — Core Game Loop (DONE)

The skeleton of the game. No gambling, no family yet — just the loop.
 -Create a Game.cs class that holds the main game loop (DONE)
 -Build a basic day counter (Day 1, Day 2, Day 3...) (DONE)
 -Create a simple main menu: [1] Go to Casino  [2] Go Home  [3] Quit (DONE)
 -Make each menu option print a placeholder message (e.g. "You head to the casino...") (DONE)
 -Add a player object with a starting balance (e.g. $200) (DONE)
 -Display the player's balance at the start of each day (DONE)
 -Add a way to end the game (quit option or day limit) (DONE)


✅ Sprint 2 — Family Needs System

 -Create a Family.cs class (DONE)
 -Add basic needs: Food, Medicine, Heat — each as a number (e.g. 0–100) (DONE)
 -Every day, each need decreases by a set amount (e.g. Food -20 per day) 
 -Build a "Go Home" screen that shows current need levels (DONE)
 -Add a shop — player can spend money to refill needs

 -Food costs $20 to refill
 -Heat costs $15 to refill
 -Medicine costs $25 to refill


 -If a need hits 0, print a warning message
 -If Food stays at 0 for 3+ days in a row, trigger a Game Over
 -Display Game Over screen with how many days you survived


✅ Sprint 3 — Blackjack

Start with the simplest possible gambling mechanic to get the casino side working.
 Create a Game.cs class
 Build a BlackJack method containing the game logic:
	 -You place your bet. (DONE)
	 -Reviece your cards. (DONE)
	 -Dealer reveals one card. (DONE)
	 -Player chose to hit/stands. (DONE)
	 -Later implementation can add splitting, doubling down, etc. (optional)


 Prevent the player from betting more than they have (DONE)
 After gambling, player returns to the main day menu (DONE)
 Make sure a broke player (balance = $0) still has to go home and face consequences (DONE)


✅ Sprint 4 — Family Members & Health

Make the family feel real by adding individual members.
	-Create a FamilyMember.cs class with: Name, Health, IsAlive, IsSick (DONE)
	-Add 2–3 family members (e.g. Spouse, Child) (DONE)
	-Each member has their own health bar (0–100) (DONE)
	-Random chance each day that a member gets sick
	-If sick and no medicine is bought, health drops faster
	-If health hits 0, that member dies — print a somber message
	-If all family members die, trigger Game Over
	-Display each family member's status on the "Go Home" screen
	-Later implementation, add bigger families for a bigger challenge (optional).

✅ Sprint 5 — Second Gambling Game

Add a second game to give the casino some variety.
	-Roulette.
	-Craps.
	-High/Low card game.
	-Possible other games.



✅ Sprint 6 — Steady Job Income

Give the player a small reliable income so the game isn't purely luck-dependent.
	-Implement some sort of way that the income is added weekly or bi-daily.


✅ Sprint 7 — Random Events

Add unpredictability to keep each run feeling different.
 Build a simple EventSystem.cs
 Each day has a small chance to trigger a random event
 Add at least 3 events to start:

 "Your child fell ill overnight" — triggers sickness immediately
 "Unexpected bill arrived" — deducts $30–$80 from balance
 "You found a $20 bill on the street" — small lucky bonus


 Display the event at the start of the day before the menu
 Add more events in later sprints as you build confidence


✅ Sprint 8 — Loan Shark

Add the borrowing mechanic and consequences for not repaying.
 Add a LoanShark.cs class
 Player can borrow money when broke (e.g. borrow $100)
 Debt accrues daily interest (e.g. +20% per day)
 Track how many days the debt is overdue
 First missed payment: a family member gets hurt (health -40)
 Second missed payment: something worse happens (your choice — a member dies, or you lose your job income for 3 days)
 Display debt status on the daily screen
 Add option to repay loan from the home menu


✅ Sprint 9 — Polish & Atmosphere

Make the game feel like Broken House. Add the 80s communist Poland atmosphere.
 Add a title screen with the game name and a short tagline
 Add flavour text to daily events that fits the setting (grey, bleak, Eastern European tone)
 Add a time display — the day starts at 09:00, casino closes at 18:00 (track turns as time passing)
 Add colour to the CLI output using Console.ForegroundColor:

 Red for danger/warnings
 Yellow for money
 White for normal text
 Dark grey for atmosphere/flavour text


 Add a small story intro that plays on first launch (skip option available)
 Update README.md with current features and how to run the game


✅ Sprint 10 — Difficulty & Replayability

Final layer — make the game replayable and adjustable.
 Add a difficulty select screen at the start:

 Easy — 1 child, lower expenses, slower need decay
 Normal — spouse + 1 child, standard costs
 Hard — spouse + 2 children, faster decay, higher bills


 Add a high score / best run tracker (most days survived)
 Add house upgrade system:

 Start in a run-down communist apartment (cheap rent, poor conditions)
 Upgrade to better housing for quality of life bonuses but higher bills


 Final playtest — balance the economy so the game is hard but fair