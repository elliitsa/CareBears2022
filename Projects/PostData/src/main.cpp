#include <WiFi.h>
#include <HTTPClient.h>

const char* ssid = "OnePlus 9 Pro";
const char* password = "Jobistop";

// the following variables are unsigned longs because the time, measured in
// milliseconds, will quickly become a bigger number than can be stored in an int.
unsigned long lastTime = 0;
// Timer set to 10 minutes (600000)
//unsigned long timerDelay = 600000;
// Set timer to 5 seconds (5000)
unsigned long timerDelay = 5000;

int post_data(int uid, float heart_rate, float oxygen_level, float latitude, float longitude, int emergency, char* date, char* time){
    if(WiFi.status()== WL_CONNECTED){

      HTTPClient http;

      const char* serverName = "http://82.75.86.150/postdata.php";

      http.begin(serverName);

      http.addHeader("Content-Type", "application/x-www-form-urlencoded");

      std::string s_uid = std::to_string(uid);
      std::string s_heart = std::to_string(heart_rate);
      std::string s_oxygen = std::to_string(oxygen_level);
      std::string s_lat = std::to_string(latitude);
      std::string s_long = std::to_string(longitude);
      std::string s_emergency = std::to_string(emergency);

      // Data to send with HTTP POST
      std::string reqstring = "appkey=sGgyNnLU2bEm7XPUY0E3KvGB6h2Y4WVV&uid="+s_uid+"&heartrate="+s_heart+"&oxygen="+s_oxygen+"&latitude="+s_lat+"&longitude="+s_long+"&emergency="+s_emergency+"&date="+date+"&time="+time;           
      
      const char* httpRequestData = reqstring.c_str();
      // Send HTTP POST request
      return http.POST(httpRequestData); //Returns status of the request (200 if succeeded)

      // Free resources
      http.end();
    }
    else {
      return -1; //Returns -1 when failed to connect
    }
}

void setup() {
  Serial.begin(115200);

  WiFi.begin(ssid, password);
  Serial.println("Connecting");
  while(WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("");
  Serial.print("Connected to WiFi network with IP Address: ");
  Serial.println(WiFi.localIP());
 
  Serial.println("Timer set to 5 seconds (timerDelay variable), it will take 5 seconds before publishing the first reading.");
}

void loop() {
  //Send an HTTP POST request every 10 minutes
  if ((millis() - lastTime) > timerDelay) {
    //Check WiFi connection status
    int status = post_data(3,82.45,98.12,23.4567543,54.1235341,0,"2022-06-05", "12:58:12");
    Serial.print("Status Code: ");
    Serial.println(status);
    lastTime = millis();
  }
}

