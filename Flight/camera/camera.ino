// Tx-Brown, Rx-Red, Gnd-Purple, Vcc-Grey

#include <SoftwareSerial.h>
#include <JPEGCamera.h>

SoftwareSerial camSerial( 50, 51 ); //rx,tx
JPEGCamera cam( camSerial );
char resp[10];
const int led = 13;
const int SLEEP_TIME = 25; // how long should we sleep before taking another picture?
const int MAX_INPUT_STRING_LENGTH = 100;
const String THIS_ID = "[pl1]";
int THIS_ID_LENGTH = THIS_ID.length();

void setup()
{
  Serial.begin( 38400 );
  
  pinMode( led, OUTPUT );
  
  // Wait for the serial port to be opened
  while (!Serial) delay( 25 );
  
  camSerial.begin( 38400 ); // open the camera port
  
  digitalWrite( led, HIGH );   // turn the LED on (HIGH is the voltage level)
  delay( 100 );               // wait for a second
  digitalWrite( led, LOW );    // turn the LED off by making the voltage LOW
  delay( 100 );               // wait for a second

  cam.reset(); // initialize
  delay( 2000 );

  digitalWrite( led, HIGH );   // turn the LED on (HIGH is the voltage level)
  delay( 100 );               // wait for a second
}

void loop()
{
  processInput();
}

void processInput()
{  
  if ( Serial.available() )
  {
    boolean keepReading = true;
    String totalInputString = Serial.readString();

    if ( totalInputString.length() > 5 )
    {
      if ( totalInputString.substring( 0,THIS_ID_LENGTH ) == THIS_ID )
      {
        Serial.println ( "Command For Me" );
        if ( totalInputString.substring ( THIS_ID_LENGTH ) == "P" )
        {
          Serial.println ( "Taking Picture" );
          takePicture();
          sendPicture();
          resetCamera();
        } else {
          Serial.println ( "Unknown " + totalInputString.substring ( THIS_ID_LENGTH ) ); 
        }
      }
    }
  }
}
void takePicture()
{
  cam.takePicture(); // take the picture
  
  digitalWrite( led, HIGH );   // turn the LED on (HIGH is the voltage level)
  delay( 100 );               // wait for a second
  digitalWrite( led, LOW );    // turn the LED off by making the voltage LOW
  delay( 100 );               // wait for a second 
}
void sendPicture()
{
  Serial.write( "[picture]" );
  cam.getData( Serial ); // print the data
  Serial.write( "[/picture]" );  
}
void resetCamera()
{
  cam.stopPictures(); // stop taking pictures 

  int i = 0; // cool down
  while ( i < SLEEP_TIME ) {
    digitalWrite( led, HIGH );
    delay( 100 );
    digitalWrite( led, LOW );
    delay( 100 );
    i++;
  }
}
