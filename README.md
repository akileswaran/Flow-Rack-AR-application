# Master_Project

download and install the android application on your android phone and point it at the marker included above to check out a basic functional version of the application. 

This project has three main aspects:
1. Augmented Reality
  - The Application uses the PTC Vuforia Engine to implement augmented reality functions. 
  - It uses a Image based marker to recogonize and detect and track objects. The Engine detects and tracks the image by comparing extracted natural features from the camera image against a known target resource database. Once the Image Target is detected, Vuforia Engine will track the image and augment your content seamlessly
  - The vuforia engine offers an cloud base feature extraction platform using which a database can be created and this database can then be packaged and downloaded into Unity.
![image](https://user-images.githubusercontent.com/62331013/113193892-c6843180-9260-11eb-8797-1cda541b5c0f.png | width=100) | ![unnamed](https://user-images.githubusercontent.com/62331013/113269011-51ecd980-92d8-11eb-9182-5f413c9957e7.jpg)
2. IIot (Industry 4.0)
  - The application uses OPC-UA, MQTT and OPCUA via REST communication to retrive and transfer data to the Beckhoff PLC (Twincat3).
  - Three separate clients where developed and tested against each other for data transfer rate, ease of implementation, and roboustness of communication
![image](https://user-images.githubusercontent.com/62331013/113193738-9b99dd80-9260-11eb-9bad-c937daf97dff.png)

3. Artificial Intelligence
  - A Convolutional Neural Network was trained using the tensorflow object detection API. 
  - The Faster-RCNN-Inception-V2-COCO Model (Pre-trained classifier with a neral network) was used to train the object detection classifier.
  -  The object detection classifier acts as a feedback system that detects and identifies the parts that have been taken out of the flow rack, and updates the part count data on the PLC.
![image](https://user-images.githubusercontent.com/62331013/113193997-e6b3f080-9260-11eb-9f99-66dddb856916.png)

