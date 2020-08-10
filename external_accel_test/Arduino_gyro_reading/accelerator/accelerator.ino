#include <Adafruit_MPU6050.h>
#include <Adafruit_Sensor.h>
#include <Wire.h>

Adafruit_MPU6050 mpu;

void setup(void) {
  // put your setup code here, to run once:
  Serial.begin(115200);
  while (!Serial)
    delay(10);

  if (!mpu.begin()) {
    while (1) {
      delay(10);
    }
  }

//  range can be +-2G/4G/8G/16G
  mpu.setAccelerometerRange(MPU6050_RANGE_4_G); 
  mpu.setGyroRange(MPU6050_RANGE_500_DEG);
  mpu.setFilterBandwidth(MPU6050_BAND_21_HZ);
  delay(100);
}

void loop() {
  // put your main code here, to run repeatedly:
  sensors_event_t a, g, temp;
  mpu.getEvent(&a, &g, &temp);

  /* Print Acceleration */
  Serial.print(a.acceleration.x);
  Serial.print(",");
  Serial.print(a.acceleration.y);
  Serial.print(",");
  Serial.print(a.acceleration.z);
  Serial.println("");
  delay(200);  

}
