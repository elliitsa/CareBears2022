#include "geoData.h"

GeoData::GeoData() {} // CONSTRUCTOR


String GeoData::displayTimeDate() // MEASURING TIME DATA
{
  String m_hour, m_minute, m_second;
  
  if (gps.time.hour() < 10)
    m_hour = String('0' + String(gps.time.hour())); // FORMATING TIME
  else
    m_hour = String(gps.time.hour());
    
  if (gps.time.minute() < 10)
    m_minute = String('0' + String(gps.time.minute()));
  else
    m_minute = String(gps.time.minute()); 
    
    
  String to_return = String(m_hour + ':' + m_minute + '%' + String(gps.date.day()) + " / " + String(gps.date.month()) + " / " + String(gps.date.year()));
  return to_return;
};

String GeoData::displayGps() // MEASURING GPS DATA
{
  String to_return = String(String(gps.location.lat(), 1) + " : " + String(gps.location.lng(),1));
  return to_return;
};
