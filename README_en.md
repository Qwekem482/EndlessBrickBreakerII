[Tiếng Việt](https://github.com/Qwekem482/EndlessBrickBreakerII/blob/main/README.md)

# Endless Brick breaker II

A new, remake version of old Endless Brick Breaker game, which was created by me and broken because I add .meta file to gitignore. 

Developed by Qwekem482


## Game Mechanism
 - There are 4 stats of each game:
    - Score: equal to the number of broken block.
    - Time: Played time, which is caculated from the start.
    - Lives: The remaining live of player.
    - Level: Number of current level.
 - At start of a game player has 3 lives (actually, 4). Player will lost 1 live when the ball drop out off the screen. 
 - When player clear all the brick, new brick will be generated automatically and immediately. Also, player will be added 2 lives, basket speed and ball speed will increase.
 - Number of blocks each turn and position of them is random in range (30, 90). 

## New Features
 - Game now have UI.
 - Game now avaiable on android.
 - Game can auto resize game object and UI to fit with different screen ratio.
 - Remove color button, but game objects (brick, ball, basket) now change color when lose a live.
 - Game now only uses light color for game objects.
 - Ball speed will increase in each level. Ball speed formula: $10 + 0.75\sqrt{3 * level} + level/40$
 - Basket speed will increase in each level. Basket speed formula: $10 + 0.75\sqrt{4 * level} + level/30$

## Existing Limitation
 - Basket moving is a little bad.
 - Menu Screen and End Screen is too simple
 - Highest row of brick sometimes is empty in some screen ratio.
 
## Support and Tutorial
 ![Percentage](https://user-images.githubusercontent.com/80797630/216106474-3f61e883-1114-42af-acfd-2af312b6d185.png)

 - This project is made with Unity Engine, coded with Visual Studio Code.
 - Sprite created using [Figma](https://www.figma.com/ "Figma") by me.
 - Sound from Unity Asset Store: 
      - [Casual Game BGM #5](https://assetstore.unity.com/packages/audio/music/casual-game-bgm-5-135943) by [B.G.M](https://assetstore.unity.com/publishers/9381 "B.G.M")
      - [FREE Casual Game SFX Pack](https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116) by [Dustyroom](https://assetstore.unity.com/publishers/16150 "Dustyroom")
 - This game is created with the help of ![4d4d4d](https://placehold.co/15x15/4d4d4d/4d4d4d.png)[Unity Forum](https://forum.unity.com/ "Unity Forum"), ![#f37700](https://placehold.co/15x15/f37700/f37700.png)[Stackoverflow](https://stackoverflow.com/ "Stackoverflow"), ![#00fff0](https://placehold.co/15x15/00fff0/00fff0.png)[noobtuts](https://noobtuts.com/unity/2d-arkanoid-game "noobtuts")
 
## Screenshot
![Screenshot_20230526-163622](https://github.com/Qwekem482/EndlessBrickBreaker/assets/80797630/d37c300a-ecf8-47bb-b504-049b170e0783)
![Screenshot_20230526-163630](https://github.com/Qwekem482/EndlessBrickBreaker/assets/80797630/779dfde7-1627-4b38-a037-4029b7d48eb4)
![Screenshot_20230526-163639](https://github.com/Qwekem482/EndlessBrickBreaker/assets/80797630/4c58c896-ce49-4ac8-8167-8c5cf3836b09)
![Screenshot_20230526-163654](https://github.com/Qwekem482/EndlessBrickBreaker/assets/80797630/b9a75bce-29f2-4114-99c2-f60dd1118673)


