# PSM-Reorder-raws
A script that reorders the downloaded pages that's shuffled from the pocket shounen magazine website and saves them as a high quality png file.

Made by the translator of the "Itsafineday" scans group that scans Bokutachi no remake(remake our life!) manga.

![Reorder Example 0](https://user-images.githubusercontent.com/32362046/119033532-fd9bd700-b9b5-11eb-86bd-3c79e89567c7.png)

![Reorder Example](https://user-images.githubusercontent.com/32362046/119033582-0d1b2000-b9b6-11eb-8cf6-e302f3a39121.png)


Only works on windows because it's based on winforms but the logic itself is trivial to convert to any other type of applications.

How to use:

1) Open the chapter you want to download and press Ctrl+Shift+I to open the inspect tools.

2) Open up the "Application" tab then go to frames > top > Images, and choose the image you want then right click and "save image as".

![ExamplePSMRO](https://user-images.githubusercontent.com/32362046/119030943-31293200-b9b3-11eb-95de-6972c2ddf8d0.jpg)
![Screenshot_1257](https://user-images.githubusercontent.com/32362046/119030502-a3e5dd80-b9b2-11eb-8fce-d5cd6d30f2b4.png)

3) Rename the Image to the page number you want, then change the file name extension to ".png" and put it in the folder you want.

4) After you downloaded all the pages and put them in the same folder, you can now start converting them.

5) Open up the .sln file in your visual studio or rider(or any IDE that accepts winforms applications made with C#). 
![Screenshot_1262](https://user-images.githubusercontent.com/32362046/119032518-ee685980-b9b4-11eb-9fe9-9d8f535e220d.png)

6) Build and run the application. You will probably see something like this
![Screenshot_1263](https://user-images.githubusercontent.com/32362046/119032943-5b7bef00-b9b5-11eb-895d-8c72fccab416.png)

7) Copy the folder path that have all the shuffled images and put it in the first box.

8) Copy the folder path that you want to save the reordered images too. 

Note: if the 2 boxes are not filled with a correct path and the button got pressed, the application will crash and you have to rerun it.

9) And...Press the button and enjoy.
 

