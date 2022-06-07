#include "bmp.h"
#include "geoData.h"
#include "bioData.h"

#include <TFT_eSPI.h>
#include <SPI.h>
#include <U8g2lib.h>

struct OledFunctor
{
public:
  U8G2_SSD1327_MIDAS_128X128_F_HW_I2C u8g2 = U8G2_SSD1327_MIDAS_128X128_F_HW_I2C(U8G2_R0,  U8X8_PIN_NONE);
  TFT_eSPI tft = TFT_eSPI();
  
  GeoData geo = GeoData();
  BioData bio = BioData();
  
  void displayTimePage();
  void displayGpsPage();
  void displayHeartPage();
  int tmp_today;
  
  OledFunctor();
};
