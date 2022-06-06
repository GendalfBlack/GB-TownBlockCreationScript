# GB-TownBlockCreationScript
 Simple to use script to generate towns from asset blocks
![Project Preview](https://user-images.githubusercontent.com/68827110/172194379-7f0254ce-f43a-4e59-99a9-9de69d295a19.png)

So this is realy simple script that uses your custom city blocks like:

![Block1Example](https://user-images.githubusercontent.com/68827110/172194937-72b115d9-ebac-41c0-9b1a-322af32e9b17.png)
![Block2Example](https://user-images.githubusercontent.com/68827110/172195175-98423681-733a-4845-9e33-90f5eb3b11f3.png)
![Block3Example](https://user-images.githubusercontent.com/68827110/172195344-97fd3d12-eb95-4f1a-b69c-fe60b8bb8ea1.png)

Its can lead to some simple, but cool locations like:

![Example1Build](https://user-images.githubusercontent.com/68827110/172195663-b3191f7e-dd40-413a-86cc-34e7033d6057.png)

Sity is now generated around the road, so two blocks for straight road and turn is essential:

![Road1Example](https://user-images.githubusercontent.com/68827110/172196039-83afcfa6-7793-4378-954a-7ceedda9c4a5.png)
![Road2Example](https://user-images.githubusercontent.com/68827110/172196131-cbb606f6-1196-4cd2-a985-f59d842c4e1e.png)

For using the script it can be setup like this:

![image](https://user-images.githubusercontent.com/68827110/172196282-5dbe803f-dca0-487f-ac26-f065f56fa717.png)
It is a simple EmptyObject with a position and blocks imported to the script you saw earlier.

For now there is buttons for 5 actions inside UnityEditor(NOT IN THE GAME):

![image](https://user-images.githubusercontent.com/68827110/172196654-f161b81a-63c4-400d-9861-d9711db17537.png)
1. Make a road block. If mark  ![image](https://user-images.githubusercontent.com/68827110/172196730-9833194f-e7db-4921-bca6-5db04c349380.png)   is checked, script generates town blocks for left and right side.
2. Make a turning road to the right.
3. Same, but to the left.
4. Undo (for now, ONLY ONE action).
5. Remove all builded blocks(roads and others).

Feel free to use it in any kind! Happy to help. Maybe there'll be a simple example scene and more improvements to the script.

P.S. The town blocks are oriented to be positive Z axies for the front. The road is positive X axies. For the turn make like in an example road that goues from neg x to neg z(to the right).
