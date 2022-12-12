#include <SoftwareSerial.h>
#include <SimpleDHT.h>

SoftwareSerial hc06(2,3);
int data = 0;
int pinDHT11 = 8;
SimpleDHT11 dht11;
void setup(){
  Serial.begin(9600);
  hc06.begin(9600);
}
void loop(){
  delay(1000);
  data = hc06.read();
  byte temperature = 0;
  byte humidity = 0;
  dht11.read(pinDHT11, &temperature, &humidity, NULL);
  if(data == 1){
    hc06.println(temperature);
  }else if(data == 2){
    hc06.println(humidity);
  }
}
