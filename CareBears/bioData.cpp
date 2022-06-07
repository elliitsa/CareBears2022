#include "bioData.h"

unsigned long time_2 = 0;
int period = 2000;
unsigned long time_now = 0;
double avered = 0;
double aveir = 0;
double sumirrms = 0;
double sumredrms = 0;
int i = 0;
int Num = 100;

int oxygen;
double ESpO2 = 95.0;
double FSpO2 = 0.7;
double frate = 0.95;

byte rateSpot = 0;
long lastBeat = 0; 
float beatsPerMinute;
int beatAvg;

BioData::BioData() // CONSTRUCTOR 
{
  byte m_rates[] {0, 0, 0, 0};
  for (byte i = 0; i < RATE_SIZE; i++)
    rates[i] = m_rates[i];
    
  particleSensor.begin(Wire, I2C_SPEED_FAST);  
  particleSensor.setup();
  particleSensor.setPulseAmplitudeRed(0x0A); 
  particleSensor.setPulseAmplitudeGreen(0);   
};

String BioData::displayHeart() // MEASURING HEART DATA
{ 
  uint32_t ir, red, green;
  double fred, fir;
  double SpO2 = 0;
  
  String to_return;
  
  particleSensor.begin(Wire, I2C_SPEED_FAST);
    
  while (particleSensor.available())
  {
    ir = particleSensor.getFIFOIR();
    red = particleSensor.getFIFORed();
    i++;
    fred = (double)red;
    fir = (double)ir;
    avered = avered * frate + (double)red * (1.0 - frate); 
    aveir = aveir * frate + (double)ir * (1.0 - frate);
    sumredrms += (fred - avered) * (fred - avered); 
    sumirrms += (fir - aveir) * (fir - aveir); 
    
    if ((i % SAMPLING) == 0)
    {
      if (millis() > TIMETOBOOT)
      {
        if (ir < FINGER_ON)
          ESpO2 = MINIMUM_SPO2;
          
        if (ESpO2 <= -1)
          ESpO2 = 0;
  
        if (ESpO2 > 100)
          ESpO2 = 100;
  
        oxygen = ESpO2;
      }
    }
    
    if ((i % Num) == 0)
    {
      double R = (sqrt(sumredrms) / avered) / (sqrt(sumirrms) / aveir);
      SpO2 = -23.3 * (R - 0.4) + 100;
      ESpO2 = FSpO2 * ESpO2 + (1.0 - FSpO2) * SpO2; 
      sumredrms = 0.0;
      sumirrms = 0.0;
      i = 0;
      break;
    }
    
    particleSensor.nextSample();
  }
  
  long delta = millis() - lastBeat;
  lastBeat = millis();

  beatsPerMinute = 60 / (delta / 1000.0);
  rates[rateSpot++] = (byte)beatsPerMinute;
  rateSpot %= RATE_SIZE;
  
  beatAvg = 0;
  for (byte x = 0 ; x < RATE_SIZE ; x++)
    beatAvg += rates[x];
  beatAvg /= RATE_SIZE;

  to_return = String(String(beatAvg) + " /  " + String(oxygen)+ "%");
  
  if(oxygen == 0 || beatAvg < 10)
    to_return = String("processing..");
  
  return to_return;
};
