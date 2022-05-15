#include "./Classes/audio.h"

bool pref_state = false;
long timer = 0;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  I2S::Init();
  
  pinMode(12, OUTPUT);
  pinMode(15, INPUT);
}

void loop() {
  if(I2S::i2s_Busy() == true){
        digitalWrite(12, HIGH);
  }
  else{
    digitalWrite(12, LOW);
    if(digitalRead(15) == true && pref_state != HIGH){
      xTaskCreate(I2S::i2s_adc, "i2s_adc", 1024 * 4, NULL, 1, NULL);
      pref_state = HIGH;
    }
    else if(digitalRead(15) == LOW){
      pref_state = LOW;
    }
  }
}