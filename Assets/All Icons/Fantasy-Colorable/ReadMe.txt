----------------------
Welcome
----------------------

A simple colorable UI for Fantasy and RPG games. Note that not every component is set up in the NGUI atlas and skin. There are some additional icons and frames which you might like to use in your own project.

Please leave a rating if you like the package. If you don't let me know and I'll do my best to address your concerns. Also let me know what components you would like me to add!

Contact me here: john@jnamobile.com

----------------------
Folder Structure
----------------------
Fantasy-Colorable
 - Fantasy-Colorable     The sample scenes are here for Unity GUI and NGUI.
   - GUISkin             GUI Skin for Unity GUI.
   - NGUI                UI Atlas set up for the NGUI framework (see below)
   - Textures            All the textures.
 - Supporting Artefacts
   - Scripts             Simple scripts that facilitate the demos and may be of use for you too!
 - ThirdParty
   - NGUI                This is a third party tool and all contents in this folder are copyright Tasharen Entertainment.

----------------------
Coloring in Unity GUI
----------------------

The colouring script for Unity GUI creates a new set of textures by multiplying the base textures with your selected colour. It also creates a new skin. This can take a little bit of time and should be done on start-up. Alternatively you can write these generated assets to file and use a fixed colour scheme.

To use in your own code:

1. Add the ColoredGUISkin object to any GameObject
2. Call ColoredGUISkin.Instance.UpdateGuiColors(primaryColor, secondaryColor) from any Start() method.
3. Access the skin with ColoredGuiSkin.Skin

