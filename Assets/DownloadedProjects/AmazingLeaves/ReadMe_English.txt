IMPORTANT:

<Assign layer(water or ground) to each objects>
If you want to use colliding effect, you need to set layer name of each your game objects to be collided by particles to "water"(not "Water") or "ground".

<Layer setting for your project setting>
New layers( water, ground, wind) should exist in your project setting for this asset.
So we made script for this, and when you import this asset, popup window will automatically appear. If you click "Yes" new layers( water, ground, wind) will be added to your project automatically.
If you want to use this feature manually, you can click fulldown menu "RealSnowAndRainEffect" and click "Sync Layers" menu.
This automatic script exists in AssetFolder/Editor/RequiredLayers.cs. If you already added new layers, it is ok if you delete this script file.


<If you want to add new layers by editor manually (not by script) >
Following steps, you can set Layer properly.
1. Edit -> Project Settings -> Tags and Layers
2. Find Layer setting part from inspector and Add layer "water", "ground", "wind" from inspector.
3. GROUND LAYER SETTING : Select ground objects from Hierachy in the scene, and set their Layer( most top area of inspector) to "ground" from inspector.
4. WATER LAYER SETTING : Select water objects from Hierachy in the scene, set their Layer to "water" from inspector.
5. WindZone : Select WindZone in the scene, set its Layer to "wind" from inspector.
6. All done.

---------------------------------------------------------------------

<Steps to apply Leaf prefab into your scene>

1. Locate the prefab

L1, L2, L3, L4, L5, L6:
There are 6 type of Leaf prefabs.  
You can use every single prefab which you want to use.
Drag and drop Leaf prefab to proper place in your scene.
You can set property of each particle type from inspector. 

LeafGroup:
"LeafGroup" prefab is a group of 6 prefabs. All 6 prefabs are superposed in same position. Use it if you want use multiple types of them. 
Drag and drop LeafGroup to proper place in your scene.
If there is particle which you don't need to use in "LeafGroup", delete the each particle from the child.
And you can set property of each particle type from inspector. 

2. Modify shape and area of the prefab
Click the Leaf prefab instance (for example L1) and expand the game object. In child, there is "LeafColliderParticle".  
Find "<Particle>" component and expand "Shape" element.
You can change the shape or size of the "Shape" component from inspector to fit your scene.

3. Modify lifetime of the particle
Click the Leaf prefab instance (for example L1) and expand the game object. In child, there is "LeafColliderParticle".  
Find "<Particle>" component and check "StartLifeTime" menu in main particle element.
You can change the lifetime to fit your scene.
If you change the lifetime too long, sometimes you need to increase "Max Particles" value in main particle element.

4. Velocity of particle
Click the Leaf prefab instance (for example L1) and expand the game object. In child, there is "LeafColliderParticle".  
Find "<Particle>" component and expand "Velocity Over Lifetime" element.
Default value is 18. This is falling velocity towards the ground. If you need, you can change this value by yourself for your scene.

5. Optimize the values by considering performance
Step 2, 3, 4 influence to performance, so you must optimize the values for your scene and test them.

6. Modify "StartSize" of Particle
Click the Leaf prefab instance and expand the game object. In child, there is "LeafColliderParticle".  
Find "<Particle>" component and change "StartSize" to fit on your scene.
This value will influence to "CollisionGap" variable. So, if you change this value, you would change CollisionGap variable.

7. Check CollisionGap variable
Click the Leaf prefab instance and expand the game object. In child, there is "LeafColliderParticle".  
Find "LeafParticleCollisionProcess" script in components from inspector.  
There is "CollisionGap" variable. Collision Gap is for relative distance from the position each particle colliding with surface of the object (through normal direction). 
It is -1.5 now. More large number will move the position to more far from the collided object. On the contrary, if it is minus value, modified position will be close to the collided object.
So, If you change the material in "renderer" element or "StartSize" in main element in "LeafColliderParticle" object, you must change CollisionGap value. And you need to check the collision position from runtime for test.

8. Set particle intensity
Click the Leaf prefab instance and you can choose "Intensity" property from "LeafController.cs" component in inspector.
There are 7 types of intensity. Very Light, Light, Moderate, Heavy, Very Heavy, Stormy, Very Stormy.
If you choose one of them, "CustomRateOverTime" property will be ignored. And selected type's value will be applied.
But if you choose "Custom", 7 types of intensity will be ignored. And "CustomRateOverTime" property will be applied and you can set "CustomRateOverTime" value by yourself.

9. Check 3 types of particles that after collision
After colliding to ground or water, old particle(falling leaf) will be destroyed and new particle(ground leaf) created.
There are 3 types of particles for after collision.
Expand Leaf particle in Hierarchy :

+-- L1
   +-- LeafColliderParticle
      +-- LeafOnGround
      +-- SplashOnWater
      +-- LeafOnWater

* LeafOnGround  : New Leaf created on surface of the collided object when falling Leaf collided with "ground" object.
* SplashOnWater : New Water Splash created on surface of the collided object when falling Leaf collided with "water" object.
* LeafOnWater   : New Leaf created on surface of the collided object when falling Leaf collided with "water" object.

Check lifetime of the 3 types of particles:
Expand "LeafColliderParticle" object in Hierarchy. There is each 3 type of particle object in child. 
Find "<Particle>" component and check "StartLifetime" property from inspector.
You can change the life time by youself. Usually lifetime of "LeafOnWater" will be short more than "LeafOnGround" because leaf on water will be more quickly disappeared (sink to water) than leaf on ground.

10. Wind Zone setting
There is a "Wind" GameObject in Hierarchy. 
If you choose the "Wind", you can change direction of wind and various settings about the Wind Zone.
All leaves particles will be influenced by the Wind Zone.
You must check Wind Zone's layer is "wind".

11. All done well!

---------------------------------------------------------------------

<How to manage 3D mesh object to be collided with Leaf>

1. Click the 3D mesh object
And click "add component" button from inspector.
And Choose "mesh collider".

2. set your object's layer name to "water"(not "Water") or "ground".

---------------------------------------------------------------------

<Instruction for prefab detail>

"L1" object: 
This prefab can collide another objects that having layer that named "water" or "ground". Then they will make spots on surface of the objects when they hit the objects.
You can drag the "L1" prefab into your scene. 
For example, in example scene in project, you can find "L1" object in Hierarchy.
Then you can select Intensity property from inspector.
There are 7 type of intensity. Very Light, Light, Moderate, Heavy, Very Heavy, Stormy, Very Stormy.
If you choose "Custom", you can set  "LeafColliderParticle" property in the inspector by yourself manually. To do so, You can click "LeafColliderParticle" child of "LeafController" in Hierarchy. 
If you click "LeafColliderParticle", you can find "LeafGroundSplash" and "LeafWaterSplash" in child. And if you click "LeafGroundSplash" you can find "renderer" tab in the "ParticleSystem" component in inspector. 
You can change Leaf splash ripple texture from this. You can choose various material in "Material" folder.
WaterSplashGround_64x64 ~ 512x512 images added in latest version. If you need more detailed image you can use 512x512 texture. if you need more simple image for mobile devices use 64x64 image. default is 128x128 image.
If you don't need to colliding effect, uncheck LeafParticleCollisionProcess script in "LeafColliderParticle" object from inspector. Then particle will not collide with another objects. and They will not make spots on surface of the objects.

---------------------------------------------------------------------

<More detail explanation about "LeafColliderParticle" object>

Generating Area Shape:
Choose a Leaf prefab.
LeafColliderParticle->ParticleSystem->Shape 
In Shape tab, you can change Generating Area Shape.  By default it is "Sphere" because it's shape is similar to tree's volume.
You can change Scale by "Scale" element(X, Y, Z axis).

Number of Particle:
LeafColliderParticle>ParticleSystem->Emission
You can change number of particle in "Rate over Time".
if you increase this value, you must increase also "Max Particles" value in "Leaf Prefab->ParticleSystem->LeafParticles".

Direction of Leaf
LeafColliderParticle->ParticleSystem->Velocity over Lifetime
if x axis value is between -3 and -15 (random value between two values), Leaf is moving to left direction.  You can change the direction with this values.
Y axis is now -80. because -80 is following y axis and this made Leaf fall into bottom direction. if you change this value you can change velocity of Leaf.

Life time of Leaf
LeafColliderParticle->ParticleSystem->LeafParticles->StartLifeTime
You can change this value for life time of Leaf.

Texture of Leaf
LeafColliderParticle->ParticleSystem->Renderer->Material
You can find "Leaf" material and you click it, you can find "Leaf" material.
you can change your own Leaf material.

More detail explanation about "LeafParticle" prefab:
Leaf Particle setting is similar to Leaf Particle. But it has one more element.
LeafColliderParticle->ParticleSystem->Noise
You can change Strength and Frequency value to change damping intension.

---------------------------------------------------------------------

<How to change Leaf Intensity by script>

1. How to change intensity option ( you can choose 7 type of intensity) :
7 types of intensity is VeryLight, Light, Moderate, Heavy, VeryHeavy, Stormy, VeryStormy. 
You can change this code by modifying code LeafController.cs. See following code.

        switch (Intensity)
        {
            case intensity.VeryLight:
                emissionModule.rateOverTime = 15;
                break;

            case intensity.Light:
                emissionModule.rateOverTime = 30;
                break;

            case intensity.Moderate:
                emissionModule.rateOverTime = 40;
                break;

            case intensity.Heavy:
                emissionModule.rateOverTime = 50;
                break;

            case intensity.VeryHeavy:
                emissionModule.rateOverTime = 70;
                break;

            case intensity.Stormy:
                emissionModule.rateOverTime = 85;
                //velocityOverLifetimeModule.x = -30;
                //mainModule.startLifetime = 15;
                break;

            case intensity.VeryStormy:
                emissionModule.rateOverTime = 100;
                //velocityOverLifetimeModule.x = -30;
                //mainModule.startLifetime = 15;
                break;
        }


If you want to change the intensity option by script, see following example code:

----------
Gameobject LeafObj = new GameObject;
LeafObj.GetComponent<LeafContoller>().Intensity = intensity.VeryLight;
----------

2. How to change custom intensity by script:
You can change intensity by following example code. ( At first, change intensity option to "Custom" and change CustomRateOverTime variable. )

----------
Gameobject LeafObj = new GameObject;
LeafObj.GetComponent<LeafContoller>().Intensity = intensity.Custom;
LeafObj.GetComponent<LeafContoller>().CustomRateOverTime = 350;
----------


3. If you want to use our another product "Real Snow and Rain Particle Effect" with this asset at same time, you should remove "RealSnowAndRain/Editor" folder or "Amazing Leaves/Editor" folder.


---------------------------------------------------------------------

Thank you for using our assets.

technical support:
oharinth@gmail.com

---------------------------------------------------------------------

<Release Note>

Ver 1.1.2
  namespace added.
  GUID for all meta files are updated to keep compatibility with our another product "Real Snow and Rain Particle Effect".
  some Missing Prefab are removed.

Ver 1.1.1 
  Layer Manager enhanced. 
  LayerManager.cs changed to RequiredLayers.cs

Ver 1.1
 * Bug Fix: LayerManager.cs script added to fix layer problem by setting layers properly in Garden scenes.
 * Manual updated.
