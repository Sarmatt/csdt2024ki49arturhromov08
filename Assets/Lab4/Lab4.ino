#include <ArduinoJson.h>
int ledPin = 9; // LED connected to digital pin 9
bool shouldStartCounter = false;
int counter = 0;
int buttonPin = 12;
const int BUFFER_SIZE = 256;
char buf[BUFFER_SIZE];
/**
* \brief The method which initialize main parameters and pins
* \return void
* \code
* void setup()
*{
* Serial.begin(9600);
* pinMode(ledPin, OUTPUT);
*pinMode(buttonPin, INPUT_PULLUP);
*
* }
* \endcode
*/
void setup()
{
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);
  pinMode(buttonPin, INPUT_PULLUP);
}
void loop()
{
  if(Serial.available() > 0)
  {
    String jsonInput = Serial.readStringUntil('\n');
    jsonInput.toCharArray(buf, BUFFER_SIZE);
    StaticJsonDocument<BUFFER_SIZE> doc;
    DeserializationError error = deserializeJson(doc, buf);
    // Check for parsing errors
    if (error) 
    {
      Serial.print("JSON parsing failed: ");
      Serial.println(error.c_str());
      return;
    }
    int value1 = doc["Pressed"]; 
    if(value1 == 0 && !shouldStartCounter)
    {
      RandomlyLightLED();
    }
  }
  TryCount();
}
/**
* \brief The method which Randomly light LED
* \return void
* \code
* void RandomlyLightLED()
* {
*int rand = random(2, 8);
* delay(rand * 1000);
* digitalWrite(ledPin, 255);
* shouldStartCounter = true;
* } 
* \endcode
*/
void RandomlyLightLED()
{
  int rand = random(2, 8);
  delay(rand * 1000);
  digitalWrite(ledPin, 255);
  shouldStartCounter = true;
} 
/**
* \brief The method which counts time
* \return void
* \code
* void TryCount()
* {
* if(!shouldStartCounter) return;
* counter++;
* delay(100);
* Serial.println(counter);
* if(ButtonPressed()){
* digitalWrite(ledPin, 0);
* shouldStartCounter = false;
* counter = 0;
* }
* \endcode
*/
void TryCount()
{
  if(!shouldStartCounter) return;
  counter++;
  delay(100);
  Serial.println(counter);
  if(ButtonPressed())
  {
    digitalWrite(ledPin, 0);
    shouldStartCounter = false;
    counter = 0;
  }
}
/**
* \brief The method which returned true if button pressed
* \return bool
* \code
* bool ButtonPressed()
* {
* if(digitalRead(buttonPin) == LOW){
* return true;
* }
* return false;
* }
* \endcode
*/
bool ButtonPressed()
{
  if(digitalRead(buttonPin) == LOW)
  {
    return true;
  }
  return false;
}