
003 P2: Refactoring/optimising a game source

Scripts refactored located in assests > scripts > refactored scripts.
The following scripts were refactored, CompanionAI & Player.
A new script was created for player input, PlayerInput

Refactor the player input system.

First, we have to install the new input package within the package manager unity registrary. Then we can set the input system within the project settings to allow the use of the legacy input, new input or both. As we are refactoring the old code, we should set it to use both input systems for now.
Now we have the new input manager installed we can implement it into the project. To do this directly through C# code, we first need to add a new input action to the asset folder and auto-generate a C# class with it by selecting it.

Now we can open the new input action file to make a new action map called Player. Here the inputs for the player can be stored. Within the actions, we can make new actions for the player's movement using the WASD and arrow keys. To do this we create an action using the action type, Value and control type Vector 2 (as this is a 2d game with only two movement axis). Then we can add a binding using an Up/Down/Left/Right Composite which provides us with 4 sub-bindings for the up, down, left and right directions. Here we can go into each sub-binding and assign a key for it. Here we added the corresponding WASD keys and a secondary control scheme using the arrow keys.

Then we can add a processor to the movement action’s bindings to normalise the Vector 2 value. This normalises the vector value when the player is moving with 2 keys at the same time, for example up and left to move diagonally. Without normalising the vector, the player will move faster than intended as both of the vector2 values will be 1.
Finally, we can add a new action for the fire input. This action uses a binding with an action type of button. Again, we can assign multiple bindings with an assigned key to this single action.

Now the action maps for the player’s input have been created we can call them within the code.
We can also separate the player's inputs from the player's script by creating a new script just for player inputs called "PlayerInput".

First, we use the unity engine input system to gain access to the code we need in the player inputs script. Next, we construct the new player input actions on the Awake method, as the awake method initialises before anything else when the game executable runs.
Then we store the new player input into a defined private variable so no other script can edit it and we can use it anywhere within the PlayerInput script. Next, we enable the Player action map so we can use any of its actions within this script.

Player movement inputs

To use the player movement inputs we create a new method that returns a vector 2 value called “GetPlayerMovementVector2”. This vector 2 value is assigned buy the Movement actions binded to WASD and the arrow keys.

To get the vector 2 value from the player movement, we use the Read Value function passing through a vector 2. Finally, we return the vector2 value from the player movement bindings, as this method outputs the value. The vector 2 value has an x value for left and right bindings and a y value for the up and down bindings. The value will be 0 meaning no input or 1 meaning there is input.

Next, we need to use this vector 2 value for the player movement. To do this we go back to the player script creating a reference to the player input script. Then using the player script we call the “GetPlayerMovementVector2” method and assign the value to a new Vector 2 called “moveDir” which will be used for the player's movement direction. This is done at the start of the update method, as we want to update the vector with the players inputs in real time. Then we input the moveDir into the transform Translate method, multiplying it by the predefined speed float variable and Time delta time to make it frame independent. Finally, we delete the old code using the using the legacy input system for the Translate method.

Player Fire Function inputs 

First, we remove the current code calling the fire method with the player script, which uses an if statement checking for the key space to be pressed before executing the method. We also need to set the fire method to public so other scripts can access it.

Then back on the player input script we add a reference to the player script where the fire method is currently located. We can create a method here for calling the player fire method with an action assigned in the player input actions. This method uses the Input action call back context and assigns it to the variable context. Here each stage of the action is returned, "start", "performed" and "cancelled" which refers to each stage of a button press. As we only want to call the fire function a single time, we only want to call the method if the context is performed using an if statement (if context.performed).

Finally, we need the method to subscribe to the perfomred input action by selecting the action within the player inputs and then adding “.performed”. To subscribe we use the += symbols followed by the name of the method subscribing.

---------------------------------------------------------------------------------------------------

Refactor the distance system.


Script Companion AI, void update:

Using the method Vector2.Distance, we calculate the distance between the two transform positions of the player and the companion to which this script is attached. As this game is 2d and only uses the x and y axis, we do not need the vector 3 distance as it would be redundant here.
This value is assigned to a variable with a float datatype called “distanceBetweenCompanionAndPlayer”. 
This variable is used as a parameter of an if statement, to check if its value is more than a pre-defined threshold called “playerDistanceCheck”.
If the value containing the vector 2 distance function is greater than the threshold, the FollowPlayer method will be executed. This method contains the code that causes the companion game object to follow the player’s game object within the scene.

The previous code can be found from line 109 onwards in the script companion AI.
Here we used a box collider 2d set as a trigger to create a player radius area. If the player’s game object entered the companion's collider, a bool would be set to true. An if statement checking when the bool became true, would execute the FollowPlayer method causing the companions game object to follow the player. If the player left the trigger the exit trigger method would be called and would turn the bool back to false, causing the if statement in the update method to stop being called.
