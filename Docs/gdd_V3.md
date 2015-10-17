**Snip, Official GDD** | Prototype v3

**Note from Project Management:** *Official GDD for our Game. Please use the below document as a starting point for all future work.* 

----------
##PURPOSE##

The purpose of this prototype is to created a framework level by creating art for main character Anais and her setting (grayscale private library with colorful Rift) and by implementing basic game mechanics and animation with the art, thus creating a foundation for the game overall.

----------
##SUMMARY##

The level opens up into a view of the scrollable private library scenery. From the left, Anais walks onto screen. A speech bubble appears above, pointing off screen, saying, “Don’t come back until you get me the big, green book.” The player will now have the freedom to control Anais. Anais will explore the library setting and come across objects that the player can choose to interact with. If the player uses crafty thinking and manages to interact with the chandelier, one of the bookshelves will slide a direction, revealing a very vibrantly colored “rip” in the wall (this is a Rift, the means of transportation to and from Snip World). Upon interacting with it, the Rift will “burst,” fading out the old scenery. This marks the end of the level.  

----------
##CHARACTER DESCRIPTION##

**Facts:** Anais is a girl of around 9 or 10 years old with a broken / introverted personality. She holds in her left hand a pair of golden scissors. 

**Appearance:** Anais is colored in the grayscale or muted style, much like the real world, and will keep that style throughout the game, including in Snip world. She will also have a 3/4th camera angle, which will show the front of her angled to the side. She has a darker skin tone (a Princess Jasmine color) with hazel eyes and uncombed dark brown hair. She has rounded facial features such as cheeks and eyes, and has a slender figure with long limbs. She wears hand-me-down clothes, which includes slim jeans, white sneakers, and a baggy, striped sweater. The right sleeve of the sweater covers her hand, while the left sleeve (her scissors hand) is rolled up to her wrist. Because she is a child, she will appear slightly smaller compared to the setting (or rather, the setting will appear slightly larger compared to her).

**Movement:** Anais walks moderately fast (no running). While she moves, she leans forward a little, defensively, as in she is unsure of what is in front of or behind her. If she is facing a direction and moves in the other direction, she will take 3 backwards steps before turning around.

**Scissors:** Anais holds her scissors in her left hand. The scissors are shaped like that of a long-necked bird (crane, stork), and have a golden color, which remains constant throughout both worlds.

**Idle Animation:** After three seconds of no input commands by the player, Anais will enter her idle animation. She will lean to one side, as if impatient, and observe her immediate surroundings while slowly snipping the air with her scissors. However, if enemies are nearby, she will not enter this animation.

----------
##GAME MECHANICS##

**Pushing and Pulling Blocks:**
Anais will have an interaction prompt appear above her when next to a block that will allow her to grab it.  Once she has grabbed it, a prompt for the left and right movement keys will appear to the side of Anais that the block is not on, showing the player that they can either push or pull the block.  The interaction button prompt will be over her head as long as she is:

 - Near the block. 
 - Moving the block.
 - Not moving but still holding onto
   the block.

The movement buttons prompt will remain to the side of Anais that the block is not on until the player presses the interaction button again, causing Anais to release the block.  By letting go of the block, the prompt for the left and right movement keys to fade out.

**Pushing and Pulling - Ladders:** 
There will be a single ladder in the library that Anais will need to move to the beginning of the library in order to climb up it onto the top of a bookshelf, which she will jump off of onto a Chandelier.  When Anais stands to the left or the right of the Ladder, an interaction prompt will appear over her head.  By pressing the interaction button, Anais will grab the side of the ladder she is closest to, and after grabbing it, a prompt for the left and right movement keys will appear on the side of Anais that the ladder is not on, informing the player that Anais can move left or right to push or pull the ladder.  The interaction button prompt will remain over Anais’ head as long as she is:

 - Near the Ladder.
 - Moving the Ladder.
 - Not moving but still holding onto the ladder.

The movement buttons prompt will remain to the side of Anais that the ladder is not on until the player presses the interaction button again, causing Anais to release the ladder.  By letting go of the ladder, the prompt for the left and right movement keys to fade out.

**Climbing Ladders:** 
When the player has Anais stand directly in front of the ladder, the interaction button will appear over her head.  By pressing the interaction button, Anais will mount the ladder.  Once Anais has mounted the ladder, movement button prompts for up and down will appear to her left, while the interaction button will fade out as long as she is not at the top or bottom of the ladder to dismount.  Once Anais dismounts from the ladder, the movement buttons prompts for her to go up or down will fade out.The interaction button prompt will remain over Anais’ head when on the ladder unless:

 - She climbs up beyond the base of the ladder. (This means if she climbs *any* amount higher than the base of the ladder where she mounted it.)
 - She climbs down a Ladder from the top. (This means if she climbs *any* amount lower than the top of the ladder where she mounted it.)

**Pulleys - Lowering/Raising Platforms:** 
Upon jumping onto the Chandelier, it will slowly lower, causing one of the bookshelves in the library to slowly slide over, revealing a Rift for her to Snip.  The chandelier will lower all the way down so that the lowest part of it is barely touching the floor, but will not touch the floor. 

Once Anais Jumps off of the Chandelier, it will rise back into place. She must stay on the Chandelier the entire time it lowers to the floor in order for the movement of the bookshelf to trigger.  

Once the bookshelf starts moving, Anais can jump off of the bookshelf at any time, the Chandelier will rise back into place, and the bookshelf will continue to slide over until it has revealed the entire rift.

**Sliding Bookshelf (Associated With Pulleys):**
After the Chandelier reaches the ground, a bookshelf in the library will slowly slide over, revealing a Rift.  The bookshelf will not slide back into its original position once it has revealed the Rift.  

If Anais stands in front of the Rift, the interaction button prompt will fade in over her head, and upon pressing it, Anais will initiate the animation* of Snipping up through the Rift, and shifting** the world into Snip World.

- *For the prototypes sake, this animation is not needed, and as the Snip Worlds look has not been completely finalized.*  
- *For the prototypes sake, the world around Anais just needs to change.  It could change to a completely white environment with no decoration at all, just as long as the mechanic can be demonstrated.*

When Anais is in Snip World, the rift will remain in the same location as it was in the Real World.

**Upgradable Items (Red Ribbon for prototype):** 
Each upgradable item will be located in the real world and Anais will have to interact with them with the interaction prompt. Once Anais has located and interacted with an upgradable item, it will remain visible on her person in both the real world and Snip world, as well as for the remainder of the playthrough. Each item will be vibrantly colored, both before being interacted with and after being added to Anais (although Anais herself will remain grayscale). The effects of the upgradable items only occur in Snip world. The red ribbon is the only upgradable item in the prototype.

----------
## Art & Animation ##

**Setting – Real World (Private Library) [Grayscale or Muted]**

 - **ART**: Anais walks onto screen into the library. A speech bubble from the hall appears, pointing off screen. It says, “Don’t come back until you get me the big, green book.” The floors are hard wood,dusty, old. The library has a gothic-style to it. Everything was once new, but now is old and uncared for. In the background, there are shelves upon shelves of old, tattered books disappearing into darkness like it goes on forever. The books are faded and nameless.
 
 - **ANIMATION**: The speech bubble must be animation to appear. The speech bubble is square with a spiky tail trailing off screen.

**Blocks**

- **ART**: Anais will encounter weight puzzles with blocks. The blocks themselves are cardboard boxes (filled with books or other old possessions such as globes, pens, etc.) or the box can appear empty to the viewer.

- **ANIMATION**: As Anais is close to, moving, or holding a block/box, a button prompt must fade in. This button prompt should be dark or light, depending on how dark the background is. The button must also be animated to fade out once Anais is not moving the block.

**Ladders**

- **ART**: A wooden ladder is present at the start of the level. She will use the ladder to access the chandelier. She will jump from atop a dusty bookshelf to the top of the chandelier. These 3 items (ladder, shelf, chandelier) must be close enough to each other so Anais can jump from one to the other. (Anais has weak jump animations, keep this in mind). 

- **ANIMATION**: The button to interact with the ladder will be the same as the “blocks” so the same animation can be used here. 

**Sliding Bookshelf**

- **ART**: There is a single sliding bookshelf at the end of the level. The shelf will move out of place to reveal a Rift (a snipping point). An area by the shelf must appear “empty,” so when the shelf moves, it can move into that area. This “empty” portion of the wall with the shelf must “tip” players off to the fact that this bookshelf moves out of the way. The empty wall should have an appearance of being worn, such as with scratches, also to hint to players about its significance.

- **ANIMATION**: Once Anais triggers the Chandelier animation, the bookshelf animation will begin. It will move to the side to reveal a Rift. 

**Rifts**

- **ART (before it is cut):** The Rifts will look like a perforated line (like a guiding line on children’s crafts) with a small opening at the bottom of the line on the wall. The bottom, where the small opening is will look like the perforated line has started to open. The colors from this opening will look like the Rift when it is fully open.

- **ANIMATION (for cutting):** To cut the perforated line, Anais will bend down and with her left hand cut from bottom up in one fluid motion. The Rift will quickly explode open to reveal the fully open Rift.

- **ANIMATION (for interaction):** Like the other actions Anais can do, there will be a prompt that fades in when she approaches the Rift line, signaling the ACTION button. Also like other actions, the prompt will fade once she has moved away from it.

- **ART (after it is cut):** The Rifts look like thin, crudely torn out pieces of the wallpaper of the houses Anais is in, but while Anais is in the grayscale Real World, the Rifts themselves have color.  They ripple and pulse with fluctuating shades of color.  Upon Snipping them, They literally seem to burst, as if they were being forcibly ripped apart without warning, with the Snip World seemingly unraveling over the Real World, as if it were new wallpaper being rolled out over a wall.

**Red Ribbon:**

- **ART:** The red ribbon will be hanging out of a book in the library, shining a bright silky red color. 

- **ANIMATION:** After being interacted with, Anais will reach up to grab the ribbon. She will briefly make hand motions with her hair, and then the vibrant red ribbon will now be holding her hair in a somewhat poofy ponytail.
