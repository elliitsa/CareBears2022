#define BUTTON_BOOT_PIN  GPIO_NUM_0
#define BUTTON_EN_PIN  GPIO_NUM_4
#define INIT_STATE 0
#define GPS_STATE 1
#define HEART_STATE 2

#include "OledFunctor.h"

#include <SoftwareSerial.h>

OledFunctor OLED = OledFunctor();
SoftwareSerial ss(RXPin, TXPin);

byte m_state = INIT_STATE;
int button_pin = 33;

void setup()
{
  OLED.bio.particleSensor.begin(Wire, I2C_SPEED_FAST); // SETUP IR SENSOR 
  OLED.bio.particleSensor.setup(); 
  OLED.bio.particleSensor.setPulseAmplitudeRed(0x0A);
  OLED.bio.particleSensor.setPulseAmplitudeGreen(0); 
     
  ss.begin(GPSBaud);

  pinMode(button_pin, INPUT);
}

void loop()
{
  OLED.u8g2.clearBuffer();
  
  if(OLED.bio.particleSensor.getIR() > 45000) // STATE MACHINE
    m_state = HEART_STATE;
  else
  {
    if (m_state == HEART_STATE)
      m_state = INIT_STATE;
    
    if(gpio_get_level(BUTTON_BOOT_PIN) == LOW)
    {
      if(m_state == GPS_STATE)
        m_state = INIT_STATE;
      else
      {
        if (m_state == INIT_STATE)
          m_state = GPS_STATE;
      }
    }
  }
  
  while (ss.available() > 0) // PRINTING ONLY WHEN GPS AVAILABLE
  {
    if (OLED.geo.gps.encode(ss.read()))
    {
      if(m_state == HEART_STATE)
        OLED.displayHeartPage();
      
      if(m_state == INIT_STATE)
        OLED.displayTimePage();    
              
      if(m_state == GPS_STATE)
        OLED.displayGpsPage();
        
      OLED.u8g2.sendBuffer();
    }
  }
}
