# PSM/ComicDays-Reorder-raws
A pretty simple script that reorders the downloaded pages that's shuffled from the pocket shounen magazine or Comic days websites and saves them as png files.

Made for my scan group to be able to get HQ raws for "Bokutachi no remake" and such.

![Reorder Example 0](https://user-images.githubusercontent.com/32362046/119033532-fd9bd700-b9b5-11eb-86bd-3c79e89567c7.png)

![Reorder Example](https://user-images.githubusercontent.com/32362046/119033582-0d1b2000-b9b6-11eb-8cf6-e302f3a39121.png)

------------------------------
It can also work to shuffle normal images if you want (Source: Ladica, Shadowverse.)
(It's a fixed pattern so you can use it for anything really.)
![NExample](https://user-images.githubusercontent.com/32362046/119096137-df68c200-ba1b-11eb-8e8b-c00b3a9fde4b.png)

------------------------------

Only works on windows because it's based on winforms but the logic itself is trivial to convert to any other type of applications.

Only accepts .jpg and .png files when reordering, can be easily changed.

How to use:

1) Open the chapter you want in https://pocket.shonenmagazine.com/ to download and press Ctrl+Shift+I to open the inspect tools.

2) Open up the "Application" tab then go to frames > top > Images, and choose the image you want then right click and "save image as".

![ExamplePSMRO](https://user-images.githubusercontent.com/32362046/119030943-31293200-b9b3-11eb-95de-6972c2ddf8d0.jpg)
![Screenshot_1257](https://user-images.githubusercontent.com/32362046/119030502-a3e5dd80-b9b2-11eb-8fce-d5cd6d30f2b4.png)

3) Download the released version and run it.

OR

3) Open up the .sln file in your visual studio or rider(or any IDE that accepts winforms applications made with C#) then build and run it. 

![Screenshot_1262](https://user-images.githubusercontent.com/32362046/119032518-ee685980-b9b4-11eb-9fe9-9d8f535e220d.png)

4) Put all the downloaded files in a folder.

5) Copy the folder path that have all the downloaded files and put it in the first box.

6) Copy the folder path that you want to save the reordered images to. 

7) Press the "Rename and convert to png" button.

8) You can now start reording them, press the "Reorder and save" button.

9) After it's done, open up the folder you saved the reordered images in, and rename each page in the right order depending on the chapter(I don't think you can automate the order accurately, but feel free to make a pull request if you found a way).

10) Enjoy.

Note: if the 2 boxes are not filled with a correct path and a button got pressed, the application may give out an error.

The "generate doc" is just for pasting into the google doc to start working on the real thing faster, it's probably useless for you but I use it.

![Screenshot_187](https://user-images.githubusercontent.com/32362046/129644878-4feb69da-a563-4883-a968-73a9844d76e8.png)

