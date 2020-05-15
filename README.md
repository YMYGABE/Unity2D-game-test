# Unity2D-game-test
这是Unity2D 的学习文件，初次尝试做游戏，只是一个测试，学得差不多后将进行自己的游戏的创作。

2020.5.15  今天算是遇到大问题，关于相机的遮挡，当在scence里可以显示而game里不能显示的时候，就先去看 culling mask是不是选了"everthing"，如果这个没问题就去设置clipping planes "near = 0","far = 1000"，基本上就可以了。
