# One Way Ticket to Hell Game
* Author: Joe Davis
* Project: One Way Ticket to Hell
* Hardware: 2012 15" Macbook Pro Retina Display.
* Software: Unity, XCode.
* Platform: iOS - iPhone / iPod touch.

If you're reviewing the project to provide feedback, please navigate to the following directories / links:
Source Code: "Assets\Scripts"
Planning / Design: "Concept and Code Structure"
Gameplay Video: "https://youtu.be/xpExF593yHg"

Summary:
'One Way Ticket to Hell' is a 2D action game built for iOS. You, the player, control an angel sent from heaven who's mission is to venture to hell and kill Satan. The objective of this game is to collect 3 tickets within each level, while avoiding / killing demons along the way. There are 5 levels overall, each with their own environment. The higher the score and the faster the time, the better. 

Purpose of this project:
To express my skill set combining technical excellence with a passion for making games, to improve my Game Design / programming capabilities and to create the games I would want to play myself.

Problems experienced / Future improvements:
I didn't fully plan out what the best coding structure would be. For the next project, it would be benefical to spend more time drawing out a structure based on the game objects' states and behaviours. 
Perhaps some of the scripts within this project could've been maerged into one big script, rather than having several  smaller scripts (enemy & player). 
Experiment with different design patterns beyond Singleton and Object Pooling. 

Known serious bugs:
None :) .. so far.

References:

[1] Unity, (2019), Physics2D.OverlapCircle, Available at: “https://docs.unity3d.com/ScriptReference/Physics2D.OverlapCircle.html” [Used in PlayerInputControl.cs].

[2] Answers.Unity, (2013), Most efficient way to check distance between player and scene objects, Available at: "https://answers.unity.com/questions/536557/most-efficient-way-to-check-distance-between-playe.html" [Used in GameController.CalculateDistanceBetweenPlayerAndHole()].

[3] Youtube, (2018), Unity Tutorial - Cinematic bars, Available at: "https://www.youtube.com/watch?v=nNbM40HFyCs" [Used in CinematicBars.cs].

[4] Raywenderlich, (2016), Object Pooling in Unity, Available at: "https://www.raywenderlich.com/847-object-pooling-in-unity" [Used in ProjectilePool.cs]

[5] Youtube, (2015), Unity 5 Tutorial: Path Follow System using Waypoints C#, Available at: "https://www.youtube.com/watch?v=1aBjTa3xQzE" [Used in EnemyMoveOnPath.cs & EditorPathScript.cs].

[6] KissPNG, PNG images. Available at: "https://www.kisspng.com/png-wings-png-25582/download-png.html" [Used in many scenes containing sprites].
