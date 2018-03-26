# WMMT5 Resolution Patcher
Special thanks to jackfuste from wsgf.org for the 2D\UI offsets\values.

If you find any issues, don't ping me on discord, open an issue here on github.

## Changelog:

v1.1.0.0
- Added 4:3, 5:4 support
- Fixed 21:9 resolutions
- Removed workaround resolutions
- Changed UI to use a combobox instead
- Added an error message if someone (for some dumb reason) doesn't select any resolution from the combobox
- Make the app quit if someone hits cancel in open file dialog

v1.0.0.2
- Added a check for Update 5 exe (so people will stop trying to patch 1.0 WMMT5)

v1.0.0.1
- Fixed some resolutions incorrect UI size
- Fixed FOV issue if patching from 21:9 to 16:9
- Added 21:9 variant of 2560x1440 and 5120x2880 (your monitor\gpu may or may not supports this, works fine on my RX480 + LG 29UM68-P), if your monitor\gpu can handle it, 
you will have stretched HUD\Menu, but they will be at correct places like in other 16:9 resolution.
- Added 1920x1080 with 21:9 (2560x1080) FOV in case you can't use the 2 other resolutions above, set your monitor to stretch so you will have fullscreen with stretched HUD\Menu,
but correct 3D.

## Known Issues:

- Very low resolutions can have issues (minor text issues)
- Movies are not scaled (workaround: upscale\downscale the movies to your desired resolution with a video editor like VEGAS)
- Rival indicator is kinda incorrect

## Supported resolutions:

- 600x480
- 640x360
- 640x480
- 640x512
- 768x432
- 800x600
- 896x504
- 960x720
- 1024x576
- 1024x768
- 1152x648
- 1152x864
- 1280x720
- 1280x960
- 1280x1024
- 1440x1080
- 1600x900
- 1600x1200
- 1920x1080
- 1920x1440
- 2560x1080
- 2560x1440
- 2560x1920
- 3440x1440
- 3840x2160
- 5120x2160
- 5120x2880
- 6880x2880
- 7680x4320