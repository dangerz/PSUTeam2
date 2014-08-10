#include <Adafruit_GPS.h>
#include <SoftwareSerial.h>
#include <JPEGCamera.h>

SoftwareSerial gpsSerial(52, 53);

Adafruit_GPS GPS( &gpsSerial );

// Set GPSECHO to 'false' to turn off echoing the GPS data to the Serial console
// Set to 'true' if you want to debug and listen to the raw GPS sentences. 
#define GPSECHO  false

// this keeps track of whether we're using the interrupt
// off by default!
boolean usingInterrupt = false;
void useInterrupt(boolean); // Func prototype keeps Arduino 0023 happy

SoftwareSerial camSerial( 51, 50 ); //camera rx, cameratx
JPEGCamera cam( camSerial );

const int led = 13;
const int SLEEP_TIME = 25; // how long should we sleep before taking another picture?
const int MAX_INPUT_STRING_LENGTH = 100;

const String THIS_ID = "pl1";
const String PICTURE_TAKE_COMMAND = "pct";
const String PICTURE_SEND_COMMAND = "pcr";
const String GPS_SEND_COMMAND = "gps";

const int ID_LENGTH = 3; // how long is our id?
const int CMD_LENGTH = 3; // how long is each command?

void setup()  
{
  Serial.begin(9600);

  // 9600 NMEA is the default baud rate for Adafruit MTK GPS's- some use 4800
  GPS.begin(9600);
  
  GPS.sendCommand(PMTK_SET_NMEA_OUTPUT_RMCGGA);
  GPS.sendCommand(PMTK_SET_NMEA_UPDATE_1HZ);   // 1 Hz update rate
  GPS.sendCommand(PGCMD_ANTENNA);

  useInterrupt(true);

  delay( 1000 );

  camSerial.begin( 38400 ); // open the camera port

  delay( 100 );
  
  cam.reset(); // initialize

  delay( 1000 );
}


uint32_t timer = millis();
void loop()
{
  processInput();
  
  // if a sentence is received, we can check the checksum, parse it...
  if (GPS.newNMEAreceived()) {
    if (!GPS.parse(GPS.lastNMEA()))   // this also sets the newNMEAreceived() flag to false
      return;  // we can fail to parse a sentence in which case we should just wait for another
  }

  // if millis() or timer wraps around, we'll just reset it
  if (timer > millis())  timer = millis();

  // approximately every 1 seconds or so, print out the current stats
  if (millis() - timer > 1000) { 
    timer = millis(); // reset the timer
    
    if (GPS.fix) {
      Serial.println( THIS_ID + GPS_SEND_COMMAND + GPS.lastNMEA() );
    } else {
      Serial.println( THIS_ID + GPS_SEND_COMMAND + "NoFix" );
    }
  }
}

void processInput()
{  
  if ( Serial.available() )
  {
    boolean keepReading = true;
    String totalInputString = Serial.readString();

    if ( totalInputString.length() > ID_LENGTH + CMD_LENGTH ) // only process if the command has enough data
    {
      digitalWrite( led, HIGH );   // turn the LED on (HIGH is the voltage level)
      if ( totalInputString.substring ( ID_LENGTH, ID_LENGTH + CMD_LENGTH ) == PICTURE_TAKE_COMMAND ) // is it a picture command? pl1pctpl
      {
        if ( totalInputString.substring ( ID_LENGTH + CMD_LENGTH, ID_LENGTH + CMD_LENGTH + ID_LENGTH ) == THIS_ID ) // if it is, is the command for us?
        {
          takePicture();
          sendPicture();
          resetCamera();
        }
      }
      digitalWrite( led, LOW );   // turn the LED on (HIGH is the voltage level)
    }
  }
}
// Interrupt is called once a millisecond, looks for any new GPS data, and stores it
SIGNAL(TIMER0_COMPA_vect) {
  char c = GPS.read();
  // if you want to debug, this is a good time to do it!
#ifdef UDR0
  if (GPSECHO)
    if (c) UDR0 = c;  
    // writing direct to UDR0 is much much faster than Serial.print 
    // but only one character can be written at a time. 
#endif
}

void useInterrupt(boolean v) {
  if (v) {
    // Timer0 is already used for millis() - we'll just interrupt somewhere
    // in the middle and call the "Compare A" function above
    OCR0A = 0xAF;
    TIMSK0 |= _BV(OCIE0A);
    usingInterrupt = true;
  } else {
    // do not call the interrupt function COMPA anymore
    TIMSK0 &= ~_BV(OCIE0A);
    usingInterrupt = false;
  }
}

// Start Camera Methods
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
  Serial.print( THIS_ID + PICTURE_SEND_COMMAND );
  cam.getData( Serial ); // print the data
}
void resetCamera()
{
  cam.stopPictures(); // stop taking pictures 

  int i = 0; // cool down
  while ( i < SLEEP_TIME ) 
  {
    digitalWrite( led, HIGH );
    delay( 100 );
    digitalWrite( led, LOW );
    delay( 100 );
    i++;
  }
}
// End Camera Methods

