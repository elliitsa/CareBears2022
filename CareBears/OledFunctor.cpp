#include "OledFunctor.h"

OledFunctor::OledFunctor() { u8g2.begin(); }; // DEFAULT CONSTRUCTOR

void OledFunctor::displayTimePage()
{ 
  String tmp_str = geo.displayTimeDate();
  String tmp_time = String(tmp_str.substring(0, tmp_str.indexOf('%')));
  String tmp_date = String(tmp_str.substring(tmp_str.indexOf('%') + 1, tmp_str.length()));
  
  char arr_time[tmp_time.length() + 1]; // DATA FORMATING
  char arr_date[tmp_date.length() + 1];
  
  strcpy(arr_time, tmp_time.c_str());
  strcpy(arr_date, tmp_date.c_str());
  
  u8g2.setFont(u8g2_font_logisoso16_tr); // PAGE HEADER
  u8g2.setCursor(42, 20);
  u8g2.print("CARE");
  u8g2.setCursor(40, 100);
  u8g2.print("BEARS");

  u8g2.setFont(u8g2_font_unifont_t_latin); // PAGE DATA
  u8g2.setCursor(43, 50);
  u8g2.print(arr_time);
  u8g2.setCursor(20, 70);
  u8g2.print(arr_date);
};

void OledFunctor::displayGpsPage()
{
  String tmp_str = geo.displayGps();
  
  char arr_gps[tmp_str.length() + 1]; // DATA FORMATING
  strcpy(arr_gps, tmp_str.c_str());

  u8g2.setFont(u8g2_font_logisoso16_tr); // PAGE HEADER
  u8g2.setCursor(42, 20);
  u8g2.print("CARE");
  u8g2.setCursor(40, 100);
  u8g2.print("BEARS");

  u8g2.setFont(u8g2_font_unifont_t_latin); // PAGE DATA
  u8g2.setCursor(23, 50);
  u8g2.print(arr_gps);  
  u8g2.setCursor(19, 70);
  u8g2.print("(lat) (lng)");  
};

void OledFunctor::displayHeartPage()
{
  String tmp_str = bio.displayHeart();
  
  char arr_heart[tmp_str.length() + 1]; // DATA FORMATING
  strcpy(arr_heart, tmp_str.c_str());

  u8g2.setFont(u8g2_font_logisoso16_tr); // PAGE HEADER
  u8g2.setCursor(42, 20);
  u8g2.print("CARE");
  u8g2.setCursor(40, 100);
  u8g2.print("BEARS");

  u8g2.setFont(u8g2_font_unifont_t_latin); // PAGE DATA
  u8g2.setCursor(24, 50);
  u8g2.print(arr_heart);
  u8g2.setCursor(17, 70);
  u8g2.print("(bpm) (spo2)");  
};
