#include <Arduino.h>
#include <esp8266-google-home-notifier.h>

const char* ssid     = "OnePlus 9 Pro";
const char* password = "Jobistop";

GoogleHomeNotifier ghn;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  Serial.println("");
  Serial.print("connecting to Wi-Fi");
  WiFi.mode(WIFI_STA);
  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(250);
    Serial.print(".");
  }
  Serial.println("");
  Serial.println("connected.");
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());  //Print the local IP
  
  Serial.println("connecting to Google Home...");

  if (ghn.device("Medical speaker", "en") != true) {
    Serial.println(ghn.getLastError());
    return;
  }

  Serial.print("found Google Home(");
  Serial.print(ghn.getIPAddress());
  Serial.print(":");
  Serial.print(ghn.getPort());
  Serial.println(")");

  pinMode(36, INPUT);
  pinMode(33, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  if(digitalRead(36)){
      ghn.notify("I recognized the danger, I am getting help");
      digitalWrite(33, HIGH);
      delay(2000);
  }
  digitalWrite(33,LOW);
}