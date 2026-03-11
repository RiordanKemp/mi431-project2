# mi431-project2

Creative Phase Project 2 - ReadMe File

Author: Riordan Kemp

Modified: 2025-03-11

What was/were your starting tutorial(s)?

https://www.youtube.com/watch?v=Gx46xUgVXrQ


What did you do in your Research Phase?

I set up a basic 2D movement system and environment, and implemented the grappling hook from the tutorial.


What did you do in your Creative Phase?

I added a physical grappling hook projectile which can bounce off chosen layers, grapple onto selected layers, and has a customizable travel distance, speed, and a return effect.  I also allowed the player to control their distance from the grapple point, and allowed the grappling hook to retrieve items


Any assets used that you didn't create yourself?  (art, music, etc. Just tell us where you got it, link it here) 

N/A


Did you receive help from anyone outside this class?  (list their names and what they helped with)

N/A


Did you get help from any AI Code Assistants?  (Tell us which .cs file to look in for the citation and describe what you learned; also be sure to comment in the .cs per the syllabus instructions)

RESEARCH -
Prompted ChatGPT React with "How do I detect a key being held down (such as "A") with Unity's 2022 input system".  Also prompted it with "How do I detect the position of a mouse in world space with the new input system".  All I learned from this is how to use old features using new syntax, but it's good to know.

CREATIVE -
Prompted ChatGPT with "How would I detect whether a collider of OnTriggerEnter2D has a layer which matches a layer mask in Unity?".  

Prompted ChatGPT with "How can I track the direction of the mouse scroll wheel using Unity's new input system?".  Similar to the research phase - I've implemented the scroll wheel detection into previous projects, but I can't find updated syntax for the new input system.

Did you get help from any additional online websites, videos, or tutorials?  (link them here)

RESEARCH -
Detect mouse left click in Unity's new input system: https://discussions.unity.com/t/mouse-clicks-not-detected-in-new-input-system/853008/3

CREATIVE -
How to instantiate an object with zero rotation: https://discussions.unity.com/t/quaternion-no-rotation/399822/2
Using Vector3 MoveTowards: https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Vector3.MoveTowards.html
Change object parent: https://discussions.unity.com/t/changing-the-parent-of-an-object-in-a-script/31685

What trouble did you have with this project?

The physical grappling hook projectile was a pain to test - getting it to properly return when desired, ignore input at the right times, and implementing a range limit with the various layer collision checks was  surprisingly challenging.


Is there anything else we should know?

N/A