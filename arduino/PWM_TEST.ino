//changes the number of lives
#include <Servo.h>
Servo servo1;
int i=0;
 
int outPWM = 9;
int duty = 0; //duty cycle
int serialRead = 0;  
int throttle = 0;  
void setup() {
  // put your setup code here, to run once:
  servo1.attach(14);
  servo1.write(0);

  delay(10000);
}


void loop() {
    throttle = analogRead(16);
    throttle = map(throttle, 0, 1023, 0, 179);
    servo1.write(throttle);
    //delay(30);
}


